using DocsStorage;
using DocsStorage.Converters.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocsStorageTests.Converters.Documents
{
    [TestClass]
    public class DocumentConverterFactoryTests
    {
        [TestMethod]
        public void TestDocumentConverterFactoryXml()
        {
            var converter = ConverterFactory.GetFormatConverter(Constants.MimeTypes.Xml);
            Assert.IsInstanceOfType(converter, typeof(XmlConverter));
        }

        [TestMethod]
        public void TestDocumentConverterFactoryMsgpack()
        {
            var converter = ConverterFactory.GetFormatConverter(Constants.MimeTypes.Msgpack);
            Assert.IsInstanceOfType(converter, typeof(MsgpackConverter));
        }
    }
}
