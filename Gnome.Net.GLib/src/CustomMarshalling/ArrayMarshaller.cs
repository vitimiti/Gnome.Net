// This file is part of the Gnome.Net project and is under the MIT license.
// See LICENSE.md for more information.

using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

using Gnome.Net.GLib.Imports;

namespace Gnome.Net.GLib.CustomMarshalling;

[CustomMarshaller(
    typeof(Array<CustomMarshallerAttribute.GenericPlaceholder>),
    MarshalMode.ManagedToUnmanagedIn,
    typeof(ArrayMarshaller<CustomMarshallerAttribute.GenericPlaceholder>)
)]
internal static unsafe class ArrayMarshaller<T>
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct GArrayUnmanaged
    {
        public byte* Data;
        public uint Length;
    }

    public static GArrayUnmanaged* ConvertToUnmanaged(
        Array<CustomMarshallerAttribute.GenericPlaceholder>? managed
    )
    {
        if (managed is null)
        {
            return null;
        }

        var unmanaged = new GArrayUnmanaged { Length = managed.Length };
        if (managed.Length == 0)
        {
            unmanaged.Data = null;
            return &unmanaged;
        }

        var gcHandle = GCHandle.Alloc(managed.Data, GCHandleType.Pinned);
        try
        {
            unmanaged.Data = (byte*)gcHandle.AddrOfPinnedObject();
        }
        finally
        {
            gcHandle.Free();
        }

        return &unmanaged;
    }

    public static void Free(GArrayUnmanaged* unmanaged)
    {
        LibraryApi.ArrayUnref((nint)unmanaged);
    }
}