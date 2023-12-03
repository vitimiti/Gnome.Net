// This file is part of the Gnome.Net project and is under the MIT license.
// See LICENSE.md for more information.

using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

using Gnome.Net.GLib.CustomMarshalling;
using Gnome.Net.GLib.Utilities;

namespace Gnome.Net.GLib.Imports;

internal static partial class GTimeZoneImports
{
    [LibraryImport(LibraryName.Default, EntryPoint = "g_time_zone_adjust_time")]
    public static partial int GTimeZoneAdjustTime(GTimeZone tz, GTimeType type, ref long time);

    [LibraryImport(LibraryName.Default, EntryPoint = "g_time_zone_find_interval")]
    public static partial int GTimeZoneFindInterval(GTimeZone tz, GTimeType type, long time);

    [LibraryImport(LibraryName.Default, EntryPoint = "g_time_zone_get_abbreviation")]
    public static partial nint GTimeZoneGetAbbreviation(GTimeZone tz, int interval);

    [LibraryImport(LibraryName.Default, EntryPoint = "g_time_zone_get_identifier")]
    public static partial nint GTimeZoneGetIdentifier(GTimeZone tz);

    [LibraryImport(LibraryName.Default, EntryPoint = "g_time_zone_get_offset")]
    public static partial int GTimeZoneGetOffset(GTimeZone tz, int interval);

    [LibraryImport(LibraryName.Default, EntryPoint = "g_time_zone_is_dst")]
    [return: MarshalUsing(typeof(ByteBooleanMarshaller))]
    public static partial bool GTimeZoneIsDst(GTimeZone tz, int interval);

    [LibraryImport(
        LibraryName.Default,
        EntryPoint = "g_time_zone_new_identifier",
        StringMarshalling = StringMarshalling.Utf8
    )]
    public static partial nint GTimeZoneNewIdentifier(string? identifier);

    [LibraryImport(LibraryName.Default, EntryPoint = "g_time_zone_new_local")]
    public static partial nint GTimeZoneNewLocal();

    [LibraryImport(LibraryName.Default, EntryPoint = "g_time_zone_new_offset")]
    public static partial nint GTimeZoneNewOffset(int seconds);

    [LibraryImport(LibraryName.Default, EntryPoint = "g_time_zone_new_utc")]
    public static partial nint GTimeZoneNewUtc();

    [LibraryImport(LibraryName.Default, EntryPoint = "g_time_zone_unref")]
    public static partial void GTimeZoneUnref(GTimeZone tz);
}
