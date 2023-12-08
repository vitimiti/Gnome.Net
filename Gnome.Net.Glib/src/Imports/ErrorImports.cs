// This file is part of the Gnome.Net project and is under the MIT license.
// See LICENSE.md for more information.

using System.Reflection;
using System.Runtime.InteropServices;

using Gnome.Net.Common;

namespace Gnome.Net.Glib.Imports;

internal static class ErrorImports
{
    static ErrorImports()
    {
        NativeLibrary.SetDllImportResolver(
            Assembly.GetExecutingAssembly(),
            LibraryImportResolver.DllImportResolver
        );
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct UnmanagedError
    {
        public uint Domain;
        public int Code;
        public nint Message;
    }
}
