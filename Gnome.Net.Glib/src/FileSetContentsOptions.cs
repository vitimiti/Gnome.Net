// This file is part of the Gnome.Net project and is under the MIT license.
// See LICENSE.md for more information.

namespace Gnome.Net.Glib;

/// <summary>
///     Flags to pass to
///     <see cref="Io.TrySetFileContents(string,string,FileSetContentsOptions,int,out Gnome.Net.Glib.ErrorDomains.IErrorQuark?)" />
///     to affect its safety and performance.
/// </summary>
[Flags]
public enum FileSetContentsOptions
{
    /// <summary>
    ///     No guarantees about file consistency or durability. The most dangerous setting, which is slightly faster
    ///     than other settings.
    /// </summary>
    None,

    /// <summary>
    ///     Guarantee file consistency: after a crash, either the old version of the file or the new version of the file
    ///     will be available, but not a mixture. On Unix systems this equates to an <c>fsync()</c> on the file and use
    ///     of an atomic <c>rename()</c> of the new version of the file over the old.
    /// </summary>
    Consistent,

    /// <summary>
    ///     Guarantee file durability: after a crash, the new version of the file will be available. On Unix systems
    ///     this equates to an <c>fsync()</c> on the file (if <see cref="Consistent" /> is unset), or the effects of
    ///     <see cref="Consistent" /> plus an <c>fsync()</c> on the directory containing the file after calling
    ///     <c>rename()</c>.
    /// </summary>
    Durable,

    /// <summary>
    ///     Only apply consistency and durability guarantees if the file already exists. This may speed up file
    ///     operations if the file doesn’t currently exist, but may result in a corrupted version of the new file if the
    ///     system crashes while writing it.
    /// </summary>
    OnlyExisting
}
