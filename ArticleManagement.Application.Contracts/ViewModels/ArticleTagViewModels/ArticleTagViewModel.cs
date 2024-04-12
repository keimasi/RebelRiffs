namespace ArticleManagement.Application.Contracts.ViewModels.ArticleTagViewModels;

public class ArticleTagViewModel()
{
    public string Article { get; set; }
    public long ArticleId { get; set; }

    public string Tag { get; set; }
    public long TagId { get; set; }
}