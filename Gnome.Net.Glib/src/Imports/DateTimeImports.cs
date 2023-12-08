// This file is part of the Gnome.Net project and is under the MIT license.
// See LICENSE.md for more information.

using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

using Gnome.Net.Common;
using Gnome.Net.Glib.CustomMarshalling;

namespace Gnome.Net.Glib.Imports;

internal static partial class DateTimeImports
{
    static DateTimeImports()
    {
        NativeLibrary.SetDllImportResolver(
            Assembly.GetExecutingAssembly(),
            LibraryImportResolver.DllImportResolver
        );
    }

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_date_time_add")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint Add(DateTime dateTime, long timeSpan);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_date_time_add_days")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint AddDays(DateTime dateTime, int days);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_date_time_add_full")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint AddFull(
        DateTime dateTime,
        int years,
        int months,
        int days,
        int hours,
        int minutes,
        double seconds
    );

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_date_time_add_hours")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint AddHours(DateTime dateTime, int hours);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_date_time_add_minutes")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint AddMinutes(DateTime dateTime, int minutes);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_date_time_add_months")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint AddMonths(DateTime dateTime, int months);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_date_time_add_seconds")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint AddSeconds(DateTime dateTime, int seconds);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_date_time_add_weeks")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint AddWeeks(DateTime dateTime, int weeks);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_date_time_add_years")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint AddYears(DateTime dateTime, int years);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_date_time_compare")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial int Compare(DateTime left, DateTime right);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_date_time_difference")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial long Difference(DateTime begin, DateTime end);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_date_time_equal")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static partial bool Equal(DateTime left, DateTime right);

    [LibraryImport(
        LibraryName.Glib,
        EntryPoint = "g_date_time_format",
        StringMarshalling = StringMarshalling.Utf8
    )]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial string? Format(DateTime dateTime, string format);

    [LibraryImport(
        LibraryName.Glib,
        EntryPoint = "g_date_time_format_iso8601",
        StringMarshalling = StringMarshalling.Utf8
    )]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial string? FormatIso8601(DateTime dateTime);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_date_time_get_day_of_month")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial int GetDayOfMonth(DateTime dateTime);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_date_time_get_day_of_week")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial int GetDayOfWeek(DateTime dateTime);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_date_time_get_day_of_year")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial int GetDayOfYear(DateTime dateTime);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_date_time_get_hour")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial int GetHour(DateTime dateTime);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_date_time_get_microsecond")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial int GetMicrosecond(DateTime dateTime);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_date_time_get_minute")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial int GetMinute(DateTime dateTime);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_date_time_get_month")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial int GetMonth(DateTime dateTime);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_date_time_get_second")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial int GetSecond(DateTime dateTime);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_date_time_get_seconds")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial double GetSeconds(DateTime dateTime);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_date_time_get_timezone")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint GetTimeZone(DateTime dateTime);

    [LibraryImport(
        LibraryName.Glib,
        EntryPoint = "g_date_time_get_timezone_abbreviation",
        StringMarshalling = StringMarshalling.Custom,
        StringMarshallingCustomType = typeof(StringRequiresStringDuplicateMarshaller)
    )]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial string? GetTimeZoneAbbreviation(DateTime dateTime);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_date_time_get_utc_offset")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial long GetUtcOffset(DateTime dateTime);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_date_time_get_week_numbering_year")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial int GetWeekNumberingYear(DateTime dateTime);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_date_time_get_week_of_year")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial int GetWeekOfYear(DateTime dateTime);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_date_time_get_year")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial int GetYear(DateTime dateTime);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_date_time_get_ymd")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void GetYearMonthDay(
        DateTime dateTime,
        out int year,
        out int month,
        out int day
    );

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_date_time_hash")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial uint Hash(DateTime dateTime);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_date_time_is_daylight_savings")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static partial bool IsDaylightSavings(DateTime dateTime);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_date_time_new")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint New(
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
    public static partial nint NewFromIso8601(string? text, TimeZone? defaultTz);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_date_time_new_from_unix_local")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint NewFromUnixLocal(long time);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_date_time_new_from_unix_utc")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint NewFromUnixUtc(long time);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_date_time_new_local")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint NewLocal(
        int year,
        int month,
        int day,
        int hour,
        int minute,
        double seconds
    );

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_date_time_new_now")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint NewNow(TimeZone tz);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_date_time_new_now_local")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint NewNowLocal();

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_date_time_new_now_utc")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint NewNowUtc();

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_date_time_new_utc")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint NewUtc(
        int year,
        int month,
        int day,
        int hour,
        int minute,
        double seconds
    );

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_date_time_to_local")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint ToLocal(DateTime dateTime);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_date_time_to_timezone")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint ToTimeZone(DateTime dateTime, TimeZone tz);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_date_time_to_unix")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial long ToUnix(DateTime dateTime);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_date_time_to_utc")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint ToUtc(DateTime dateTime);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_date_time_unref")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void Unref(nint dateTime);
}
