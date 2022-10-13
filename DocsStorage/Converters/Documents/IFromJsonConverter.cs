using DocsStorage.Models;

namespace DocsStorage.Converters.Documents
{
    public interface IFromJsonConverter
    {
        string Convert(string json);
    }
}
