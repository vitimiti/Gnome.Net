// This file is part of the Gnome.Net project and is under the MIT license.
// See LICENSE.md for more information.

using System.Reflection;
using System.Runtime.InteropServices;

namespace Gnome.Net.Common;

/// <summary>
///     Represents a library name resolver that provides functionality to resolve platform-dependent library names.
/// </summary>
public struct LibraryName
{
    private static readonly Dictionary<PlatformID, string> GlibNames =
        new()
        {
            { PlatformID.Win32NT, "libglib-2.0-0.dll" },
            { PlatformID.MacOSX, "libglib-2.0.0.dylib" },
            { PlatformID.Unix, "libglib-2.0.so.0" }
        };

    /// <summary>Represents the default filename of the Glib library.</summary>
    public const string Glib = "glib-2.dll";

    internal static string GetOsVersionDependentLibraryName(string libraryName)
    {
        return libraryName switch
        {
            Glib
                => Environment.OSVersion.Platform switch
                {
                    PlatformID.Win32NT => GlibNames[PlatformID.Win32NT],
                    PlatformID.MacOSX => GlibNames[PlatformID.MacOSX],
                    PlatformID.Unix => GlibNames[PlatformID.Unix],
                    _ => libraryName,
                },
            _ => libraryName,
        };
    }
}
