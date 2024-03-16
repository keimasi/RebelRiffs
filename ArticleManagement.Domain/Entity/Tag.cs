using Framework.Domain;

namespace ArticleManagement.Domain.Entity;

public class Tag : EntityBase
{
    public string? Title { get; set; }

    //Relation 
    public Article Article { get; private set; }
    public long ArticleId { get; private set; }

    protected Tag()
    {
        
    }

    public Tag(string? title, long articleId)
    {
        Title = title;
        ArticleId = articleId;
    }
    public void Edit(string? title, long articleId)
    {
        Title = title;
        ArticleId = articleId;
    }

}