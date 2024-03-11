namespace Framework.Domain;

public class PictureBase : EntityBase
{
    public string? Path { get; private set; }
   // public SeoPicture SeoPicture { get; private set; }

    public PictureBase(string? path/*, SeoPicture seoPicture*/)
    {
        Path = path;
        //SeoPicture = seoPicture;
    }

    protected PictureBase()
    {

    }
}