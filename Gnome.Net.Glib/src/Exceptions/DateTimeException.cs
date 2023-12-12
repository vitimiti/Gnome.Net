// This file is part of the Gnome.Net project and is under the MIT license.
// See LICENSE.md for more information.

namespace Gnome.Net.Glib.Exceptions;

/// <summary
[Serializable]
public class DateTimeException : Exception
{
    /// <summary>
    ///     Represents an exception that is thrown when there is an error related to <see cref="DateTime" />.
    /// </summary>
    public DateTimeException() { }

    /// <summary>
    ///     Represents an exception that is thrown when an error occurs related to <see cref="DateTime" />.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    public DateTimeException(string? message)
        : base(message) { }

    /// <summary>Represents an exception related to <see cref="DateTime" /> operations.</summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    /// <param name="innerException">
    ///     The exception that is the cause of the current exception, or a null reference if no inner exception is
    ///     specified.
    /// </param>
    public DateTimeException(string? message, Exception? innerException)
        : base(message, innerException) { }
}
