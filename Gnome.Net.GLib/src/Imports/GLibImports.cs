// This file is part of the Gnome.Net project and is under the MIT license.
// See LICENSE.md for more information.

using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

using Gnome.Net.GLib.LibraryUtilities;

namespace Gnome.Net.GLib.Imports;

internal static partial class GLibApi
{
    static GLibApi()
    {
        NativeLibrary.SetDllImportResolver(
            Assembly.GetExecutingAssembly(),
            LibraryName.DllImportResolver
        );
    }

    [LibraryImport(LibraryName.GLib, EntryPoint = "g_free")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void GFree(nint memory);

    [LibraryImport(
        LibraryName.GLib,
        EntryPoint = "g_get_application_name",
        StringMarshalling = StringMarshalling.Utf8
    )]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint GGetApplicationName();

    [LibraryImport(
        LibraryName.GLib,
        EntryPoint = "g_get_prgname",
        StringMarshalling = StringMarshalling.Utf8
    )]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint GGetProgramName();

    [LibraryImport(
        LibraryName.GLib,
        EntryPoint = "g_set_application_name",
        StringMarshalling = StringMarshalling.Utf8
    )]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void GSetApplicationName(string applicationName);

    [LibraryImport(
        LibraryName.GLib,
        EntryPoint = "g_set_prgname",
        StringMarshalling = StringMarshalling.Utf8
    )]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void GSetProgramName(string applicationName);

    [LibraryImport(LibraryName.GLib, EntryPoint = "g_shell_error_quark")]
    public static partial uint GShellErrorQuark();

    [LibraryImport(
        LibraryName.GLib,
        EntryPoint = "g_strdup",
        StringMarshalling = StringMarshalling.Utf8
    )]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial string? GStringDuplicate(nint strPtr);
}
