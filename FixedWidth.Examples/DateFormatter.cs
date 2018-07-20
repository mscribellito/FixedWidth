using System;

namespace Mscribel.FixedWidth.Examples
{

    public class DateFormatter : ITextFormatter
    {

        private const string Format = "yyyyMMdd";

        public object Deserialize(string value)
        {
            return DateTime.ParseExact(value, Format, null);
        }

        public string Serialize(object value)
        {
            return ((DateTime)value).ToString(Format);
        }

    }

}
