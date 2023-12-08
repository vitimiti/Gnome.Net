// This file is part of the Gnome.Net project and is under the MIT license.
// See LICENSE.md for more information.

namespace Gnome.Net.GLib.Errors;

/// <summary>Error codes returned by bookmark file parsing.</summary>
public enum BookmarkFileError
{
    /// <summary>URI was ill-formed.</summary>
    InvalidUri,

    /// <summary>A requested field was not found.</summary>
    InvalidValue,

    /// <summary>A requested application did not register a bookmark.</summary>
    AppNotRegistered,

    /// <summary>A requested URI was not found.</summary>
    UriNotFound,

    /// <summary>Document was ill formed.</summary>
    Read,

    /// <summary>The text being parsed was in an unknown encoding.</summary>
    UnknownEncoding,

    /// <summary>An error occurred while writing.</summary>
    Write,

    /// <summary>Requested file was not found.</summary>
    FileNotFound
}
