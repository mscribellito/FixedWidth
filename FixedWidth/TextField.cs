using System;
using System.Linq;
using System.Reflection;

namespace FixedWidth
{

    /// <summary>
    /// The text field attribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property,
        AllowMultiple = false)]
    public class TextField : Attribute
    {

        /// <summary>
        /// Name of text field.
        /// </summary>
        internal string Name { get; set; }

        /// <summary>
        /// Position of text field.
        /// </summary>
        public int Position { get; set; }

        /// <summary>
        /// Size of text field.
        /// </summary>
        public int Size { get; set; }

        /// <summary>
        /// Character used to pad text field.
        /// </summary>
        public char Padding { get; set; }

        /// <summary>
        /// Text alignment of field.
        /// </summary>
        public TextAlignment Alignment { get; set; }

        private Type formatterType;

        /// <summary>
        /// Type to be utilized for deserialze/serialize.
        /// </summary>
        public Type FormatterType
        {
            get
            {
                return formatterType;
            }
            set
            {
                formatterType = value;
                Formatter = (ITextFormatter)formatterType.Assembly.CreateInstance(formatterType.FullName);
            }
        }

        internal MemberInfo Member { get; set; }

        internal ITextFormatter Formatter { get; private set; }

        /// <summary>
        /// Define text field.
        /// </summary>
        /// <param name="position">Position of text field</param>
        /// <param name="size">Size of text field</param>
        public TextField(int position, int size)
        {

            Position = position;
            Size = size;
            Padding = ' ';
            Alignment = TextAlignment.Left;

        }

        /// <summary>
        /// Define text field.
        /// </summary>
        /// <param name="position">Position of text field</param>
        /// <param name="size">Size of text field</param>
        /// <param name="padding">Character used to pad text field</param>
        public TextField(int position, int size, char padding) : this(position, size)
        {

            Padding = padding;

        }

        /// <summary>
        /// Return type of member
        /// </summary>
        /// <returns>type of member</returns>
        internal Type GetMemberType()
        {

            if (Member is FieldInfo)
            {
                return ((FieldInfo)Member).FieldType;
            }
            else if (Member is PropertyInfo)
            {
                return ((PropertyInfo)Member).PropertyType;
            }
            else
            {
                throw new Exception();
            }

        }

    }

}
