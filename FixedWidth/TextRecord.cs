using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace FixedWidth
{

    public abstract class TextRecord
    {

        public override string ToString()
        {

            List<string> properties = new List<string>();

            foreach (PropertyInfo property in GetType().GetProperties())
            {

                TextField attribute = (TextField)property.GetCustomAttributes(typeof(TextField), false).SingleOrDefault();

                if (attribute == null)
                {
                    continue;
                }

                properties.Add(string.Format("{0} = \"{1}\"", property.Name, property.GetValue(this, null)));

            }

            return "{" + string.Join(", ", properties) + "}";

        }

    }

}
