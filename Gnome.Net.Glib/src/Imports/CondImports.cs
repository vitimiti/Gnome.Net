// This file is part of the Gnome.Net project and is under the MIT license.
// See LICENSE.md for more information.

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

using Gnome.Net.Common;

namespace Gnome.Net.Glib.Imports;

internal static partial class ApiImports
{
    [LibraryImport(LibraryName.Glib, EntryPoint = "g_cond_broadcast")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void CondBroadcast(nint cond);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_cond_clear")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void CondClear(nint cond);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_cond_init")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void CondInit(nint cond);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_cond_signal")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void CondSignal(nint cond);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_cond_wait")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void CondWait(nint cond, nint mutex);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_cond_wait_until")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static partial bool CondWaitUntil(nint cond, nint mutex, long endTime);
}
