// This file is part of the Gnome.Net project and is under the MIT license.
// See LICENSE.md for more information.

using System.Runtime.InteropServices.Marshalling;

using Gnome.Net.GLib.Imports;

using Microsoft.Win32.SafeHandles;

namespace Gnome.Net.GLib;

/// <summary>Represents a time zone.</summary>
[NativeMarshalling(typeof(SafeHandleMarshaller<GTimeZone>))]
public sealed class GTimeZone : SafeHandleZeroOrMinusOneIsInvalid
{
    /// <summary>Creates a <see cref="GTimeZone" /> corresponding to local time.</summary>
    /// <value>A <see cref="GTimeZone" /> with the local timezone.</value>
    /// <remarks>
    ///     The local time zone may change between invocations to this function; for example, if the system
    ///     administrator changes it.
    /// </remarks>
    public static GTimeZone Local => new(GLibApi.GTimeZoneNewLocal());

    /// <summary>Creates a <see cref="GTimeZone" /> corresponding to UTC.</summary>
    /// <value>A new <see cref="GTimeZone" /> with the universal timezone.</value>
    /// <remarks>
    ///     This is equivalent to calling <see cref="CreateFromIdentifier" /> with a value like “Z”, “UTC”, “+00”, etc.
    /// </remarks>
    public static GTimeZone Utc => new(GLibApi.GTimeZoneNewUtc());

    /// <summary>Get the identifier of this GTimeZone, as passed to <see cref="CreateFromIdentifier" />.</summary>
    /// <value>A <see cref="string" /> with the identifier for the timezone.</value>
    /// <remarks>
    ///     <para>
    ///         If the identifier passed at construction time was not recognised, UTC will be returned. If it was
    ///         <see langword="null" />, the identifier of the local timezone at construction time will be returned.
    ///     </para>
    ///     <para>
    ///         The identifier will be returned in the same format as provided at construction time: if provided as a
    ///         time offset, that will be returned by this function.
    ///     </para>
    /// </remarks>
    public string Identifier =>
        GLibApi.GStringDuplicate(GLibApi.GTimeZoneGetIdentifier(this)) ?? string.Empty;

    /// <summary>Creates a <see cref="GTimeZone" /> corresponding to <paramref name="identifier" />.</summary>
    /// <param name="identifier">A <see cref="string" /> with the identifier.</param>
    /// <returns>A new <see cref="GTimeZone" /> or <see langword="null" /> on failure.</returns>
    /// <remarks>
    ///     <para>If identifier cannot be parsed or loaded, <see langword="null" /> is returned.</para>
    ///     <para>
    ///         <paramref name="identifier" /> can either be an RFC3339/ISO 8601 time offset or something that would
    ///         pass as a valid value for the TZ environment variable (including <see langword="null" />).
    ///     </para>
    ///     <para>
    ///         In Windows, <paramref name="identifier" /> can also be the unlocalized name of a time zone for standard
    ///         time, for example “Pacific Standard Time”.
    ///     </para>
    ///     <para>
    ///         Valid RFC3339 time offsets are "Z" (for UTC) or "±hh:mm". ISO 8601 additionally specifies "±hhmm" and
    ///         "±hh". Offsets are time values to be added to Coordinated Universal Time (UTC) to get the local time.
    ///     </para>
    ///     <para>
    ///         In UNIX, the TZ environment variable typically corresponds to the name of a file in the zoneinfo
    ///         database, an absolute path to a file somewhere else, or a string in “std offset [dst
    ///         [offset],start[/time],end[/time]]” (POSIX) format. There are no spaces in the specification. The name of
    ///         standard and daylight savings time zone must be three or more alphabetic characters. Offsets are time
    ///         values to be added to local time to get Coordinated Universal Time (UTC) and should be
    ///         "[±]hh[[:]mm[:ss]]". Dates are either "Jn" (Julian day with n between 1 and 365, leap years not
    ///         counted), "n" (zero-based Julian day with n between 0 and 365) or "Mm.w.d" (day d (0 <![CDATA[<]]>= d
    ///         <![CDATA[<]]>= 6) of week w (1 <![CDATA[<]]>= w <![CDATA[<]]>= 5) of month m (1 <![CDATA[<]]>= m
    ///         <![CDATA[<]]>= 12), day 0 is a Sunday). Times are in local wall clock time, the default is 02:00:00.
    ///     </para>
    ///     <para>
    ///         In Windows, the “tzn[+|–]hh[:mm[:ss]][dzn]” format is used, but also accepts POSIX format. The Windows
    ///         format uses US rules for all time zones; daylight savings time is 60 minutes behind the standard time
    ///         with date and time of change taken from Pacific Standard Time. Offsets are time values to be added to
    ///         the local time to get Coordinated Universal Time (UTC).
    ///     </para>
    ///     <para>
    ///         <see cref="Local" /> calls this function with the value of the TZ environment variable. This
    ///         function itself is independent of the value of TZ, but if <paramref name="identifier" /> is
    ///         <see langword="null" /> then /etc/localtime will be consulted to discover the correct time zone on UNIX
    ///         and the registry will be consulted or GetTimeZoneInformation() will be used to get the local time zone
    ///         on Windows.
    ///     </para>
    ///     <para>
    ///         If intervals are not available, only time zone rules from TZ environment variable or other means, then
    ///         they will be computed from year 1900 to 2037. If the maximum year for the rules is available and it is
    ///         greater than 2037, then it will followed instead.
    ///     </para>
    ///     <para>
    ///         See <a href="https://datatracker.ietf.org/doc/html/rfc3339#section-5.6">RFC3339 §5.6</a> for a precise
    ///         definition of valid RFC3339 time offsets (the time-offset expansion) and ISO 8601 for the full list of
    ///         valid time offsets. See
    ///         <a href="https://www.gnu.org/software/libc/manual/html_node/TZ-Variable.html">
    ///             The GNU C Library manual
    ///         </a>
    ///         for an explanation of the possible values of the TZ environment variable. See
    ///         <a href="https://learn.microsoft.com/en-us/previous-versions/windows/embedded/ms912391(v=winembedded.11)?redirectedfrom=MSDN">
    ///             Microsoft Time Zone Index Values
    ///         </a>
    ///         for the list of time zones on Windows.
    ///     </para>
    /// </remarks>
    public static GTimeZone? CreateFromIdentifier(string? identifier)
    {
        var result = GLibApi.GTimeZoneNewIdentifier(identifier);
        return result == nint.Zero ? null : new GTimeZone(result);
    }

