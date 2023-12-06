// This file is part of the Gnome.Net project and is under the MIT license.
// See LICENSE.md for more information.

using Gnome.Net.GLib.Errors;

namespace Gnome.Net.GLib.ErrorDomains;

/// <summary>Error codes returned by shell functions.</summary>
public class GShellErrorQuark : IErrorQuark
{
    /// <inheritdoc cref="IErrorQuark.Domain" />
    public uint Domain { get; internal init; }

    /// <summary>The error code.</summary>
    /// <value>A <see cref="GShellError" /> with the error code.</value>
    public GShellError Code { get; internal init; }

    /// <inheritdoc cref="IErrorQuark.Message" />
    public string? Message { get; internal init; }
}
