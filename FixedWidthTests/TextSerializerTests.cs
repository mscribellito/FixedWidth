using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FixedWidth.Tests
{

    [TestClass()]
    public class TextSerializerTests
    {

        public const string FixedWidth = "CXXXX62790003826.73         MY CHECKING 5";

        public TextSerializer<AccountClass> serializer;

        public AccountClass deserialized;

        public string serialized;

        public TextSerializerTests()
        {

            serializer = new TextSerializer<AccountClass>();

            deserialized = serializer.Deserialize(FixedWidth);
            serialized = serializer.Serialize(deserialized);

        }

        [TestMethod()]
        public void DeserializeTest()
        {

            Assert.AreEqual('C', deserialized.Type);
            Assert.AreEqual("6279", deserialized.Number);
            Assert.AreEqual((decimal)3826.73, deserialized.Balance);
            Assert.AreEqual("MY CHECKING", deserialized.Name);
            Assert.AreEqual(5, deserialized.Status);

        }

        [TestMethod()]
        public void SerializeTest()
        {

            Assert.AreEqual(FixedWidth, serialized);

        }

    }

}
