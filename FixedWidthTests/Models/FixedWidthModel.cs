using FixedWidth;

namespace FixedWidthTests.Models
{

    [TextSerializable]
    public class FixedWidthModel : TextRecord
    {

        [TextField(1, 2)]
        public int Id { get; set; }

        [TextField(3, 15)]
        public string Make { get; set; }

        [TextField(18, 10)]
        public string Model { get; set; }

        [TextField(28, 4)]
        public int Year { get; set; }

        [TextField(32, 3)]
        public int Mileage { get; set; }

        [TextField(35, 5)]
        public int Price { get; set; }

    }

}
