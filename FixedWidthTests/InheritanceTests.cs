using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Mscribel.FixedWidth.Tests
{

    [TestClass()]
    public class InheritanceTests
    {

        [TextSerializable]
        public class BaseClass
        {
            [TextField(1, 1)]
            public char Value { get; set; }
        }

        public class DerivedClass : BaseClass
        {
        }

        [TestMethod()]
        public void InstantiateWithInheritance_Success()
        {
            var baseSerializer = new TextSerializer<BaseClass>();
            var derivedSerializer = new TextSerializer<DerivedClass>();
        }

        [TestMethod()]
        public void InheritanceSerialization_Success()
        {

            var serializer = new TextSerializer<DerivedClass>();
            string str = "a";

            var d = serializer.Deserialize(str);
            Assert.AreEqual('a', d.Value);
            var s = serializer.Serialize(d);
            Assert.AreEqual(str, s);

        }

    }

}