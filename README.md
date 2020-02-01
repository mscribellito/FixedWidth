# FixedWidth 

[![Build status](https://ci.appveyor.com/api/projects/status/00s0wpj80kb30bnt?svg=true)](https://ci.appveyor.com/project/mscribellito/fixedwidth)
[![Software License](https://img.shields.io/badge/license-MIT-brightgreen.svg?style=flat-square)](LICENSE)

Released under a MIT license - https://opensource.org/licenses/MIT

[NuGet Package](https://www.nuget.org/packages/Mscribel.FixedWidth/)

FixedWidth is an easy to use .NET library for working with fixed width (flat formatted) text files. By applying attributes to your code, you can setup the position and format for your data when deserializing/serializing to and from fixed width files.

## Documentation
Available on [Wiki](https://github.com/mscribellito/FixedWidth/wiki).

## Features
* Serialize an object into a string and deserialize a string into an object
* Supports most built-in types
	* bool (using `BooleanFormatter`)
	* char
	* decimal
	* double
	* float
	* int/uint
	* long/ulong
	* short/ushort
	* string
* Supports custom serialization and deserialization via `ITextFormatter`
* Specify field padding and text alignment
* Handles zero and one based indexes

## Example

### Apply attributes to class members

```csharp
[TextSerializable]
public class Dog
{

    [TextField(1, 10)]
    public string Name { get; set; }

    [TextField(11, 1)]
    public char Sex { get; set; }

    [TextField(12, 3,
        Padding = '0',
        Alignment = TextAlignment.Right)]
    public int Weight { get; set; }

    [TextField(15, 8,
        FormatterType = typeof(DateFormatter))]
    public DateTime BirthDate { get; set; }

    [TextField(23, 1,
        FormatterType = typeof(BooleanFormatter))]
    public bool SpayedNeutered { get; set; }

}
```

### Create `TextSerializer` instance

```csharp
var serializer = new TextSerializer<Dog>();
```

### Deserialize string into object

```csharp
var deserialized = serializer.Deserialize("Wally     M065201011161");
```

```
BirthDate [DateTime]:{11/16/2010 12:00:00 AM}
Name [string]:"Wally"
Sex [char]:77 'M'
SpayedNeutered [bool]:true
Weight [int]:65
```

### Serialize object into string

```csharp
var serialized = serializer.Serialize(deserialized);
```

```
"Wally     M065201011161"
```
