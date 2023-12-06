// This file is part of the Gnome.Net project and is under the MIT license.
// See LICENSE.md for more information.

using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

using Gnome.Net.GLib.CustomMarshalling;
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

    [LibraryImport(LibraryName.GLib, EntryPoint = "g_file_error_quark")]
    public static partial uint GFileErrorQuark();

    [LibraryImport(LibraryName.GLib, EntryPoint = "g_free")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void GFree(nint memory);

    [LibraryImport(
        LibraryName.GLib,
        EntryPoint = "g_get_application_name",
        StringMarshalling = StringMarshalling.Custom,
        StringMarshallingCustomType = typeof(StringRequiresGStringDuplicateMarshaller)
    )]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial string? GGetApplicationName();

    [LibraryImport(
        LibraryName.GLib,
        EntryPoint = "g_get_prgname",
        StringMarshalling = StringMarshalling.Custom,
        StringMarshallingCustomType = typeof(StringRequiresGStringDuplicateMarshaller)
    )]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial string? GGetProgramName();

    [LibraryImport(
        LibraryName.GLib,
        EntryPoint = "g_get_system_data_dirs",
        StringMarshalling = StringMarshalling.Custom,
        StringMarshallingCustomType = typeof(StringRequiresGStringDuplicateMarshaller)
    )]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    [return: MarshalUsing(typeof(NullTerminatedUtf8StringArrayMarshaller))]
    public static partial string[]? GGetSystemDataDirs();

    [LibraryImport(
        LibraryName.GLib,
        EntryPoint = "g_get_user_config_dir",
        StringMarshalling = StringMarshalling.Custom,
        StringMarshallingCustomType = typeof(StringRequiresGStringDuplicateMarshaller)
    )]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial string? GGetUserConfigDir();

    [LibraryImport(
        LibraryName.GLib,
        EntryPoint = "g_get_user_data_dir",
        StringMarshalling = StringMarshalling.Custom,
        StringMarshallingCustomType = typeof(StringRequiresGStringDuplicateMarshaller)
    )]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial string? GGetUserDataDir();

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
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial uint GShellErrorQuark();

    [LibraryImport(
        LibraryName.GLib,
        EntryPoint = "g_strdup",
        StringMarshalling = StringMarshalling.Utf8
    )]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial string? GStringDuplicate(nint strPtr);
}
