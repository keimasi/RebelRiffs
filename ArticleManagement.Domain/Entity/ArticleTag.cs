namespace ArticleManagement.Domain.Entity;

public class ArticleTag
{
    public Article Article { get; private set; }
    public long? ArticleId { get; private set; }

    public Tag Tag { get; private set; }
    public long? TagId { get; private set; }
    protected ArticleTag(){}
    public ArticleTag(long? articleId, long? tagId)
    {
        ArticleId = articleId;
        TagId = tagId;
    }
}