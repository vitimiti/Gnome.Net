// This file is part of the Gnome.Net project and is under the MIT license.
// See LICENSE.md for more information.

using System.Runtime.InteropServices;

using Gnome.Net.GLib.ErrorDomains;
using Gnome.Net.GLib.Errors;
using Gnome.Net.GLib.Imports;

namespace Gnome.Net.GLib.CustomMarshalling;

internal static class GErrorMarshaller
{
    public static IErrorQuark? FromUnmanaged(nint unmanaged)
    {
        if (unmanaged == nint.Zero)
        {
            return null;
        }

        var managed = (GLibApi.GError)(
            Marshal.PtrToStructure(unmanaged, typeof(GLibApi.GError)) ?? new GLibApi.GError()
        );

        if (managed.Domain == GLibApi.GBookmarkFileErrorQuark())
        {
            return new GBookmarkFileErrorQuark
            {
                Domain = managed.Domain,
                Code = (GBookmarkFileError)managed.Code,
                Message = Marshal.PtrToStringUTF8(managed.Message)
            };
        }

        if (managed.Domain == GLibApi.GFileErrorQuark())
        {
            return new GFileErrorQuark
            {
                Domain = managed.Domain,
                Code = (GFileError)managed.Code,
                Message = Marshal.PtrToStringUTF8(managed.Message)
            };
        }

        if (managed.Domain == GLibApi.GShellErrorQuark())
        {
            return new GShellErrorQuark
            {
                Domain = managed.Domain,
                Code = (GShellError)managed.Code,
                Message = Marshal.PtrToStringUTF8(managed.Message)
            };
        }

        return null;
    }
}
