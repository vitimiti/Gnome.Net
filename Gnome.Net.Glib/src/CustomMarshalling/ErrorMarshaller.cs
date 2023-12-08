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

        var managed = (ErrorImports.UnmanagedError)(
            Marshal.PtrToStructure(unmanaged, typeof(ErrorImports.UnmanagedError))
            ?? new ErrorImports.UnmanagedError()
        );

        if (managed.Domain == BookmarkFileImports.ErrorQuark())
        {
            return new BookmarkFileErrorQuark
            {
                Domain = managed.Domain,
                Code = (BookmarkFileError)managed.Code,
                Message = Marshal.PtrToStringUTF8(managed.Message)
            };
        }

        if (managed.Domain == CoreImports.FileErrorQuark())
        {
            return new FileErrorQuark
            {
                Domain = managed.Domain,
                Code = (FileError)managed.Code,
                Message = Marshal.PtrToStringUTF8(managed.Message)
            };
        }

        if (managed.Domain == CoreImports.ShellErrorQuark())
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
