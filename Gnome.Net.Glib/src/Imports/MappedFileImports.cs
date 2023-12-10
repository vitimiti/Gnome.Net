// This file is part of the Gnome.Net project and is under the MIT license.
// See LICENSE.md for more information.

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

using Gnome.Net.Common;

namespace Gnome.Net.Glib.Imports;

internal static partial class ApiImports
{
    [LibraryImport(
        LibraryName.Glib,
        EntryPoint = "g_mapped_file_new",
        StringMarshalling = StringMarshalling.Utf8
    )]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint MappedFileNew(
        string filename,
        [MarshalAs(UnmanagedType.Bool)] bool writable,
        out nint error
    );

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_mapped_file_get_bytes")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint MappedFileGetBytes(MappedFile file);

    [LibraryImport(
        LibraryName.Glib,
        EntryPoint = "g_mapped_file_get_contents",
        StringMarshalling = StringMarshalling.Utf8
    )]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial string? MappedFileGetContents(MappedFile file);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_mapped_file_get_length")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nuint MappedFileGetLength(MappedFile file);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_mapped_file_unref")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void MappedFileUnref(nint file);
}
