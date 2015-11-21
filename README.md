# BerTlv.NET

[![Build status](https://ci.appveyor.com/api/projects/status/0k3ng0ykfuoysxwi?svg=true)](https://ci.appveyor.com/project/kspearrin/bertlv-net)

BerTlv.NET is a library that makes parsing TLV data easy. It is especially
useful for parsing things like EMV credit card transaction data.

## Use

Using BerTlv.NET is very simple. Two static methods are exposed to you in the
`Tlv` class (one for hex and one for a byte array). Example:

```csharp
var tlvs = BerTlv.Tlv.ParseTlv("6F1A840E315041592E5359532E4444463031A5088801025F2D02656E");

// Use the tlvs collection now.
```

## Changelog

### 1.0.0

Initial release.
