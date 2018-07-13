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
        public void InstantiateWithInheritance2_Success()
        {

            var serializer = new TextSerializer<DerivedClass>();

            var d = serializer.Deserialize("a");
            Assert.AreEqual('a', d.Value);

        }

    }

}