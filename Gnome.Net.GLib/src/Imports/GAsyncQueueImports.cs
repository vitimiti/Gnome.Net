// This file is part of the Gnome.Net project and is under the MIT license.
// See LICENSE.md for more information.

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

using Gnome.Net.GLib.LibraryUtilities;

namespace Gnome.Net.GLib.Imports;

internal static partial class GLibApi
{
    [LibraryImport(LibraryName.GLib, EntryPoint = "g_async_queue_length")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial int GAsyncQueueLength(GAsyncQueue queue);

    [LibraryImport(LibraryName.GLib, EntryPoint = "g_async_queue_length_unlocked")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial int GAsyncQueueLengthUnlocked(GAsyncQueue queue);

    [LibraryImport(LibraryName.GLib, EntryPoint = "g_async_queue_lock")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void GAsyncQueueLock(GAsyncQueue queue);

    [LibraryImport(LibraryName.GLib, EntryPoint = "g_async_queue_new")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint GAsyncQueueNew();

    [LibraryImport(LibraryName.GLib, EntryPoint = "g_async_queue_pop")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint GAsyncQueuePop(GAsyncQueue queue);

    [LibraryImport(LibraryName.GLib, EntryPoint = "g_async_queue_pop_unlocked")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint GAsyncQueuePopUnlocked(GAsyncQueue queue);

    [LibraryImport(LibraryName.GLib, EntryPoint = "g_async_queue_push")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void GAsyncQueuePush(GAsyncQueue queue, GPointer data);

    [LibraryImport(LibraryName.GLib, EntryPoint = "g_async_queue_push_front")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void GAsyncQueuePushFront(GAsyncQueue queue, GPointer item);

    [LibraryImport(LibraryName.GLib, EntryPoint = "g_async_queue_push_front_unlocked")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void GAsyncQueuePushFrontUnlocked(GAsyncQueue queue, GPointer item);

    [LibraryImport(LibraryName.GLib, EntryPoint = "g_async_queue_push_unlocked")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void GAsyncQueuePushUnlocked(GAsyncQueue queue, GPointer data);

    [LibraryImport(LibraryName.GLib, EntryPoint = "g_async_queue_remove")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static partial bool GAsyncQueueRemove(GAsyncQueue queue, GPointer item);

    [LibraryImport(LibraryName.GLib, EntryPoint = "g_async_queue_remove_unlocked")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static partial bool GAsyncQueueRemoveUnlocked(GAsyncQueue queue, GPointer item);

    [LibraryImport(LibraryName.GLib, EntryPoint = "g_async_queue_timeout_pop")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint GAsyncQueueTimeoutPop(GAsyncQueue queue, uint timeout);

    [LibraryImport(LibraryName.GLib, EntryPoint = "g_async_queue_timeout_pop_unlocked")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint GAsyncQueueTimeoutPopUnlocked(GAsyncQueue queue, uint timeout);

    [LibraryImport(LibraryName.GLib, EntryPoint = "g_async_queue_try_pop")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint GAsyncQueueTryPop(GAsyncQueue queue);

    [LibraryImport(LibraryName.GLib, EntryPoint = "g_async_queue_try_pop_unlocked")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint GAsyncQueueTryPopUnlocked(GAsyncQueue queue);

    [LibraryImport(LibraryName.GLib, EntryPoint = "g_async_queue_unlock")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void GAsyncQueueUnlock(GAsyncQueue queue);

    [LibraryImport(LibraryName.GLib, EntryPoint = "g_async_queue_unref")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void GAsyncQueueUnref(nint queue);
}
