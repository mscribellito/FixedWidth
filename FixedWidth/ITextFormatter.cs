namespace FixedWidth
{

    /// <summary>
    /// Interface for deserializing/serializing a custom format.
    /// </summary>
    public interface ITextFormatter
    {

        /// <summary>
        /// Deserialize a string using custom rules.
        /// </summary>
        /// <param name="str">string to deserialize</param>
        /// <returns>deserialized object</returns>
        object Deserialize(string str);

        /// <summary>
        /// Serialize an object using custom rules.
        /// </summary>
        /// <param name="obj">object to serialize</param>
        /// <returns>serialized string</returns>
        string Serialize(object obj);

    }

}
