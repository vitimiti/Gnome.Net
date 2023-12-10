// This file is part of the Gnome.Net project and is under the MIT license.
// See LICENSE.md for more information.

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

using Gnome.Net.Common;

namespace Gnome.Net.Glib.Imports;

internal static partial class ApiImports
{
    [LibraryImport(
        LibraryName.Glib,
        EntryPoint = "g_bookmark_file_add_application",
        StringMarshalling = StringMarshalling.Utf8
    )]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void BookmarkFileAddApplication(
        BookmarkFile bookmark,
        string uri,
        string? name,
        string? exec
    );

    [LibraryImport(
        LibraryName.Glib,
        EntryPoint = "g_bookmark_file_add_group",
        StringMarshalling = StringMarshalling.Utf8
    )]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void BookmarkFileAddGroup(
        BookmarkFile bookmark,
        string uri,
        string group
    );

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_bookmark_file_copy")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint BookmarkFileCopy(BookmarkFile bookmark);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_bookmark_file_error_quark")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial uint BookmarkFileErrorQuark();

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_bookmark_file_free")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void BookmarkFileFree(nint bookmark);

    [LibraryImport(
        LibraryName.Glib,
        EntryPoint = "g_bookmark_file_get_added_date_time",
        StringMarshalling = StringMarshalling.Utf8
    )]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint BookmarkFileGetAddedDateTime(
        BookmarkFile bookmark,
        string uri,
        out nint error
    );

    [LibraryImport(
        LibraryName.Glib,
        EntryPoint = "g_bookmark_file_get_application_info",
        StringMarshalling = StringMarshalling.Utf8
    )]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static partial bool BookmarkFileGetApplicationInfo(
        BookmarkFile bookmark,
        string uri,
        string name,
        out string? exec,
        out uint count,
        out nint stamp,
        out nint error
    );

    [LibraryImport(
        LibraryName.Glib,
        EntryPoint = "g_bookmark_file_get_applications",
        StringMarshalling = StringMarshalling.Utf8
    )]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    [return: MarshalUsing(typeof(ArrayMarshaller<string, nint>), CountElementName = nameof(length))]
    public static partial string[]? BookmarkFileGetApplications(
        BookmarkFile bookmark,
        string uri,
        out nuint length,
        out nint error
    );

    [LibraryImport(
        LibraryName.Glib,
        EntryPoint = "g_bookmark_file_get_description",
        StringMarshalling = StringMarshalling.Utf8
    )]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial string? BookmarkFileGetDescription(
        BookmarkFile bookmark,
        string uri,
        out nint error
    );

    [LibraryImport(
        LibraryName.Glib,
        EntryPoint = "g_bookmark_file_get_groups",
        StringMarshalling = StringMarshalling.Utf8
    )]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    [return: MarshalUsing(typeof(ArrayMarshaller<string, nint>), CountElementName = nameof(length))]
    public static partial string[]? BookmarkFileGetGroups(
        BookmarkFile bookmark,
        string uri,
        out nuint length,
        out nint error
    );

    [LibraryImport(
        LibraryName.Glib,
        EntryPoint = "g_bookmark_file_get_icon",
        StringMarshalling = StringMarshalling.Utf8
    )]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static partial bool BookmarkFileGetIcon(
        BookmarkFile bookmark,
        string uri,
        out string? href,
        out string? mimeType,
        out nint error
    );

    [LibraryImport(
        LibraryName.Glib,
        EntryPoint = "g_bookmark_file_get_is_private",
        StringMarshalling = StringMarshalling.Utf8
    )]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static partial bool BookmarkFileGetIsPrivate(
        BookmarkFile bookmark,
        string uri,
        out nint error
    );

    [LibraryImport(
        LibraryName.Glib,
        EntryPoint = "g_bookmark_file_get_mime_type",
        StringMarshalling = StringMarshalling.Utf8
    )]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial string? BookmarkFileGetMimeType(
        BookmarkFile bookmark,
        string uri,
        out nint error
    );

    [LibraryImport(
        LibraryName.Glib,
        EntryPoint = "g_bookmark_file_get_modified_date_time",
        StringMarshalling = StringMarshalling.Utf8
    )]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint BookmarkFileGetModifiedDateTime(
        BookmarkFile bookmark,
        string uri,
        out nint error
    );

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_bookmark_file_get_size")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial int BookmarkFileGetSize(BookmarkFile bookmark);

    [LibraryImport(
        LibraryName.Glib,
        EntryPoint = "g_bookmark_file_get_title",
        StringMarshalling = StringMarshalling.Utf8
    )]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial string? BookmarkFileGetTitle(
        BookmarkFile bookmark,
        string? uri,
        out nint error
    );

    [LibraryImport(
        LibraryName.Glib,
        EntryPoint = "g_bookmark_file_get_uris",
        StringMarshalling = StringMarshalling.Utf8
    )]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    [return: MarshalUsing(typeof(ArrayMarshaller<string, nint>), CountElementName = nameof(length))]
    public static partial string[]? BookmarkFileGetUris(BookmarkFile bookmark, out nuint length);

    [LibraryImport(
        LibraryName.Glib,
        EntryPoint = "g_bookmark_file_get_visited_date_time",
        StringMarshalling = StringMarshalling.Utf8
    )]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint BookmarkFileGetVisitedDateTime(
        BookmarkFile bookmark,
        string uri,
        out nint error
    );

    [LibraryImport(
        LibraryName.Glib,
        EntryPoint = "g_bookmark_file_has_application",
        StringMarshalling = StringMarshalling.Utf8
    )]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static partial bool BookmarkFileHasApplication(
        BookmarkFile bookmark,
        string uri,
        string name,
        out nint error
    );

    [LibraryImport(
        LibraryName.Glib,
        EntryPoint = "g_bookmark_file_has_group",
        StringMarshalling = StringMarshalling.Utf8
    )]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static partial bool BookmarkFileHasGroup(
        BookmarkFile bookmark,
        string uri,
        string group,
        out nint error
    );

    [LibraryImport(
        LibraryName.Glib,
        EntryPoint = "g_bookmark_file_has_item",
        StringMarshalling = StringMarshalling.Utf8
    )]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static partial bool BookmarkFileHasItem(BookmarkFile bookmark, string uri);

    [LibraryImport(
        LibraryName.Glib,
        EntryPoint = "g_bookmark_file_load_from_data",
        StringMarshalling = StringMarshalling.Utf8
    )]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static partial bool BookmarkFileLoadFromData(
        BookmarkFile bookmark,
        [MarshalUsing(typeof(ArrayMarshaller<byte, byte>), CountElementName = nameof(length))]
            byte[] data,
        nuint length,
        out nint error
    );

    [LibraryImport(
        LibraryName.Glib,
        EntryPoint = "g_bookmark_file_load_from_data_dirs",
        StringMarshalling = StringMarshalling.Utf8
    )]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static partial bool BookmarkFileLoadFromDataDirs(
        BookmarkFile bookmark,
        string file,
        out string? fullPath,
        out nint error
    );

    [LibraryImport(
        LibraryName.Glib,
        EntryPoint = "g_bookmark_file_load_from_file",
        StringMarshalling = StringMarshalling.Utf8
    )]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static partial bool BookmarkFileLoadFromFile(
        BookmarkFile bookmark,
        string fileName,
        out nint error
    );

    [LibraryImport(
        LibraryName.Glib,
        EntryPoint = "g_bookmark_file_move_item",
        StringMarshalling = StringMarshalling.Utf8
    )]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static partial bool BookmarkFileMoveItem(
        BookmarkFile bookmark,
        string oldUri,
        string? newUri,
        out nint error
    );

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_bookmark_file_new")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint BookmarkFileNew();

    [LibraryImport(
        LibraryName.Glib,
        EntryPoint = "g_bookmark_file_remove_application",
        StringMarshalling = StringMarshalling.Utf8
    )]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static partial bool BookmarkFileRemoveApplication(
        BookmarkFile bookmark,
        string uri,
        string name,
        out nint error
    );

    [LibraryImport(
        LibraryName.Glib,
        EntryPoint = "g_bookmark_file_remove_group",
        StringMarshalling = StringMarshalling.Utf8
    )]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static partial bool BookmarkFileRemoveGroup(
        BookmarkFile bookmark,
        string uri,
        string group,
        out nint error
    );

    [LibraryImport(
        LibraryName.Glib,
        EntryPoint = "g_bookmark_file_remove_item",
        StringMarshalling = StringMarshalling.Utf8
    )]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static partial bool BookmarkFileRemoveItem(
        BookmarkFile bookmark,
        string uri,
        out nint error
    );

    [LibraryImport(
        LibraryName.Glib,
        EntryPoint = "g_bookmark_file_set_added_date_time",
        StringMarshalling = StringMarshalling.Utf8
    )]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void BookmarkFileSetAddedDateTime(
        BookmarkFile bookmark,
        string uri,
        DateTime added
    );

    [LibraryImport(
        LibraryName.Glib,
        EntryPoint = "g_bookmark_file_set_application_info",
        StringMarshalling = StringMarshalling.Utf8
    )]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static partial bool BookmarkFileSetApplicationInfo(
        BookmarkFile bookmark,
        string uri,
        string name,
        string exec,
        int count,
        DateTime? stamp,
        out nint error
    );

    [LibraryImport(
        LibraryName.Glib,
        EntryPoint = "g_bookmark_file_set_description",
        StringMarshalling = StringMarshalling.Utf8
    )]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void BookmarkFileSetDescription(
        BookmarkFile bookmark,
        string? uri,
        string description
    );

    [LibraryImport(
        LibraryName.Glib,
        EntryPoint = "g_bookmark_file_set_groups",
        StringMarshalling = StringMarshalling.Utf8
    )]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void BookmarkFileSetGroups(
        BookmarkFile bookmark,
        string uri,
        [MarshalUsing(typeof(ArrayMarshaller<string, nint>), CountElementName = nameof(length))]
            string[]? groups,
        nuint length
    );

    [LibraryImport(
        LibraryName.Glib,
        EntryPoint = "g_bookmark_file_set_icon",
        StringMarshalling = StringMarshalling.Utf8
    )]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void BookmarkFileSetIcon(
        BookmarkFile bookmark,
        string uri,
        string? href,
        string mimeType
    );

    [LibraryImport(
        LibraryName.Glib,
        EntryPoint = "g_bookmark_file_set_is_private",
        StringMarshalling = StringMarshalling.Utf8
    )]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void BookmarkFileSetIsPrivate(
        BookmarkFile bookmark,
        string uri,
        [MarshalAs(UnmanagedType.Bool)] bool isPrivate
    );

    [LibraryImport(
        LibraryName.Glib,
        EntryPoint = "g_bookmark_file_set_mime_type",
        StringMarshalling = StringMarshalling.Utf8
    )]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void BookmarkFileSetMimeType(
        BookmarkFile bookmark,
        string uri,
        string mimeType
    );

    [LibraryImport(
        LibraryName.Glib,
        EntryPoint = "g_bookmark_file_set_modified_date_time",
        StringMarshalling = StringMarshalling.Utf8
    )]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void BookmarkFileSetModifiedDateTime(
        BookmarkFile bookmark,
        string uri,
        DateTime modified
    );

    [LibraryImport(
        LibraryName.Glib,
        EntryPoint = "g_bookmark_file_set_title",
        StringMarshalling = StringMarshalling.Utf8
    )]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void BookmarkFileSetTitle(
        BookmarkFile bookmark,
        string? uri,
        string title
    );

    [LibraryImport(
        LibraryName.Glib,
        EntryPoint = "g_bookmark_file_set_visited_date_time",
        StringMarshalling = StringMarshalling.Utf8
    )]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void BookmarkFileSetVisitedDateTime(
        BookmarkFile bookmark,
        string uri,
        DateTime visited
    );

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_bookmark_file_to_data")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    [return: MarshalUsing(typeof(ArrayMarshaller<byte, byte>), CountElementName = nameof(length))]
    public static partial byte[] BookmarkFileToData(
        BookmarkFile bookmark,
        out nuint length,
        out nint error
    );

    [LibraryImport(
        LibraryName.Glib,
        EntryPoint = "g_bookmark_file_to_file",
        StringMarshalling = StringMarshalling.Utf8
    )]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static partial bool BookmarkFileToFile(
        BookmarkFile bookmark,
        string filename,
        out nint error
    );
}
