// This file is part of the Gnome.Net project and is under the MIT license.
// See LICENSE.md for more information.

using Gnome.Net.Glib.Imports;

using Microsoft.Win32.SafeHandles;

namespace Gnome.Net.Glib;

/// <summary>Represents a condition.</summary>
/// <remarks>
///     <para>
///         Threads can block on a <see cref="Cond" /> if they find a certain condition to be <see langword="false" />.
///         If other threads change the state of this condition they signal the <see cref="Cond" />, and that causes the
///         waiting threads to be woken up.
///     </para>
///     <para>
///         Consider the following example of a shared variable. One or more threads can wait for data to be published
///         to the variable and when another thread publishes the data, it can signal one of the waiting threads to wake
///         up to collect the data.
///     </para>
///     <para>
///         Here is an example for using <see cref="Cond" /> to block a thead until a condition is satisfied:
///         <code>
/// var currentData = new Pointer();
/// var mutex = new Mutex();
/// var cond = new Cond();
///
/// void PushData(Pointer data)
/// {
///     mutex.Lock();
///     currentData = data;
///     cond.Signal();
///     mutex.Unlock();
/// }
///
/// Pointer PopData()
/// {
///     var data = new Pointer();
///     mutex.Lock();
///     while (currentData.IsInvalid)
///     {
///         cond.Wait(mutex);
///     }
///
///     data = currentData;
///     currentData = new Pointer();
///     mutex.Unlock();
///     return data;
/// }
///         </code>
///     </para>
///     <para>
///         Whenever a thread calls <c>PopData()</c> now, it will wait until <c>currentData</c> is
///         non-<see langword="null" />, i.e. until some other thread has called <c>PushData()</c>.
///     </para>
///     <para>
///         The example shows that use of a condition variable must always be paired with a mutex. Without the use of a
///         mutex, there would be a race between the check of <c>currentData</c> by the while loop in <c>PopData()</c>
///         and waiting. Specifically, another thread could set <c>currentData</c> after the check, and signal the cond
///         (with nobody waiting on it) before the first thread goes to sleep. <see cref="Cond" /> is specifically
///         useful for its ability to release the mutex and go to sleep atomically.
///     </para>
///     <para>
///         It is also important to use the <see cref="Wait" /> and <see cref="WaitUntil" /> functions only inside a
///         loop which checks for the condition to be true. See <see cref="Wait" /> for an explanation of why the
///         condition may not be true even after it returns.
///     </para>
///     <para>
///         If a <see cref="Cond" /> is allocated in static storage then it can be used without initialisation.
///         Otherwise, you should call <see cref="Cond()" /> on it and <see cref="Cond.ReleaseHandle" /> when done.
///     </para>
/// </remarks>
public class Cond : SafeHandleMinusOneIsInvalid
{
    /// <summary>Initialises a <see cref="Cond" /> so that it can be used.</summary>
    public Cond()
        : base(true)
    {
        ApiImports.CondInit(handle);
    }

    /// <summary>
    ///     If threads are waiting for the cond, all of them are unblocked. If no threads are waiting for the cond, this
    ///     function has no effect.
    /// </summary>
    /// <remarks>
    ///     It is good practice to lock the same mutex as the waiting threads while calling this function, though not
    ///     required.
    /// </remarks>
    public void Broadcast()
    {
        ApiImports.CondBroadcast(handle);
    }

    /// <summary>If threads are waiting for the cond, at least one of them is unblocked.</summary>
    /// <remarks>
    ///     If no threads are waiting for the cond, this function has no effect. It is good practice to hold the same
    ///     lock as the waiting thread while calling this function, though not required.
    /// </remarks>
    public void Signal()
    {
        ApiImports.CondSignal(handle);
    }

