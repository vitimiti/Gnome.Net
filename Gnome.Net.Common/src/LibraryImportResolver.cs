// This file is part of the Gnome.Net project and is under the MIT license.
// See LICENSE.md for more information.

using System.Reflection;
using System.Runtime.InteropServices;

namespace Gnome.Net.Common;

/// <summary>
///     This class provides a method for resolving DLL imports by attempting to load a native library with the specified
///     parameters.
/// </summary>
public static class LibraryImportResolver
{
    /// <summary>Resolves the DLL import by attempting to load a native library with the specified parameters.</summary>
    /// <param name="libraryName">The name of the library to load.</param>
    /// <param name="assembly">The assembly in which the library is loaded.</param>
    /// <param name="searchPath">
    ///     The search path to use for locating the library. Can be <see langword="null" />.
    /// </param>
    /// <returns>
    ///     The handle to the loaded library if successful, otherwise <see cref="nint" />.<see cref="nint.Zero" />.
    /// </returns>
    public static nint DllImportResolver(
        string libraryName,
        Assembly assembly,
        DllImportSearchPath? searchPath
    )
    {
        var platformDependentName = LibraryName.GetOsVersionDependentLibraryName(libraryName);
        NativeLibrary.TryLoad(platformDependentName, assembly, searchPath, out var handle);
        return handle;
    }
}
