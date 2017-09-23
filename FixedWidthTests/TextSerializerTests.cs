using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using FixedWidth;
using FixedWidthTests.Models;
using FixedWidthTests.Expectations;

namespace FixedWidthTests.Tests
{

    [TestClass]
    public class TextSerializerTests : BaseTest<FixedWidthModel>
    {

        public TextSerializerTests() : base("FixedWidth.txt")
        {

            Serializer = new TextSerializer<FixedWidthModel>();
            Expectations = new FixedWidthExpectations();
            Comparer = new FixedWidthComparer();

        }

        private class FixedWidthComparer : IComparer
        {

            public int Compare(object x, object y)
            {

                var left = (FixedWidthModel)x;
                var right = (FixedWidthModel)y;

                bool equal = left.Id == right.Id &&
                    left.Make == right.Make &&
                    left.Model == right.Model &&
                    left.Year == right.Year &&
                    left.Mileage == right.Mileage &&
                    left.Price == right.Price;

                return equal ? 0 : 1;

            }

        }

    }

}
