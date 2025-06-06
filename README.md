# BonyadCode.Mapper.AspNetCore

A lightweight and flexible object-to-object mapping utility for .NET. Supports automatic property mapping between classes, structs, and records using reflection. Ideal for DTO transformations, data shaping, and lightweight model copying.

---

## ✨ Features

* **Universal Mapping**: Works with classes, structs, and records.
* **Zero Configuration**: Automatically maps matching property names.
* **Safe Type Conversion**: Converts between compatible property types (e.g., `int` to `double`).
* **Minimal Footprint**: One simple method, no dependencies or profiles.
* **Extension-Based**: Clean syntax via `source.MapTo<T>()`.

---

## 📦 Installation

```bash
dotnet add package BonyadCode.Mapper.AspNetCore
```

---

## 🚀 Quick Examples

### ✅ Map Between Records

```csharp
var source = new PersonDto { Name = "Ali", Age = 30 };
var result = source.MapTo<PersonEntity>();
```

### ✅ Map Between Structs

```csharp
var pointDto = new PointDto { X = 5, Y = 10 };
var result = pointDto.MapTo<Point>();
```

### ✅ Map Between Anonymous and Concrete Types

```csharp
var anon = new { Username = "user123", Email = "user@example.com" };
var userDto = anon.MapTo<UserDto>();
```

---

## 📘 How It Works

* Maps properties by **name match** (case-sensitive).
* Supports type conversion via `Convert.ChangeType` for assignable values.
* Ignores unreadable or unwritable properties.
* Throws meaningful errors if instantiation or mapping fails.

---

## 🧪 Sample Models

```csharp
record PersonDto(string Name, int Age);
record PersonEntity { public string Name { get; set; } public int Age { get; set; } }

struct PointDto { public int X { get; set; } public int Y { get; set; } }
struct Point { public int X { get; set; } public int Y { get; set; } }

class UserDto { public string Username { get; set; } public string Email { get; set; } }
```

---

## ⚙️ Notes & Limitations

* Source and target properties must have the **same name**.
* Properties must be **public instance properties**.
* No nested object or collection support (yet).
* All target types must have a **public parameterless constructor** or be value types.

---

## 🔧 Internals

* Uses `Activator.CreateInstance<T>()` to support both value types and reference types.
* Uses cached reflection lookups for performance in future versions (planned).
* Throws descriptive exceptions when instantiation or mapping fails.

---

## 🤝 Contributing

Contributions, ideas, and pull requests are welcome! [GitHub →](https://github.com/bonyadcode/BonyadCode.Mapper.AspNetCore)

## 📄 License

Apache 2.0 — see the [LICENSE](LICENSE) file.

## 📦 Links

* [NuGet](https://www.nuget.org/packages/BonyadCode.Mapper.AspNetCore)
* [GitHub](https://github.com/bonyadcode/BonyadCode.Mapper.AspNetCore)

Usage Conditions:
- This program must not be used for any military or governmental purposes without the owner's consent.
- This program must not be used for any inhumane purposes.
- This program must not be used for any illegal or haram activities.