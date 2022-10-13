using MessagePack;
using System.Text;
using System.Text.Json;

namespace DocsStorage.Converters.Documents
{
    public class MsgpackConverter : IFromJsonConverter
    {
        public string Convert(string json)
        {
            var bytes = MessagePackSerializer.ConvertFromJson(json);
            return Encoding.UTF8.GetString(bytes);
        }
    }
}
