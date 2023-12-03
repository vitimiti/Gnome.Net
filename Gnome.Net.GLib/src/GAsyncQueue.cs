// This file is part of the Gnome.Net project and is under the MIT license.
// See LICENSE.md for more information.

using System.Runtime.InteropServices.Marshalling;

using Gnome.Net.GLib.Imports;

using Microsoft.Win32.SafeHandles;

namespace Gnome.Net.GLib;

/// <summary>An opaque data structure which represents an asynchronous queue.</summary>
[NativeMarshalling(typeof(SafeHandleMarshaller<GAsyncQueue>))]
public class GAsyncQueue : SafeHandleZeroOrMinusOneIsInvalid
{
    private bool _isLocked;

    /// <summary>Get the length of the queue.</summary>
    /// <value>An <see cref="int" /> with the length of the queue.</value>
    /// <remarks>
    ///     Actually this function returns the number of data items in the queue minus the number of waiting threads, so
    ///     a negative value means waiting threads, and a positive value means available entries in the queue. A return
    ///     value of 0 could mean n entries in the queue and n threads waiting. This can happen due to locking of the
    ///     queue or due to scheduling.
    /// </remarks>
    public int Length =>
        _isLocked
            ? GLibApi.GAsyncQueueLengthUnlocked(this)
            : GLibApi.GAsyncQueueLength(this);

    /// <summary>Creates a new asynchronous queue.</summary>
    public GAsyncQueue()
        : base(true)
    {
        handle = GLibApi.GAsyncQueueNew();
    }

    /// <summary>Acquires the queue‘s lock.</summary>
    /// <remarks>
    ///     <para>
    ///         If another thread is already holding the lock, this call will block until the lock becomes available.
    ///     </para>
    ///     <para>Call <see cref="Unlock" /> to drop the lock again.</para>
    /// </remarks>
    public void Lock()
    {
        GLibApi.GAsyncQueueLock(this);
        _isLocked = true;
    }

    /// <summary>Pops data from the queue.</summary>
    /// <returns>A new <see cref="GPointer" /> with the popped data, or <see langword="null" />.</returns>
    /// <remarks>If queue is empty, this function blocks until data becomes available.</remarks>
    public GPointer? Pop()
    {
        var data = _isLocked
            ? GLibApi.GAsyncQueuePopUnlocked(this)
            : GLibApi.GAsyncQueuePop(this);

        return data == nint.Zero ? null : new GPointer(data);
    }

    /// <summary>Pushes the <paramref name="data" /> into the queue.</summary>
    /// <param name="data">A <see cref="GPointer" /> with the data to push.</param>
    /// <remarks><paramref name="data" /> must hold a valid handle.</remarks>
    public void Push(GPointer data)
    {
        if (_isLocked)
        {
            GLibApi.GAsyncQueuePushUnlocked(this, data);
            return;
        }

        GLibApi.GAsyncQueuePush(this, data);
    }

    /// <summary>Pushes the <paramref name="item" /> into the queue.</summary>
    /// <param name="item">A <see cref="GPointer" /> with the item to push.</param>
    /// <remarks>
    ///     <paramref name="item" /> must hold a valid handle. In contrast to <see cref="Push" />, this function pushes
    ///     the new item ahead of the items already in the queue, so that it will be the next one to be popped off the
    ///     queue.
    /// </remarks>
    public void PushFront(GPointer item)
    {
        if (_isLocked)
        {
            GLibApi.GAsyncQueuePushFrontUnlocked(this, item);
            return;
        }

        GLibApi.GAsyncQueuePushFront(this, item);
    }

    /// <summary>Pops data from the queue.</summary>
    /// <param name="timeout">A <see cref="uint" /> with the number of microseconds to wait.</param>
    /// <returns>Data from the queue or <see langword="null" /> when no data is received before the timeout.</returns>
    /// <remarks>
    ///     <para>
    ///         If the queue is empty, blocks for <paramref name="timeout" /> microseconds, or until data becomes
    ///         available.
    ///     </para>
    ///     <para>
    ///         If no data is received before the timeout, <see langword="null" /> is returned.
    ///     </para>
    /// </remarks>
    public GPointer? TimeoutPop(uint timeout)
    {
        var data = _isLocked
            ? GLibApi.GAsyncQueueTimeoutPopUnlocked(this, timeout)
            : GLibApi.GAsyncQueueTimeoutPop(this, timeout);

        return data == nint.Zero ? null : new GPointer(data);
    }

    /// <summary>Remove an item from the queue.</summary>
    /// <param name="item">A <see cref="GPointer" /> with the data to remove from the queue.</param>
    /// <returns>
    ///     <see langword="true" /> if the <paramref name="item" /> was removed, <see langword="false" /> otherwise.
    /// </returns>
    public bool TryRemove(GPointer item)
    {
        return _isLocked
            ? GLibApi.GAsyncQueueRemoveUnlocked(this, item)
            : GLibApi.GAsyncQueueRemove(this, item);
    }

    /// <summary>Tries to pop data from the queue.</summary>
    /// <returns>
    ///     A new <see cref="GPointer" /> with the popped data or <see langword="null" /> if no data is available.
    /// </returns>
    public GPointer? TryPop()
    {
        var data = _isLocked
            ? GLibApi.GAsyncQueueTryPopUnlocked(this)
            : GLibApi.GAsyncQueueTryPop(this);

        return data == nint.Zero ? null : new GPointer(data);
    }

    /// <summary>Releases the queue’s lock.</summary>
    /// <remarks>
    ///     Calling this function when you have not acquired the with <see cref="Lock" /> leads to undefined behaviour.
    /// </remarks>
    public void Unlock()
    {
        GLibApi.GAsyncQueueUnlock(this);
        _isLocked = false;
    }

    /// <summary>Releases the memory held in the queue.</summary>
    /// <returns>Always <see langword="true" />.</returns>
    protected override bool ReleaseHandle()
    {
        if (_isLocked)
        {
            Unlock();
        }

        if (handle == nint.Zero)
        {
            return true;
        }

        GLibApi.GAsyncQueueUnref(this);
        handle = nint.Zero;
        return true;
    }
}
