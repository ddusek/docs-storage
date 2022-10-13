using Microsoft.Extensions.Caching.Memory;
using System.Text;

namespace DocsStorage.Services.Storage
{
    public class FileService : IFileService
    {
        private const string FileStoragePath = "/Data";
        private readonly Encoding FileEncoding = Encoding.UTF8;

        private MemoryCacheEntryOptions cacheOptions = new()
        {
            AbsoluteExpirationRelativeToNow =
            TimeSpan.FromMinutes(30)
        };

        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IMemoryCache _memoryCache;

        public FileService(IWebHostEnvironment webHostEnvironment, IMemoryCache memoryCache)
        {
            _webHostEnvironment = webHostEnvironment;
            _memoryCache = memoryCache;
        }

        public async Task<bool> WriteToFile(string content, string documentID)
        {
            var fileName = GetFileName(documentID);
            if (File.Exists(fileName))
            {
                return false;
            }

            await File.WriteAllTextAsync(fileName, content, FileEncoding);
            return true;
        }

        public async Task<string> ReadFileContent(string documentID)
        {

            var fileName = GetFileName(documentID);
            if (_memoryCache.TryGetValue(fileName, out string cachedValue))
            {
                return cachedValue;
            }
            if (!File.Exists(fileName))
            {
                return null;
            }

            using var reader = new StreamReader(fileName, FileEncoding);

            var content = await reader.ReadToEndAsync();
            _memoryCache.Set(fileName, content, cacheOptions);

            return content;
        }

        public async Task<bool> ChangeFile(string content, string documentID)
        {
            var fileName = GetFileName(documentID);
            if (!File.Exists(fileName))
            {
                return false;
            }

            await File.WriteAllTextAsync(fileName, content, encoding: FileEncoding);
            _memoryCache.Set(fileName, content, cacheOptions);

            return true;
        }

        internal string GetFileName(string documentID) => $"{_webHostEnvironment.ContentRootPath}/{FileStoragePath}/{documentID}.json";
    }
}
