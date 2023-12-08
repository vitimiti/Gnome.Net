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
