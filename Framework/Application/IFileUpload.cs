using Microsoft.AspNetCore.Http;

namespace Framework.Application
{
    public interface IFileUpload
    {
        string Upload(IFormFile file, string path);
    }
}
