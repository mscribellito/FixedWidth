# FixedWidth
FixedWidth is an easy to use .NET library for working with fixed width (flat formatted) text files. By applying attributes to your code, you can setup the position and format for your data when deserializing/serializing to and from fixed width files.

FixedWidth handles the following built-in types:
* string
* char
* int
* double
* bool

You can also write and plugin your own formatters for custom data types by implementing the `ITextFormatter` interface.

## Features
* Serialize an object into a string and deserialize a string into an object
* Supports most built-in types
* Supports custom serialization and deserialization via `ITextFormatter`
* Specify field padding and text alignment

## Getting Started
To start using FixedWidth, you only have to apply attributes to your class and members (fields & properties). An example can be found below in the Usage section.

# Usage

## Define Format
Add `TextSerializable` attribute to class and `TextField` attribute to each field/property you want to serialize.
```csharp
[TextSerializable]
public class Account
{
	[TextField(1, 1)]
	public char Type { get; set; }
	[TextField(2, 4, '0',
		Alignment = TextAlignment.Right)]
	public int Number { get; set; }
	[TextField(6, 10)]
	public string Name { get; set; }
	[TextField(16, 5)]
	public double Balance { get; set; }
	[TextField(21, 1,
		FormatterType = typeof(BooleanFormatter))]
	public bool Locked { get; set; }
}
```

## Create Serializer
Create new `TextSerializer` and use class as generic type.
```csharp
var serializer = new TextSerializer<Account>();
```

## Deserialize String
Pass `Deserialize()` the serialized string.
```csharp
var deserialized = serializer.Deserialize("C0001Acme Corp 12.340");
```
*Object: {Type = "C", Number = "1", Name = "Acme Corp", Balance = "12.34", Locked = "False"}*

## Serialize Object
Pass `Serialize()` the deserialized object.
```csharp
var serialized = serializer.Serialize(new Account()
{
	Type = 'C',
	Number = 1,
	Name = "Acme Corp",
	Balance = 12.34,
	Locked = false
});
```
*String: "C0001Acme Corp 12.340"*

# Frequently Asked Questions

## Can FixedWidth help me parse large text files?

As of now, no. The API simply maps one line to an object or vice versa. However, you could loop through a large file and use the `TextSerializer` object to deserializing/serializing.

## How do I create a custom formatter?
By implementing the `ITextFormatter` interface. Example below:

```csharp
class DateFormatter : ITextFormatter
{

	private const string Format = "yyyyMMdd";

	public object Deserialize(string value)
	{
		return DateTime.ParseExact(value, Format, CultureInfo.InvariantCulture);
	}

	public string Serialize(object value)
	{
		throw new System.NotImplementedException();
	}

}
```

# License
Released under a MIT license - https://opensource.org/licenses/MIT
