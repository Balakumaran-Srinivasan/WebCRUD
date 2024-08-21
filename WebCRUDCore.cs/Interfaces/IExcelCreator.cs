using Microsoft.AspNetCore.Http;

namespace WebCRUDCore.cs.Interfaces
{
    public interface IExcelCreator
    {
        Task uploadFile(IFormFile file);
    }
}