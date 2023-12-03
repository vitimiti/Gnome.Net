// This file is part of the Gnome.Net project and is under the MIT license.
// See LICENSE.md for more information.

using System.Reflection;
using System.Runtime.InteropServices;

namespace Gnome.Net.GLib.LibraryUtilities;

internal struct LibraryName
{
    private const string WindowsName = "libglib-2.0.0.dll";
    private const string OsxName = "libglib-2.0.0.dylib";
    private const string UnixName = "libglib-2.0.so.0";

    public const string GLib = "GLib";
    
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
