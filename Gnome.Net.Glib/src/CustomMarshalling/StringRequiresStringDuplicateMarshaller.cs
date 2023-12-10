// This file is part of the Gnome.Net project and is under the MIT license.
// See LICENSE.md for more information.

using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

using Gnome.Net.Glib.Imports;

namespace Gnome.Net.Glib.CustomMarshalling;

[CustomMarshaller(
    typeof(string),
    MarshalMode.Default,
    typeof(StringRequiresStringDuplicateMarshaller)
)]
internal static class StringRequiresStringDuplicateMarshaller
{
    public static nint ConvertToUnmanaged(string? managed)
    {
        return Marshal.StringToCoTaskMemUTF8(managed);
    }

    public static string? ConvertToManaged(nint unmanaged)
    {
        return ApiImports.StringDuplicate(unmanaged);
    }
}
