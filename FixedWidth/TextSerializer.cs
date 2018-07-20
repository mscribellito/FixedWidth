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
    public partial class TextSerializer<T> where T : new()
    {

        private readonly Type _type;

        private readonly SortedDictionary<int, TextField> _fields;

        private bool _zeroBased;

        /// <summary>
        /// Specifies if field positions are zero based or not.
        /// </summary>
        public bool ZeroBased { get => _zeroBased; set => _zeroBased = value; }

        private string _currentString;
        private T _currentObject;

        /// <summary>
        /// Instantiates a new TextSerializer.
        /// </summary>
        public TextSerializer()
        {

            _type = typeof(T);
            _fields = new SortedDictionary<int, TextField>();

            CheckForAttribute();
            AnalyzeMembers();

        }

        /// <summary>
        /// Check that TextSerializable attribute is attached to T.
        /// </summary>
        private void CheckForAttribute()
        {

            TextSerializable attribute = (TextSerializable)_type.GetCustomAttribute(typeof(TextSerializable), true);

            if (attribute == null)
            {
                throw new Exception(string.Format("{0} must have a {1} attribute",
                    _type, typeof(TextSerializable)));
            }

            ZeroBased = attribute.ZeroBased;

        }

        /// <summary>
        /// Analyze class members for text fields.
        /// </summary>
        private void AnalyzeMembers()
        {

            // Get public fields and properties of T
            MemberInfo[] members = _type.GetMembers(BindingFlags.Instance | BindingFlags.Public |
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
                _fields.Add(field.Position, field);

            }

        }

    }

}
