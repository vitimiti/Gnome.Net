// This file is part of the Gnome.Net project and is under the MIT license.
// See LICENSE.md for more information.

using Gnome.Net.GLib.Errors;

namespace Gnome.Net.GLib.ErrorDomains;

/// <summary>Error codes corresponding to <c>errno</c> codes returned from file operations on UNIX.</summary>
/// <remarks>
///     <para>
///         Unlike <c>errno</c> codes, <see cref="GFileError" /> values are available on all systems, even Windows. The
///         exact meaning of each code depends on what sort of file operation you were performing; the UNIX
///         documentation gives more details. The following error code descriptions come from the GNU C Library manual,
///         and are under the copyright of that manual.
///     </para>
///     <para>
///         It’s not very portable to make detailed assumptions about exactly which errors will be returned from a given
///         operation. Some errors don’t occur on some systems, etc., sometimes there are subtle differences in when a
///         system will report a given error, etc.
///     </para>
/// </remarks>
public class GFileErrorQuark : IErrorQuark
{
    /// <inheritdoc cref="IErrorQuark.Domain" />
    public uint Domain { get; internal init; }

    /// <summary>The error code.</summary>
    /// <value>A <see cref="GFileError" /> with the error code.</value>
    public GFileError Code { get; internal init; }

    /// <inheritdoc cref="IErrorQuark.Message" />
    public string? Message { get; internal init; }
}
