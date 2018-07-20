using System;
using System.ComponentModel;

namespace Mscribel.FixedWidth.Examples
{

    class Program
    {

        static void Main(string[] args)
        {

            string str = "Wally     M065201011161";
            Console.WriteLine("Text='" + str + "'");
            Console.WriteLine("-----");

            var serializer = new TextSerializer<Dog>();

            Console.WriteLine("Deserialized:");
            var deserialized = serializer.Deserialize(str);
            foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(deserialized))
            {
                string name = descriptor.Name;
                object value = descriptor.GetValue(deserialized);
                Console.WriteLine("{0}={1}", name, value);
            }

            Console.WriteLine("-----");

            Console.WriteLine("Serialized:");
            var serialized = serializer.Serialize(deserialized);
            Console.WriteLine(serialized);

        }

    }

}
