# FixedWidth
.NET library for deserializing and serializing fixed width files.

## Features
* Serialize an object into a string and deserialize a string into an object
* Supports most built-in types
* Supports custom serialization and deserialization via ITextFormatter
* Specify field padding and text alignment

## Usage

### Define Format
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

### Create Serializer
Create new `TextSerializer` and use class as generic type.
```csharp
var serializer = new TextSerializer<Account>();
```

### Deserialize String
Pass `Deserialize()` the serialized string.
```csharp
var deserialized = serializer.Deserialize("C0001Acme Corp 12.340");
```
*Object: {Type = "C", Number = "1", Name = "Acme Corp", Balance = "12.34", Locked = "False"}*

### Serialize Object
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

## License
Released under a MIT license - https://opensource.org/licenses/MIT
