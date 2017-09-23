namespace FixedWidth
{

    public interface ITextFormatter
    {

        string Serialize(object value);

        object Deserialize(string value);

    }

}
