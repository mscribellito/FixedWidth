using Microsoft.VisualStudio.TestTools.UnitTesting;
using FixedWidth.Formatters;
using System;

namespace FixedWidth.Tests
{

    [TestClass()]
    public class LengthTests
    {

        [TextSerializable]
        public class StringClass
        {
            [TextField(1, 10)]
            public string Value { get; set; }
        }

        [TestMethod()]
        public void Length_Success()
        {

            string str = "10charlong";

            var serializer = new TextSerializer<StringClass>();
            var deserialized = serializer.Deserialize(str);

            Assert.AreEqual(str, deserialized.Value);
            Assert.AreEqual(str, serializer.Serialize(deserialized));

        }

        [TestMethod()]
        public void Length_Failure()
        {

            string str = "10charlong";

            var serializer = new TextSerializer<StringClass>();
            var deserialized = serializer.Deserialize(str);

            Assert.AreEqual(str, deserialized.Value);
            Assert.AreEqual(str, serializer.Serialize(deserialized));

            string str2 = "not10charlong";
            deserialized.Value = str2;
            Assert.AreNotEqual(str, deserialized.Value);
            Assert.AreEqual(str2.Substring(0, 10), serializer.Serialize(deserialized));
            Assert.AreNotEqual(str2, serializer.Serialize(deserialized));

        }

    }

}