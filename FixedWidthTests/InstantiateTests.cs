using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FixedWidth.Tests
{

    [TestClass()]
    public class InstantiateTests
    {

        [TextSerializable]
        public struct StructSuccess
        {
        }

        public struct StructFailure
        {
        }

        [TextSerializable]
        public class ClassSuccess
        {
        }

        public class ClassFailure
        {
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
        public void InstantiateWithStruct_Success()
        {
            var serializer = new TextSerializer<StructSuccess>();
        }

        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void InstantiateWithStruct_Failure()
        {
            var serializer = new TextSerializer<StructFailure>();
        }

    }

}