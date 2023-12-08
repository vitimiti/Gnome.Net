// This file is part of the Gnome.Net project and is under the MIT license.
// See LICENSE.md for more information.

using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

using Gnome.Net.Common;
using Gnome.Net.Glib.CustomMarshalling;

namespace Gnome.Net.Glib.Imports;

internal static partial class TimeZoneImports
{
    static TimeZoneImports()
    {
        NativeLibrary.SetDllImportResolver(
            Assembly.GetExecutingAssembly(),
            LibraryImportResolver.DllImportResolver
        );
    }

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_time_zone_adjust_time")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial int AdjustTime(TimeZone tz, TimeType type, ref long time);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_time_zone_find_interval")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial int FindInterval(TimeZone tz, TimeType type, long time);

    [LibraryImport(
        LibraryName.Glib,
        EntryPoint = "g_time_zone_get_abbreviation",
        StringMarshalling = StringMarshalling.Custom,
        StringMarshallingCustomType = typeof(StringRequiresStringDuplicateMarshaller)
    )]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial string? GetAbbreviation(TimeZone tz, int interval);

    [LibraryImport(
        LibraryName.Glib,
        EntryPoint = "g_time_zone_get_identifier",
        StringMarshalling = StringMarshalling.Custom,
        StringMarshallingCustomType = typeof(StringRequiresStringDuplicateMarshaller)
    )]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial string? GetIdentifier(TimeZone tz);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_time_zone_get_offset")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial int GetOffset(TimeZone tz, int interval);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_time_zone_is_dst")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static partial bool IsDst(TimeZone tz, int interval);

    [LibraryImport(
        LibraryName.Glib,
        EntryPoint = "g_time_zone_new_identifier",
        StringMarshalling = StringMarshalling.Utf8
    )]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint NewIdentifier(string? identifier);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_time_zone_new_local")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint NewLocal();

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_time_zone_new_offset")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint NewOffset(int seconds);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_time_zone_new_utc")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint NewUtc();

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_time_zone_unref")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void Unref(nint tz);
}
