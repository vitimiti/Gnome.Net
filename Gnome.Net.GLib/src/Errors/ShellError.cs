// This file is part of the Gnome.Net project and is under the MIT license.
// See LICENSE.md for more information.

namespace Gnome.Net.GLib.Errors;

/// <summary>Error codes returned by shell functions.</summary>
public enum ShellError
{
    /// <summary>Mismatched or otherwise mangled quoting.</summary>
    BadQuoting,

    /// <summary>String to be parsed was empty.</summary>
    EmptyString,

    /// <summary>Some other error.</summary>
    Failed
}
