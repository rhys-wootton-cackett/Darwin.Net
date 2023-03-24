# Preamble

To utilize this wrapper, it's essential to have a solid grasp of Object Oriented Programming, the C# programming language, and Task-based Asynchronous Pattern. It is also advised that you have a good understanding of the Darwin system used by National Rail UK, and what content it can deliver depending on what you request.

If you're a beginner to C# or programming in general, using this library may pose a challenge. However, there's a wealth of resources available to help you learn the language. Microsoft offers a comprehensive page dedicated to such resources: https://dotnet.microsoft.com/en-us/learn/csharp.

# Supported Platforms

Darwin.Net targets .NET Standard 2.1, allowing you to utilise it within many different implementations. However, support is only provided to specific platforms.

| Platform/Framework | Supported? | Notes |
|---------------------|------------|-------|
| .NET | ✔️ | .NET Core 3.1 and .NET 5.0 should work.<br>.NET 6.0 LTS and .NET 7.0 are supported. |
| .NET Framework | ⚠️ | .NET Framework 4.6.1 through 4.8 should work fine, though it is recommended that you use the latest or LTS version of .NET instead. |
| Mono | ❌️ | Mono has numerous flaws that can break things without warning. If you need a cross-platform runtime, use .NET. |
| Wine | ❌️ | Wine is a compatibility layer that allows Windows applications to run on Unix-like operating systems. It does not support .NET Standard 2.1 natively, and Darwin.Net does not provide support for it as a platform. |

If you aim to use Darwin.Net on a platform that isn't supported, you will find it harder to get support for any issues that may arise. Therefore, it is recommended that you use the .NET platform wherever you can, and .NET Framework as a fallback legacy option.