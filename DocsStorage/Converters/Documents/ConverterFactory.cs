using DocsStorage.Models;

namespace DocsStorage.Converters.Documents
{
    public static class ConverterFactory
    {
        public static IFromJsonConverter GetFormatConverter(string mimeType) => mimeType switch
        {
            Constants.MimeTypes.Xml => new XmlConverter(),
            Constants.MimeTypes.Msgpack => new MsgpackConverter(),
            _ => null,
        };
    }
}
