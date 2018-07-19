# FixedWidth

[![Build status](https://ci.appveyor.com/api/projects/status/00s0wpj80kb30bnt?svg=true)](https://ci.appveyor.com/project/mscribellito/fixedwidth)
[![Software License](https://img.shields.io/badge/license-MIT-brightgreen.svg?style=flat-square)](LICENSE)

Released under a MIT license - https://opensource.org/licenses/MIT

[NuGet Package](https://www.nuget.org/packages/Mscribel.FixedWidth/)

FixedWidth is an easy to use .NET library for working with fixed width (flat formatted) text files. By applying attributes to your code, you can setup the position and format for your data when deserializing/serializing to and from fixed width files.

## Features
* Serialize an object into a string and deserialize a string into an object
* Supports most built-in types
* Supports custom serialization and deserialization via `ITextFormatter`
* Specify field padding and text alignment
* Handles zero and one based indexes

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

var serializer = new TextSerializer<Account>();

var deserialized = serializer.Deserialize("C0001Acme Corp 12.340");

var serialized = serializer.Serialize(new Account()
{
	Type = 'C',
	Number = 1,
	Name = "Acme Corp",
	Balance = 12.34,
	Locked = false
});
```
