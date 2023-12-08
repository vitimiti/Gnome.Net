// This file is part of the Gnome.Net project and is under the MIT license.
// See LICENSE.md for more information.

namespace Gnome.Net.Glib.Exceptions;

/// <summary>
///     When <see cref="DateTime" /> fails to set its internal handle to a non-<see langword="null" /> value.
/// </summary>
[Serializable]
public class DateTimeException : Exception
{
    public DateTimeException() { }

    public DateTimeException(string? message)
        : base(message) { }

    public DateTimeException(string? message, Exception? innerException)
        : base(message, innerException) { }
}
