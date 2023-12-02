// This file is part of the Gnome.Net project and is under the MIT license.
// See LICENSE.md for more information.

using System.Runtime.InteropServices;

namespace Gnome.Net.GLib.Imports;

internal static partial class GArrayImports
{
    [LibraryImport("GLib", EntryPoint = "g_array_unref")]
    public static partial void GArrayUnref(nint array);
}