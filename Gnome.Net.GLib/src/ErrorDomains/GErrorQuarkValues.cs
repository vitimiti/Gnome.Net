// This file is part of the Gnome.Net project and is under the MIT license.
// See LICENSE.md for more information.

using Gnome.Net.GLib.Imports;

namespace Gnome.Net.GLib.ErrorDomains;

/// <summary>A static structure to get the error quark values of the different errors.</summary>
public struct GErrorQuarkValues
{
    /// <summary>The <see cref="GBookmarkFileErrorQuark" /> value.</summary>
    /// <value>A <see cref="uint" /> with the quark value.</value>
    public static uint GBookmarkFileError => GLibApi.GBookmarkFileErrorQuark();

    /// <summary>The <see cref="GShellError" /> value.</summary>
    /// <value>A <see cref="uint" /> with the quark value.</value>
    public static uint GShellError => GLibApi.GShellErrorQuark();
}
