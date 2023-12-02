// This file is part of the Gnome.Net project and is under the MIT license.
// See LICENSE.md for more information.

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

using Gnome.Net.GLib.Utilities;

namespace Gnome.Net.GLib.Imports;

internal static partial class GArrayImports
{
    [LibraryImport(LibraryName.Default, EntryPoint = "g_array_unref")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void GArrayUnref(nint array);
}
