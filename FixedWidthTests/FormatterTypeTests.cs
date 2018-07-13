using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Mscribel.FixedWidth.Tests
{

    [TestClass()]
    public class FormatterTypeTests
    {

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
                try
                {
                    return DateTime.ParseExact(value, Format, null);
                }
                catch
                {
                    return null;
                }
            }

            public string Serialize(object value)
            {
                return ((DateTime)value).ToString(Format);
            }

        }

        [TestMethod()]
        public void DateTimeTest()
        {

            string original = "   20141017 18:30:00";

            var serializer = new TextSerializer<SimpleDateTime>();
            var deserialized = serializer.Deserialize(original);

            Assert.AreEqual(new DateTime(2014, 10, 17, 18, 30, 0), deserialized.Value);
            Assert.AreEqual(original, serializer.Serialize(deserialized));

        }

    }

}
