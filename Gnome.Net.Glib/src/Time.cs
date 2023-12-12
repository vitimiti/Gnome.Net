// This file is part of the Gnome.Net project and is under the MIT license.
// See LICENSE.md for more information.

using Gnome.Net.Glib.Imports;

namespace Gnome.Net.Glib;

/// <summary>A static class to manage time related data.</summary>
public static class Time
{
    /// <summary>Queries the system monotonic time.</summary>
    /// <value>An <see cref="long" /> with the system monotonic time.</value>
    /// <remarks>
    ///     <para>
    ///         The monotonic clock will always increase and doesn’t suffer discontinuities when the user (or NTP)
    ///         changes the system time. It may or may not continue to tick during times where the machine is suspended.
    ///     </para>
    ///     <para>
    ///         We try to use the clock that corresponds as closely as possible to the passage of time as measured by
    ///         system calls such as <c>poll()</c> but it may not always be possible to do this.
    ///     </para>
    /// </remarks>
    public static long MonotonicTime => ApiImports.GetMonotonicTime();
}
