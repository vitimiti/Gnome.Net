// This file is part of the Gnome.Net project and is under the MIT license.
// See LICENSE.md for more information.

namespace Gnome.Net.GLib;

/// <summary>Disambiguates a given time in two ways.</summary>
/// <remarks>
///     <para>First, specifies if the given time is in universal or local time.</para>
///     <para>
///         Second, if the time is in local time, specifies if it is local standard time or local daylight time. This is
///         important for the case where the same local time occurs twice (during daylight savings time transitions, for
///         example).
///     </para>
/// </remarks>
public enum TimeType
{
    /// <summary>The time is in local standard time.</summary>
    Standard,

    /// <summary>The time is in local daylight time.</summary>
    Daylight,

    /// <summary>The time is in UTC.</summary>
    Universal
}
