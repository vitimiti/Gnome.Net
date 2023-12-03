// This file is part of the Gnome.Net project and is under the MIT license.
// See LICENSE.md for more information.

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

using Gnome.Net.GLib.LibraryUtilities;

namespace Gnome.Net.GLib.Imports;

internal static partial class GLibApi
{
    [LibraryImport(LibraryName.GLib, EntryPoint = "g_time_zone_adjust_time")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial int GTimeZoneAdjustTime(GTimeZone tz, GTimeType type, ref long time);

    [LibraryImport(LibraryName.GLib, EntryPoint = "g_time_zone_find_interval")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial int GTimeZoneFindInterval(GTimeZone tz, GTimeType type, long time);

    [LibraryImport(LibraryName.GLib, EntryPoint = "g_time_zone_get_abbreviation")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint GTimeZoneGetAbbreviation(GTimeZone tz, int interval);

    [LibraryImport(LibraryName.GLib, EntryPoint = "g_time_zone_get_identifier")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint GTimeZoneGetIdentifier(GTimeZone tz);

    [LibraryImport(LibraryName.GLib, EntryPoint = "g_time_zone_get_offset")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial int GTimeZoneGetOffset(GTimeZone tz, int interval);

    [LibraryImport(LibraryName.GLib, EntryPoint = "g_time_zone_is_dst")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static partial bool GTimeZoneIsDst(GTimeZone tz, int interval);

    [LibraryImport(
        LibraryName.GLib,
        EntryPoint = "g_time_zone_new_identifier",
        StringMarshalling = StringMarshalling.Utf8
    )]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint GTimeZoneNewIdentifier(string? identifier);

    [LibraryImport(LibraryName.GLib, EntryPoint = "g_time_zone_new_local")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint GTimeZoneNewLocal();

    [LibraryImport(LibraryName.GLib, EntryPoint = "g_time_zone_new_offset")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint GTimeZoneNewOffset(int seconds);

    [LibraryImport(LibraryName.GLib, EntryPoint = "g_time_zone_new_utc")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint GTimeZoneNewUtc();

    [LibraryImport(LibraryName.GLib, EntryPoint = "g_time_zone_unref")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void GTimeZoneUnref(GTimeZone tz);
}
