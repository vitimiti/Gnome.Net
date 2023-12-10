// This file is part of the Gnome.Net project and is under the MIT license.
// See LICENSE.md for more information.

using System.Runtime.InteropServices;

namespace Gnome.Net.Glib.Imports;

internal static partial class ApiImports
{
    [StructLayout(LayoutKind.Sequential)]
    public struct UnmanagedError
    {
        public uint Domain;
        public int Code;
        public nint Message;
    }
}
