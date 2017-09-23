using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace FixedWidth
{

    /// <summary>
    /// Serialize and deserialize fixed width text
    /// </summary>
    /// <typeparam name="T">The type of object</typeparam>
    public class TextSerializer<T> where T : new()
    {

        public bool ZeroIndexed { get; set; } = false;

        protected readonly Type type;

        protected readonly SortedDictionary<int, TextField> fields;

        /// <summary>
        /// Serialize and deserialize fixed width text
        /// </summary>
        public TextSerializer()
        {

            type = typeof(T);
            fields = new SortedDictionary<int, TextField>();

            CheckForAttribute();
            AnalyzeMembers();

        }

        private void CheckForAttribute()
        {

            // Check that TextSerializable attribute is attached to T
            if (type.GetCustomAttributes(typeof(TextSerializable), false).Length == 0)
            {
                throw new Exception(type + " must have a " + typeof(TextSerializable) + " attribute");
            }

        }

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
        /// Creates T object from fixed width text
        /// </summary>
        /// <param name="text">string to deserialize</param>
        /// <returns>deserialized object</returns>
        public T Deserialize(string text)
        {

            T deserialized = new T();
            string temp;

            foreach (TextField field in fields.Values)
            {

                int position = ZeroIndexed == true ? field.Position : field.Position - 1;
                try
                {
                    temp = text.Substring(position, field.Size).Trim(field.Padding);
                }
                catch (ArgumentOutOfRangeException e)
                {
                    throw new Exception(string.Format("Position={0}, Size={1}", position, field.Size), e);
                }
                object value = null;
                if (field.Formatter != null)
                {
                    value = field.Formatter.Deserialize(temp);
                }
                else
                {
                    value = Convert.ChangeType(temp, field.GetMemberType());
                }
                var property = type.GetProperty(field.Name);
                property.SetValue(deserialized, value, null);

            }

            return deserialized;

        }

        /// <summary>
        /// Creates fixed width text from T object
        /// </summary>
        /// <param name="record">object to serialize</param>
        /// <returns>serialized string</returns>
        public string Serialize(T record)
        {

            StringBuilder sb = new StringBuilder();
            object temp = null;

            foreach (TextField field in fields.Values)
            {

                if (field.Member is FieldInfo)
                {
                    temp = ((FieldInfo)field.Member).GetValue(record);
                }
                else if (field.Member is PropertyInfo)
                {
                    temp = ((PropertyInfo)field.Member).GetValue(record, null);
                }
                string value = null;
                if (field.Formatter != null)
                {
                    value = field.Formatter.Serialize(temp);
                }
                else
                {
                    value = temp.ToString();
                }
                int paddingCount = field.Size - value.Length;
                if (paddingCount > 0)
                {
                    sb.Append(field.Padding, paddingCount);
                }
                sb.Append(value);

            }

            return sb.ToString();

        }

    }

}
