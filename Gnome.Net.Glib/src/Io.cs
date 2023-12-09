// This file is part of the Gnome.Net project and is under the MIT license.
// See LICENSE.md for more information.

using Gnome.Net.Glib.CustomMarshalling;
using Gnome.Net.Glib.ErrorDomains;
using Gnome.Net.Glib.Errors;
using Gnome.Net.Glib.Imports;

namespace Gnome.Net.Glib;

/// <summary>Static class with IO functions.</summary>
public static class Io
{
    /// <summary>Writes all of <paramref name="contents" /> to a file named <paramref name="filename" />.</summary>
    /// <param name="filename">A <see cref="string" /> with the file name.</param>
    /// <param name="contents">A <see cref="string" /> to write into.</param>
    /// <param name="error">
    ///     An <see langword="out" /> value to a <see cref="IErrorQuark" /> with
    ///     <a href="https://docs.gtk.org/glib/error-reporting.html#rules-for-use-of-gerror">a recoverable error</a>,
    ///     or <see langword="null" /> if there was no error.
    /// </param>
    /// <returns><see langword="true" /> on success, <see langword="false" /> if an error occurred.</returns>
    /// <remarks>
    ///     This is a convenience wrapper around calling
    ///     <see cref="TrySetFileContents(string,string,FileSetContentsOptions,int,out Gnome.Net.Glib.ErrorDomains.IErrorQuark?)" />
    ///     with flags set to <see cref="FileSetContentsOptions" />.<see cref="FileSetContentsOptions.Consistent" /> |
    ///     <see cref="FileSetContentsOptions" />.<see cref="FileSetContentsOptions.OnlyExisting" /> and mode set to
    ///     0666.
    /// </remarks>
    public static bool TrySetFileContents(string filename, string contents, out IErrorQuark? error)
    {
        var result = CoreImports.FileSetContents(
            filename,
            contents,
            contents.Length,
            out var errorHandle
        );
        error = ErrorMarshaller.FromUnmanaged(errorHandle);
        return result;
    }

    /// <summary>
    ///     Writes all of <paramref name="contents" /> to a file named <paramref name="filename" />, with good error
    ///     checking.
    /// </summary>
    /// <param name="filename">A <see cref="string" /> with the file name.</param>
    /// <param name="contents">A <see cref="string" /> to write into.</param>
    /// <param name="flags">
    ///     The <see cref="FileSetContentsOptions" /> with the flags controlling the safety vs speed of the operation.
    /// </param>
    /// <param name="mode">
    ///     An <see cref="int" /> with the file mode, as passed to <c>open()</c>; typically this will be 0666.
    /// </param>
    /// <param name="error">
    ///     An <see langword="out" /> value to a <see cref="IErrorQuark" /> with
    ///     <a href="https://docs.gtk.org/glib/error-reporting.html#rules-for-use-of-gerror">a recoverable error</a>,
    ///     or <see langword="null" /> if there was no error.
    /// </param>
    /// <returns><see langword="true" /> on success, <see langword="false" /> if an error occurred.</returns>
    /// <remarks>
    ///     <para>If a file called <paramref name="filename" /> already exists it will be overwritten.</para>
    ///     <para>
    ///         <paramref name="flags" /> control the properties of the write operation: whether it’s atomic, and what
    ///         the tradeoff is between returning quickly or being resilient to system crashes.
    ///     </para>
    ///     <para>
    ///         As this function performs file I/O, it is recommended to not call it anywhere where blocking would cause
    ///         problems, such as in the main loop of a graphical application. In particular, if
    ///         <paramref name="flags" /> has any value other than
    ///         <see cref="FileSetContentsOptions" />.<see cref="FileSetContentsOptions.None" /> then this function may
    ///         call <c>fsync()</c>.
    ///     </para>
    ///     <para>
    ///         If <see cref="FileSetContentsOptions" />.<see cref="FileSetContentsOptions.Consistent" /> is set in
    ///         <paramref name="flags" />, the operation is atomic in the sense that it is first written to a temporary
    ///         file which is then renamed to the final name.
    ///     </para>
    ///     <para>
    ///         Notes:
    ///         <list type="bullet">
    ///             <item>
    ///                 On UNIX, if <paramref name="filename" /> already exists hard links to
    ///                 <paramref name="filename" /> will break. Also since the file is recreated, existing permissions,
    ///                 access control lists, metadata etc. may be lost. If <paramref name="filename" /> is a symbolic
    ///                 link, the link itself will be replaced, not the linked file.
    ///             </item>
    ///             <item>
    ///                 On UNIX, if <paramref name="filename" /> already exists and is non-empty, and if the system
    ///                 supports it (via a journalling filesystem or equivalent), and if
    ///                 <see cref="FileSetContentsOptions" />.<see cref="FileSetContentsOptions.Consistent" /> is set in
    ///                 <paramref name="flags" />, the <c>fsync()</c> call (or equivalent) will be used to ensure atomic
    ///                 replacement: <paramref name="filename" /> will contain either its old contents or
    ///                 <paramref name="contents" />, even in the face of system power loss, the disk being unsafely
    ///                 removed, etc.
    ///             </item>
    ///             <item>
    ///                 On UNIX, if <paramref name="filename" /> does not already exist or is empty, there is a
    ///                 possibility that system power loss etc. after calling this function will leave
    ///                 <paramref name="filename" /> empty or full of NUL bytes, depending on the underlying filesystem,
    ///                 unless <see cref="FileSetContentsOptions" />.<see cref="FileSetContentsOptions.Durable" /> and
    ///                 <see cref="FileSetContentsOptions" />.<see cref="FileSetContentsOptions.Consistent" /> are set
    ///                 in flags.
    ///             </item>
    ///             <item>
    ///                 On Windows renaming a file will not remove an existing file with the new name, so on Windows
    ///                 there is a race condition between the existing file being removed and the temporary file being
    ///                 renamed.
    ///             </item>
    ///             <item>
    ///                 On Windows there is no way to remove a file that is open to some process, or mapped into memory.
    ///                 Thus, this function will fail if <paramref name="filename" /> already exists and is open.
    ///             </item>
    ///         </list>
    ///     </para>
    ///     <para>
    ///         If the call was successful, it returns <see langword="true" />. If the call was not successful, it
    ///         returns <see langword="false" /> and sets <paramref name="error" />. The error domain is
    ///         <see cref="FileErrorQuark" />. Possible error codes are those in the <see cref="FileError" />
    ///         enumeration.
    ///     </para>
    ///     <para>
    ///         Note that the name for the temporary file is constructed by appending up to 7 characters to
    ///         <paramref name="filename" />.
    ///     </para>
    ///     <para>
    ///         If the file didn’t exist before and is created, it will be given the permissions from
    ///         <paramref name="mode" />. Otherwise, the permissions of the existing file may be changed to
    ///         <paramref name="mode" /> depending on <paramref name="flags" />, or they may remain unchanged.
    ///     </para>
    /// </remarks>
    public static bool TrySetFileContents(
        string filename,
        string contents,
        FileSetContentsOptions flags,
        int mode,
        out IErrorQuark? error
    )
    {
        var result = CoreImports.FileSetContentsFull(
            filename,
            contents,
            contents.Length,
            flags,
            mode,
            out var errorHandle
        );

        error = ErrorMarshaller.FromUnmanaged(errorHandle);
        return result;
    }
}
