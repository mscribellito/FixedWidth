using Microsoft.VisualStudio.TestTools.UnitTesting;
using FixedWidth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace FixedWidth.Tests
{

    [TestClass()]
    public class TextSerializerTests
    {

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
        public class SimpleDecimal
        {
            [TextField(1, 10)]
            public decimal Value { get; set; }
        }

        [TextSerializable]
        public class SimpleDateTime
        {
            [TextField(1, 20,
                Alignment = TextAlignment.Right,
                FormatterType = typeof(DateTimeFormatter))]
            public DateTime Value { get; set; }
        }

        public class DateTimeFormatter : ITextFormatter
        {

            public const string Format = "yyyyMMdd HH:mm:ss";

            public object Deserialize(string value)
            {
                return DateTime.ParseExact(value, Format, null);
            }

            public string Serialize(object value)
            {
                return ((DateTime)value).ToString(Format);
            }
        }

        [TestMethod()]
        public void StringTest()
        {

            var serializer = new TextSerializer<SimpleString>();
            var deserialized = serializer.Deserialize("asdf      ");

            Assert.AreEqual("asdf", deserialized.Value);

        }

        [TestMethod()]
        public void IntTest()
        {

            var serializer = new TextSerializer<SimpleInt>();
            var deserialized = serializer.Deserialize("1234      ");

            Assert.AreEqual(1234, deserialized.Value);

        }

        [TestMethod()]
        public void DecimalTest()
        {

            var serializer = new TextSerializer<SimpleDecimal>();
            var deserialized = serializer.Deserialize("12.3      ");

            Assert.AreEqual(12.3m, deserialized.Value);

        }

        [TestMethod()]
        public void DateTimeTest()
        {

            string original = "   20141017 18:30:00";

            var serializer = new TextSerializer<SimpleDateTime>();

            var deserialized = serializer.Deserialize(original);
            Assert.AreEqual(new DateTime(2014, 10, 17, 18, 30, 0), deserialized.Value);

            var serialized = serializer.Serialize(deserialized);
            Assert.AreEqual(original, serialized);

        }

    }

}