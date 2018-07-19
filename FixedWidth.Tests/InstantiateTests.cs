using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Mscribel.FixedWidth.Tests
{

    [TestClass()]
    public class InstantiateTests
    {

        [TextSerializable]
        public class ClassSuccess
        {
        }

        public class ClassFailure
        {
        }

        [TextSerializable(ZeroBased = true)]
        public class ZeroBased
        {
            [TextField(0, 1)]
            public char Value { get; set; }
        }

        [TextSerializable]
        public class NonZeroBased
        {
            [TextField(1, 1)]
            public char Value { get; set; }
        }

        [TestMethod()]
        public void InstantiateWithClass_Success()
        {
            var serializer = new TextSerializer<ClassSuccess>();
        }

        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void InstantiateWithClass_Failure()
        {
            var serializer = new TextSerializer<ClassFailure>();
        }

        [TestMethod()]
        public void InstantiateZeroBased_Success()
        {

            var serializer = new TextSerializer<ZeroBased>();
            Assert.IsTrue(serializer.ZeroBased);

            string str = "a";
            var deserialized = serializer.Deserialize(str);
            Assert.AreEqual('a', deserialized.Value);

        }

        [TestMethod()]
        public void InstantiateNonZeroBased_Success()
        {

            var serializer = new TextSerializer<NonZeroBased>();
            Assert.IsFalse(serializer.ZeroBased);

            string str = "a";
            var deserialized = serializer.Deserialize(str);
            Assert.AreEqual('a', deserialized.Value);

        }

    }

}