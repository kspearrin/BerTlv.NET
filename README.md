# BerTlv.NET

[![Build status](https://ci.appveyor.com/api/projects/status/0k3ng0ykfuoysxwi?svg=true)](https://ci.appveyor.com/project/kspearrin/bertlv-net)

BerTlv.NET is a library that makes parsing TLV data easy. It is especially
useful for parsing things like EMV credit card transaction data.

## Get It

You can install BerTlv.NET from [nuget](https://www.nuget.org/packages/BerTlv.NET/):

    PM> Install-Package BerTlv.NET

Or download and build the source from here and reference the `BerTlv.dll`.

## Use It

Using BerTlv.NET is very simple. Two static methods are exposed to you in the
`Tlv` class (one for hex and one for a byte array). Example:

First add the using statement:

```csharp
using BerTlv;
```

then:

```csharp
ICollection<Tlv> tlvs = Tlv.ParseTlv("6F1A840E315041592E5359532E4444463031A5088801025F2D02656E");

// Use the tlvs collection now.
```

## Changelog

### 2.0.3

Fixes issue with parsing of null bytes (0x00 and 0xFF) before, between, or after a valid tag

### 2.0.2

Add `netstandard2.0` support.

### 2.0.1

Add back `net45` support.

### 2.0.0

Change project to use `netstandard1.1`.

### 1.0.1

Renamed `Tlv.DataHex` property to `Tlv.HexData` to be consistent with the naming convention of the rest of the `Tlv.Hex*` properties.

### 1.0.0

Initial release.
