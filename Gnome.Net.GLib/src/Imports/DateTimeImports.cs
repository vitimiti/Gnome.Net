// This file is part of the Gnome.Net project and is under the MIT license.
// See LICENSE.md for more information.

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

using Gnome.Net.GLib.CustomMarshalling;
using Gnome.Net.GLib.LibraryUtilities;

namespace Gnome.Net.GLib.Imports;

internal static partial class LibraryApi
{
    [LibraryImport(LibraryName.GLib, EntryPoint = "g_date_time_add")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint DateTimeAdd(DateTime dateTime, long timeSpan);

    [LibraryImport(LibraryName.GLib, EntryPoint = "g_date_time_add_days")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint DateTimeAddDays(DateTime dateTime, int days);

    [LibraryImport(LibraryName.GLib, EntryPoint = "g_date_time_add_full")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint DateTimeAddFull(
        DateTime dateTime,
        int years,
        int months,
        int days,
        int hours,
        int minutes,
        double seconds
    );

    [LibraryImport(LibraryName.GLib, EntryPoint = "g_date_time_add_hours")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint DateTimeAddHours(DateTime dateTime, int hours);

    [LibraryImport(LibraryName.GLib, EntryPoint = "g_date_time_add_minutes")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint DateTimeAddMinutes(DateTime dateTime, int minutes);

    [LibraryImport(LibraryName.GLib, EntryPoint = "g_date_time_add_months")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint DateTimeAddMonths(DateTime dateTime, int months);

    [LibraryImport(LibraryName.GLib, EntryPoint = "g_date_time_add_seconds")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint DateTimeAddSeconds(DateTime dateTime, int seconds);

    [LibraryImport(LibraryName.GLib, EntryPoint = "g_date_time_add_weeks")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint DateTimeAddWeeks(DateTime dateTime, int weeks);

    [LibraryImport(LibraryName.GLib, EntryPoint = "g_date_time_add_years")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint DateTimeAddYears(DateTime dateTime, int years);

    [LibraryImport(LibraryName.GLib, EntryPoint = "g_date_time_compare")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial int DateTimeCompare(DateTime left, DateTime right);

    [LibraryImport(LibraryName.GLib, EntryPoint = "g_date_time_difference")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial long DateTimeDifference(DateTime begin, DateTime end);

    [LibraryImport(LibraryName.GLib, EntryPoint = "g_date_time_equal")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static partial bool DateTimeEqual(DateTime left, DateTime right);

    [LibraryImport(
        LibraryName.GLib,
        EntryPoint = "g_date_time_format",
        StringMarshalling = StringMarshalling.Utf8
    )]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial string? DateTimeFormat(DateTime dateTime, string format);

    [LibraryImport(
        LibraryName.GLib,
        EntryPoint = "g_date_time_format_iso8601",
        StringMarshalling = StringMarshalling.Utf8
    )]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial string? DateTimeFormatIso8601(DateTime dateTime);

    [LibraryImport(LibraryName.GLib, EntryPoint = "g_date_time_get_day_of_month")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial int DateTimeGetDayOfMonth(DateTime dateTime);

    [LibraryImport(LibraryName.GLib, EntryPoint = "g_date_time_get_day_of_week")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial int DateTimeGetDayOfWeek(DateTime dateTime);

    [LibraryImport(LibraryName.GLib, EntryPoint = "g_date_time_get_day_of_year")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial int DateTimeGetDayOfYear(DateTime dateTime);

    [LibraryImport(LibraryName.GLib, EntryPoint = "g_date_time_get_hour")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial int DateTimeGetHour(DateTime dateTime);

    [LibraryImport(LibraryName.GLib, EntryPoint = "g_date_time_get_microsecond")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial int DateTimeGetMicrosecond(DateTime dateTime);

    [LibraryImport(LibraryName.GLib, EntryPoint = "g_date_time_get_minute")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial int DateTimeGetMinute(DateTime dateTime);

    [LibraryImport(LibraryName.GLib, EntryPoint = "g_date_time_get_month")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial int DateTimeGetMonth(DateTime dateTime);

    [LibraryImport(LibraryName.GLib, EntryPoint = "g_date_time_get_second")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial int DateTimeGetSecond(DateTime dateTime);

    [LibraryImport(LibraryName.GLib, EntryPoint = "g_date_time_get_seconds")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial double DateTimeGetSeconds(DateTime dateTime);

    [LibraryImport(LibraryName.GLib, EntryPoint = "g_date_time_get_timezone")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint DateTimeGetTimeZone(DateTime dateTime);

    [LibraryImport(
        LibraryName.GLib,
        EntryPoint = "g_date_time_get_timezone_abbreviation",
        StringMarshalling = StringMarshalling.Custom,
        StringMarshallingCustomType = typeof(StringRequiresStringDuplicateMarshaller)
    )]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial string? DateTimeGetTimeZoneAbbreviation(DateTime dateTime);

    [LibraryImport(LibraryName.GLib, EntryPoint = "g_date_time_get_utc_offset")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial long DateTimeGetUtcOffset(DateTime dateTime);

    [LibraryImport(LibraryName.GLib, EntryPoint = "g_date_time_get_week_numbering_year")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial int DateTimeGetWeekNumberingYear(DateTime dateTime);

    [LibraryImport(LibraryName.GLib, EntryPoint = "g_date_time_get_week_of_year")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial int DateTimeGetWeekOfYear(DateTime dateTime);

    [LibraryImport(LibraryName.GLib, EntryPoint = "g_date_time_get_year")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial int DateTimeGetYear(DateTime dateTime);

    [LibraryImport(LibraryName.GLib, EntryPoint = "g_date_time_get_ymd")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void DateTimeGetYearMonthDay(
        DateTime dateTime,
        out int year,
        out int month,
        out int day
    );

    [LibraryImport(LibraryName.GLib, EntryPoint = "g_date_time_hash")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial uint DateTimeHash(DateTime dateTime);

    [LibraryImport(LibraryName.GLib, EntryPoint = "g_date_time_is_daylight_savings")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static partial bool DateTimeIsDaylightSavings(DateTime dateTime);

    [LibraryImport(LibraryName.GLib, EntryPoint = "g_date_time_new")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint DateTimeNew(
        TimeZone tz,
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
    public static partial nint DateTimeNewFromIso8601(string? text, TimeZone? defaultTz);

    [LibraryImport(LibraryName.GLib, EntryPoint = "g_date_time_new_from_unix_local")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint DateTimeNewFromUnixLocal(long time);

    [LibraryImport(LibraryName.GLib, EntryPoint = "g_date_time_new_from_unix_utc")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint DateTimeNewFromUnixUtc(long time);

    [LibraryImport(LibraryName.GLib, EntryPoint = "g_date_time_new_local")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint DateTimeNewLocal(
        int year,
        int month,
        int day,
        int hour,
        int minute,
        double seconds
    );

    [LibraryImport(LibraryName.GLib, EntryPoint = "g_date_time_new_now")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint DateTimeNewNow(TimeZone tz);

    [LibraryImport(LibraryName.GLib, EntryPoint = "g_date_time_new_now_local")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint DateTimeNewNowLocal();

    [LibraryImport(LibraryName.GLib, EntryPoint = "g_date_time_new_now_utc")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint DateTimeNewNowUtc();

    [LibraryImport(LibraryName.GLib, EntryPoint = "g_date_time_new_utc")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint DateTimeNewUtc(
        int year,
        int month,
        int day,
        int hour,
        int minute,
        double seconds
    );

    [LibraryImport(LibraryName.GLib, EntryPoint = "g_date_time_to_local")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint DateTimeToLocal(DateTime dateTime);

    [LibraryImport(LibraryName.GLib, EntryPoint = "g_date_time_to_timezone")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint DateTimeToTimeZone(DateTime dateTime, TimeZone tz);

    [LibraryImport(LibraryName.GLib, EntryPoint = "g_date_time_to_unix")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial long DateTimeToUnix(DateTime dateTime);

    [LibraryImport(LibraryName.GLib, EntryPoint = "g_date_time_to_utc")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint DateTimeToUtc(DateTime dateTime);

    [LibraryImport(LibraryName.GLib, EntryPoint = "g_date_time_unref")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void DateTimeUnref(nint dateTime);
}
