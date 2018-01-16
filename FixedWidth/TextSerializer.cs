using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace FixedWidth
{

    /// <summary>
    /// Deserialize and serialize fixed width text.
    /// </summary>
    /// <typeparam name="T">The type of object</typeparam>
    public class TextSerializer<T> where T : new()
    {

        /// <summary>
        /// Specifies if field positions are zero based or not.
        /// </summary>
        public bool ZeroIndexed { get; set; }

        public IEnumerable<TextField> Fields
        {
            get { return fields.Values; }
        }

        private readonly Type type;

        private readonly SortedDictionary<int, TextField> fields;

        /// <summary>
        /// Instantiates a new TextSerializer.
        /// </summary>
        public TextSerializer()
        {

            ZeroIndexed = false;

            type = typeof(T);
            fields = new SortedDictionary<int, TextField>();

            CheckForAttribute();
            AnalyzeMembers();

        }

        /// <summary>
        /// Check that TextSerializable attribute is attached to T.
        /// </summary>
        private void CheckForAttribute()
        {

            if (type.GetCustomAttributes(typeof(TextSerializable), false).Length == 0)
            {
                throw new Exception(type + " must have a " + typeof(TextSerializable) + " attribute");
            }

        }

        /// <summary>
        /// Analyze class members for text fields.
        /// </summary>
        private void AnalyzeMembers()
        {

            // Get members of class
            MemberInfo[] members = type.GetMembers(BindingFlags.Instance | BindingFlags.Public |
                BindingFlags.GetField | BindingFlags.GetProperty);
            foreach (MemberInfo member in members)
            {

                Attribute attribute = member.GetCustomAttribute(typeof(TextField), false);
                if (attribute != null)
                {
                    if (!(member is FieldInfo || member is PropertyInfo))
                    {
                        throw new Exception("Invalid member type");
                    }

                    // Check that TextField attribute is attached
                    TextField field = (TextField)attribute;

                    if (string.IsNullOrEmpty(field.Name))
                    {
                        field.Name = member.Name;
                    }
                    field.Member = member;

                    fields.Add(field.Position, field);
                }

            }

        }

        /// <summary>
        /// Creates T object from fixed width text.
        /// </summary>
        /// <param name="text">string to deserialize</param>
        /// <returns>deserialized object</returns>
        public T Deserialize(string text)
        {

            T deserialized = new T();
            string temp;

            foreach (TextField field in fields.Values)
            {

                object value = null;

                // Get field text
                int position = ZeroIndexed == true ? field.Position : field.Position - 1;
                try
                {
                    temp = text.Substring(position, field.Size).Trim(field.Padding);
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

                // Set object value
                var property = type.GetProperty(field.Name);
                property.SetValue(deserialized, value, null);

            }

            return deserialized;

        }

        /// <summary>
        /// Creates fixed width text from T object.
        /// </summary>
        /// <param name="record">object to serialize</param>
        /// <returns>serialized string</returns>
        public string Serialize(T record)
        {

            StringBuilder serialized = new StringBuilder();
            object temp = null;

            foreach (TextField field in fields.Values)
            {

                string value = null;

                // Get member value
                if (field.Member is FieldInfo)
                {
                    temp = ((FieldInfo)field.Member).GetValue(record);
                }
                else if (field.Member is PropertyInfo)
                {
                    temp = ((PropertyInfo)field.Member).GetValue(record, null);
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

                // Add to string, optionally pad
                int paddingCount = field.Size - value.Length;
                if (paddingCount > 0 && field.Alignment == TextAlignment.Right)
                {
                    serialized.Append(field.Padding, paddingCount);
                }
                serialized.Append(value);
                if (paddingCount > 0 && field.Alignment == TextAlignment.Left)
                {
                    serialized.Append(field.Padding, paddingCount);
                }

            }

            return serialized.ToString();

        }

    }

}
