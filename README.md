# Gnome.Net

A marshalled modern GTK stack set of libraries to use the GNOME system through modern dotnet.

The supported libraries are:

- [Gnome.Net.Common](#gnomenetcommon)
- [Gnome.Net.GLib](#gnomenetglib)
- [QuickTests](#quicktests)

## List of Projects

### Gnome.Net.Common

A common library for all Gnome.Net projects to include common utilities and tools.

Currently, this library does:

- Setup the library name depending on OS and native library.
- Create a DllImporter function to share amongst all projects.

### Gnome.Net.GLib

GLib is a general-purpose, portable utility library, which provides many useful data types, macros, type conversions,
string utilities, file utilities, a mainloop abstraction, and so on.

- Version: 2.76
- Authors: GTK Development Team
- License: LGPL-2.1-or-later
- [Website](https://www.gtk.org)
- [Source](https://gitlab.gnome.org/GNOME/glib/)

#### Related Libraries

- Gnome.Net.GModule
- Gnome.Net.GObject
- Gnome.Net.GIo

#### Native Dependencies

- Windows
    - libglib-2.0-0.dll
- OSX
    - libglib-2.0.0.dylib
- Linux and FreeBSD
    - libglib-2.0.so.0

### QuickTests

A quick tests project that is empty. This project WILL BE REMOVED once all the libraries are implemented in their most
basic form and will always be empty and without usable code.

## Contributing

If you wish to contribute, you must follow the existing style. To achieve it, respect the
existing [Editor Configuration](.editorconfig) configuration and use CSharpier (dotnet-csharpier) to format your files.

Ensure each class has its imports with the same name of the class followed by "Imports", i.e.: AsyncQueue ->
AsyncQueueImports.

Respect the existing [Gnome.Net.Common](#gnomenetcommon) tooling and make use of it, don't remake its functionality
somewhere else!

Each GNOME related library must have their own project and link to dependencies accordingly.

For every `LibraryImport` attribute, there MUST be a `UnmanagedCallConventions` attribute that is
exactly: `[UnmanagedCallConventions = new [] { typeof(CallConvCdecl) }]`.

Make use of the existing Microsoft custom marshaller classes first, create custom marshaller classes as a backup for
when you cannot use the existing Microsoft ones.

No `DllImport` attributes are allowed, this project makes heavy use of P/Invoke code marshalling instead.

## License

The MIT license is in use in this project. See the [license file](LICENSE.md) for more information.

## Contact Information

Victor Matia <vmatir@gmail.com>.
