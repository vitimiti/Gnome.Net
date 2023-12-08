// This file is part of the Gnome.Net project and is under the MIT license.
// See LICENSE.md for more information.

using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Gnome.Net.Glib.CustomMarshalling;

[CustomMarshaller(
    typeof(string[]),
    MarshalMode.Default,
    typeof(NullTerminatedUtf8StringArrayMarshaller)
)]
internal static class NullTerminatedUtf8StringArrayMarshaller
{
    public static string[]? ConvertToManaged(nint unmanaged)
    {
        if (unmanaged == nint.Zero)
        {
            return null;
        }

        var list = new List<string>();
        var elementSize = Marshal.SizeOf<nint>();
        for (var i = 0; i < 256; i++) // Unknown length
        {
            var ptr = Marshal.ReadIntPtr(unmanaged, i * elementSize);
            var str = Marshal.PtrToStringUTF8(ptr);
            if (string.IsNullOrWhiteSpace(str))
            {
                break;
            }

            list.Add(str);
        }

        return list.ToArray();
    }

    public static nint ConvertToUnmanaged(string[]? managed)
    {
        if (managed is null)
        {
            return nint.Zero;
        }

        var managedPtrArray = new nint[managed.Length];
        for (var i = 0; i < managed.Length; i++)
        {
            managedPtrArray[i] = Marshal.StringToCoTaskMemUTF8(managed[i]);
        }

        var ptr = Marshal.AllocHGlobal(Marshal.SizeOf<nint>() * managed.Length);
        Marshal.Copy(managedPtrArray, 0, ptr, managed.Length);
        return ptr;
    }
}
