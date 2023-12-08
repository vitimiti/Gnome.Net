// This file is part of the Gnome.Net project and is under the MIT license.
// See LICENSE.md for more information.

using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

using Gnome.Net.Common;

namespace Gnome.Net.Glib.Imports;

internal static partial class AsyncQueueImports
{
    static AsyncQueueImports()
    {
        NativeLibrary.SetDllImportResolver(
            Assembly.GetExecutingAssembly(),
            LibraryImportResolver.DllImportResolver
        );
    }

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_async_queue_length")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial int Length(AsyncQueue queue);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_async_queue_length_unlocked")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial int LengthUnlocked(AsyncQueue queue);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_async_queue_lock")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void Lock(AsyncQueue queue);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_async_queue_new")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint New();

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_async_queue_pop")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint Pop(AsyncQueue queue);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_async_queue_pop_unlocked")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint PopUnlocked(AsyncQueue queue);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_async_queue_push")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void Push(AsyncQueue queue, Pointer data);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_async_queue_push_front")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void PushFront(AsyncQueue queue, Pointer item);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_async_queue_push_front_unlocked")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void PushFrontUnlocked(AsyncQueue queue, Pointer item);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_async_queue_push_unlocked")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void PushUnlocked(AsyncQueue queue, Pointer data);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_async_queue_remove")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static partial bool Remove(AsyncQueue queue, Pointer item);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_async_queue_remove_unlocked")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static partial bool RemoveUnlocked(AsyncQueue queue, Pointer item);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_async_queue_timeout_pop")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint TimeoutPop(AsyncQueue queue, uint timeout);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_async_queue_timeout_pop_unlocked")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint TimeoutPopUnlocked(AsyncQueue queue, uint timeout);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_async_queue_try_pop")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint TryPop(AsyncQueue queue);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_async_queue_try_pop_unlocked")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint TryPopUnlocked(AsyncQueue queue);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_async_queue_unlock")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void Unlock(AsyncQueue queue);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_async_queue_unref")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void Unref(nint queue);
}
