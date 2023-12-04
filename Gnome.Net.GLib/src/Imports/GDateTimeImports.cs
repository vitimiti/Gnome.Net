// This file is part of the Gnome.Net project and is under the MIT license.
// See LICENSE.md for more information.

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

using Gnome.Net.GLib.LibraryUtilities;

namespace Gnome.Net.GLib.Imports;

internal static partial class GLibApi
{
    [LibraryImport(LibraryName.GLib, EntryPoint = "g_date_time_add")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint GDateTimeAdd(GDateTime dateTime, long timeSpan);

    [LibraryImport(LibraryName.GLib, EntryPoint = "g_date_time_add_days")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint GDateTimeAddDays(GDateTime dateTime, int days);

    [LibraryImport(LibraryName.GLib, EntryPoint = "g_date_time_add_full")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint GDateTimeAddFull(
        GDateTime dateTime,
        int years,
        int months,
        int days,
        int hours,
        int minutes,
        double seconds
    );

    [LibraryImport(LibraryName.GLib, EntryPoint = "g_date_time_add_hours")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint GDateTimeAddHours(GDateTime dateTime, int hours);

    [LibraryImport(LibraryName.GLib, EntryPoint = "g_date_time_add_minutes")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint GDateTimeAddMinutes(GDateTime dateTime, int minutes);

    [LibraryImport(LibraryName.GLib, EntryPoint = "g_date_time_add_months")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint GDateTimeAddMonths(GDateTime dateTime, int months);

    [LibraryImport(LibraryName.GLib, EntryPoint = "g_date_time_add_seconds")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint GDateTimeAddSeconds(GDateTime dateTime, int seconds);

    [LibraryImport(LibraryName.GLib, EntryPoint = "g_date_time_add_weeks")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint GDateTimeAddWeeks(GDateTime dateTime, int weeks);

    [LibraryImport(LibraryName.GLib, EntryPoint = "g_date_time_add_years")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint GDateTimeAddYears(GDateTime dateTime, int years);

    [LibraryImport(LibraryName.GLib, EntryPoint = "g_date_time_compare")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial int GDateTimeCompare(GDateTime left, GDateTime right);

    [LibraryImport(LibraryName.GLib, EntryPoint = "g_date_time_difference")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial long GDateTimeDifference(GDateTime begin, GDateTime end);

    [LibraryImport(LibraryName.GLib, EntryPoint = "g_date_time_equal")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static partial bool GDateTimeEqual(GDateTime left, GDateTime right);

    [LibraryImport(
        LibraryName.GLib,
        EntryPoint = "g_date_time_format",
        StringMarshalling = StringMarshalling.Utf8
    )]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial string? GDateTimeFormat(GDateTime dateTime, string format);

    [LibraryImport(
        LibraryName.GLib,
        EntryPoint = "g_date_time_format_iso8601",
        StringMarshalling = StringMarshalling.Utf8
    )]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial string? GDateTimeFormatIso8601(GDateTime dateTime);

    [LibraryImport(LibraryName.GLib, EntryPoint = "g_date_time_get_day_of_month")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial int GDateTimeGetDayOfMonth(GDateTime dateTime);

    [LibraryImport(LibraryName.GLib, EntryPoint = "g_date_time_get_day_of_week")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial int GDateTimeGetDayOfWeek(GDateTime dateTime);

    [LibraryImport(LibraryName.GLib, EntryPoint = "g_date_time_get_day_of_year")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial int GDateTimeGetDayOfYear(GDateTime dateTime);

    [LibraryImport(LibraryName.GLib, EntryPoint = "g_date_time_get_hour")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial int GDateTimeGetHour(GDateTime dateTime);

    [LibraryImport(LibraryName.GLib, EntryPoint = "g_date_time_get_microsecond")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial int GDateTimeGetMicrosecond(GDateTime dateTime);

    [LibraryImport(LibraryName.GLib, EntryPoint = "g_date_time_get_minute")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial int GDateTimeGetMinute(GDateTime dateTime);

    [LibraryImport(LibraryName.GLib, EntryPoint = "g_date_time_get_month")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial int GDateTimeGetMonth(GDateTime dateTime);

    [LibraryImport(LibraryName.GLib, EntryPoint = "g_date_time_get_second")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial int GDateTimeGetSecond(GDateTime dateTime);

    [LibraryImport(LibraryName.GLib, EntryPoint = "g_date_time_get_seconds")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial double GDateTimeGetSeconds(GDateTime dateTime);

    [LibraryImport(LibraryName.GLib, EntryPoint = "g_date_time_get_timezone")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint GDateTimeGetTimeZone(GDateTime dateTime);

    [LibraryImport(LibraryName.GLib, EntryPoint = "g_date_time_get_timezone_abbreviation")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint GDateTimeGetTimeZoneAbbreviation(GDateTime dateTime);

    [LibraryImport(LibraryName.GLib, EntryPoint = "g_date_time_get_utc_offset")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial long GDateTimeGetUtcOffset(GDateTime dateTime);

    [LibraryImport(LibraryName.GLib, EntryPoint = "g_date_time_get_week_numbering_year")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial int GDateTimeGetWeekNumberingYear(GDateTime dateTime);

    [LibraryImport(LibraryName.GLib, EntryPoint = "g_date_time_get_week_of_year")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial int GDateTimeGetWeekOfYear(GDateTime dateTime);

    [LibraryImport(LibraryName.GLib, EntryPoint = "g_date_time_get_year")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial int GDateTimeGetYear(GDateTime dateTime);

    [LibraryImport(LibraryName.GLib, EntryPoint = "g_date_time_get_ymd")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void GDateTimeGetYearMonthDay(
        GDateTime dateTime,
        out int year,
        out int month,
        out int day
    );

    [LibraryImport(LibraryName.GLib, EntryPoint = "g_date_time_hash")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial uint GDateTimeHash(GDateTime dateTime);

    [LibraryImport(LibraryName.GLib, EntryPoint = "g_date_time_is_daylight_savings")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static partial bool GDateTimeIsDaylightSavings(GDateTime dateTime);

    [LibraryImport(LibraryName.GLib, EntryPoint = "g_date_time_new")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint GDateTimeNew(
        GTimeZone tz,
        int year,
        int month,
        int day,
        int hour,
        int minute,
        double seconds
    );

    [LibraryImport(
        LibraryName.GLib,
        EntryPoint = "g_date_time_new_from_iso8601",
        StringMarshalling = StringMarshalling.Utf8
    )]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint GDateTimeNewFromIso8601(string? text, GTimeZone? defaultTz);

    [LibraryImport(LibraryName.GLib, EntryPoint = "g_date_time_new_from_unix_local")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint GDateTimeNewFromUnixLocal(long time);

    [LibraryImport(LibraryName.GLib, EntryPoint = "g_date_time_new_from_unix_utc")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint GDateTimeNewFromUnixUtc(long time);

    [LibraryImport(LibraryName.GLib, EntryPoint = "g_date_time_new_local")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint GDateTimeNewLocal(
        int year,
        int month,
        int day,
        int hour,
        int minute,
        double seconds
    );

    [LibraryImport(LibraryName.GLib, EntryPoint = "g_date_time_new_now")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint GDateTimeNewNow(GTimeZone tz);

    [LibraryImport(LibraryName.GLib, EntryPoint = "g_date_time_new_now_local")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint GDateTimeNewNowLocal();

    [LibraryImport(LibraryName.GLib, EntryPoint = "g_date_time_new_now_utc")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint GDateTimeNewNowUtc();

    [LibraryImport(LibraryName.GLib, EntryPoint = "g_date_time_new_utc")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint GDateTimeNewUtc(
        int year,
        int month,
        int day,
        int hour,
        int minute,
        double seconds
    );

    [LibraryImport(LibraryName.GLib, EntryPoint = "g_date_time_to_local")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint GDateTimeToLocal(GDateTime dateTime);

    [LibraryImport(LibraryName.GLib, EntryPoint = "g_date_time_to_timezone")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint GDateTimeToTimeZone(GDateTime dateTime, GTimeZone tz);

    [LibraryImport(LibraryName.GLib, EntryPoint = "g_date_time_to_unix")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial long GDateTimeToUnix(GDateTime dateTime);

    [LibraryImport(LibraryName.GLib, EntryPoint = "g_date_time_to_utc")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint GDateTimeToUtc(GDateTime dateTime);

    [LibraryImport(LibraryName.GLib, EntryPoint = "g_date_time_unref")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void GDateTimeUnref(GDateTime dateTime);
}
