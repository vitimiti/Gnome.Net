// This file is part of the Gnome.Net project and is under the MIT license.
// See LICENSE.md for more information.

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

using Gnome.Net.Common;
using Gnome.Net.Glib.CustomMarshalling;

namespace Gnome.Net.Glib.Imports;

internal static partial class ApiImports
{
    [LibraryImport(LibraryName.Glib, EntryPoint = "g_checksum_copy")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint ChecksumCopy(nint checksum);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_checksum_free")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void ChecksumFree(nint checksum);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_checksum_get_digest")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void ChecksumGetDigest(
        nint checksum,
        [MarshalUsing(typeof(ArrayMarshaller<byte, byte>), CountElementName = nameof(digestLength))]
            byte[] buffer,
        ref nuint digestLength
    );

    [LibraryImport(
        LibraryName.Glib,
        EntryPoint = "g_checksum_get_string",
        StringMarshalling = StringMarshalling.Custom,
        StringMarshallingCustomType = typeof(StringRequiresStringDuplicateMarshaller)
    )]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial string ChecksumGetString(nint checksum);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_checksum_new")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint ChecksumNew(ChecksumType checksumType);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_checksum_reset")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void ChecksumReset(nint checksum);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_checksum_type_get_length")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint ChecksumGetTypeLength(ChecksumType checksumType);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_checksum_update")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void ChecksumUpdate(
        nint checksum,
        [MarshalUsing(typeof(ArrayMarshaller<byte, byte>), CountElementName = nameof(length))]
            byte[] data,
        nint length
    );
}
