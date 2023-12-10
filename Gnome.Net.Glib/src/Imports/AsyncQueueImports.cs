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
    public static partial int AsyncQueueLength(AsyncQueue queue);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_async_queue_length_unlocked")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial int AsyncQueueLengthUnlocked(AsyncQueue queue);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_async_queue_lock")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void AsyncQueueLock(AsyncQueue queue);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_async_queue_new")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint AsyncQueueNew();

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_async_queue_pop")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint AsyncQueuePop(AsyncQueue queue);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_async_queue_pop_unlocked")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint AsyncQueuePopUnlocked(AsyncQueue queue);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_async_queue_push")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void AsyncQueuePush(AsyncQueue queue, Pointer data);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_async_queue_push_front")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void AsyncQueuePushFront(AsyncQueue queue, Pointer item);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_async_queue_push_front_unlocked")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void AsyncQueuePushFrontUnlocked(AsyncQueue queue, Pointer item);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_async_queue_push_unlocked")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void AsyncQueuePushUnlocked(AsyncQueue queue, Pointer data);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_async_queue_remove")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static partial bool AsyncQueueRemove(AsyncQueue queue, Pointer item);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_async_queue_remove_unlocked")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static partial bool AsyncQueueRemoveUnlocked(AsyncQueue queue, Pointer item);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_async_queue_timeout_pop")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint AsyncQueueTimeoutPop(AsyncQueue queue, uint timeout);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_async_queue_timeout_pop_unlocked")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint AsyncQueueTimeoutPopUnlocked(AsyncQueue queue, uint timeout);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_async_queue_try_pop")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint AsyncQueueTryPop(AsyncQueue queue);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_async_queue_try_pop_unlocked")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint AsyncQueueTryPopUnlocked(AsyncQueue queue);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_async_queue_unlock")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void AsyncQueueUnlock(AsyncQueue queue);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_async_queue_unref")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void AsyncQueueUnref(nint queue);
}
