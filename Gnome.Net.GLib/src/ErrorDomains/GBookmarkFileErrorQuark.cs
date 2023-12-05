// This file is part of the Gnome.Net project and is under the MIT license.
// See LICENSE.md for more information.

using Gnome.Net.GLib.Errors;

namespace Gnome.Net.GLib.ErrorDomains;

/// <summary>Error codes returned by bookmark file parsing.</summary>
public struct GBookmarkFileErrorQuark : IErrorQuark
{
    /// <summary>The error domain.</summary>
    /// <value>A <see cref="uint" /> with the error domain.</value>
    public uint Domain { get; internal init; }

    /// <summary>The error code.</summary>
    /// <value>A <see cref="GBookmarkFileError" /> with the error code.</value>
    public GBookmarkFileError Code { get; internal init; }

    /// <summary>The error message.</summary>
    /// <value>A <see cref="string" /> with the error message, or <see langword="null" />.</value>
    public string? Message { get; internal init; }
}
