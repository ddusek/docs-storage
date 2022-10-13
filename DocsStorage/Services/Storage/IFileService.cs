using DocsStorage.Models;

namespace DocsStorage.Services.Storage
{
    public interface IFileService
    {
        Task<bool> WriteToFile(string content, string documentID);
        Task<string> ReadFileContent(string documentID);
        Task<bool> ChangeFile(string content, string documentID);
    }
}
