// This file is part of the Gnome.Net project and is under the MIT license.
// See LICENSE.md for more information.

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

using Gnome.Net.Common;

namespace Gnome.Net.Glib.Imports;

internal static partial class ApiImports
{
    [LibraryImport(LibraryName.Glib, EntryPoint = "g_mutex_clear")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void MutexClear(nint mutex);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_mutex_init")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void MutexInit(nint mutex);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_mutex_lock")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void MutexLock(nint mutex);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_mutex_trylock")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static partial bool MutexTryLock(nint mutex);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_mutex_unlock")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void MutexUnlock(nint mutex);
}
