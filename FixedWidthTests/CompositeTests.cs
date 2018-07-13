using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mscribel.FixedWidth.Formatters;

namespace Mscribel.FixedWidth.Tests
{

    [TestClass()]
    public class CompositeTests
    {

        [TextSerializable]
        public class CompositeClass
        {
            [TextField(1, 1)]
            public char Type { get; set; }
            [TextField(2, 15)]
            public string Name { get; set; }
            [TextField(17, 2,
                Padding = '0',
                Alignment = TextAlignment.Right)]
            public int Status { get; set; }
            [TextField(19, 7)]
            public double Amount { get; set; }
            [TextField(26, 1,
                FormatterType = typeof(BooleanFormatter))]
            public bool Closed { get; set; }
        }

        [TestMethod()]
        public void Composite_Success()
        {

            string str = "SAcme Company   011234.560";

            var serializer = new TextSerializer<CompositeClass>();
            var deserialized = serializer.Deserialize(str);

            Assert.AreEqual('S', deserialized.Type);
            Assert.AreEqual("Acme Company", deserialized.Name);
            Assert.AreEqual(1, deserialized.Status);
            Assert.AreEqual(1234.56, deserialized.Amount);
            Assert.AreEqual(false, deserialized.Closed);

            Assert.AreEqual(str, serializer.Serialize(deserialized));

        }

    }

}
