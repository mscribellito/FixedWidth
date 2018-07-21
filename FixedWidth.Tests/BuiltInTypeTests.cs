using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mscribel.FixedWidth.Formatters;
using Mscribel.FixedWidth.Tests.Models;

namespace Mscribel.FixedWidth.Tests
{

    [TestClass()]
    public class BuiltInTypeTests
    {

        [TestMethod()]
        public void Bool_Success()
        {

            string str = "1";

            var serializer = new TextSerializer<SimpleBool>();
            var deserialized = serializer.Deserialize(str);

            Assert.AreEqual(true, deserialized.Value);
            Assert.AreEqual(str, serializer.Serialize(deserialized));

        }

        [TestMethod()]
        public void Char_Success()
        {

            string str = "a";

            var serializer = new TextSerializer<SimpleChar>();
            var deserialized = serializer.Deserialize(str);

            Assert.AreEqual('a', deserialized.Value);
            Assert.AreEqual(str, serializer.Serialize(deserialized));

        }

        [TestMethod()]
        public void Decimal_Success()
        {

            string str = "12.3      ";

            var serializer = new TextSerializer<SimpleDecimal>();
            var deserialized = serializer.Deserialize(str);

            Assert.AreEqual(12.3m, deserialized.Value);
            Assert.AreEqual(str, serializer.Serialize(deserialized));

        }

        [TestMethod()]
        public void Double_Success()
        {

            string str = "12.3      ";

            var serializer = new TextSerializer<SimpleDouble>();
            var deserialized = serializer.Deserialize(str);

            Assert.AreEqual(12.3, deserialized.Value);
            Assert.AreEqual(str, serializer.Serialize(deserialized));

        }

        [TestMethod()]
        public void Float_Success()
        {

            string str = "12.3      ";

            var serializer = new TextSerializer<SimpleFloat>();
            var deserialized = serializer.Deserialize(str);

            Assert.AreEqual(12.3, deserialized.Value, 0.001);
            Assert.AreEqual(str, serializer.Serialize(deserialized));

        }

        [TestMethod()]
        public void Int_Success()
        {

            string str = "1234      ";

            var serializer = new TextSerializer<SimpleInt>();
            var deserialized = serializer.Deserialize(str);

            Assert.AreEqual(1234, deserialized.Value);
            Assert.AreEqual(str, serializer.Serialize(deserialized));

        }

        [TestMethod()]
        public void Uint_Success()
        {

            string str = "1234      ";

            var serializer = new TextSerializer<SimpleUint>();
            var deserialized = serializer.Deserialize(str);

            Assert.AreEqual((uint)1234, deserialized.Value);
            Assert.AreEqual(str, serializer.Serialize(deserialized));

        }

        [TestMethod()]
        public void Long_Success()
        {

            string str = "1234      ";

            var serializer = new TextSerializer<SimpleLong>();
            var deserialized = serializer.Deserialize(str);

            Assert.AreEqual((long)1234, deserialized.Value);
            Assert.AreEqual(str, serializer.Serialize(deserialized));

        }

        [TestMethod()]
        public void Ulong_Success()
        {

            string str = "1234      ";

            var serializer = new TextSerializer<SimpleUlong>();
            var deserialized = serializer.Deserialize(str);

            Assert.AreEqual((ulong)1234, deserialized.Value);
            Assert.AreEqual(str, serializer.Serialize(deserialized));

        }

        [TestMethod()]
        public void Short_Success()
        {

            string str = "1234      ";

            var serializer = new TextSerializer<SimpleShort>();
            var deserialized = serializer.Deserialize(str);

            Assert.AreEqual((short)1234, deserialized.Value);
            Assert.AreEqual(str, serializer.Serialize(deserialized));

        }

        [TestMethod()]
        public void Ushort_Success()
        {

            string str = "1234      ";

            var serializer = new TextSerializer<SimpleUshort>();
            var deserialized = serializer.Deserialize(str);

            Assert.AreEqual((ushort)1234, deserialized.Value);
            Assert.AreEqual(str, serializer.Serialize(deserialized));

        }

        [TestMethod()]
        public void String_Success()
        {

            string str = "asdf      ";

            var serializer = new TextSerializer<SimpleString>();
            var deserialized = serializer.Deserialize(str);

            Assert.AreEqual("asdf", deserialized.Value);
            Assert.AreEqual(str, serializer.Serialize(deserialized));

        }

    }

}