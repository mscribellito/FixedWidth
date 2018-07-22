using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Mscribel.FixedWidth.Tests.Formatters;
using Mscribel.FixedWidth.Tests.Models;

namespace Mscribel.FixedWidth.Tests
{

    [TestClass()]
    public class CompositeTests
    {

        [TestMethod()]
        public void Composite_Success()
        {

            string str = "C0000583420141102 16:31:420023267.47";

            var serializer = new TextSerializer<Account>();
            var account = serializer.Deserialize(str);

            Assert.AreEqual('C', account.Type);
            Assert.AreEqual("5834", account.Number);
            Assert.AreEqual(new DateTime(2014, 11, 2, 16, 31, 42), account.Opened);
            Assert.AreEqual(23267.47m, account.Amount);

            Assert.AreEqual(str, serializer.Serialize(account));

        }

    }

}
