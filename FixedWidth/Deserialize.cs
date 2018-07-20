using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Mscribel.FixedWidth
{

    public partial class TextSerializer<T> where T : new()
    {

        /// <summary>
        /// Creates T object from fixed width text.
        /// </summary>
        /// <param name="str">string to deserialize</param>
        /// <returns>deserialized object</returns>
        public T Deserialize(string str)
        {

            if (str == null)
            {
                throw new ArgumentNullException("str", "cannot be null");
            }

            _currentString = str;
            T deserialized = new T();

            // Iterate over fields and set member in T object
            foreach (TextField field in _fields.Values)
            {

                object value = GetObject(field);
                AssignValue(field, deserialized, value);

            }

            return deserialized;

        }

        /// <summary>
        /// Get T object from string
        /// </summary>
        /// <param name="field">text field</param>
        /// <returns>the T object</returns>
        private object GetObject(TextField field)
        {

            string temp = string.Empty;
            object value = null;

            // Get field text
            int position = ZeroBased == true ? field.Position : field.Position - 1;
            try
            {
                temp = _currentString.Substring(position, field.Size).Trim(field.Padding);
            }
            catch (ArgumentOutOfRangeException e)
            {
                throw new Exception(string.Format("Position={0}, Size={1}", position, field.Size), e);
            }

            // String to object
            if (field.Formatter != null)
            {
                try
                {
                    value = field.Formatter.Deserialize(temp);
                }
                catch (Exception e)
                {
                    throw new Exception(string.Format("Field: Name={0}, Position={1}, Size={2}",
                        field.Name, field.Position, field.Size), e);
                }
            }
            else
            {
                value = Convert.ChangeType(temp, field.GetMemberType());
            }

            return value;

        }

        /// <summary>
        /// Assign value to object
        /// </summary>
        /// <param name="field">text field</param>
        /// <param name="deserialized">deserialized object</param>
        /// <param name="value">text field value</param>
        private void AssignValue(TextField field, T deserialized, object value)
        {

            // Set member value
            if (field.Member is FieldInfo)
            {
                ((FieldInfo)field.Member).SetValue(deserialized, value);
            }
            else if (field.Member is PropertyInfo)
            {
                ((PropertyInfo)field.Member).SetValue(deserialized, value, null);
            }

        }

    }

}
