namespace FixedWidth
{

    /// <summary>
    /// Interface for deserializing and serializing.
    /// </summary>
    public interface ITextFormatter
    {

        /// <summary>
        /// Deserialize a string.
        /// </summary>
        /// <param name="value">string to deserialize</param>
        /// <returns>deserialized object</returns>
        object Deserialize(string value);

        /// <summary>
        /// Serialize an object.
        /// </summary>
        /// <param name="value">object to serialize</param>
        /// <returns>serialized string</returns>
        string Serialize(object value);

    }

}
