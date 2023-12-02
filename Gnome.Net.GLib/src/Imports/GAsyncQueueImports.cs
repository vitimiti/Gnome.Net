// This file is part of the Gnome.Net project and is under the MIT license.
// See LICENSE.md for more information.

using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

using Gnome.Net.GLib.CustomMarshalling;
using Gnome.Net.GLib.Utilities;

namespace Gnome.Net.GLib.Imports;

internal static partial class GAsyncQueueImports
{
    [LibraryImport(LibraryName.Default, EntryPoint = "g_async_queue_length")]
    public static partial int GAsyncQueueLength(GAsyncQueue queue);

    [LibraryImport(LibraryName.Default, EntryPoint = "g_async_queue_length_unlocked")]
    public static partial int GAsyncQueueLengthUnlocked(GAsyncQueue queue);

    [LibraryImport(LibraryName.Default, EntryPoint = "g_async_queue_lock")]
    public static partial void GAsyncQueueLock(GAsyncQueue queue);

    [LibraryImport(LibraryName.Default, EntryPoint = "g_async_queue_new")]
    public static partial nint GAsyncQueueNew();

    [LibraryImport(LibraryName.Default, EntryPoint = "g_async_queue_pop")]
    public static partial nint GAsyncQueuePop(GAsyncQueue queue);

    [LibraryImport(LibraryName.Default, EntryPoint = "g_async_queue_pop_unlocked")]
    public static partial nint GAsyncQueuePopUnlocked(GAsyncQueue queue);

    [LibraryImport(LibraryName.Default, EntryPoint = "g_async_queue_push")]
    public static partial void GAsyncQueuePush(GAsyncQueue queue, GPointer data);

    [LibraryImport(LibraryName.Default, EntryPoint = "g_async_queue_push_front")]
    public static partial void GAsyncQueuePushFront(GAsyncQueue queue, GPointer item);

    [LibraryImport(LibraryName.Default, EntryPoint = "g_async_queue_push_front_unlocked")]
    public static partial void GAsyncQueuePushFrontUnlocked(GAsyncQueue queue, GPointer item);

    [LibraryImport(LibraryName.Default, EntryPoint = "g_async_queue_push_unlocked")]
    public static partial void GAsyncQueuePushUnlocked(GAsyncQueue queue, GPointer data);

    [LibraryImport(LibraryName.Default, EntryPoint = "g_async_queue_remove")]
    [return: MarshalUsing(typeof(ByteBooleanMarshaller))]
    public static partial bool GAsyncQueueRemove(GAsyncQueue queue, GPointer item);

    [LibraryImport(LibraryName.Default, EntryPoint = "g_async_queue_remove_unlocked")]
    [return: MarshalUsing(typeof(ByteBooleanMarshaller))]
    public static partial bool GAsyncQueueRemoveUnlocked(GAsyncQueue queue, GPointer item);

    [LibraryImport(LibraryName.Default, EntryPoint = "g_async_queue_timeout_pop")]
    public static partial nint GAsyncQueueTimeoutPop(GAsyncQueue queue, uint timeout);

    [LibraryImport(LibraryName.Default, EntryPoint = "g_async_queue_timeout_pop_unlocked")]
    public static partial nint GAsyncQueueTimeoutPopUnlocked(GAsyncQueue queue, uint timeout);

    [LibraryImport(LibraryName.Default, EntryPoint = "g_async_queue_try_pop")]
    public static partial nint GAsyncQueueTryPop(GAsyncQueue queue);

    [LibraryImport(LibraryName.Default, EntryPoint = "g_async_queue_try_pop_unlocked")]
    public static partial nint GAsyncQueueTryPopUnlocked(GAsyncQueue queue);

    [LibraryImport(LibraryName.Default, EntryPoint = "g_async_queue_unlock")]
    public static partial void GAsyncQueueUnlock(GAsyncQueue queue);

    [LibraryImport(LibraryName.Default, EntryPoint = "g_async_queue_unref")]
    public static partial void GAsyncQueueUnref(GAsyncQueue queue);
}
