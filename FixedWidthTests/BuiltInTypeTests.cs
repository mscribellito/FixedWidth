using Microsoft.VisualStudio.TestTools.UnitTesting;
using FixedWidth.Formatters;

namespace FixedWidth.Tests
{

    [TestClass()]
    public class BuiltInTypeTests
    {

        [TextSerializable]
        public class CharClass
        {
            [TextField(1, 1)]
            public char Value { get; set; }
        }

        [TextSerializable]
        public class StringClass
        {
            [TextField(1, 10)]
            public string Value { get; set; }
        }

        [TextSerializable]
        public class IntClass
        {
            [TextField(1, 10)]
            public int Value { get; set; }
        }

        [TextSerializable]
        public class DoubleClass
        {
            [TextField(1, 10)]
            public double Value { get; set; }
        }

        [TextSerializable]
        public class BoolClass
        {
            [TextField(1, 1, FormatterType = typeof(BooleanFormatter))]
            public bool Value { get; set; }
        }

        [TestMethod()]
        public void CharClass_Success()
        {

            string str = "a";

            var serializer = new TextSerializer<CharClass>();
            var deserialized = serializer.Deserialize(str);

            Assert.AreEqual('a', deserialized.Value);
            Assert.AreEqual(str, serializer.Serialize(deserialized));

        }

        [TestMethod()]
        public void StringClass_Success()
        {

            string str = "asdf      ";

            var serializer = new TextSerializer<StringClass>();
            var deserialized = serializer.Deserialize(str);

            Assert.AreEqual("asdf", deserialized.Value);
            Assert.AreEqual(str, serializer.Serialize(deserialized));

        }

        [TestMethod()]
        public void IntClass_Success()
        {

            string str = "1234      ";

            var serializer = new TextSerializer<IntClass>();
            var deserialized = serializer.Deserialize(str);

            Assert.AreEqual(1234, deserialized.Value);
            Assert.AreEqual(str, serializer.Serialize(deserialized));

        }

        [TestMethod()]
        public void DoubleClass_Success()
        {

            string str = "12.3      ";

            var serializer = new TextSerializer<DoubleClass>();
            var deserialized = serializer.Deserialize(str);

            Assert.AreEqual(12.3, deserialized.Value);
            Assert.AreEqual(str, serializer.Serialize(deserialized));

        }

        [TestMethod()]
        public void BoolClass_Success()
        {

            string str = "1";

            var serializer = new TextSerializer<BoolClass>();
            var deserialized = serializer.Deserialize(str);

            Assert.AreEqual(true, deserialized.Value);
            Assert.AreEqual(str, serializer.Serialize(deserialized));

        }

    }

}