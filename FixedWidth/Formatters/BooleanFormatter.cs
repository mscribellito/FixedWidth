using System;

namespace FixedWidth.Formatters
{

    public class BooleanFormatter : ITextFormatter
    {

        public object Deserialize(string str)
        {

            if (Int32.TryParse(str, out int value))
            {
                return value == 1 ? true : false;
            }

            throw new Exception(string.Format("Error converting {0} to boolean",
                str));

        }

        public string Serialize(object obj)
        {

            return ((bool)obj) ? "1" : "0";

        }

    }

}
