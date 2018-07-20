using System;
using Mscribel.FixedWidth.Formatters;

namespace Mscribel.FixedWidth.Examples
{

    [TextSerializable]
    public class Dog
    {

        [TextField(1, 10)]
        public string Name { get; set; }

        [TextField(11, 1)]
        public char Sex { get; set; }

        [TextField(12, 3,
            Padding = '0',
            Alignment = TextAlignment.Right)]
        public int Weight { get; set; }

        [TextField(15, 8,
            FormatterType = typeof(DateFormatter))]
        public DateTime BirthDate { get; set; }

        [TextField(23, 1,
            FormatterType = typeof(BooleanFormatter))]
        public bool SpayedNeutered { get; set; }

    }

}
