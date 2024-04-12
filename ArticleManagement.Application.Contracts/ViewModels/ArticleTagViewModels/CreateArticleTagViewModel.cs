using ArticleManagement.Application.Contracts.ViewModels.TagViewModels;

namespace ArticleManagement.Application.Contracts.ViewModels.ArticleTagViewModels;

public class CreateArticleTagViewModel
{
    public long ArticleId { get; set; }
    public List<CreateTagViewModel> Tags { get; set; }
}