    /// <summary>
    ///     Creates a <see cref="GTimeZone" /> corresponding to the given constant offset from UTC, in seconds.
    /// </summary>
    /// <param name="seconds">An <see cref="int" /> with the offset to UTC, in seconds.</param>
    /// <returns>A new <see cref="GTimeZone" /> at the given offset from UTC, or UTC on failure.</returns>
    /// <remarks>
    ///     It is possible for this function to fail if <paramref name="seconds" /> is too big (greater than 24 hours),
    ///     in which case this function will return the UTC timezone for backwards compatibility. To detect failures
    ///     like this, use <see cref="CreateFromIdentifier" /> directly.
    /// </remarks>
    public static GTimeZone CreateFromOffset(int seconds)
    {
        return new GTimeZone(GLibApi.GTimeZoneNewOffset(seconds));
    }

    internal GTimeZone(nint preexistingHandle)
        : base(true)
    {
        handle = preexistingHandle;
    }

    /// <summary>
    ///     Determines if daylight savings time is in effect during a particular <paramref name="interval" /> of time in
    ///     the timezone.
    /// </summary>
    /// <param name="interval">An <see cref="int" /> with the interval within the timezone.</param>
    /// <returns>
    ///     <see langword="true" /> if daylight savings time is in effect, <see langword="false" /> otherwise.
    /// </returns>
    public bool IsDaylightSavingsTime(int interval)
    {
        return GLibApi.GTimeZoneIsDst(this, interval);
    }

    /// <summary>
    ///     Determines the time zone abbreviation to be used during a particular <paramref name="interval" /> of time in
    ///     the time zone timezone.
    /// </summary>
    /// <param name="interval">An <see cref="int" /> with the interval within the timezone.</param>
    /// <returns>A <see cref="string" /> with the timezone abbreviation.</returns>
    /// <remarks>
    ///     For example, in Toronto this is “EST” during the winter months and “EDT” during the summer months when
    ///     daylight savings time is in effect.
    /// </remarks>
    public string GetAbbreviation(int interval)
    {
        return GLibApi.GStringDuplicate(GLibApi.GTimeZoneGetAbbreviation(this, interval))
            ?? string.Empty;
    }

