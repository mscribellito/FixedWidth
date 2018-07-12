using System;

namespace FixedWidth
{

    /// <summary>
    /// The text serializable attribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class,
        AllowMultiple = false)]
    public class TextSerializable : Attribute
    {
    }

}
