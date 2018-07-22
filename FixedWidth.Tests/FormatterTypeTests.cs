using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Mscribel.FixedWidth.Tests.Formatters;

namespace Mscribel.FixedWidth.Tests
{

    [TestClass()]
    public class FormatterTypeTests
    {

        [TextSerializable]
        public class SimpleDateTime
        {
            [TextField(1, 17,
                FormatterType = typeof(DateTimeFormatter))]
            public DateTime Value { get; set; }
        }

        [TestMethod()]
        public void DateTimeTest()
        {

            string original = "20141017 18:30:00";

            var serializer = new TextSerializer<SimpleDateTime>();
            var deserialized = serializer.Deserialize(original);

            Assert.AreEqual(new DateTime(2014, 10, 17, 18, 30, 0), deserialized.Value);
            Assert.AreEqual(original, serializer.Serialize(deserialized));

        }

    }

}
