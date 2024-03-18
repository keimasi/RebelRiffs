using ArticleManagement.Application.Contracts.Contracts;
using ArticleManagement.Application.Contracts.ViewModels.ArticleTagViewModels;
using ArticleManagement.Domain.Entity;
using ArticleManagement.Domain.IRepository;
using Framework.Application;

namespace ArticleManagement.Application;

public class ArticleTagApplication(IArticleTagRepository articleTagRepository) : IArticleTagApplication
{
    public async Task<OperationResult> Add(CreateArticleTagViewModel articleTag)
    {
        var convert = articleTag.Tags.Select(e => new
            ArticleTag(articleTag.ArticleId, e.Id));

        articleTagRepository.AddRangeEntity(convert);
        return (await articleTagRepository.SaveChangesAsync()).Parse();
    }
}

