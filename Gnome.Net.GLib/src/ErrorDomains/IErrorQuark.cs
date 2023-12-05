// This file is part of the Gnome.Net project and is under the MIT license.
// See LICENSE.md for more information.

namespace Gnome.Net.GLib.ErrorDomains;

public interface IErrorQuark
{
    public uint Domain { get; }
    public string? Message { get; }
}
