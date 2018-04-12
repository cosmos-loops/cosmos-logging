# Cosmos.Encryption <a href="https://www.nuget.org/packages/Cosmos.Encryption/" rel="nofollow"><img src="https://img.shields.io/nuget/v/Cosmos.Encryption.svg?style=flat" alt="NuGet Version" data-canonical-src="https://img.shields.io/nuget/v/Cosmos.Encryption.svg?style=flat" style="max-width:100%;"></a>

[Cosmos.Encryption](https://github.com/CosmosLoops/Cosmos/tree/dev/Encryption) is an inline project of [COSMOS LOOPS PROGRAMME](https://github.com/CosmosLoops).

## Install

From NuGet:
```
Install-Package Cosmos.Encryption
```

## Includes

+ MD4
+ MD5
+ SHA1/SHA256/SHA384/SHA512
+ HMAC
+ AES
+ DES
+ RC4
+ TripleDES
+ DEA
+ RSA
+ CRC16/CRC32
+ BASE64

## Usage

HAMC-SHA1:
```
var signature = HMACSHA1HashingProvider.Signature("image", "alexinea");
```

DES without salt:
```
var s = DESEncryptionProvider.Encrypt("image", "alexinea", "forerunner");
Assert.Equal("fJ2yrnAPaH0=", s);

var o = DESEncryptionProvider.Decrypt(s, "alexinea", "forerunner");
Assert.Equal("image", o);
```

DES with salt:
```
var s = DESEncryptionProvider.Encrypt("image", "alexinea", "forerunner", "123412341234");
Assert.Equal("s4h5u8hA/2Y=", s);

var o = DESEncryptionProvider.Decrypt(s, "alexinea", "forerunner", "123412341234");
Assert.Equal("image", o);
```

DES with salt and autokey
```
 var key = DESEncryptionProvider.CreateKey();
var s = DESEncryptionProvider.Encrypt("image", key.Key, key.IV, "123412341234");
var o = DESEncryptionProvider.Decrypt(s, key.Key, key.IV, "123412341234");
Assert.Equal("image", o);
```

* * *

[MIT](https://mit-license.org/)
