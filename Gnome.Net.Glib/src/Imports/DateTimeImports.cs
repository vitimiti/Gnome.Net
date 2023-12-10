// This file is part of the Gnome.Net project and is under the MIT license.
// See LICENSE.md for more information.

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

using Gnome.Net.Common;
using Gnome.Net.Glib.CustomMarshalling;

namespace Gnome.Net.Glib.Imports;

internal static partial class ApiImports
{
    [LibraryImport(LibraryName.Glib, EntryPoint = "g_date_time_add")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint DateTimeAdd(nint dateTime, long timeSpan);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_date_time_add_days")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint DateTimeAddDays(nint dateTime, int days);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_date_time_add_full")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint DateTimeAddFull(
        nint dateTime,
        int years,
        int months,
        int days,
        int hours,
        int minutes,
        double seconds
    );

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_date_time_add_hours")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint DateTimeAddHours(nint dateTime, int hours);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_date_time_add_minutes")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint DateTimeAddMinutes(nint dateTime, int minutes);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_date_time_add_months")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint DateTimeAddMonths(nint dateTime, int months);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_date_time_add_seconds")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint DateTimeAddSeconds(nint dateTime, int seconds);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_date_time_add_weeks")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint DateTimeAddWeeks(nint dateTime, int weeks);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_date_time_add_years")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint DateTimeAddYears(nint dateTime, int years);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_date_time_compare")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial int DateTimeCompare(nint left, nint right);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_date_time_difference")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial long DateTimeDifference(nint begin, nint end);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_date_time_equal")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static partial bool DateTimeEqual(nint left, nint right);

    [LibraryImport(
        LibraryName.Glib,
        EntryPoint = "g_date_time_format",
        StringMarshalling = StringMarshalling.Utf8
    )]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial string? DateTimeFormat(nint dateTime, string format);

    [LibraryImport(
        LibraryName.Glib,
        EntryPoint = "g_date_time_format_iso8601",
        StringMarshalling = StringMarshalling.Utf8
    )]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial string? DateTimeFormatIso8601(nint dateTime);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_date_time_get_day_of_month")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial int DateTimeGetDayOfMonth(nint dateTime);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_date_time_get_day_of_week")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial int DateTimeGetDayOfWeek(nint dateTime);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_date_time_get_day_of_year")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial int DateTimeGetDayOfYear(nint dateTime);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_date_time_get_hour")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial int DateTimeGetHour(nint dateTime);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_date_time_get_microsecond")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial int DateTimeGetMicrosecond(nint dateTime);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_date_time_get_minute")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial int DateTimeGetMinute(nint dateTime);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_date_time_get_month")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial int DateTimeGetMonth(nint dateTime);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_date_time_get_second")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial int DateTimeGetSecond(nint dateTime);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_date_time_get_seconds")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial double DateTimeGetSeconds(nint dateTime);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_date_time_get_timezone")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint DateTimeGetTimeZone(nint dateTime);

    [LibraryImport(
        LibraryName.Glib,
        EntryPoint = "g_date_time_get_timezone_abbreviation",
        StringMarshalling = StringMarshalling.Custom,
        StringMarshallingCustomType = typeof(StringRequiresStringDuplicateMarshaller)
    )]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial string? DateTimeGetTimeZoneAbbreviation(nint dateTime);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_date_time_get_utc_offset")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial long DateTimeGetUtcOffset(nint dateTime);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_date_time_get_week_numbering_year")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial int DateTimeGetWeekNumberingYear(nint dateTime);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_date_time_get_week_of_year")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial int DateTimeGetWeekOfYear(nint dateTime);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_date_time_get_year")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial int DateTimeGetYear(nint dateTime);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_date_time_get_ymd")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void DateTimeGetYearMonthDay(
        nint dateTime,
        out int year,
        out int month,
        out int day
    );

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_date_time_hash")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial uint DateTimeHash(nint dateTime);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_date_time_is_daylight_savings")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static partial bool DateTimeIsDaylightSavings(nint dateTime);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_date_time_new")]
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
        LibraryName.Glib,
        EntryPoint = "g_date_time_new_from_iso8601",
        StringMarshalling = StringMarshalling.Utf8
    )]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint DateTimeNewFromIso8601(string? text, TimeZone? defaultTz);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_date_time_new_from_unix_local")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint DateTimeNewFromUnixLocal(long time);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_date_time_new_from_unix_utc")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint DateTimeNewFromUnixUtc(long time);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_date_time_new_local")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint DateTimeNewLocal(
        int year,
        int month,
        int day,
        int hour,
        int minute,
        double seconds
    );

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_date_time_new_now")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint DateTimeNewNow(TimeZone tz);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_date_time_new_now_local")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint DateTimeNewNowLocal();

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_date_time_new_now_utc")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint DateTimeNewNowUtc();

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_date_time_new_utc")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint DateTimeNewUtc(
        int year,
        int month,
        int day,
        int hour,
        int minute,
        double seconds
    );

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_date_time_to_local")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint DateTimeToLocal(nint dateTime);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_date_time_to_timezone")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint DateTimeToTimeZone(nint dateTime, TimeZone tz);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_date_time_to_unix")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial long DateTimeToUnix(nint dateTime);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_date_time_to_utc")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint DateTimeToUtc(nint dateTime);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_date_time_unref")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void DateTimeUnref(nint dateTime);
}
