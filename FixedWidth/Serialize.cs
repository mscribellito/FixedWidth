using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Mscribel.FixedWidth
{

    public partial class TextSerializer<T> where T : new()
    {

        /// <summary>
        /// Creates fixed width text from T object.
        /// </summary>
        /// <param name="obj">object to serialize</param>
        /// <returns>serialized string</returns>
        public string Serialize(T obj)
        {

            if (obj == null)
            {
                throw new ArgumentNullException("obj", "cannot be null");
            }

            _currentObject = obj;
            StringBuilder serialized = new StringBuilder();

            // Iterate over fields and get string representation
            foreach (TextField field in _fields.Values)
            {

                string value = GetString(field);
                serialized.Append(ApplyFormatting(field, value));

            }

            return serialized.ToString();

        }

        /// <summary>
        /// Get string from T object
        /// </summary>
        /// <param name="field">text field</param>
        /// <returns>the string</returns>
        private string GetString(TextField field)
        {

            object temp = null;
            string value = string.Empty;

            // Get member value
            if (field.Member is FieldInfo)
            {
                temp = ((FieldInfo)field.Member).GetValue(_currentObject);
            }
            else if (field.Member is PropertyInfo)
            {
                temp = ((PropertyInfo)field.Member).GetValue(_currentObject, null);
            }

            // Object to string
            if (field.Formatter != null)
            {
                value = field.Formatter.Serialize(temp);
            }
            else
            {
                value = temp.ToString();
            }

            return value;

        }

        /// <summary>
        /// Apply formatting to string
        /// </summary>
        /// <param name="field">text field</param>
        /// <param name="value">text field value</param>
        /// <returns>the formatted string</returns>
        private string ApplyFormatting(TextField field, string value)
        {

            // Truncate value if longer than field size
            if (value.Length > field.Size)
            {
                value = value.Substring(0, field.Size);
            }
            // Pad and align value if less than field size
            else
            {
                int paddingCount = field.Size - value.Length;
                if (paddingCount > 0)
                {
                    switch (field.Alignment)
                    {
                        default:
                        case TextAlignment.Left:
                            value = value + new string(field.Padding, paddingCount);
                            break;
                        case TextAlignment.Right:
                            value = new string(field.Padding, paddingCount) + value;
                            break;
                    }
                }
            }

            return value;

        }

    }

}
