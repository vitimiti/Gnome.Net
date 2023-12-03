// This file is part of the Gnome.Net project and is under the MIT license.
// See LICENSE.md for more information.

using System.Runtime.InteropServices;

using Gnome.Net.GLib.Utilities;

namespace Gnome.Net.GLib.Imports;

internal static partial class GLibImports
{
    [LibraryImport(LibraryName.Default, EntryPoint = "g_free")]
    public static partial void GFree(nint memory);

    [LibraryImport(
        LibraryName.Default,
        EntryPoint = "g_get_application_name",
        StringMarshalling = StringMarshalling.Utf8
    )]
    public static partial nint GGetApplicationName();

    [LibraryImport(
        LibraryName.Default,
        EntryPoint = "g_get_prgname",
        StringMarshalling = StringMarshalling.Utf8
    )]
    public static partial nint GGetProgramName();

    [LibraryImport(
        LibraryName.Default,
        EntryPoint = "g_set_application_name",
        StringMarshalling = StringMarshalling.Utf8
    )]
    public static partial void GSetApplicationName(string applicationName);

    [LibraryImport(
        LibraryName.Default,
        EntryPoint = "g_set_prgname",
        StringMarshalling = StringMarshalling.Utf8
    )]
    public static partial void GSetProgramName(string applicationName);

    [LibraryImport(
        LibraryName.Default,
        EntryPoint = "g_strdup",
        StringMarshalling = StringMarshalling.Utf8
    )]
    public static partial string? GStringDuplicate(nint strPtr);
}
