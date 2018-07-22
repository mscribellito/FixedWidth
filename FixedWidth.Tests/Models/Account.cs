using System;
using Mscribel.FixedWidth.Tests.Formatters;

namespace Mscribel.FixedWidth.Tests.Models
{

    [TextSerializable]
    public class Account
    {

        [TextField(1, 1)]
        public char Type { get; set; }

        [TextField(2, 8, '0',
            Alignment = TextAlignment.Right)]
        public string Number { get; set; }

        [TextField(10, 17,
            FormatterType = typeof(DateTimeFormatter))]
        public DateTime Opened { get; set; }

        [TextField(27, 10, '0',
            Alignment = TextAlignment.Right)]
        public decimal Amount { get; set; }

    }

}
