namespace ArticleManagement.Application.Contracts.ViewModels.ArticleViewModels;

public class ArticleViewModel
{
    public long Id { get; set; }
    public string Title { get; set; }
    public DateTime ReleaseDateTime { get; set; }
    public string State { get; set; }
}