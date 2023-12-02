// This file is part of the Gnome.Net project and is under the MIT license.
// See LICENSE.md for more information.

using System.Reflection;
using System.Runtime.InteropServices;

namespace Gnome.Net.GLib.Utilities;

internal static class ImportResolver
{
    static ImportResolver()
    {
        Console.WriteLine("TEST");
        NativeLibrary.SetDllImportResolver(Assembly.GetCallingAssembly(), DllResolver);
    }

    private static nint DllResolver(
        string libraryName,
        Assembly assembly,
        DllImportSearchPath? searchPath
    )
    {
        _ = NativeLibrary.TryLoad(libraryName, assembly, searchPath, out var handle);
        return handle;
    }
}
