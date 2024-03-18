using ArticleManagement.Application.Contracts.ViewModels.ArticleViewModels;
using Framework.Application;

namespace ArticleManagement.Application.Contracts.Contracts;

public interface IArticleApplication
{
    Task<OperationResult> Add(CreateArticleViewModel? article);
    Task<OperationResult> Edit(EditArticleViewModel? article);
    Task<EditArticleViewModel?> Edit(long id);
    Task<List<ArticleViewModel>> ToList();
}