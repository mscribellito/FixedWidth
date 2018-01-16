using Microsoft.VisualStudio.TestTools.UnitTesting;
using FixedWidth.Formatters;

namespace FixedWidth.Tests
{

    [TestClass()]
    public class BuiltInTypeTests
    {

        [TextSerializable]
        public class SimpleChar
        {
            [TextField(1, 1)]
            public char Value { get; set; }
        }

        [TextSerializable]
        public class SimpleString
        {
            [TextField(1, 10)]
            public string Value { get; set; }
        }

        [TextSerializable]
        public class SimpleInt
        {
            [TextField(1, 10)]
            public int Value { get; set; }
        }

        [TextSerializable]
        public class SimpleDouble
        {
            [TextField(1, 10)]
            public double Value { get; set; }
        }

        [TextSerializable]
        public class SimpleBool
        {
            [TextField(1, 1, FormatterType = typeof(BooleanFormatter))]
            public bool Value { get; set; }
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
        public void String_Success()
        {

            string str = "asdf      ";

            var serializer = new TextSerializer<SimpleString>();
            var deserialized = serializer.Deserialize(str);

            Assert.AreEqual("asdf", deserialized.Value);
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
        public void Double_Success()
        {

            string str = "12.3      ";

            var serializer = new TextSerializer<SimpleDouble>();
            var deserialized = serializer.Deserialize(str);

            Assert.AreEqual(12.3, deserialized.Value);
            Assert.AreEqual(str, serializer.Serialize(deserialized));

        }

        [TestMethod()]
        public void Bool_Success()
        {

            string str = "1";

            var serializer = new TextSerializer<SimpleBool>();
            var deserialized = serializer.Deserialize(str);

            Assert.AreEqual(true, deserialized.Value);
            Assert.AreEqual(str, serializer.Serialize(deserialized));

        }

    }

}