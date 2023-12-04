// This file is part of the Gnome.Net project and is under the MIT license.
// See LICENSE.md for more information.

namespace Gnome.Net.GLib.Exceptions;

/// <summary>
///     When <see cref="GDateTime" /> fails to set its internal handle to a non-<see langword="null" /> value.
/// </summary>
[Serializable]
public class GDateTimeException : Exception
{
    public GDateTimeException() { }

    public GDateTimeException(string? message)
        : base(message) { }

    public GDateTimeException(string? message, Exception? innerException)
        : base(message, innerException) { }
}
