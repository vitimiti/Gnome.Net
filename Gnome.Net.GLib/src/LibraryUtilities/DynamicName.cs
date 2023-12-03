// This file is part of the Gnome.Net project and is under the MIT license.
// See LICENSE.md for more information.

using System.Reflection;
using System.Runtime.InteropServices;

using Microsoft.VisualBasic;

namespace Gnome.Net.GLib.LibraryUtilities;

internal static class DynamicName
{
    private static string GetOsVersionDependentLibraryName(string libraryName)
    {
        return libraryName switch
        {
            LibraryName.GLib
                => Environment.OSVersion.Platform switch
                {
                    PlatformID.Win32NT => LibraryName.OsxName,
                    PlatformID.MacOSX => LibraryName.OsxName,
                    PlatformID.Unix => LibraryName.UnixName,
                    _ => libraryName,
                },
            _ => libraryName,
        };
    }

    public static nint DllImportResolver(
        string libraryName,
        Assembly assembly,
        DllImportSearchPath? searchPath
    )
    {
        var platformDependentName = GetOsVersionDependentLibraryName(libraryName);

        NativeLibrary.TryLoad(platformDependentName, assembly, searchPath, out var handle);
        return handle;
    }
}
