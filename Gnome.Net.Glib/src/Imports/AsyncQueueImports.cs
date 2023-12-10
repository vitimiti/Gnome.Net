// This file is part of the Gnome.Net project and is under the MIT license.
// See LICENSE.md for more information.

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

using Gnome.Net.Common;

namespace Gnome.Net.Glib.Imports;

internal static partial class ApiImports
{
    [LibraryImport(LibraryName.Glib, EntryPoint = "g_async_queue_length")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial int AsyncQueueLength(nint queue);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_async_queue_length_unlocked")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial int AsyncQueueLengthUnlocked(nint queue);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_async_queue_lock")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void AsyncQueueLock(nint queue);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_async_queue_new")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint AsyncQueueNew();

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_async_queue_pop")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint AsyncQueuePop(nint queue);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_async_queue_pop_unlocked")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint AsyncQueuePopUnlocked(nint queue);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_async_queue_push")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void AsyncQueuePush(nint queue, Pointer data);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_async_queue_push_front")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void AsyncQueuePushFront(nint queue, Pointer item);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_async_queue_push_front_unlocked")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void AsyncQueuePushFrontUnlocked(nint queue, Pointer item);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_async_queue_push_unlocked")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void AsyncQueuePushUnlocked(nint queue, Pointer data);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_async_queue_remove")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static partial bool AsyncQueueRemove(nint queue, Pointer item);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_async_queue_remove_unlocked")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static partial bool AsyncQueueRemoveUnlocked(nint queue, Pointer item);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_async_queue_timeout_pop")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint AsyncQueueTimeoutPop(nint queue, uint timeout);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_async_queue_timeout_pop_unlocked")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint AsyncQueueTimeoutPopUnlocked(nint queue, uint timeout);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_async_queue_try_pop")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint AsyncQueueTryPop(nint queue);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_async_queue_try_pop_unlocked")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint AsyncQueueTryPopUnlocked(nint queue);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_async_queue_unlock")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void AsyncQueueUnlock(nint queue);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_async_queue_unref")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void AsyncQueueUnref(nint queue);
}
