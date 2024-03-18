using ArticleManagement.Domain.Enums;
using Framework.Domain;

namespace ArticleManagement.Domain.Entity;

public class Article : EntityBase
{

    public string Title { get; private set; }
    public string ShortDescription { get; private set; }
    public string Content { get; private set; }
    public string Slug { get; private set; }
    public DateTime ReleaseDateTime { get; private set; }
    public State State { get; private set; }

    //Relation
    public ICollection<Tag> Tags { get; private set; }
    public ICollection<ArticleTag> ArticleTags { get; private set; }
    protected Article(){}

    public Article(string title, string shortDescription, string content, DateTime releaseDateTime, string slug)
    {
        Title = title;
        ShortDescription = shortDescription;
        Content = content;
        ReleaseDateTime = releaseDateTime;
        Slug = slug;
        State = State.Active;
    }

    public void Edit(string title, string shortDescription, string content, DateTime releaseDateTime)
    {
        Title = title;
        ShortDescription = shortDescription;
        Content = content;
        ReleaseDateTime = releaseDateTime;
    }

    public override void ChangeStatus()
    {
        State = State is State.Active ? State.UnActive : State.Active;
    }
}