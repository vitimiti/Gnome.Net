// This file is part of the Gnome.Net project and is under the MIT license.
// See LICENSE.md for more information.

using Gnome.Net.GLib.Errors;

namespace Gnome.Net.GLib.ErrorDomains;

/// <summary>Error codes returned by bookmark file parsing.</summary>
public class GBookmarkFileErrorQuark : IErrorQuark
{
    /// <inheritdoc cref="IErrorQuark.Domain" />
    public uint Domain { get; internal init; }

    /// <summary>Gets the error code.</summary>
    /// <value>A <see cref="GBookmarkFileError" /> with the error code.</value>
    public GBookmarkFileError Code { get; internal init; }

    /// <inheritdoc cref="IErrorQuark.Message" />
    public string? Message { get; internal init; }
}
