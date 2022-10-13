using Newtonsoft.Json;

namespace DocsStorage.Converters.Documents
{
    public class XmlConverter : IFromJsonConverter
    {
        public string Convert(string json)
        {
            var xml = JsonConvert.DeserializeXmlNode("{\"Root\":" + json + "}", "");
            return xml.OuterXml;
        }
    }
}
