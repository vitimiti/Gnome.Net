// This file is part of the Gnome.Net project and is under the MIT license.
// See LICENSE.md for more information.

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

using Gnome.Net.GLib.CustomMarshalling;
using Gnome.Net.GLib.LibraryUtilities;

namespace Gnome.Net.GLib.Imports;

internal static partial class LibraryApi
{
    [LibraryImport(LibraryName.Glib, EntryPoint = "g_time_zone_adjust_time")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial int TimeZoneAdjustTime(TimeZone tz, TimeType type, ref long time);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_time_zone_find_interval")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial int TimeZoneFindInterval(TimeZone tz, TimeType type, long time);

    [LibraryImport(
        LibraryName.Glib,
        EntryPoint = "g_time_zone_get_abbreviation",
        StringMarshalling = StringMarshalling.Custom,
        StringMarshallingCustomType = typeof(StringRequiresStringDuplicateMarshaller)
    )]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial string? TimeZoneGetAbbreviation(TimeZone tz, int interval);

    [LibraryImport(
        LibraryName.Glib,
        EntryPoint = "g_time_zone_get_identifier",
        StringMarshalling = StringMarshalling.Custom,
        StringMarshallingCustomType = typeof(StringRequiresStringDuplicateMarshaller)
    )]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial string? TimeZoneGetIdentifier(TimeZone tz);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_time_zone_get_offset")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial int TimeZoneGetOffset(TimeZone tz, int interval);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_time_zone_is_dst")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static partial bool TimeZoneIsDst(TimeZone tz, int interval);

    [LibraryImport(
        LibraryName.Glib,
        EntryPoint = "g_time_zone_new_identifier",
        StringMarshalling = StringMarshalling.Utf8
    )]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint TimeZoneNewIdentifier(string? identifier);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_time_zone_new_local")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint TimeZoneNewLocal();

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_time_zone_new_offset")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint TimeZoneNewOffset(int seconds);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_time_zone_new_utc")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint TimeZoneNewUtc();

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_time_zone_unref")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void TimeZoneUnref(nint tz);
}
