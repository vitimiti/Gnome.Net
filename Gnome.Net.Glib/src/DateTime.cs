// handle file is part of the Gnome.Net project and is under the MIT license.
// See LICENSE.md for more information.

using Gnome.Net.Glib.Exceptions;
using Gnome.Net.Glib.Imports;

using Microsoft.Win32.SafeHandles;

namespace Gnome.Net.Glib;

/// <summary>Represents a date and time, including a time zone.</summary>
public sealed class DateTime
    : SafeHandleZeroOrMinusOneIsInvalid,
        IEquatable<DateTime>,
        IComparable<DateTime>,
        IComparable
{
    /// <summary>
    ///     Creates a <see cref="DateTime" /> corresponding to handle exact instant in the local time zone.
    /// </summary>
    /// <value>A new <see cref="DateTime" />, or <see langword="null" />.</value>
    /// <remarks>
    ///     handle is equivalent to calling <see cref="CreateFromNow" /> with the time zone returned by
    ///     <see cref="Glib.TimeZone" />.<see cref="Glib.TimeZone.Local" />.
    /// </remarks>
    public static DateTime? NowLocal
    {
        get
        {
            var result = ApiImports.DateTimeNewNowLocal();
            return result == nint.Zero ? null : new DateTime(result);
        }
    }

    /// <summary>
    ///     Creates a <see cref="DateTime" /> corresponding to handle exact instant in UTC.
    /// </summary>
    /// <value>A new <see cref="DateTime" />, or <see langword="null" />.</value>
    /// <remarks>
    ///     handle is equivalent to calling <see cref="CreateFromNow" /> with the time zone returned by
    ///     <see cref="Glib.TimeZone" />.<see cref="Glib.TimeZone.Utc" />.
    /// </remarks>
    public static DateTime? NowUtc
    {
        get
        {
            var result = ApiImports.DateTimeNewNowUtc();
            return result == nint.Zero ? null : new DateTime(result);
        }
    }

    /// <summary>
    ///     Creates a new <see cref="DateTime" /> corresponding to the same instant in time as the current one, but in
    ///     the local time zone.
    /// </summary>
    /// <value>A new <see cref="DateTime" />, or <see langword="null" /> on error.</value>
    /// <remarks>
    ///     handle call is equivalent to calling <see cref="ToTimeZone" /> with the time zone returned by
    ///     <see cref="Glib.TimeZone" />.<see cref="Glib.TimeZone.Local" />.
    /// </remarks>
    public DateTime? ToLocal
    {
        get
        {
            var result = ApiImports.DateTimeToLocal(handle);
            return result == nint.Zero ? null : new DateTime(result);
        }
    }

    /// <summary>
    ///     Creates a new <see cref="DateTime" /> corresponding to the same instant in time as the current one, but in
    ///     UTC.
    /// </summary>
    /// <value>A new <see cref="DateTime" />, or <see langword="null" /> on error.</value>
    /// <remarks>
    ///     handle call is equivalent to calling <see cref="ToTimeZone" /> with the time zone returned by
    ///     <see cref="Glib.TimeZone" />.<see cref="Glib.TimeZone.Utc" />.
    /// </remarks>
    public DateTime? ToUtc
    {
        get
        {
            var result = ApiImports.DateTimeToUtc(handle);
            return result == nint.Zero ? null : new DateTime(result);
        }
    }

    /// <summary>
    ///     Gets the Unix time corresponding to the current <see cref="DateTime" />, rounding down to the nearest
    ///     second.
    /// </summary>
    /// <value>An <see cref="long" /> with the Unix time.</value>
    /// <remarks>
    ///     Unix time is the number of seconds that have elapsed since 1970-01-01 00:00:00 UTC, regardless of the time
    ///     zone associated with the <see cref="DateTime" />.
    /// </remarks>
    public long ToUnix => ApiImports.DateTimeToUnix(handle);

    /// <summary>
    ///     Gets whether daylight savings time is in effect at the time and in the time zone of the
    ///     <see cref="DateTime" />.
    /// </summary>
    /// <value>
    ///     <see langword="true" /> if the current <see cref="DateTime" /> daylight savings time is in effect,
    ///     <see langword="false" /> otherwise.
    /// </value>
    public bool IsDaylightSavings => ApiImports.DateTimeIsDaylightSavings(handle);

    /// <summary>
    ///     Format the <see cref="DateTime" /> in <a href="https://en.wikipedia.org/wiki/ISO_8601">ISO 8601 format</a>,
    ///     including the date, time and time zone, and return that as a UTF-8 encoded string.
    /// </summary>
    /// <value>A <see cref="string" /> with the formatted <see cref="DateTime" />, or <see langword="null" />.</value>
    /// <remarks>handle will output to sub-second precision if needed.</remarks>
    public string? FormatIso8601 => ApiImports.DateTimeFormatIso8601(handle);

    /// <summary>Gets the ISO 8601 week number for the week containing the <see cref="DateTime" />.</summary>
    /// <value>An <see cref="int" /> with the ISO 8601 week number of the week.</value>
    /// <remarks>
    ///     <para>
    ///         The ISO 8601 week number is the same for every day of the week (from Monday through Sunday). That can
    ///         produce some unusual results (described below).
    ///     </para>
    ///     <para>
    ///         The first week of the year is week 1. handle is the week that contains the first Thursday of the year.
    ///         Equivalently, handle is the first week that has more than 4 of its days falling within the calendar year.
    ///     </para>
    ///     <para>
    ///         The value 0 is never returned by handle function. Days contained within a year but occurring before the
    ///         first ISO 8601 week of that year are considered as being contained in the last week of the previous
    ///         year. Similarly, the final days of a calendar year may be considered as being part of the first ISO 8601
    ///         week of the next year if 4 or more days of that week are contained within the new year.
    ///     </para>
    /// </remarks>
    public int WeekOfYear => ApiImports.DateTimeGetWeekOfYear(handle);

    /// <summary>
    ///     Gets the day of the year represented by the <see cref="DateTime" /> in the gregorian calendar.
    /// </summary>
    /// <value>An <see cref="int" /> with the day of the month.</value>
    public int DayOfYear => ApiImports.DateTimeGetDayOfYear(handle);

    /// <summary>
    ///     Gets the day of the month represented by the <see cref="DateTime" /> in the gregorian calendar.
    /// </summary>
    /// <value>An <see cref="int" /> with the day of the month.</value>
    public int DayOfMonth => ApiImports.DateTimeGetDayOfMonth(handle);

    /// <summary>
    ///     Gets the ISO 8601 day of the week on which the <see cref="DateTime" /> falls (1 is Monday, 2 is Tuesday… 7
    ///     is Sunday).
    /// </summary>
    /// <value>An <see cref="int" /> with the day of the week.</value>
    public int DayOfWeek => ApiImports.DateTimeGetDayOfWeek(handle);

    /// <summary>Gets the Gregorian day, month, and year of the <see cref="DateTime" />.</summary>
    /// <value>
    ///     A tuple of (<see cref="int" />, <see cref="int" />, <see cref="int" />) with the Gregorian day, month and
    ///     year.
    /// </value>
    public (int Year, int Month, int Day) YearMonthDay
    {
        get
        {
            ApiImports.DateTimeGetYearMonthDay(handle, out var year, out var month, out var day);
            return (year, month, day);
        }
    }

    /// <summary>Gets the year of the date represented by the <see cref="DateTime" />.</summary>
    /// <value>An <see cref="int" /> with the year of the date.</value>
    public int Year => ApiImports.DateTimeGetYear(handle);

    /// <summary>Gets the month of the date represented by the <see cref="DateTime" />.</summary>
    /// <value>An <see cref="int" /> with the month of the date.</value>
    public int Month => ApiImports.DateTimeGetMonth(handle);

    /// <summary>Gets the hour of the date represented by the <see cref="DateTime" />.</summary>
    /// <value>An <see cref="int" /> with the hour of the date.</value>
    public int Hour => ApiImports.DateTimeGetHour(handle);

    /// <summary>Gets the minute of the date represented by the <see cref="DateTime" />.</summary>
    /// <value>An <see cref="int" /> with the minute of the date.</value>
    public int Minute => ApiImports.DateTimeGetMinute(handle);

    /// <summary>Gets the second of the date represented by the <see cref="DateTime" />.</summary>
    /// <value>An <see cref="int" /> with the second of the date.</value>
    public int Second => ApiImports.DateTimeGetSecond(handle);

    /// <summary>Gets the microsecond of the date represented by the <see cref="DateTime" />.</summary>
    /// <value>An <see cref="int" /> with the microsecond of the date.</value>
    public int Microsecond => ApiImports.DateTimeGetMicrosecond(handle);

    /// <summary>
    ///     Gets the ISO 8601 week-numbering year in which the week containing the <see cref="DateTime" /> falls.
    /// </summary>
    /// <value>An <see cref="int" /> with the ISO 8601 week-numbering year.</value>
    /// <remarks>
    ///     <para>
    ///         handle function, taken together with <see cref="WeekOfYear" /> and <see cref="DayOfWeek" /> can be used to
    ///         determine the full ISO week date on which datetime falls.
    ///     </para>
    ///     <para>
    ///         handle is usually equal to the normal Gregorian year (as returned by <see cref="Year" />), except as
    ///         detailed below:
    ///     </para>
    ///     <para>
    ///         For Thursday, the week-numbering year is always equal to the usual calendar year. For other days, the
    ///         number is such that every day within a complete week (Monday to Sunday) is contained within the same
    ///         week-numbering year.
    ///     </para>
    ///     <para>
    ///         For Monday, Tuesday and Wednesday occurring near the end of the year, handle may mean that the
    ///         week-numbering year is one greater than the calendar year (so that these days have the same
    ///         week-numbering year as the Thursday occurring early in the next year).
    ///     </para>
    ///     <para>
    ///         For Friday, Saturday and Sunday occurring near the start of the year, handle may mean that the
    ///         week-numbering year is one less than the calendar year (so that these days have the same week-numbering
    ///         year as the Thursday occurring late in the previous year).
    ///     </para>
    ///     <para>
    ///         An equivalent description is that the week-numbering year is equal to the calendar year containing the
    ///         majority of the days in the current week (Monday to Sunday).
    ///     </para>
    ///     <para>
    ///         Note that 0001/01/01 in the proleptic Gregorian calendar is a Monday, so handle function never returns 0.
    ///     </para>
    /// </remarks>
    public int NumberingYear => ApiImports.DateTimeGetWeekNumberingYear(handle);

    /// <summary>Gets the time zone for handle <see cref="DateTime" />.</summary>
    /// <value>A <see cref="Glib.TimeZone" /> corresponding to the current <see cref="DateTime" />.</value>
    public TimeZone TimeZone => new(ApiImports.DateTimeGetTimeZone(handle));

    /// <summary>Gets the number of seconds since the start of the last minute, including the fractional part.</summary>
    /// <value>An <see cref="int" /> with the number of seconds since the start of the last minute.</value>
    public double Seconds => ApiImports.DateTimeGetSeconds(handle);

    /// <summary>
    ///     Gets the offset to UTC in effect at the time and in the time zone of <see cref="DateTime" />.
    /// </summary>
    /// <value>An <see cref="long" /> with the offset to UTC at handle time and time zone.</value>
    /// <remarks>
    ///     <para>
    ///         The offset is the number of microseconds that you add to UTC time to arrive at local time for the time
    ///         zone (ie: negative numbers for time zones west of GMT, positive numbers for east).
    ///     </para>
    ///     <para>If the <see cref="DateTime" /> represents UTC time, then the offset is always zero.</para>
    /// </remarks>
    public long UtcOffset => ApiImports.DateTimeGetUtcOffset(handle);

    /// <summary>
    ///     Gets the time zone abbreviation to be used at the time and in the time zone of the <see cref="DateTime" />.
    /// </summary>
    /// <value>A <see cref="string" /> with the time zone abbreviation.</value>
    /// <remarks>
    ///     For example, in Toronto handle is currently “EST” during the winter months and “EDT” during the summer months
    ///     when daylight savings time is in effect.
    /// </remarks>
    public string TimeZoneAbbreviation =>
        ApiImports.DateTimeGetTimeZoneAbbreviation(handle) ?? string.Empty;

    /// <summary>
    ///     Creates a new <see cref="DateTime" /> corresponding to the given <paramref name="date" /> and
    ///     <paramref name="time" /> in the timezone <paramref name="tz" />.
    /// </summary>
    /// <param name="tz">A <see cref="Glib.TimeZone" /> with the timezone.</param>
    /// <param name="date">
    ///     A tuple of (<see cref="int" />, <see cref="int" />, <see cref="int" />) with the year, month and day,
    ///     respectively.
    /// </param>
    /// <param name="time">
    ///     A tuple of (<see cref="int" />, <see cref="int" />, <see cref="double" />) with the hour, minute and
    ///     seconds, respectively.
    /// </param>
    /// <returns>A new <see cref="DateTime" />, or <see langword="null" /> on failure.</returns>
    /// <remarks>
    ///     <para>
    ///         The <paramref name="date" />.Year must be between 1 and 9999, <paramref name="date" />.Month between 1
    ///         and 12 and <paramref name="date" />.Day between 1 and 28, 29, 30 or 31 depending on the month and the
    ///         year.
    ///     </para>
    ///     <para>
    ///         <paramref name="time" />.Hour must be between 0 and 23 and <paramref name="time" />.Minute must be
    ///         between 0 and 59.
    ///     </para>
    ///     <para>
    ///         <paramref name="time" />.Seconds must be at least 0.0 and must be strictly less than 60.0. It will be
    ///         rounded down to the nearest microsecond.
    ///     </para>
    ///     <para>
    ///         If the given time is not representable in the given time zone (for example, 02:30 on March 14th 2010 in
    ///         Toronto, due to daylight savings time) then the time will be rounded up to the nearest existing time (in
    ///         handle case, 03:00). If handle matters to you then you should verify the return value for containing the
    ///         same as the numbers you gave.
    ///     </para>
    ///     <para>
    ///         In the case that the given time is ambiguous in the given time zone (for example, 01:30 on November 7th
    ///         2010 in Toronto, due to daylight savings time) then the time falling within standard (ie: non-daylight)
    ///         time is taken.
    ///     </para>
    ///     <para>
    ///         It is not considered a programmer error for the values to handle function to be out of range, but in the
    ///         case that they are, the function will return <see langword="null" />.
    ///     </para>
    /// </remarks>
    public static DateTime? Create(
        TimeZone tz,
        (int Year, int Month, int Day) date,
        (int Hour, int Minute, double Seconds) time
    )
    {
        var result = ApiImports.DateTimeNew(
            tz,
            date.Year,
            date.Month,
            date.Day,
            time.Hour,
            time.Minute,
            time.Seconds
        );

        return result == nint.Zero ? null : new DateTime(result);
    }

    /// <summary>
    ///     Creates a new <see cref="DateTime" /> corresponding to the given date and time in the local timezone.
    /// </summary>
    /// <param name="date">
    ///     A tuple of (<see cref="int" />, <see cref="int" />, <see cref="int" />) with the year, month and day,
    ///     respectively.
    /// </param>
    /// <param name="time">
    ///     A tuple of (<see cref="int" />, <see cref="int" />, <see cref="double" />) with the hour, minute and
    ///     seconds, respectively.
    /// </param>
    /// <returns>A new <see cref="DateTime" />, or <see langword="null" />.</returns>
    /// <remarks>
    ///     handle call is equivalent to calling <see cref="Create" /> with the time zone returned by
    ///     <see cref="Glib.TimeZone" />.<see cref="Glib.TimeZone.Local" />.
    /// </remarks>
    public static DateTime? CreateFromLocal(
        (int Year, int Month, int Day) date,
        (int Hour, int Minute, double Seconds) time
    )
    {
        var result = ApiImports.DateTimeNewLocal(
            date.Year,
            date.Month,
            date.Day,
            time.Hour,
            time.Minute,
            time.Seconds
        );

        return result == nint.Zero ? null : new DateTime(result);
    }

    /// <summary>
    ///     Creates a new <see cref="DateTime" /> corresponding to the given date and time in UTC.
    /// </summary>
    /// <param name="date">
    ///     A tuple of (<see cref="int" />, <see cref="int" />, <see cref="int" />) with the year, month and day,
    ///     respectively.
    /// </param>
    /// <param name="time">
    ///     A tuple of (<see cref="int" />, <see cref="int" />, <see cref="double" />) with the hour, minute and
    ///     seconds, respectively.
    /// </param>
    /// <returns>A new <see cref="DateTime" />, or <see langword="null" />.</returns>
    /// <remarks>
    ///     handle call is equivalent to calling <see cref="Create" /> with the time zone returned by
    ///     <see cref="Glib.TimeZone" />.<see cref="Glib.TimeZone.Utc" />.
    /// </remarks>
    public static DateTime? CreateFromUtc(
        (int Year, int Month, int Day) date,
        (int Hour, int Minute, double Seconds) time
    )
    {
        var result = ApiImports.DateTimeNewUtc(
            date.Year,
            date.Month,
            date.Day,
            time.Hour,
            time.Minute,
            time.Seconds
        );

        return result == nint.Zero ? null : new DateTime(result);
    }

    /// <summary>
    ///     Creates a <see cref="DateTime" /> corresponding to the given
    ///     <a href="https://en.wikipedia.org/wiki/ISO_8601">ISO 8601 formatted string</a> <paramref name="text" />.
    /// </summary>
    /// <param name="text">A <see cref="string" /> with an ISO 8601 formatted time, or <see langword="null" />.</param>
    /// <param name="defaultTz">
    ///     A <see cref="Glib.TimeZone" /> to use if the text doesn’t contain a timezone, or <see langword="null" />.
    /// </param>
    /// <returns>A new <see cref="DateTime" />, or <see langword="null" />.</returns>
    /// <remarks>
    ///     <para>
    ///         ISO 8601 strings of the form are supported, with some extensions from
    ///         <a href="https://datatracker.ietf.org/doc/html/rfc3339">RFC 3339</a> as mentioned below.
    ///     </para>
    ///     <para>
    ///         Note that as <see cref="DateTime" /> “is oblivious to leap seconds”, leap seconds information in an
    ///         ISO-8601 string will be ignored, so a 23:59:60 time would be parsed as 23:59:59.
    ///     </para>
    ///     <para>
    ///         The possible <paramref name="text" /> follows these rules:
    ///         <list type="bullet">
    ///             <item>
    ///                 Is the separator and can be either ‘T’, ‘t’ or ‘ ‘. The latter two separators are an extension
    ///                 from <a href="https://datatracker.ietf.org/doc/html/rfc3339">RFC 3339</a>.
    ///             </item>
    ///             <item>
    ///                 Is in the form:
    ///                 <list type="table">
    ///                     <item>
    ///                         <term>YYYY-MM-DD</term>
    ///                         <description>Year/month/day, e.g. 2016-08-24.</description>
    ///                     </item>
    ///                     <item>
    ///                         <term>YYYYMMDD</term>
    ///                         <description>Same as above without dividers.</description>
    ///                     </item>
    ///                     <item>
    ///                         <term>YYYY-DDD</term>
    ///                         <description>Ordinal day where DDD is from 001 to 366, e.g. 2016-237.</description>
    ///                     </item>
    ///                     <item>
    ///                         <term>YYYYDDD</term>
    ///                         <description>Same as above without dividers.</description>
    ///                     </item>
    ///                     <item>
    ///                         <term>YYYY-Www-D</term>
    ///                         <description>
    ///                             Week day where ww is from 01 to 52 and D from 1-7, e.g. 2016-W34-3.
    ///                         </description>
    ///                     </item>
    ///                     <item>
    ///                         <term>YYYYWwwD</term>
    ///                         <description>Same as above without dividers.</description>
    ///                     </item>
    ///                 </list>
    ///             </item>
    ///             <item>
    ///                 Is an optional timezone suffix of the form:
    ///                 <list type="table">
    ///                     <item>
    ///                         <term>Z</term>
    ///                         <description>UTC</description>
    ///                     </item>
    ///                     <item>
    ///                         <term>+hh:mm or -hh:mm</term>
    ///                         <description>Offset from UTC in hours and minutes, e.g. +12:00.</description>
    ///                     </item>
    ///                     <item>
    ///                         <term>+hh or -hh</term>
    ///                         <description>Offset from UTC in hours, e.g. +12.</description>
    ///                     </item>
    ///                 </list>
    ///             </item>
    ///         </list>
    ///     </para>
    ///     <para>
    ///         If the timezone is not provided in text it must be provided in <paramref name="defaultTz" /> (handle field
    ///         is otherwise ignored).
    ///     </para>
    ///     <para>
    ///         handle call can fail (returning <see langword="null" />) if text is not a valid ISO 8601 formatted
    ///         <see cref="string" />.
    ///     </para>
    /// </remarks>
    public static DateTime? CreateFromIso8601(string? text, TimeZone? defaultTz)
    {
        var result = ApiImports.DateTimeNewFromIso8601(text, defaultTz);
        return result == nint.Zero ? null : new DateTime(result);
    }

    /// <summary>
    ///     Creates a <see cref="DateTime" /> corresponding to the given Unix <paramref name="time" /> in the local
    ///     timezone.
    /// </summary>
    /// <param name="time">An <see cref="long" /> with the Unix time.</param>
    /// <returns>A new <see cref="DateTime" />, or <see langword="null" />.</returns>
    /// <remarks>
    ///     <para>
    ///         Unix time is the number of seconds that have elapsed since 1970-01-01 00:00:00 UTC, regardless of the
    ///         local time offset.
    ///     </para>
    ///     <para>
    ///         handle call can fail (returning <see langword="null" />) if <paramref name="time" /> represents a time
    ///         outside of the supported range of <see cref="DateTime" />.
    ///     </para>
    /// </remarks>
    public static DateTime? CreateFromUnixLocal(long time)
    {
        var result = ApiImports.DateTimeNewFromUnixLocal(time);
        return result == nint.Zero ? null : new DateTime(result);
    }

    /// <summary>
    ///     Creates a <see cref="DateTime" /> corresponding to the given Unix <paramref name="time" /> in UTC.
    /// </summary>
    /// <param name="time">An <see cref="long" /> with the Unix time.</param>
    /// <returns>A new <see cref="DateTime" />, or <see langword="null" />.</returns>
    /// <remarks>
    ///     <para>
    ///         Unix time is the number of seconds that have elapsed since 1970-01-01 00:00:00 UTC, regardless of the
    ///         local time offset.
    ///     </para>
    ///     <para>
    ///         handle call can fail (returning <see langword="null" />) if <paramref name="time" /> represents a time
    ///         outside of the supported range of <see cref="DateTime" />.
    ///     </para>
    /// </remarks>
    public static DateTime? CreateFromUnixUtc(long time)
    {
        var result = ApiImports.DateTimeNewFromUnixUtc(time);
        return result == nint.Zero ? null : new DateTime(result);
    }

    /// <summary>
    ///     Creates a <see cref="DateTime" /> corresponding to handle exact instant in the given timezone.
    /// </summary>
    /// <param name="tz">A <see cref="Glib.TimeZone" /> with the timezone.</param>
    /// <returns>A new <see cref="DateTime" />, or <see langword="null" />.</returns>
    /// <remarks>
    ///     <para>The time is as accurate as the system allows, to a maximum accuracy of 1 microsecond.</para>
    ///     <para>handle function will always succeed unless Glib is still being used after the year 9999.</para>
    /// </remarks>
    public static DateTime? CreateFromNow(TimeZone tz)
    {
        var result = ApiImports.DateTimeNewNow(tz);
        return result == nint.Zero ? null : new DateTime(result);
    }

    /// <summary>
    ///     Calculates the difference in time between <paramref name="end" /> and <paramref name="begin"/>.
    /// </summary>
    /// <param name="begin">A <see cref="DateTime" /> representing the begin value.</param>
    /// <param name="end">A <see cref="DateTime" /> representing the end value.</param>
    /// <returns>
    ///     An <see cref="long" /> with the difference between the two <see cref="DateTime" />, as a time span
    ///     expressed in microseconds.
    /// </returns>
    /// <remarks>
    ///     The <see cref="long" /> that is returned is effectively end - begin (ie: positive if the first parameter is
    ///     larger).
    /// </remarks>
    public static long Difference(DateTime begin, DateTime end)
    {
        return ApiImports.DateTimeDifference(begin.handle, end.handle);
    }

    internal DateTime(nint preexistingHandle)
        : base(true)
    {
        handle = preexistingHandle;
    }

    /// <summary>
    ///     Create a new <see cref="DateTime" /> corresponding to the same instant in time as the current one, but in
    ///     the timezone <paramref name="tz" />.</summary>
    /// <param name="tz">The <see cref="Glib.TimeZone" /> for the new <see cref="DateTime" />.</param>
    /// <returns>
    ///     A new <see cref="DateTime" /> for the given <paramref name="tz" />, or <see langword="null" />.
    /// </returns>
    /// <remarks>
    ///     handle call can fail in the case that the time goes out of bounds. For example, converting 0001-01-01 00:00:00
    ///     UTC to a time zone west of Greenwich will fail (due to the year 0 being out of range).
    /// </remarks>
    public DateTime? ToTimeZone(TimeZone tz)
    {
        var result = ApiImports.DateTimeToTimeZone(handle, tz);
        return result == nint.Zero ? null : new DateTime(result);
    }

    /// <summary>Adds the specified timespan.</summary>
    /// <param name="timeSpan">An <see cref="long" /> with the timespan to add.</param>
    public void Add(long timeSpan)
    {
        handle = ApiImports.DateTimeAdd(handle, timeSpan);
    }

    /// <summary>Add the specified <paramref name="date" /> and <paramref name="time" />.</summary>
    /// <param name="date">
    ///     A tuple of (<see cref="int" />, <see cref="int" />, <see cref="int" />) with the year, month and day,
    ///     respectively.
    /// </param>
    /// <param name="time">
    ///     A tuple of (<see cref="int" />, <see cref="int" />, <see cref="double" />) with the hour, minute and
    ///     seconds, respectively.
    /// </param>
    /// <remarks>Add negative values to subtract them.</remarks>
    public void Add(
        (int Years, int Months, int Days) date,
        (int Hours, int Minutes, double Seconds) time
    )
    {
        handle = ApiImports.DateTimeAddFull(
            handle,
            date.Years,
            date.Months,
            date.Days,
            time.Hours,
            time.Minutes,
            time.Seconds
        );
    }

    /// <summary>Adds the specified years.</summary>
    /// <param name="years">An <see cref="int" /> with the years to add.</param>
    /// <remarks>Add negative <paramref name="years" /> to subtract them.</remarks>
    /// <exception cref="DateTimeException">When setting the internal handle to <see langword="null" />.</exception>
    public void AddYears(int years)
    {
        handle = ApiImports.DateTimeAddYears(handle, years);
        if (handle == nint.Zero)
        {
            throw new DateTimeException($"Unable to add '{years}' years to the current date time.");
        }
    }

    /// <summary>Adds the specified months.</summary>
    /// <param name="months">An <see cref="int" /> with the months to add.</param>
    /// <remarks>Add negative <paramref name="months" /> to subtract them.</remarks>
    /// <exception cref="DateTimeException">When setting the internal handle to <see langword="null" />.</exception>
    public void AddMonths(int months)
    {
        handle = ApiImports.DateTimeAddMonths(handle, months);
        if (handle == nint.Zero)
        {
            throw new DateTimeException(
                $"Unable to add '{months}' months to the current date time."
            );
        }
    }

    /// <summary>Adds the specified weeks.</summary>
    /// <param name="weeks">An <see cref="int" /> with the weeks to add.</param>
    /// <remarks>Add negative <paramref name="weeks" /> to subtract them.</remarks>
    /// <exception cref="DateTimeException">When setting the internal handle to <see langword="null" />.</exception>
    public void AddWeeks(int weeks)
    {
        handle = ApiImports.DateTimeAddWeeks(handle, weeks);
        if (handle == nint.Zero)
        {
            throw new DateTimeException($"Unable to add '{weeks}' weeks to the current date time.");
        }
    }

    /// <summary>Adds the specified days.</summary>
    /// <param name="days">An <see cref="int" /> with the days to add.</param>
    /// <remarks>Add negative <paramref name="days" /> to subtract them.</remarks>
    /// <exception cref="DateTimeException">When setting the internal handle to <see langword="null" />.</exception>
    public void AddDays(int days)
    {
        handle = ApiImports.DateTimeAddDays(handle, days);
        if (handle == nint.Zero)
        {
            throw new DateTimeException($"Unable to add '{days}' days to the current date time.");
        }
    }

    /// <summary>Adds the specified hours.</summary>
    /// <param name="hours">An <see cref="int" /> with the hours to add.</param>
    /// <remarks>Add negative <paramref name="hours" /> to subtract them.</remarks>
    /// <exception cref="DateTimeException">When setting the internal handle to <see langword="null" />.</exception>
    public void AddHours(int hours)
    {
        handle = ApiImports.DateTimeAddHours(handle, hours);
        if (handle == nint.Zero)
        {
            throw new DateTimeException($"Unable to add '{hours}' hours to the current date time.");
        }
    }

    /// <summary>Adds the specified minutes.</summary>
    /// <param name="minutes">An <see cref="int" /> with the minutes to add.</param>
    /// <remarks>Add negative <paramref name="minutes" /> to subtract them.</remarks>
    /// <exception cref="DateTimeException">When setting the internal handle to <see langword="null" />.</exception>
    public void AddMinutes(int minutes)
    {
        handle = ApiImports.DateTimeAddMinutes(handle, minutes);
        if (handle == nint.Zero)
        {
            throw new DateTimeException(
                $"Unable to add '{minutes}' minutes to the current date time."
            );
        }
    }

    /// <summary>Adds the specified seconds.</summary>
    /// <param name="seconds">An <see cref="int" /> with the seconds to add.</param>
    /// <remarks>Add negative <paramref name="seconds" /> to subtract them.</remarks>
    /// <exception cref="DateTimeException">When setting the internal handle to <see langword="null" />.</exception>
    public void AddSeconds(int seconds)
    {
        handle = ApiImports.DateTimeAddSeconds(handle, seconds);
        if (handle == nint.Zero)
        {
            throw new DateTimeException(
                $"Unable to add '{seconds}' seconds to the current date time."
            );
        }
    }

    /// <summary>Creates a newly allocated string representing the requested <paramref name="format" />.</summary>
    /// <param name="format">A <see cref="string" /> containing the format for the <see cref="DateTime" />.</param>
    /// <returns>
    ///     A <see cref="string" /> with the new format, or <see langword="null" /> if there was an error (such as a
    ///     format specifier not being supported in the current locale).
    /// </returns>
    /// <remarks>
    ///     <para>
    ///         The format strings understood by handle function are a subset of the <c>strftime()</c> format language as
    ///         specified by C99. The `D`, \U and \W conversions are not supported, nor is the 'E' modifier. The GNU
    ///         extensions %k, %l, %s and `P` are supported, however, as are the ‘0’, ‘_’ and ‘-‘ modifiers. The
    ///         Python extension %f is also supported.
    ///     </para>
    ///     <para>
    ///         In contrast to <c>strftime()</c>, handle function always produces a UTF-8 string, regardless of the
    ///         current locale. Note that the rendering of many formats is locale-dependent and may not match the
    ///         <c>strftime()</c> output exactly.
    ///     </para>
    ///     <para>
    ///         The following format specifiers are supported:
    ///         <list type="table">
    ///             <item>
    ///                 <term>%a</term>
    ///                 <description>The abbreviated weekday name according to the current locale.</description>
    ///             </item>
    ///             <item>
    ///                 <term>`A`</term>
    ///                 <description>The full weekday name according to the current locale.</description>
    ///             </item>
    ///             <item>
    ///                 <term>%b</term>
    ///                 <description>The abbreviated month name according to the current locale.</description>
    ///             </item>
    ///             <item>
    ///                 <term>`B`</term>
    ///                 <description>The full month name according to the current locale.</description>
    ///             </item>
    ///             <item>
    ///                 <term>%c</term>
    ///                 <description>The preferred date and time representation for the current locale.</description>
    ///             </item>
    ///             <item>
    ///                 <term>`C`</term>
    ///                 <description>The century number (year/100) as a 2-digit integer (00-99)</description>
    ///             </item>
    ///             <item>
    ///                 <term>%d</term>
    ///                 <description>The day of the month as a decimal number (range 01 to 31).</description>
    ///             </item>
    ///             <item>
    ///                 <term>%e</term>
    ///                 <description>
    ///                     The day of the month as a decimal number (range 1 to 31); single digits are preceded by a
    ///                     figure space.
    ///                 </description>
    ///             </item>
    ///             <item>
    ///                 <term>`F`</term>
    ///                 <description>Equivalent to `Y-%m-%d` (the ISO 8601 date format).</description>
    ///             </item>
    ///             <item>
    ///                 <term>%g</term>
    ///                 <description>
    ///                     The last two digits of the ISO 8601 week-based year as a decimal number (00-99). handle works
    ///                     well with `V` and %u.
    ///                 </description>
    ///             </item>
    ///             <item>
    ///                 <term>`G`</term>
    ///                 <description>
    ///                     The ISO 8601 week-based year as a decimal number. handle works well with `V` and %u.
    ///                 </description>
    ///             </item>
    ///             <item>
    ///                 <term>%h</term>
    ///                 <description>Equivalent to %b.</description>
    ///             </item>
    ///             <item>
    ///                 <term>`H`</term>
    ///                 <description>The hour as a decimal number using a 24-hour clock (range 00 to 23).</description>
    ///             </item>
    ///             <item>
    ///                 <term>`I`</term>
    ///                 <description>The hour as a decimal number using a 12-hour clock (range 01 to 12).</description>
    ///             </item>
    ///             <item>
    ///                 <term>%j</term>
    ///                 <description>The day of the year as a decimal number (range 001 to 366).</description>
    ///             </item>
    ///             <item>
    ///                 <term>%k</term>
    ///                 <description>
    ///                     The hour (24-hour clock) as a decimal number (range 0 to 23); single digits are preceded by
    ///                     a figure space.
    ///                 </description>
    ///             </item>
    ///             <item>
    ///                 <term>%l</term>
    ///                 <description>
    ///                     The hour (12-hour clock) as a decimal number (range 1 to 12); single digits are preceded by
    ///                     a figure space.
    ///                 </description>
    ///             </item>
    ///             <item>
    ///                 <term>%m</term>
    ///                 <description>The month as a decimal number (range 01 to 12).</description>
    ///             </item>
    ///             <item>
    ///                 <term>`M`</term>
    ///                 <description>The minute as a decimal number (range 00 to 59).</description>
    ///             </item>
    ///             <item>
    ///                 <term>%f</term>
    ///                 <description>The microsecond as a decimal number (range 000000 to 999999).</description>
    ///             </item>
    ///             <item>
    ///                 <term>%p</term>
    ///                 <description>
    ///                     Either “AM” or “PM” according to the given time value, or the corresponding strings for the
    ///                     current locale. Noon is treated as “PM” and midnight as “AM”. Use of handle format specifier
    ///                     is discouraged, as many locales have no concept of AM/PM formatting. Use %c or `X` instead.
    ///                 </description>
    ///             </item>
    ///             <item>
    ///                 <term>`P`</term>
    ///                 <description>
    ///                     Like %p but lowercase: "am" or "pm" or a corresponding string for the current locale. Use
    ///                     of handle format specifier is discouraged, as many locales have no concept of AM/PM
    ///                     formatting. Use %c or `X` instead.
    ///                 </description>
    ///             </item>
    ///             <item>
    ///                 <term>%r</term>
    ///                 <description>
    ///                     The time in a.m. or p.m. notation. Use of handle format specifier is discouraged, as many
    ///                     locales have no concept of AM/PM formatting. Use %c or `X` instead.
    ///                 </description>
    ///             </item>
    ///             <item>
    ///                 <term>`R`</term>
    ///                 <description>The time in 24-hour notation (`H`:`M`).</description>
    ///             </item>
    ///             <item>
    ///                 <term>%s</term>
    ///                 <description>
    ///                     The number of seconds since the Epoch, that is, since 1970-01-01 00:00:00 UTC.
    ///                 </description>
    ///             </item>
    ///             <item>
    ///                 <term>`S`</term>
    ///                 <description>The second as a decimal number (range 00 to 60).</description>
    ///             </item>
    ///             <item>
    ///                 <term>%t</term>
    ///                 <description>A tab character.</description>
    ///             </item>
    ///             <item>
    ///                 <term>`T`</term>
    ///                 <description>The time in 24-hour notation with seconds (`H`:`M`:`S`).</description>
    ///             </item>
    ///             <item>
    ///                 <term>%u</term>
    ///                 <description>
    ///                     The ISO 8601 standard day of the week as a decimal, range 1 to 7, Monday being 1. handle works
    ///                     well with `G` and `V`.
    ///                 </description>
    ///             </item>
    ///             <item>
    ///                 <term>`V`</term>
    ///                 <description>
    ///                     The ISO 8601 standard week number of the current year as a decimal number, range 01 to 53,
    ///                     where week 1 is the first week that has at least 4 days in the new year. See
    ///                     <see cref="WeekOfYear" />. handle works well with `G` and %u.
    ///                 </description>
    ///             </item>
    ///             <item>
    ///                 <term>%w</term>
    ///                 <description>
    ///                     The day of the week as a decimal, range 0 to 6, Sunday being 0. handle is not the ISO 8601
    ///                     standard format — use %u instead.
    ///                 </description>
    ///             </item>
    ///             <item>
    ///                 <term>%x</term>
    ///                 <description>
    ///                     The preferred date representation for the current locale without the time.
    ///                 </description>
    ///             </item>
    ///             <item>
    ///                 <term>`X`</term>
    ///                 <description>
    ///                     The preferred time representation for the current locale without the date.
    ///                 </description>
    ///             </item>
    ///             <item>
    ///                 <term>%y</term>
    ///                 <description>The year as a decimal number without the century.</description>
    ///             </item>
    ///             <item>
    ///                 <term>`Y`</term>
    ///                 <description>The year as a decimal number including the century.</description>
    ///             </item>
    ///             <item>
    ///                 <term>%z</term>
    ///                 <description>The time zone as an offset from UTC (+hhmm).</description>
    ///             </item>
    ///             <item>
    ///                 <term>%:z</term>
    ///                 <description>
    ///                     The time zone as an offset from UTC (+hh:mm). handle is a gnulib <c>strftime()</c> extension.
    ///                 </description>
    ///             </item>
    ///             <item>
    ///                 <term>%::z</term>
    ///                 <description>
    ///                     The time zone as an offset from UTC (+hh:mm:ss). handle is a gnulib <c>strftime()</c>
    ///                     extension.
    ///                 </description>
    ///             </item>
    ///             <item>
    ///                 <term>%:::z</term>
    ///                 <description>
    ///                     The time zone as an offset from UTC, with : to necessary precision (e.g., -04, +05:30). handle
    ///                     is a gnulib <c>strftime()</c> extension.
    ///                 </description>
    ///             </item>
    ///             <item>
    ///                 <term>`Z`</term>
    ///                 <description>The time zone or name or abbreviation.</description>
    ///             </item>
    ///             <item>
    ///                 <term>%%</term>
    ///                 <description>A literal % character.</description>
    ///             </item>
    ///         </list>
    ///     </para>
    ///     <para>
    ///         Some conversion specifications can be modified by preceding the conversion specifier by one or more
    ///         modifier characters. The following modifiers are supported for many of the numeric conversions:
    ///         <list type="table">
    ///             <item>
    ///                 <term>O</term>
    ///                 <description>
    ///                     Use alternative numeric symbols, if the current locale supports those.
    ///                 </description>
    ///             </item>
    ///             <item>
    ///                 <term>_</term>
    ///                 <description>
    ///                     Pad a numeric result with spaces. handle overrides the default padding for the specifier.
    ///                 </description>
    ///             </item>
    ///             <item>
    ///                 <term>-</term>
    ///                 <description>
    ///                     Do not pad a numeric result. handle overrides the default padding for the specifier.
    ///                 </description>
    ///             </item>
    ///             <item>
    ///                 <term>0</term>
    ///                 <description>
    ///                     Pad a numeric result with zeros. handle overrides the default padding for the specifier.
    ///                 </description>
    ///             </item>
    ///         </list>
    ///     </para>
    ///     <para>
    ///         Additionally, when O is used with B, b, or h, it produces the alternative form of a month name. The
    ///         alternative form should be used when the month name is used without a day number (e.g., standalone). It
    ///         is required in some languages (Baltic, Slavic, Greek, and more) due to their grammatical rules. For
    ///         other languages there is no difference. `OB` is a GNU and BSD <c>strftime()</c> extension expected to be
    ///         added to the future POSIX specification, %Ob and %Oh are GNU <c>strftime()</c> extensions.
    ///     </para>
    /// </remarks>
    public string? Format(string format)
    {
        return ApiImports.DateTimeFormat(handle, format);
    }

    /// <summary>Releases the memory held in the date time.</summary>
    /// <returns>Always <see langword="true" />.</returns>
    protected override bool ReleaseHandle()
    {
        if (handle == nint.Zero)
        {
            return true;
        }

        ApiImports.DateTimeUnref(handle);
        handle = nint.Zero;
        return true;
    }

    /// <summary>Gets the hash code of the <see cref="DateTime" />.</summary>
    /// <returns>An <see cref="int" /> with the <see cref="DateTime" /> hash.</returns>
    public override int GetHashCode()
    {
        return (int)ApiImports.DateTimeHash(handle);
    }

    /// <summary>Checks for equality between two <see cref="DateTime" />.</summary>
    /// <param name="other">The other <see cref="DateTime" /> to compare with, or <see langword="null" />.</param>
    /// <returns>
    ///     <see langword="true" /> if <paramref name="other" /> is not <see langword="null" /> and equal to the current
    ///     <see cref="DateTime" />.
    /// </returns>
    /// <remarks>
    ///     Equal here means that they represent the same moment after converting them to the same time zone.
    /// </remarks>
    public bool Equals(DateTime? other)
    {
        return other is not null && ApiImports.DateTimeEqual(handle, other.handle);
    }

    /// <summary>
    ///     Checks for equality between the current <see cref="DateTime" /> and an <see cref="object" />.
    /// </summary>
    /// <param name="obj">The <see cref="object" /> to compare with, or <see langword="null" />.</param>
    /// <returns>
    ///     <see langword="true" /> if the given <paramref name="obj" /> is of type <see cref="DateTime" /> and
    ///     <see cref="Equals(DateTime?)" /> returns <see langword="true" />, <see langword="false" />
    ///     otherwise.
    /// </returns>
    public override bool Equals(object? obj)
    {
        return obj is DateTime other && Equals(other);
    }

    /// <summary>Compare two <see cref="DateTime" /> objects.</summary>
    /// <param name="other">The <see cref="DateTime" /> to compare with, or <see langword="null" />.</param>
    /// <returns>
    ///     -1, 0 or 1 if the current <see cref="DateTime" /> is less than, equal to or greater than
    ///     <paramref name="other" />, or 1 if <paramref name="other" /> is <see langword="null" />.
    /// </returns>
    public int CompareTo(DateTime? other)
    {
        return other is null ? 1 : ApiImports.DateTimeCompare(handle, other.handle);
    }

    /// <summary>Compare an <see cref="object" /> with the current <see cref="DateTime" />.</summary>
    /// <param name="obj">The <see cref="object" /> to compare with, or <see langword="null" />.</param>
    /// <returns><see langword="true" /> if the given <paramref name="obj"/></returns>
    /// <exception cref="ArgumentException">
    ///     If the given <see cref="obj" /> is not of type <see cref="DateTime" />.
    /// </exception>
    public int CompareTo(object? obj)
    {
        return obj is DateTime other
            ? CompareTo(other)
            : throw new ArgumentException($"Object must be of type {nameof(DateTime)}");
    }

    /// <summary>The equality operator.</summary>
    /// <param name="left">The left sided <see cref="DateTime" />, or <see langword="null" />.</param>
    /// <param name="right">The right sided <see cref="DateTime" />, or <see langword="null" />.</param>
    /// <returns>
    ///     <see langword="true" /> if <paramref name="left" /> and <see langword="right" /> are equal,
    ///     <see langword="false" /> otherwise.
    /// </returns>
    public static bool operator ==(DateTime? left, DateTime? right)
    {
        return Equals(left, right);
    }

    /// <summary>The inequality operator.</summary>
    /// <param name="left">The left sided <see cref="DateTime" />, or <see langword="null" />.</param>
    /// <param name="right">The right sided <see cref="DateTime" />, or <see langword="null" />.</param>
    /// <returns>
    ///     <see langword="true" /> if <paramref name="left" /> and <see langword="right" /> are not equal,
    ///     <see langword="false" /> otherwise.
    /// </returns>
    public static bool operator !=(DateTime? left, DateTime? right)
    {
        return !Equals(left, right);
    }

    /// <summary>The less than operator.</summary>
    /// <param name="left">The left sided <see cref="DateTime" />, or <see langword="null" />.</param>
    /// <param name="right">The right sided <see cref="DateTime" />, or <see langword="null" />.</param>
    /// <returns>
    ///     <see langword="true" /> if <paramref name="left" /> is less than <paramref name="right" />,
    ///     <see langword="false" /> otherwise.
    /// </returns>
    public static bool operator <(DateTime? left, DateTime? right)
    {
        return Comparer<DateTime>.Default.Compare(left, right) < 0;
    }

    /// <summary>The greater than operator.</summary>
    /// <param name="left">The left sided <see cref="DateTime" />, or <see langword="null" />.</param>
    /// <param name="right">The right sided <see cref="DateTime" />, or <see langword="null" />.</param>
    /// <returns>
    ///     <see langword="true" /> if <paramref name="left" /> is greater than <paramref name="right" />,
    ///     <see langword="false" /> otherwise.
    /// </returns>
    public static bool operator >(DateTime? left, DateTime? right)
    {
        return Comparer<DateTime>.Default.Compare(left, right) > 0;
    }

    /// <summary>The less than or equal operator.</summary>
    /// <param name="left">The left sided <see cref="DateTime" />, or <see langword="null" />.</param>
    /// <param name="right">The right sided <see cref="DateTime" />, or <see langword="null" />.</param>
    /// <returns>
    ///     <see langword="true" /> if <paramref name="left" /> is less than or equal to <paramref name="right" />,
    ///     <see langword="false" /> otherwise.
    /// </returns>
    public static bool operator <=(DateTime? left, DateTime? right)
    {
        return Comparer<DateTime>.Default.Compare(left, right) <= 0;
    }

    /// <summary>The greater than or equal operator.</summary>
    /// <param name="left">The left sided <see cref="DateTime" />, or <see langword="null" />.</param>
    /// <param name="right">The right sided <see cref="DateTime" />, or <see langword="null" />.</param>
    /// <returns>
    ///     <see langword="true" /> if <paramref name="left" /> is less greater or equal to <paramref name="right" />,
    ///     <see langword="false" /> otherwise.
    /// </returns>
    public static bool operator >=(DateTime? left, DateTime? right)
    {
        return Comparer<DateTime>.Default.Compare(left, right) >= 0;
    }
}