    /// <summary>
    ///     Determines the offset to UTC in effect during a particular <paramref name="interval" /> of time in the
    ///     timezone.
    /// </summary>
    /// <param name="interval">An <see cref="int" /> with the interval within the timezone.</param>
    /// <returns>
    ///     An <see cref="int" /> with the number of seconds that should be added to UTC to get the local time in the
    ///     timezone.
    /// </returns>
    /// <remarks>
    ///     The offset is the number of seconds that you add to UTC time to arrive at local time for the timezone (ie:
    ///     negative numbers for time zones west of GMT, positive numbers for east).
    /// </remarks>
    public int GetOffset(int interval)
    {
        return GLibApi.GTimeZoneGetOffset(this, interval);
    }

    /// <summary>
    ///     Finds an interval within the timezone that corresponds to the given <paramref name="time" />, possibly
    ///     adjusting <paramref name="time" /> if required to fit into an interval.
    /// </summary>
    /// <param name="type">A <see cref="GTimeType" /> with the type of <paramref name="time" />.</param>
    /// <param name="time">
    ///     A <see langword="ref" /> value to an <see cref="long" /> with the number of seconds since 1970/01/01.
    /// </param>
    /// <returns>An <see cref="int" /> with the interval containing <paramref name="time" />, never -1.</returns>
    /// <remarks>
    ///     <para>The meaning of <paramref name="time" /> depends on <paramref name="type" />.</para>
    ///     <para>
    ///         This function is similar to <see cref="FindInterval" />, with the difference that it always succeeds (by
    ///         making the adjustments described below).
    ///     </para>
    ///     <para>
    ///         In any of the cases where <see cref="FindInterval" /> succeeds then this function returns the same
    ///         value, without modifying <paramref name="time" />.
    ///     </para>
    ///     <para>
    ///         This function may, however, modify <paramref name="time" /> in order to deal with non-existent times. If
    ///         the non-existent local <paramref name="time" /> of 02:30 were requested on March 14th 2010 in Toronto
    ///         then this function would adjust <paramref name="time" /> to be 03:00 and return the interval containing
    ///         the adjusted time.
    ///     </para>
    /// </remarks>
    public int AdjustTime(GTimeType type, ref long time)
    {
        return GLibApi.GTimeZoneAdjustTime(this, type, ref time);
    }

    /// <summary>Finds an interval within the timezone that corresponds to the given <paramref name="time" />.</summary>
    /// <param name="type">A <see cref="GTimeType" /> with the type of <paramref name="time" />.</param>
    /// <param name="time">An <see cref="long" /> with the number of seconds since 1970/01/01.</param>
    /// <returns>
    ///     An <see cref="int" /> with the interval containing <paramref name="time" />, or -1 in case of failure.
    /// </returns>
    /// <remarks>
    ///     <para>The meaning of <paramref name="time" /> depends on <paramref name="type" />.</para>
    ///     <para>
    ///         If <paramref name="type" /> is <see cref="GTimeType" />.<see cref="GTimeType.Universal" /> then this
    ///         function will always succeed (since universal time is monotonic and continuous).
    ///     </para>
    ///     <para>
    ///         Otherwise <paramref name="time" /> is treated as local time. The distinction between
    ///         <see cref="GTimeType" />.<see cref="GTimeType.Standard" /> and
    ///         <see cref="GTimeType" />.<see cref="GTimeType.Daylight" /> is ignored except in the case that the given
    ///         <paramref name="time" /> is ambiguous. In Toronto, for example, 01:30 on November 7th 2010 occurred
    ///         twice (once inside of daylight savings time and the next, an hour later, outside of daylight savings
    ///         time). In this case, the different value of type would result in a different interval being returned.
    ///     </para>
    ///     <para>
    ///         It is still possible for this function to fail. In Toronto, for example, 02:00 on March 14th 2010 does
    ///         not exist (due to the leap forward to begin daylight savings time). -1 is returned in that case.
    ///     </para>
    /// </remarks>
    public int FindInterval(GTimeType type, long time)
    {
        return GLibApi.GTimeZoneFindInterval(this, type, time);
    }

    /// <summary>Frees the timezone.</summary>
    /// <returns>Always <see langword="true" />.</returns>
    protected override bool ReleaseHandle()
    {
        if (handle == nint.Zero)
        {
            return true;
        }

        GLibApi.GTimeZoneUnref(handle);
        handle = nint.Zero;
        return true;
    }
}
