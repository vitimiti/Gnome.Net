// This file is part of the Gnome.Net project and is under the MIT license.
// See LICENSE.md for more information.

using System.Runtime.InteropServices;

using Gnome.Net.GLib.Utilities;

namespace Gnome.Net.GLib.Imports;

internal static partial class GLibImports
{
    [LibraryImport(LibraryName.Default, EntryPoint = "g_free")]
    public static partial void GFree(nint memory);
}
