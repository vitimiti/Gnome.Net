// This file is part of the Gnome.Net project and is under the MIT license.
// See LICENSE.md for more information.

using Gnome.Net.Glib.Imports;

using Microsoft.Win32.SafeHandles;

namespace Gnome.Net.Glib;

/// <summary>Represents a mutex (mutual exclusion).</summary>
/// <remarks>It can be used to protect data against shared access.</remarks>
public class Mutex : SafeHandleMinusOneIsInvalid
{
    /// <summary>Initializes the mutex so that it can be used.</summary>
    /// <param name="ownsHandle"></param>
    public Mutex(bool ownsHandle)
        : base(ownsHandle)
    {
        ApiImports.MutexInit(handle);
    }

    /// <summary>Locks the mutex.</summary>
    /// <remarks>
    ///     <para>
    ///         If the mutex is already locked by another thread, the current thread will block until the mutex is
    ///         unlocked by the other thread.
    ///     </para>
    ///     <para>
    ///         <see cref="Mutex" /> is neither guaranteed to be recursive nor to be non-recursive. As such, calling
    ///         <see cref="Lock" /> on a <see cref="Mutex" /> that has already been locked by the same thread results is
    ///         undefined behaviour (including but not limited to deadlocks).
    ///     </para>
    /// </remarks>
    public void Lock()
    {
        ApiImports.MutexLock(handle);
    }

    /// <summary>Tried to lock the mutex.</summary>
    /// <returns><see langword="true" /> if the mutex was locked, <see langword="false" /> otherwise.</returns>
    /// <remarks>
    ///     <para>
    ///         If the mutex is already locked by another thread, it immediately returns <see langword="false" />.
    ///         Otherwise it locks the mutex and returns <see langword="true" />.
    ///     </para>
    ///     <para>
    ///         <see cref="Mutex" /> is neither guaranteed to be recursive nor to be non-recursive. As such, calling
    ///         <see cref="Lock" /> on a mutex that has already been locked  by the same thread results in undefined
    ///         behaviour (including but not limited to deadlocks or arbitrary return values).
    ///     </para>
    /// </remarks>
    public bool TryLock()
    {
        return ApiImports.MutexTryLock(handle);
    }

    /// <summary>Unlocks the mutex.</summary>
    /// <remarks>
    ///     <para>
    ///         If another thread is blocked in a <see cref="Lock" /> call for mutex, it will become unblocked and can
    ///         lock the mutex itself.
    ///     </para>
    ///     <para>
    ///         Calling <see cref="Unlock" /> on a mutex that is not locked by the current thread leads to undefined
    ///         behaviour.
    ///     </para>
    /// </remarks>
    public void Unlock()
    {
        ApiImports.MutexUnlock(handle);
    }

    /// <summary>Frees the resources allocated to a mutex.</summary>
    /// <returns>Always <see langword="true" />.</returns>
    protected override bool ReleaseHandle()
    {
        if (handle == nint.Zero)
        {
            return true;
        }

        ApiImports.MutexClear(handle);
        handle = nint.Zero;
        return true;
    }
}
