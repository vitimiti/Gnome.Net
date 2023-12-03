// This file is part of the Gnome.Net project and is under the MIT license.
// See LICENSE.md for more information.

using Gnome.Net.GLib.Imports;

namespace Gnome.Net.GLib;

/// <summary>Information related functions and properties.</summary>
public static class GInformation
{
    /// <summary>Gets/Sets a human-readable name for the application.</summary>
    /// <value>
    ///     A <see cref="string" /> with the application name. This may return <see langword="null" /> but cannot be
    ///     given a <see langword="null" /> <see langword="value" />.
    /// </value>
    /// <exception cref="ArgumentNullException">
    ///     If the <see langword="value" /> is <see langword="null" /> when setting the application name.
    /// </exception>
    /// <remarks>
    ///     This name should be localized if possible, and is intended for display to the user. Contrast with
    ///     <see cref="ProgramName" />, which gets a non-localized name. If the application name hasn't been set, the
    ///     getter returns the value of <see cref="ProgramName" />.
    /// </remarks>
    public static string? ApplicationName
    {
        get => GLibApi.GStringDuplicate(GLibApi.GGetApplicationName());
        set
        {
            ArgumentNullException.ThrowIfNull(value);
            GLibApi.GSetApplicationName(value);
        }
    }

    // TODO: Ensure the non dependent libraries documentation is correctly named once implemented.
    /// <summary>Gets the name of the program.</summary>
    /// <value>
    ///     A <see cref="string" /> with the program name. This may return <see langword="null" /> but cannot be
    ///     given a <see langword="null" /> <see langword="value" />.
    /// </value>
    /// <exception cref="ArgumentNullException">
    ///     If the <see langword="value" /> is <see langword="null" /> when setting the program name.
    /// </exception>
    /// <remarks>
    ///     This name should not be localized, in contrast to <see cref="ApplicationName" />. If you are using
    ///     GApplication the program name is set in GApplication.Run(). In case of GDK or GTK+ it is set in
    ///     Gdk.GEngine.Init(), which is called by Gtk.GEngine.Init(), and the GtkApplication.Startup handler. The
    ///     program name is found by taking the last component of the application arguments.
    /// </remarks>
    public static string? ProgramName
    {
        get => GLibApi.GStringDuplicate(GLibApi.GGetProgramName());
        set
        {
            ArgumentNullException.ThrowIfNull(value);
            GLibApi.GSetProgramName(value);
        }
    }
}
