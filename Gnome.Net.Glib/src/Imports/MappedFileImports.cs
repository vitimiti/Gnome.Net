// This file is part of the Gnome.Net project and is under the MIT license.
// See LICENSE.md for more information.

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

using Gnome.Net.Common;

namespace Gnome.Net.Glib.Imports;

internal static partial class MappedFileImports
{
    [LibraryImport(
        LibraryName.Glib,
        EntryPoint = "g_mapped_file_new",
        StringMarshalling = StringMarshalling.Utf8
    )]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint New(
        string filename,
        [MarshalAs(UnmanagedType.Bool)] bool writable,
        out nint error
    );

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_mapped_file_get_bytes")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint GetBytes(MappedFile file);

    [LibraryImport(
        LibraryName.Glib,
        EntryPoint = "g_mapped_file_get_contents",
        StringMarshalling = StringMarshalling.Utf8
    )]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial string? GetContents(MappedFile file);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_mapped_file_get_length")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nuint GetLength(MappedFile file);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_mapped_file_unref")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void Unref(nint file);
}
