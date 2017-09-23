using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using FixedWidth;

namespace FixedWidthTests
{

    public abstract class BaseTest<T> where T : new()
    {

        protected readonly string TestFile;

        protected List<string> Lines;

        protected TextSerializer<T> Serializer;

        protected IExpectations<T> Expectations;

        protected System.Collections.IComparer Comparer;

        public BaseTest(string file)
        {

            TestFile = file;
            ReadTestFile();

        }

        private void ReadTestFile()
        {

            Lines = File.ReadAllLines(Path.Combine("Files", TestFile)).ToList();

        }

        [TestMethod]
        public void TestDeserialize()
        {

            List<T> serialized = new List<T>();

            foreach (string line in Lines)
            {
                serialized.Add(Serializer.Deserialize(line));
            }

            CollectionAssert.AreEqual((ICollection)Expectations.List(), serialized, Comparer);

        }

    }

}
