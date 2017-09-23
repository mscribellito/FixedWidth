using System.Collections.Generic;
using FixedWidthTests.Models;

namespace FixedWidthTests.Expectations
{

    internal class FixedWidthExpectations : IExpectations<FixedWidthModel>
    {

        private static readonly List<FixedWidthModel> expected = new List<FixedWidthModel>()
        {
            new FixedWidthModel
            {
                Id = 1,
                Make = "Toyota",
                Model = "RAV4",
                Year = 2007,
                Mileage = 121,
                Price = 10599
            },
            new FixedWidthModel
            {
                Id = 2,
                Make = "Hyundai",
                Model = "Sonata",
                Year = 2011,
                Mileage = 116,
                Price = 9998
            },
            new FixedWidthModel
            {
                Id = 3,
                Make = "Nissan",
                Model = "Frontier",
                Year = 2009,
                Mileage = 76,
                Price = 14998
            }
        };

        public ICollection<FixedWidthModel> List()
        {

            return expected;

        }

    }

}
