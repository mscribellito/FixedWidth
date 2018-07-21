using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mscribel.FixedWidth.Formatters;

namespace Mscribel.FixedWidth.Tests.Models
{

    [TextSerializable]
    public class SimpleBool
    {
        [TextField(1, 1, FormatterType = typeof(BooleanFormatter))]
        public bool Value { get; set; }
    }

    [TextSerializable]
    public class SimpleChar
    {
        [TextField(1, 1)]
        public char Value { get; set; }
    }

    [TextSerializable]
    public class SimpleDecimal
    {
        [TextField(1, 10)]
        public decimal Value { get; set; }
    }

    [TextSerializable]
    public class SimpleDouble
    {
        [TextField(1, 10)]
        public double Value { get; set; }
    }

    [TextSerializable]
    public class SimpleFloat
    {
        [TextField(1, 10)]
        public float Value { get; set; }
    }

    [TextSerializable]
    public class SimpleInt
    {
        [TextField(1, 10)]
        public int Value { get; set; }
    }

    [TextSerializable]
    public class SimpleUint
    {
        [TextField(1, 10)]
        public uint Value { get; set; }
    }

    [TextSerializable]
    public class SimpleLong
    {
        [TextField(1, 10)]
        public long Value { get; set; }
    }

    [TextSerializable]
    public class SimpleUlong
    {
        [TextField(1, 10)]
        public ulong Value { get; set; }
    }

    [TextSerializable]
    public class SimpleShort
    {
        [TextField(1, 10)]
        public short Value { get; set; }
    }

    [TextSerializable]
    public class SimpleUshort
    {
        [TextField(1, 10)]
        public ushort Value { get; set; }
    }

    [TextSerializable]
    public class SimpleString
    {
        [TextField(1, 10)]
        public string Value { get; set; }
    }

}