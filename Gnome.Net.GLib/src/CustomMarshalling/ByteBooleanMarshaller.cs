// This file is part of the Gnome.Net project and is under the MIT license.
// See LICENSE.md for more information.

using System.Runtime.InteropServices.Marshalling;

namespace Gnome.Net.GLib.CustomMarshalling;

[CustomMarshaller(typeof(bool), MarshalMode.Default, typeof(ByteBooleanMarshaller))]
internal static class ByteBooleanMarshaller
{
    public static byte ConvertToUnmanaged(bool managed)
    {
        return (byte)(managed ? 1 : 0);
    }

    public static bool ConvertToManaged(byte unmanaged)
    {
        return unmanaged != 0;
    }
}