    /// <summary>Atomically releases the <paramref name="mutex" /> and waits until the cond is signalled.</summary>
    /// <param name="mutex">A <see cref="Mutex" /> that is currently locked.</param>
    /// <remarks>
    ///     <para>
    ///         When this function returns, <paramref name="mutex" /> is locked again and owned by the calling thread.
    ///     </para>
    ///     <para>
    ///         When using condition variables, it is possible that a spurious wakeup may occur (ie: <see cref="Wait" />
    ///         returns even though <see cref="Signal" /> was not called). It’s also possible that a stolen wakeup may
    ///         occur. This is when <see cref="Signal" /> is called, but another thread acquires
    ///         <paramref name="mutex" /> before this thread and modifies the state of the program in such a way that
    ///         when <see cref="Wait" /> is able to return, the expected condition is no longer met.
    ///     </para>
    ///     <para>
    ///         For this reason, <see cref="Wait" /> must always be used in a loop. See the documentation for
    ///         <see cref="Cond" /> for a complete example.
    ///     </para>
    /// </remarks>
    public void Wait(Mutex mutex)
    {
        ApiImports.CondWait(handle, mutex.DangerousGetHandle());
    }

    /// <summary>Waits until either the cond is signalled or <paramref name="endTime" /> has passed.</summary>
    /// <param name="mutex">A <see cref="Mutex" /> that is currently locked.</param>
    /// <param name="endTime">An <see cref="long" /> with the monotonic time to wait until, in microseconds.</param>
    /// <returns><see langword="true" /> on a signal, <see langword="false" /> on a timeout.</returns>
    /// <remarks>
    ///     <para>
    ///         As with <see cref="Wait" /> it is possible that a spurious or stolen wakeup could occur. For that
    ///         reason, waiting on a condition variable should always be in a loop, based on an explicitly-checked
    ///         predicate.
    ///     </para>
    ///     <para>
    ///         <see langword="true" /> is returned if the condition variable was signalled (or in the case of a
    ///         spurious wakeup). <see langword="false" /> is returned if <paramref name="endTime" /> has passed.
    ///     </para>
    ///     <para>
    ///         The following code shows how to correctly perform a timed wait on a condition variable (extending the
    ///         example presented in the documentation for <see cref="Cond" />):
    ///         <code>
    /// var currentData = new Pointer();
    /// var mutex = new Mutex();
    /// var cond = new Cond();
    ///
    /// void PushData(Pointer data)
    /// {
    ///     mutex.Lock();
    ///     currentData = data;
    ///     cond.Signal();
    ///     mutex.Unlock();
    /// }
    ///
    /// Pointer PopData()
    /// {
    ///     var data = new Pointer();
    ///     mutex.Lock();
    ///     while (currentData.IsInvalid)
    ///     {
    ///         cond.Wait(mutex);
    ///     }
    ///
    ///     data = currentData;
    ///     currentData = new Pointer();
    ///     mutex.Unlock();
    ///     return data;
    /// }
    ///
    /// Pointer PopDataTimed()
    /// {
    ///     mutex.Lock();
    ///     var endTime = Time.MonotonicTime + 5 * TimeSpan.Second // 5 seconds of monotonic time.
    ///     while (currentData.IsInvalid)
    ///     {
    ///         if (!cond.WaitUntil(mutex, endTime))
    ///         {
    ///             // Timeout has passed.
    ///             mutex.Unlock();
    ///             return new Pointer();
    ///         }
    ///     }
    ///
    ///     // There is data for us
    ///     var data = currentData;
    ///     currentData = new Pointer();
    ///     mutex.Unlock();
    ///     return data;
    /// }
    ///         </code>
    ///     </para>
    ///     <para>
    ///         Notice that the end time is calculated once, before entering the loop and reused. This is the motivation
    ///         behind the use of absolute time on this API — if a relative time of 5 seconds were passed directly to
    ///         the call and a spurious wakeup occurred, the program would have to start over waiting again (which would
    ///         lead to a total wait time of more than 5 seconds).
    ///     </para>
    /// </remarks>
    public bool WaitUntil(Mutex mutex, long endTime)
    {
        return ApiImports.CondWaitUntil(handle, mutex.DangerousGetHandle(), endTime);
    }

    /// <summary>Frees the resources allocated to a cond.</summary>
    /// <returns>Always <see langword="true" />.</returns>
    protected override bool ReleaseHandle()
    {
        if (handle == nint.Zero)
        {
            return true;
        }

        ApiImports.CondClear(handle);
        handle = nint.Zero;
        return true;
    }
}
