namespace ArticleManagement.Application.Contracts.ViewModels.ArticleViewModels;

public class CreateArticleViewModel
{
    public string Title { get; set; }
    public string ShortDescription { get; set; }
    public string Content { get; set; }
    public string Slug { get; set; }
    public DateTime ReleaseDateTime { get; set; }
}