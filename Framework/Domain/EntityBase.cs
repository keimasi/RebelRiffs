namespace Framework.Domain;

public abstract class EntityBase
{
    public long Id { get; private set; }
    public DateTime CreationTime { get; private set; }

    public EntityBase()
    {
        CreationTime = DateTime.Now;
    }


    public virtual void ChangeStatus() => throw new Exception();
}