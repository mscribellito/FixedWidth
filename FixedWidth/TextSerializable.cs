using System;

namespace FixedWidth
{

    /// <summary>
    /// The text serializable attribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct,
        AllowMultiple = false)]
    public class TextSerializable : Attribute
    {
    }

}
