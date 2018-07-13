using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Mscribel.FixedWidth
{

    /// <summary>
    /// Class to deserialize and serialize fixed width text.
    /// </summary>
    /// <typeparam name="T">The type of object</typeparam>
    public class TextSerializer<T> where T : new()
    {

        private readonly Type type;

        private readonly SortedDictionary<int, TextField> fields;

        private string currentString;
        private T currentObject;

        /// <summary>
        /// Specifies if field positions are zero based or not.
        /// </summary>
        public bool ZeroIndexed { get; set; }

        /// <summary>
        /// Instantiates a new TextSerializer.
        /// </summary>
        public TextSerializer()
        {

            type = typeof(T);
            fields = new SortedDictionary<int, TextField>();

            ZeroIndexed = false;

            CheckForAttribute();
            AnalyzeMembers();

        }

        /// <summary>
        /// Check that TextSerializable attribute is attached to T.
        /// </summary>
        private void CheckForAttribute()
        {

            if (type.GetCustomAttribute(typeof(TextSerializable), false) == null)
            {
                throw new Exception(string.Format("{0} must have a {1} attribute",
                    type, typeof(TextSerializable)));
            }

        }

        /// <summary>
        /// Analyze class members for text fields.
        /// </summary>
        private void AnalyzeMembers()
        {

            // Get public fields and properties of T
            MemberInfo[] members = type.GetMembers(BindingFlags.Instance | BindingFlags.Public |
                BindingFlags.GetField | BindingFlags.GetProperty);
            foreach (MemberInfo member in members)
            {

                // Check that TextField attribute is attached
                Attribute attribute = member.GetCustomAttribute(typeof(TextField), false);
                if (attribute == null)
                {
                    continue;
                }

                TextField field = (TextField)attribute;

                // Override name if provided
                if (string.IsNullOrEmpty(field.Name))
                {
                    field.Name = member.Name;
                }

                field.Member = member;
                fields.Add(field.Position, field);

            }

        }
        
        // D E S E R I A L I Z E

        /// <summary>
        /// Creates T object from fixed width text.
        /// </summary>
        /// <param name="text">string to deserialize</param>
        /// <returns>deserialized object</returns>
        public T Deserialize(string text)
        {

            currentString = text;
            T deserialized = new T();

            foreach (TextField field in fields.Values)
            {

                object value = GetObject(field);

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
            int position = ZeroIndexed == true ? field.Position : field.Position - 1;
            try
            {
                temp = currentString.Substring(position, field.Size).Trim(field.Padding);
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

        // S E R I A L I Z E

        /// <summary>
        /// Creates fixed width text from T object.
        /// </summary>
        /// <param name="record">object to serialize</param>
        /// <returns>serialized string</returns>
        public string Serialize(T record)
        {

            currentObject = record;
            StringBuilder serialized = new StringBuilder();

            foreach (TextField field in fields.Values)
            {

                string value = GetString(field);
                value = FormatFieldString(field, value);
                serialized.Append(value);

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
                temp = ((FieldInfo)field.Member).GetValue(currentObject);
            }
            else if (field.Member is PropertyInfo)
            {
                temp = ((PropertyInfo)field.Member).GetValue(currentObject, null);
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
        /// Format field string - add padding and alignment
        /// </summary>
        /// <param name="field">text field</param>
        /// <param name="value">text field value</param>
        /// <returns>the formatted string</returns>
        private string FormatFieldString(TextField field, string value)
        {

            // Truncate value if longer than field size
            if (value.Length > field.Size)
            {
                value = value.Substring(0, field.Size);
            }
            // Pad value if less than field size
            else
            {
                int paddingCount = field.Size - value.Length;
                if (paddingCount > 0)
                {
                    switch (field.Alignment)
                    {
                        case TextAlignment.Left:
                            value = value + new string(field.Padding, paddingCount);
                            break;
                        case TextAlignment.Right:
                            value = new string(field.Padding, paddingCount) + value;
                            break;
                        default:
                            break;
                    }
                }
            }

            return value;

        }

    }

}
