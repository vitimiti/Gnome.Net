// This file is part of the Gnome.Net project and is under the MIT license.
// See LICENSE.md for more information.

using System.Runtime.InteropServices;

namespace Gnome.Net.Common;

/// <summary>
///     Represents a library name resolver that provides functionality to resolve platform-dependent library names.
/// </summary>
public struct LibraryName
{
    private static readonly Dictionary<string, bool> GlibNames =
        new()
        {
            { "libglib-2.0-0.dll", OperatingSystem.IsWindows() },
            { "libglib-2.0.0.dylib", OperatingSystem.IsMacOS() },
            { "libglib-2.0.so.0", OperatingSystem.IsLinux() || OperatingSystem.IsFreeBSD() }
        };

    /// <summary>Represents the default filename of the Glib library.</summary>
    public const string Glib = "glib-2.dll";

    internal static string GetOsVersionDependentLibraryName(string libraryName)
    {
        foreach (var name in GlibNames.Where(name => name.Value))
        {
            return name.Key;
        }

        return libraryName;
    }
}
