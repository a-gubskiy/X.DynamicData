using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace UnitTests
{
    [TestClass]
    public class FtpFileUploadTests
    {
        [TestMethod]
        public void TestFileUpload()
        {
            const string text = "This is test text";
            byte[] bytes;

            using (var stream = new MemoryStream())
            {
                var writer = new StreamWriter(stream);
                writer.Write(text);
                writer.Flush();
                bytes = stream.ToArray();
            }

            X.DynamicData.Core.Global.Context.StorageConnectionString = "ftp://user:passrd@exmple.com";
            X.DynamicData.Core.Global.Context.StorageUrl = "http://exmple.com/static/";

            var url = X.DynamicData.Core.Global.UploadFile(bytes, "test.txt");

            Assert.AreEqual("http://exmple.com/static/test.txt", url);
        }
    }
}
