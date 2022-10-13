using MessagePack;
using System.Dynamic;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace DocsStorage.Models
{
    [MessagePackObject]
    public class Document
    {
        [Key("ID")]
        public string ID { get; set; }

        [Key("Tags")]
        public List<string> Tags { get; set; }

        [Key("Data")]
        public dynamic Data { get; set; }

        public bool IsValid() => !string.IsNullOrEmpty(ID) && Tags.Count > 0 && Data is not null;
    }
}
