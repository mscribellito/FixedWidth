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
    }

}
