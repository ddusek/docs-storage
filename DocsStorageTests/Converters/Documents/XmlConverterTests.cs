using DocsStorage.Converters.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocsStorageTests.Converters.Documents
{
    [TestClass]
    public class XmlConverterTests
    {
        [TestMethod]
        public async Task TestConvertJson1()
        {
            var converter = new XmlConverter();
            var json = "{\"key1\":\"val1\"}";
            var xml = converter.Convert(json);

            var expectedResult = "<Root><key1>val1</key1></Root>";
            Assert.AreEqual(expectedResult, xml, $"xml conversion failed. expected result: {expectedResult} but got {xml}");
        }

        [TestMethod]
        public async Task TestConvertJson2()
        {
            var converter = new XmlConverter();
            var json = "{\"key1\":[\"val1\", \"val2\", \"val3\"]}";
            var xml = converter.Convert(json);

            var expectedResult = "<Root><key1>val1</key1><key1>val2</key1><key1>val3</key1></Root>";
            Assert.AreEqual(expectedResult, xml, $"xml conversion failed. expected result: {expectedResult} but got {xml}");
        }
    }
}
