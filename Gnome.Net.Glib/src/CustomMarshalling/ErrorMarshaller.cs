// This file is part of the Gnome.Net project and is under the MIT license.
// See LICENSE.md for more information.

using System.Runtime.InteropServices;

using Gnome.Net.Glib.ErrorDomains;
using Gnome.Net.Glib.Errors;
using Gnome.Net.Glib.Imports;

namespace Gnome.Net.Glib.CustomMarshalling;

internal static class ErrorMarshaller
{
    public static IErrorQuark? FromUnmanaged(nint unmanaged)
    {
        if (unmanaged == nint.Zero)
        {
            return null;
        }

        var managed = (LibraryApi.UnmanagedError)(
            Marshal.PtrToStructure(unmanaged, typeof(LibraryApi.UnmanagedError)) ?? new LibraryApi.UnmanagedError()
        );

        if (managed.Domain == LibraryApi.BookmarkFileErrorQuark())
        {
            return new BookmarkFileErrorQuark
            {
                Domain = managed.Domain,
                Code = (BookmarkFileError)managed.Code,
                Message = Marshal.PtrToStringUTF8(managed.Message)
            };
        }

        if (managed.Domain == LibraryApi.FileErrorQuark())
        {
            return new FileErrorQuark
            {
                Domain = managed.Domain,
                Code = (FileError)managed.Code,
                Message = Marshal.PtrToStringUTF8(managed.Message)
            };
        }

        if (managed.Domain == LibraryApi.ShellErrorQuark())
        {
            return new ShellErrorQuark
            {
                Domain = managed.Domain,
                Code = (ShellError)managed.Code,
                Message = Marshal.PtrToStringUTF8(managed.Message)
            };
        }

        return null;
    }
}
