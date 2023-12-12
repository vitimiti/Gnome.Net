// This file is part of the Gnome.Net project and is under the MIT license.
// See LICENSE.md for more information.

using System.Runtime.InteropServices;

using Gnome.Net.Glib.Imports;

using Microsoft.Win32.SafeHandles;

namespace Gnome.Net.Glib;

/// <summary>A safe handle to a GLib pointer.</summary>
public sealed class Pointer : SafeHandleZeroOrMinusOneIsInvalid
{
    /// <summary>Gets the data represented as a read-only span of bytes.</summary>
    /// <value>A <see cref="ReadOnlySpan{T}" /> of <see cref="byte" />.</value>
    /// <remarks>This property retrieves the data stored in the handle as a read-only span of bytes.</remarks>
    public ReadOnlySpan<byte> Data
    {
        get
        {
            var list = new List<byte>();
            var elementSize = Marshal.SizeOf<nint>();
            var lastByte = (byte)1;
            var index = 0;
            while (lastByte != 0)
            {
                var ptr = Marshal.ReadIntPtr(handle, index * elementSize);
                lastByte = Marshal.ReadByte(ptr);
                list.Add(lastByte);
                index += 1;
            }

            return list.ToArray();
        }
    }

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

        ApiImports.Free(handle);
        handle = nint.Zero;
        return true;
    }
}
