// This file is part of the Gnome.Net project and is under the MIT license.
// See LICENSE.md for more information.

namespace Gnome.Net.GLib.ErrorDomains;

/// <summary>An interface to set the error quarks.</summary>
public interface IErrorQuark
{
    /// <summary>Gets the error domain.</summary>
    /// <remarks>A <see cref="uint" /> with the error domain.</remarks>
    public uint Domain { get; }

    /// <summary>Gets the error message.</summary>
    /// <value>A <see cref="string" /> with the error message, or <see langword="null" /></value>
    public string? Message { get; }
}
