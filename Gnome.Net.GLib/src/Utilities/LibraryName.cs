// This file is part of the Gnome.Net project and is under the MIT license.
// See LICENSE.md for more information.

using System.Runtime.InteropServices;

namespace Gnome.Net.GLib.Utilities;

internal static class LibraryName
{
    private const string Windows = "libglib-2.0.0.dll";
    private const string OsX = "libglib-2.0.0.dylib";
    private const string Unix = "libglib-2.0.so.0";

    public const string Default = "GLib";

    public static string GetOsSpecificName(string currentName)
    {
        if (currentName != Default)
        {
            return currentName;
        }

        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            return Windows;
        }

        if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
        {
            return OsX;
        }

        if (
            RuntimeInformation.IsOSPlatform(OSPlatform.Linux)
            || RuntimeInformation.IsOSPlatform(OSPlatform.FreeBSD)
        )
        {
            return Unix;
        }

        return currentName;
    }
}
