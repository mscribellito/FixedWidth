using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mscribel.FixedWidth.Formatters;

namespace Mscribel.FixedWidth.Tests
{

    [TestClass()]
    public class BuiltInTypeTests
    {

        [TextSerializable]
        public class BoolClass
        {
            [TextField(1, 1, FormatterType = typeof(BooleanFormatter))]
            public bool Value { get; set; }
        }

        [TextSerializable]
        public class CharClass
        {
            [TextField(1, 1)]
            public char Value { get; set; }
        }

        [TextSerializable]
        public class DecimalClass
        {
            [TextField(1, 10)]
            public decimal Value { get; set; }
        }

        [TextSerializable]
        public class DoubleClass
        {
            [TextField(1, 10)]
            public double Value { get; set; }
        }

        [TextSerializable]
        public class FloatClass
        {
            [TextField(1, 10)]
            public float Value { get; set; }
        }

        [TextSerializable]
        public class IntClass
        {
            [TextField(1, 10)]
            public int Value { get; set; }
        }

        [TextSerializable]
        public class UintClass
        {
            [TextField(1, 10)]
            public uint Value { get; set; }
        }

        [TextSerializable]
        public class LongClass
        {
            [TextField(1, 10)]
            public long Value { get; set; }
        }

        [TextSerializable]
        public class UlongClass
        {
            [TextField(1, 10)]
            public ulong Value { get; set; }
        }

        [TextSerializable]
        public class ShortClass
        {
            [TextField(1, 10)]
            public short Value { get; set; }
        }

        [TextSerializable]
        public class UshortClass
        {
            [TextField(1, 10)]
            public ushort Value { get; set; }
        }

        [TextSerializable]
        public class StringClass
        {
            [TextField(1, 10)]
            public string Value { get; set; }
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
        public void DecimalClass_Success()
        {

            string str = "12.3      ";

            var serializer = new TextSerializer<DecimalClass>();
            var deserialized = serializer.Deserialize(str);

            Assert.AreEqual(12.3m, deserialized.Value);
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
        public void FloatClass_Success()
        {

            string str = "12.3      ";

            var serializer = new TextSerializer<FloatClass>();
            var deserialized = serializer.Deserialize(str);

            Assert.AreEqual(12.3, deserialized.Value, 0.001);
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
        public void UintClass_Success()
        {

            string str = "1234      ";

            var serializer = new TextSerializer<UintClass>();
            var deserialized = serializer.Deserialize(str);

            Assert.AreEqual((uint)1234, deserialized.Value);
            Assert.AreEqual(str, serializer.Serialize(deserialized));

        }

        [TestMethod()]
        public void LongClass_Success()
        {

            string str = "1234      ";

            var serializer = new TextSerializer<LongClass>();
            var deserialized = serializer.Deserialize(str);

            Assert.AreEqual((long)1234, deserialized.Value);
            Assert.AreEqual(str, serializer.Serialize(deserialized));

        }

        [TestMethod()]
        public void UlongClass_Success()
        {

            string str = "1234      ";

            var serializer = new TextSerializer<UlongClass>();
            var deserialized = serializer.Deserialize(str);

            Assert.AreEqual((ulong)1234, deserialized.Value);
            Assert.AreEqual(str, serializer.Serialize(deserialized));

        }

        [TestMethod()]
        public void ShortClass_Success()
        {

            string str = "1234      ";

            var serializer = new TextSerializer<ShortClass>();
            var deserialized = serializer.Deserialize(str);

            Assert.AreEqual((short)1234, deserialized.Value);
            Assert.AreEqual(str, serializer.Serialize(deserialized));

        }

        [TestMethod()]
        public void UshortClass_Success()
        {

            string str = "1234      ";

            var serializer = new TextSerializer<UshortClass>();
            var deserialized = serializer.Deserialize(str);

            Assert.AreEqual((ushort)1234, deserialized.Value);
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

    }

}