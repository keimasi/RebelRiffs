using ArticleManagement.Application.Contracts.Contracts;
using ArticleManagement.Application.Contracts.ViewModels.ArticleViewModels;
using ArticleManagement.Domain.Entity;
using ArticleManagement.Domain.IRepository;
using Framework.Application;
using Framework.Infrastructure;

namespace ArticleManagement.Application
{
    public class ArticleApplication(IArticleRepository articleRepository)
        : IArticleApplication
    {
        private readonly OperationResult _message = new();
        public async Task<OperationResult> Add(CreateArticleViewModel? article)
        {
            if (article is null)
                return _message.Failed(OperationMessage.Null);

            if (!await articleRepository.AnyEntityAsync(e => e.Slug == article.Slug))
                return _message.Failed(OperationMessage.DuplicatedSlug);

            var model = new Article(article.Title, article.ShortDescription, 
                article.Content, article.ReleaseDateTime,
                article.Slug);

            var result = articleRepository.AddEntity(model);

            if (result is not DbState.Added)
                return _message.Failed(OperationMessage.FailedAdd);

            return (await articleRepository.SaveChangesAsync()).Parse();
        }

        public async Task<OperationResult> Edit(EditArticleViewModel? article)
        {
            if (article is null)
                return _message.Failed(OperationMessage.Null);

            if (!await articleRepository.AnyEntityAsync(e => e.Id == article.Id))
                return _message.Failed(OperationMessage.NotFound);

            var find = await articleRepository.FindAsync(e => e.Id == article.Id);
            find?.Edit(article.Title, article.ShortDescription, article.Content, article.ReleaseDateTime);

            return (await articleRepository.SaveChangesAsync()).Parse();
        }

        public async Task<EditArticleViewModel?> Edit(long id)
        {
            if (!await articleRepository.AnyEntityAsync(e => e.Id == id))
                return new EditArticleViewModel();

            var find = await articleRepository.FindAsync(e => e.Id == id,
                s => new EditArticleViewModel()
                {
                    Id = s.Id,
                    Content = s.Content,
                    ReleaseDateTime = s.ReleaseDateTime,
                    ShortDescription = s.ShortDescription,
                    Title = s.Title
                }, null);
            return find;
        }

        public async Task<List<ArticleViewModel>> ToList()
        {
            CancellationToken? token = new CancellationToken();
            var list = await articleRepository.ToViewsAsync(null,
                e => new ArticleViewModel()
                {
                    Id = e.Id,
                    State = e.State.ToString(),
                    Title = e.Title,
                    ReleaseDateTime = e.ReleaseDateTime
                }, token);
            return list;
        }
    }
}
