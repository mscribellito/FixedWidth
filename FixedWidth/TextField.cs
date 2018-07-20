using System;
using System.Linq;
using System.Reflection;

namespace Mscribel.FixedWidth
{

    /// <summary>
    /// The text field attribute. Indicates that a field or property is serializable.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property,
        AllowMultiple = false,
        Inherited = true)]
    public class TextField : Attribute
    {

        /// <summary>
        /// Name of text field.
        /// </summary>
        internal string Name { get; set; }

        /// <summary>
        /// Position of text field.
        /// </summary>
        private readonly int _position;
        public int Position
        {
            get { return _position; }
        }

        /// <summary>
        /// Size of text field.
        /// </summary>
        private readonly int _size;
        public int Size
        {
            get { return _size; }
        }

        /// <summary>
        /// Character used to pad text field.
        /// </summary>
        public char Padding { get; set; }

        /// <summary>
        /// Text alignment of field.
        /// </summary>
        public TextAlignment Alignment { get; set; }

        private Type _formatterType;

        /// <summary>
        /// Type to be utilized for deserialze/serialize.
        /// </summary>
        public Type FormatterType
        {
            get
            {
                return _formatterType;
            }
            set
            {
                _formatterType = value;
                Formatter = (ITextFormatter)_formatterType.Assembly.CreateInstance(_formatterType.FullName);
            }
        }

        internal MemberInfo Member { get; set; }

        internal ITextFormatter Formatter { get; private set; }

        /// <summary>
        /// Define text field.
        /// </summary>
        /// <param name="position">Position of text field</param>
        /// <param name="size">Size of text field</param>
        public TextField(uint position, uint size)
        {

            _position = (int)position;
            _size = (int)size;
            Padding = ' ';
            Alignment = TextAlignment.Left;

        }

        /// <summary>
        /// Define text field.
        /// </summary>
        /// <param name="position">Position of text field</param>
        /// <param name="size">Size of text field</param>
        /// <param name="padding">Character used to pad text field</param>
        public TextField(uint position, uint size, char padding) : this(position, size)
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
