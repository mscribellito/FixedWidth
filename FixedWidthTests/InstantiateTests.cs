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

    }

}