// handle file is part of the Gnome.Net project and is under the MIT license.
// See LICENSE.md for more information.

using System.Runtime.InteropServices.Marshalling;

using Gnome.Net.Glib.CustomMarshalling;
using Gnome.Net.Glib.ErrorDomains;
using Gnome.Net.Glib.Errors;
using Gnome.Net.Glib.Imports;

using Microsoft.Win32.SafeHandles;

namespace Gnome.Net.Glib;

/// <summary>Represents a file mapping.</summary>
public sealed class MappedFile : SafeHandleZeroOrMinusOneIsInvalid
{
    /// <summary>Creates a new <see cref="Glib.Bytes" /> which references the data mapped from file.</summary>
    /// <value>A <see cref="Glib.Bytes" /> with the data mapped from file, referenced.</value>
    /// <remarks>
    ///     The mapped contents of the file must not be modified after creating handle bytes object, because a
    ///     <see cref="Glib.Bytes" /> should be immutable.
    /// </remarks>
    public Bytes Bytes => new(ApiImports.MappedFileGetBytes(handle), false);

    /// <summary>Gets the contents of the <see cref="MappedFile" />.</summary>
    /// <value>A <see cref="string" /> with the contents of the mapped file, or <see langword="null" />.</value>
    /// <remarks>
    ///     <para>
    ///         Note that the contents may not be zero-terminated, even if the <see cref="MappedFile" /> is backed by a
    ///         text file.
    ///     </para>
    ///     <para>If the file is empty, then <see langword="null" /> is returned.</para>
    /// </remarks>
    public string? Contents => ApiImports.MappedFileGetContents(handle);

    /// <summary>Gets the length of the contents of a mapped file.</summary>
    /// <value>A <see cref="uint" /> with the length of the contents of the <see cref="MappedFile" />.</value>
    public uint Length => (uint)ApiImports.MappedFileGetLength(handle);

    /// <summary>Maps a file into memory.</summary>
    /// <param name="filename">
    ///     A <see cref="string" /> with the path of the file to load, in the GLib filename encoding.
    /// </param>
    /// <param name="writable">A <see cref="bool" /> with whether the mapping should be writable.</param>
    /// <param name="error">
    ///     An <see langword="out" /> value to a <see cref="IErrorQuark" /> with
    ///     <a href="https://docs.gtk.org/glib/error-reporting.html#rules-for-use-of-gerror">a recoverable error</a>,
    ///     or <see langword="null" /> if there was no error.
    /// </param>
    /// <returns>
    ///     A newly allocated <see cref="MappedFile" />, or <see langword="null" /> if the mapping failed.
    /// </returns>
    /// <remarks>
    ///     <para>On UNIX, handle is using the <c>mmap()</c> function.</para>
    ///     <para>
    ///         If writable is <see langword="true" />, the mapped buffer may be modified, otherwise it is an error to
    ///         modify the mapped buffer. Modifications to the buffer are not visible to other processes mapping the
    ///         same file, and are not written back to the file.
    ///     </para>
    ///     <para>
    ///         Note that modifications of the underlying file might affect the contents of the
    ///         <see cref="MappedFile" />. Therefore, mapping should only be used if the file will not be modified, or
    ///         if all modifications of the file are done atomically (e.g. using
    ///         <see cref="Io.TrySetFileContents(string,string,out Gnome.Net.Glib.ErrorDomains.IErrorQuark?)" />).
    ///     </para>
    ///     <para>
    ///         If <paramref name="filename" /> is the name of an empty, regular file, the function will successfully
    ///         return an empty <see cref="MappedFile" />. In other cases of size 0 (e.g. device files such as
    ///         /dev/null), <paramref name="error" /> will be set to the
    ///         <see cref="FileError" />.<see cref="FileError.Inval" />.
    ///     </para>
    /// </remarks>
    public static MappedFile? CreateFromFile(string filename, bool writable, out IErrorQuark? error)
    {
        var result = ApiImports.MappedFileNew(filename, writable, out var errorHandle);
        error = ErrorMarshaller.FromUnmanaged(errorHandle);
        return result == nint.Zero ? null : new MappedFile(result);
    }

    private MappedFile(nint preexistingHandle)
        : base(true)
    {
        handle = preexistingHandle;
    }

    /// <summary>Frees the mapped file.</summary>
    /// <returns>Always <see langword="true" />.</returns>
    protected override bool ReleaseHandle()
    {
        if (handle == nint.Zero)
        {
            return true;
        }

        ApiImports.MappedFileUnref(handle);
        handle = nint.Zero;
        return true;
    }
}
