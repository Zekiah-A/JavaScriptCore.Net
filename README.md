# JavaScriptCore.Net
### About:
Work-In-Progress, low-level C# bindings for the [JavaScriptCore](https://github.com/WebKit/WebKit/tree/main/Source/JavaScriptCore/API) engine.
- Aims to provide an almost 1:1 experience with the original library, providing very little abstractions or
  marshalling (usage of unsafe code is recommended).
- This  is still alpha software. Things might break or change, and production usage 
  is not recommended.
- Help would be appreciated!

### Usage:
- Reference this library in your project and
- API should be highly similar to the JavaScriptCore C interface, therefore you can look to the
  [official documentation](https://developer.apple.com/documentation/javascriptcore) for guidance with usage.
- Keep in mind that many methods have been separated into appropriate namespaces, so methods such as
  **(c)** `JSContextGroupCreate`, will be accessible as **(c#)** `JSContextGroup.Create` in this library,
  and vice versa.

This project is maintained under the [MIT](https://opensource.org/license/mit) license.