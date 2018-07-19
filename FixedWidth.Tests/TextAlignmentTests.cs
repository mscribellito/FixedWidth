using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Mscribel.FixedWidth.Tests
{

    [TestClass()]
    public class TextAlignmentTests
    {

        [TextSerializable]
        public class StringClass
        {
            [TextField(1, 10)]
            public string Value { get; set; }
        }

        [TextSerializable]
        public class StringClassLeft
        {
            [TextField(1, 10,
                Alignment = TextAlignment.Left)]
            public string Value { get; set; }
        }

        [TextSerializable]
        public class StringClassRight
        {
            [TextField(1, 10,
                Alignment = TextAlignment.Right)]
            public string Value { get; set; }
        }

        [TestMethod()]
        public void TextAlignmentDefault_Success()
        {

            string original = "abc       ";

            var serializer = new TextSerializer<StringClass>();
            var deserialized = serializer.Deserialize(original);

            Assert.AreEqual("abc", deserialized.Value);
            Assert.AreEqual(original, serializer.Serialize(deserialized));

        }

        [TestMethod()]
        public void TextAlignmentLeft_Success()
        {

            string original = "abc       ";

            var serializer = new TextSerializer<StringClassLeft>();
            var deserialized = serializer.Deserialize(original);

            Assert.AreEqual("abc", deserialized.Value);
            Assert.AreEqual(original, serializer.Serialize(deserialized));

        }

        [TestMethod()]
        public void TextAlignmentRight_Success()
        {

            string original = "       abc";

            var serializer = new TextSerializer<StringClassRight>();
            var deserialized = serializer.Deserialize(original);

            Assert.AreEqual("abc", deserialized.Value);
            Assert.AreEqual(original, serializer.Serialize(deserialized));

        }

    }

}
