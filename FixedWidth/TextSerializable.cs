using System;

namespace Mscribel.FixedWidth
{

    /// <summary>
    /// The text serializable attribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class,
        AllowMultiple = false,
        Inherited = true)]
    public class TextSerializable : Attribute
    {
        
        private bool _zeroBased;

        /// <summary>
        /// Specifies if field positions are zero based or not.
        /// </summary>
        public bool ZeroBased { get => _zeroBased; set => _zeroBased = value; }

    }

}
