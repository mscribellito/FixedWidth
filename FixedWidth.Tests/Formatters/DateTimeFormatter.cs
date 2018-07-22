using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Mscribel.FixedWidth.Formatters;

namespace Mscribel.FixedWidth.Tests.Formatters
{

    public class DateTimeFormatter : ITextFormatter
    {

        public const string Format = "yyyyMMdd HH:mm:ss";

        public object Deserialize(string value)
        {
            try
            {
                return DateTime.ParseExact(value, Format, null);
            }
            catch
            {
                return null;
            }
        }

        public string Serialize(object value)
        {
            return ((DateTime)value).ToString(Format);
        }

    }

}