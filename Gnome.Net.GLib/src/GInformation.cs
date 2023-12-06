// This file is part of the Gnome.Net project and is under the MIT license.
// See LICENSE.md for more information.

using System.Runtime.InteropServices;

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
        get => GLibApi.GGetApplicationName();
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
        get => GLibApi.GGetProgramName();
        set
        {
            ArgumentNullException.ThrowIfNull(value);
            GLibApi.GSetProgramName(value);
        }
    }

    /// <summary>
    ///     Returns a base directory in which to store user-specific application configuration information such as user
    ///     preferences and settings.
    /// </summary>
    /// <value>A <see cref="string" /> with the user configuration directory.</value>
    /// <remarks>
    ///     <para>
    ///         On UNIX platforms this is determined using the mechanisms described in the
    ///         <a href="http://www.freedesktop.org/Standards/basedir-spec">XDG Base Directory Specification</a>. In
    ///         this case the directory retrieved will be <c>XDG_CONFIG_HOME</c>.
    ///     </para>
    ///     <para>
    ///         On Windows it follows XDG Base Directory Specification if <c>XDG_DATA_HOME</c> is defined. If
    ///         <c>XDG_CONFIG_HOME</c> is undefined, the folder to user for local (as opposed to roaming) application
    ///         data is used instead. See the
    ///         <a href="https://docs.microsoft.com/en-us/windows/win32/shell/knownfolderid">
    ///             documentation for <c>FOLDERID_LocalAppData</c>
    ///         </a>. Note that in this case on Windows it will be the same as what <see cref="UserDataDir" />
    ///         returns.
    ///     </para>
    /// </remarks>
    public static string? UserConfigDir => GLibApi.GGetUserConfigDir();

    /// <summary>
    ///     Returns a base directory in which to access application data such as icons that is customized for a
    ///     particular user.
    /// </summary>
    /// <value>A <see cref="string" /> with the user data directory.</value>
    /// <remarks>
    ///     <para>
    ///         On UNIX platforms this is determined using the mechanisms described in the
    ///         <a href="http://www.freedesktop.org/Standards/basedir-spec">XDG Base Directory Specification</a>. In
    ///         this case the directory retrieved will be <c>XDG_DATA_HOME</c>.
    ///     </para>
    ///     <para>
    ///         On Windows it follows XDG Base Directory Specification if <c>XDG_DATA_HOME</c> is defined. If
    ///         <c>XDG_DATA_HOME</c> is undefined, the folder to user for local (as opposed to roaming) application
    ///         data is used instead. See the
    ///         <a href="https://docs.microsoft.com/en-us/windows/win32/shell/knownfolderid">
    ///             documentation for <c>FOLDERID_LocalAppData</c>
    ///         </a>. Note that in this case on Windows it will be the same as what <see cref="UserConfigDir" />
    ///         returns.
    ///     </para>
    ///     <para>
    ///         The return value is cached and modifying it at runtime is not supported, as it's not thread-safe to
    ///         modify environment variables at runtime.
    ///     </para>
    /// </remarks>
    public static string? UserDataDir => GLibApi.GGetUserDataDir();

    public static string[]? SystemDataDirs => GLibApi.GGetSystemDataDirs();
}
