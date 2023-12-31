// This file is part of the Gnome.Net project and is under the MIT license.
// See LICENSE.md for more information.

using Gnome.Net.Glib.Imports;

namespace Gnome.Net.Glib;

/// <summary>Information related functions and properties.</summary>
public static class Information
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
        get => ApiImports.GetApplicationName();
        set
        {
            ArgumentNullException.ThrowIfNull(value);
            ApiImports.SetApplicationName(value);
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
        get => ApiImports.GetProgramName();
        set
        {
            ArgumentNullException.ThrowIfNull(value);
            ApiImports.SetProgramName(value);
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
    ///         On Windows it follows XDG Base Directory Specification if <c>XDG_CONFIG_HOME</c> is defined. If
    ///         <c>XDG_CONFIG_HOME</c> is undefined, the folder to user for local (as opposed to roaming) application
    ///         data is used instead. See the
    ///         <a href="https://docs.microsoft.com/en-us/windows/win32/shell/knownfolderid"> documentation for
    ///         <c>FOLDERID_LocalAppData</c></a>. Note that in this case on Windows it will be the same as what
    ///         <see cref="UserDataDir" /> returns.
    ///     </para>
    /// </remarks>
    public static string? UserConfigDir => ApiImports.GetUserConfigDir();

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
    ///         <a href="https://docs.microsoft.com/en-us/windows/win32/shell/knownfolderid"> documentation for
    ///             <c>FOLDERID_LocalAppData</c></a>. Note that in this case on Windows it will be the same as what
    ///         <see cref="UserConfigDir" /> returns.
    ///     </para>
    ///     <para>
    ///         The return value is cached and modifying it at runtime is not supported, as it's not thread-safe to
    ///         modify environment variables at runtime.
    ///     </para>
    /// </remarks>
    public static string? UserDataDir => ApiImports.GetUserDataDir();

    /// <summary>Returns an ordered list of base directories in which to access system-wide application data.</summary>
    /// <value>
    ///     A <see cref="ReadOnlySpan{T}" /> of <see cref="string" /> with the data directories, or
    ///     <see cref="ReadOnlySpan{T}.Empty" />.
    /// </value>
    /// <remarks>
    ///     <para>
    ///         On UNIX platforms this is determined using the mechanisms described in the
    ///         <a href="http://www.freedesktop.org/Standards/basedir-spec">XDG Base Directory Specification</a>. In
    ///         this case the directory retrieved will be <c>XDG_DATA_DIRS</c>.
    ///     </para>
    ///     <para>
    ///         On Windows it follows XDG Base Directory Specification if <c>XDG_DATA_DIRS</c> is defined. If
    ///         <c>XDG_DATA_DIRS</c> is undefined, the first elements in the list are the Application Data and Documents
    ///         folders for All Users. (These can be determined only on Windows 2000 or later and are not present in the
    ///         list on other Windows versions.) See
    ///         <a href="https://docs.microsoft.com/en-us/windows/win32/shell/knownfolderid"> documentation for
    ///             <c>FOLDERID_ProgramData</c> and <c>FOLDERID_PublicDocuments</c></a>.
    ///     </para>
    ///     <para>
    ///         Then follows the “share” subfolder in the installation folder for the package containing the DLL that
    ///         calls this function, if it can be determined.
    ///     </para>
    ///     <para>
    ///         Finally the list contains the “share” subfolder in the installation folder for GLib, and in the
    ///         installation folder for the package the application’s .exe file belongs to.
    ///     </para>
    ///     <para>
    ///         The installation folders above are determined by looking up the folder where the module (DLL or EXE) in
    ///         question is located. If the folder’s name is “bin”, its parent is used, otherwise the folder itself.
    ///     </para>
    ///     <para>
    ///         Note that on Windows the returned list can vary depending on where this function is called.
    ///     </para>
    ///     <para>
    ///         The return value is cached and modifying it at runtime is not supported, as it’s not thread-safe to
    ///         modify environment variables at runtime.
    ///     </para>
    /// </remarks>
    public static ReadOnlySpan<string> SystemDataDirs => ApiImports.GetSystemDataDirs();
}
