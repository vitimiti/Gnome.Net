// This file is part of the Gnome.Net project and is under the MIT license.
// See LICENSE.md for more information.

using Gnome.Net.GLib.Imports;

namespace Gnome.Net.GLib.ErrorDomains;

/// <summary>A static structure to get the error quark values of the different errors.</summary>
public struct ErrorQuarkValues
{
    /// <summary>The <see cref="BookmarkFileErrorQuark" /> value.</summary>
    /// <value>A <see cref="uint" /> with the quark value.</value>
    public static uint BookmarkFileError => LibraryApi.BookmarkFileErrorQuark();

    /// <summary>The <see cref="FileErrorQuark" /> value.</summary>
    /// <value>A <see cref="uint" /> with the quark value.</value>
    public static uint FileError => LibraryApi.FileErrorQuark();

    /// <summary>The <see cref="ShellError" /> value.</summary>
    /// <value>A <see cref="uint" /> with the quark value.</value>
    public static uint ShellError => LibraryApi.ShellErrorQuark();
}
