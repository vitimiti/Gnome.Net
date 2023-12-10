// This file is part of the Gnome.Net project and is under the MIT license.
// See LICENSE.md for more information.

using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

using Gnome.Net.Common;

namespace Gnome.Net.Glib.Imports;

internal static partial class BytesImports
{
    static BytesImports()
    {
        NativeLibrary.SetDllImportResolver(
            Assembly.GetExecutingAssembly(),
            LibraryImportResolver.DllImportResolver
        );
    }

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_bytes_compare")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial int Compare(Bytes? left, Bytes? right);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_bytes_equal")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static partial bool Equal(Bytes? left, Bytes? right);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_bytes_get_data")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    [return: MarshalUsing(typeof(ArrayMarshaller<byte, byte>), CountElementName = nameof(size))]
    public static partial byte[]? GetData(Bytes bytes, out nuint size);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_bytes_get_region")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint GetRegion(
        Bytes bytes,
        nuint elementSize,
        nuint offset,
        nuint numberOfElements
    );

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_bytes_get_size")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nuint GetSize(Bytes bytes);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_bytes_hash")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial uint Hash(Bytes bytes);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_bytes_new")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint New(nint data, nuint size);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_bytes_new_take")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint NewTake(nint data, nuint size);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_bytes_unref")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void Unref(nint bytes);
}
