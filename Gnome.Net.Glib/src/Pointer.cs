// This file is part of the Gnome.Net project and is under the MIT license.
// See LICENSE.md for more information.

using System.Runtime.InteropServices.Marshalling;

using Gnome.Net.Glib.Imports;

using Microsoft.Win32.SafeHandles;

namespace Gnome.Net.Glib;

/// <summary>A safe handle to a GLib pointer.</summary>
[NativeMarshalling(typeof(SafeHandleMarshaller<Pointer>))]
public class Pointer : SafeHandleZeroOrMinusOneIsInvalid
{
    /// <summary>Create the GPointer with an empty GLib pointer.</summary>
    /// <param name="ownsHandle">
    ///     <see langword="true" /> if the GPointer owns the handle, <see langword="false" /> otherwise.
    /// </param>
    public Pointer(bool ownsHandle = true)
        : base(ownsHandle) { }

    /// <summary>Create the GPointer from an existing handle.</summary>
    /// <param name="preexistingHandle">An <see cref="nint" /> with the existing handle.</param>
    /// <param name="ownsHandle">
    ///     <see langword="true" /> if the GPointer owns the handle, <see langword="false" /> otherwise.
    /// </param>
    public Pointer(nint preexistingHandle, bool ownsHandle = true)
        : base(ownsHandle)
    {
        handle = preexistingHandle;
    }

    /// <summary>The releasing system for the internal handle.</summary>
    /// <returns>Always <see langword="true" />.</returns>
    protected override bool ReleaseHandle()
    {
        if (handle == nint.Zero)
        {
            return true;
        }

        CoreImports.Free(handle);
        handle = nint.Zero;
        return true;
    }
}
