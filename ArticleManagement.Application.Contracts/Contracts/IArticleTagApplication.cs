using ArticleManagement.Application.Contracts.ViewModels.ArticleTagViewModels;
using Framework.Application;

namespace ArticleManagement.Application.Contracts.Contracts;

public interface IArticleTagApplication
{
    Task<OperationResult> Add(CreateArticleTagViewModel articleTag);

}