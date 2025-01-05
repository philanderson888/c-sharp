# .net 8 / c#12      

## contents

- [.net 8 / c#12](#net-8--c12)
  - [contents](#contents)
  - [introduction](#introduction)
  - [tooling](#tooling)
  - [upgrade to .net 8.0 which has c# version 12](#upgrade-to-net-80-which-has-c-version-12)
    - [collections](#collections)
    - [spread operator](#spread-operator)
    - [constructors](#constructors)
    - [alias](#alias)
    - [lambda](#lambda)
    - [ref readonly](#ref-readonly)
    - [inline arrays](#inline-arrays)
    - [experimental attributes](#experimental-attributes)
    - [interceptor](#interceptor)
  - [code](#code)

## introduction 

the following items have been upgraded for .NET 8

- runtime
- sdk
- c# 12 
- .net aspire to build in the cloud 
- .net maui for app building 
- entity framework core 8
- windows forms
- wpf

key upgrades to microservices

- observability
- resilience
- health checks
- testing
- testing fakes

- extensions
  - resilience
  - telemetry
  - compliance

- integrate blazor with ai llm

- mobile deployment with MAUI

- speed upgrade with PGO profile guided optimisation

- .net aspire builds cloud native distributed apps at github dotnet aspire 

- dotnet images and containers
  - non root user built in
  - publish without docker
  - hardened
  - smaller
  - more productive
  - aot base images
  - compile into native code
  - aot ahead of time compilation

- ai
  - chatbot
  - augmented generation
  - azure open ai
  - azure cognitive search
  - semantic kernel llm

- blazor full stack
  - blazor server
  - blazor web assembly
  - web ui
    - static server render
    - streaming
  - web assembly
    - hot reload

- .net maui
  - one codebase for windows mac android ios

## tooling

install c# dev kit for vs code

## upgrade to .net 8.0 which has c# version 12 

```cs
<Project Sdk="Microsoft.NET.Sdk">
    <PropertyGroup>
        <TargetFramework>net8.0</TargetFramework>
    </PropertyGroup>
</Project>
```


```cs
// Create a list:
List<int> a = [1, 2, 3, 4, 5, 6, 7, 8];

// Create a span
Span<char> b  = ['a', 'b', 'c', 'd', 'e', 'f', 'h', 'i'];

// Use the spread operator to concatenate
int[] array1 = [1, 2, 3];
int[] array2 = [4, 5, 6];
int[] array3 = [7, 8, 9];
int[] fullArray = [..array1, ..array2, ..array3]; // contents is [1, 2, 3, 4, 5, 6, 7, 8, 9]
```

### collections

```cs
// array
int[] x1 = new int[] { 1, 2, 3, 4 };

// empty array
int[] x2 = Array.Empty<int>();

// byte array
WriteByteArray(new[] { (byte)1, (byte)2, (byte)3 });

//list
List<int> x4 = new() { 1, 2, 3, 4 };

// span
Span<DateTime> dates = stackalloc DateTime[] { GetDate(0), GetDate(1) };

// byte span
WriteByteSpan(stackalloc[] { (byte)1, (byte)2, (byte)3 });
```

becomes

```cs
// array
int[] x1 = [1, 2, 3, 4];
// empty array
int[] x2 = [];
// byte array
WriteByteArray([1, 2, 3]);
// list
List<int> x4 = [1, 2, 3, 4];
// span
Span<DateTime> dates = [GetDate(0), GetDate(1)];
// byte span
WriteByteSpan([1, 2, 3]);
```

### spread operator

```cs
int[] numbers1 = [1, 2, 3];
int[] numbers2 = [4, 5, 6];
int[] moreNumbers = [.. numbers1, .. numbers2, 7, 8, 9];
// moreNumbers contains [1, 2, 3, 4, 5, 6, 7, 8, ,9];
```

### constructors

```cs
public class BankAccount(string accountID, string owner)
{
    public string AccountID { get; } = accountID;
    public string Owner { get; } = owner;

    public override string ToString() => $"Account ID: {AccountID}, Owner: {Owner}";
}
```

### alias

```cs
using intArray = int[]; // Array types.
using Point = (int x, int y);  // Tuple type
using unsafe ArrayPtr = int*;  // Pointer type (requires "unsafe")
```

### lambda

```cs
var IncrementBy = (int source, int increment = 1) => source + increment;

Console.WriteLine(IncrementBy(5)); // 6
Console.WriteLine(IncrementBy(5, 2)); // 7
```

### ref readonly

passing parameters by reference

```cs

```

### inline arrays

avoids using unsafe `stackalloc` declaration

work with memory buffers

this is a fixed size array structure based on `structs`

### experimental attributes

adding `System.Diagnostics.CodeAnalysis.ExperimentalAttribute`

includes diagnostic id which can be used for error identification or hiding

### interceptor

can intercept a method call at compile time and replace it with a call to itself 


## code

see code at 

[01-overview](/projects/01-overview/)

