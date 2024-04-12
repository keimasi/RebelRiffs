using Framework.Domain;

namespace ArticleManagement.Domain.Entity;

public class Tag : EntityBase
{
    public string? Title { get; set; }

    //Relation 
    public ICollection<Article> Articles { get; private set; }
    public ICollection<ArticleTag> ArticleTags { get; private set; }

    protected Tag()
    {
        
    }

    public Tag(string? title)
    {
        Title = title;
    }
    public void Edit(string? title)
    {
        Title = title;
    }

}