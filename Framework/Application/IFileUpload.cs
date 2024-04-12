using Microsoft.AspNetCore.Http;

namespace Framework.Application
{
    public interface IFileUpload
    {
       Task<string> Upload(IFormFile file, string path);
    }
}
