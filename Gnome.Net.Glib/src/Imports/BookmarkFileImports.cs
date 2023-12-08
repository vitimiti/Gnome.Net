// This file is part of the Gnome.Net project and is under the MIT license.
// See LICENSE.md for more information.

using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

using Gnome.Net.Common;

namespace Gnome.Net.Glib.Imports;

internal static partial class BookmarkFileImports
{
    static BookmarkFileImports()
    {
        NativeLibrary.SetDllImportResolver(
            Assembly.GetExecutingAssembly(),
            LibraryImportResolver.DllImportResolver
        );
    }

    [LibraryImport(
        LibraryName.Glib,
        EntryPoint = "g_bookmark_file_add_application",
        StringMarshalling = StringMarshalling.Utf8
    )]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void AddApplication(
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
    public static partial void AddGroup(BookmarkFile bookmark, string uri, string group);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_bookmark_file_copy")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint Copy(BookmarkFile bookmark);

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_bookmark_file_error_quark")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial uint ErrorQuark();

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_bookmark_file_free")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void Free(nint bookmark);

    [LibraryImport(
        LibraryName.Glib,
        EntryPoint = "g_bookmark_file_get_added_date_time",
        StringMarshalling = StringMarshalling.Utf8
    )]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint GetAddedDateTime(BookmarkFile bookmark, string uri, out nint error);

    [LibraryImport(
        LibraryName.Glib,
        EntryPoint = "g_bookmark_file_get_application_info",
        StringMarshalling = StringMarshalling.Utf8
    )]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static partial bool GetApplicationInfo(
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
    public static partial string[]? GetApplications(
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
    public static partial string? GetDescription(BookmarkFile bookmark, string uri, out nint error);

    [LibraryImport(
        LibraryName.Glib,
        EntryPoint = "g_bookmark_file_get_groups",
        StringMarshalling = StringMarshalling.Utf8
    )]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    [return: MarshalUsing(typeof(ArrayMarshaller<string, nint>), CountElementName = nameof(length))]
    public static partial string[]? GetGroups(
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
    public static partial bool GetIcon(
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
    public static partial bool GetIsPrivate(BookmarkFile bookmark, string uri, out nint error);

    [LibraryImport(
        LibraryName.Glib,
        EntryPoint = "g_bookmark_file_get_mime_type",
        StringMarshalling = StringMarshalling.Utf8
    )]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial string? GetMimeType(BookmarkFile bookmark, string uri, out nint error);

    [LibraryImport(
        LibraryName.Glib,
        EntryPoint = "g_bookmark_file_get_modified_date_time",
        StringMarshalling = StringMarshalling.Utf8
    )]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint GetModifiedDateTime(
        BookmarkFile bookmark,
        string uri,
        out nint error
    );

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_bookmark_file_get_size")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial int GetSize(BookmarkFile bookmark);

    [LibraryImport(
        LibraryName.Glib,
        EntryPoint = "g_bookmark_file_get_title",
        StringMarshalling = StringMarshalling.Utf8
    )]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial string? GetTitle(BookmarkFile bookmark, string? uri, out nint error);

    [LibraryImport(
        LibraryName.Glib,
        EntryPoint = "g_bookmark_file_get_uris",
        StringMarshalling = StringMarshalling.Utf8
    )]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    [return: MarshalUsing(typeof(ArrayMarshaller<string, nint>), CountElementName = nameof(length))]
    public static partial string[]? GetUris(BookmarkFile bookmark, out nuint length);

    [LibraryImport(
        LibraryName.Glib,
        EntryPoint = "g_bookmark_file_get_visited_date_time",
        StringMarshalling = StringMarshalling.Utf8
    )]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint GetVisitedDateTime(
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
    public static partial bool HasApplication(
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
    public static partial bool HasGroup(
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
    public static partial bool HasItem(BookmarkFile bookmark, string uri);

    [LibraryImport(
        LibraryName.Glib,
        EntryPoint = "g_bookmark_file_load_from_data",
        StringMarshalling = StringMarshalling.Utf8
    )]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static partial bool LoadFromData(
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
    public static partial bool LoadFromDataDirs(
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
    public static partial bool LoadFromFile(BookmarkFile bookmark, string fileName, out nint error);

    [LibraryImport(
        LibraryName.Glib,
        EntryPoint = "g_bookmark_file_move_item",
        StringMarshalling = StringMarshalling.Utf8
    )]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static partial bool MoveItem(
        BookmarkFile bookmark,
        string oldUri,
        string? newUri,
        out nint error
    );

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_bookmark_file_new")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint New();

    [LibraryImport(
        LibraryName.Glib,
        EntryPoint = "g_bookmark_file_remove_application",
        StringMarshalling = StringMarshalling.Utf8
    )]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static partial bool RemoveApplication(
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
    public static partial bool RemoveGroup(
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
    public static partial bool RemoveItem(BookmarkFile bookmark, string uri, out nint error);

    [LibraryImport(
        LibraryName.Glib,
        EntryPoint = "g_bookmark_file_set_added_date_time",
        StringMarshalling = StringMarshalling.Utf8
    )]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void SetAddedDateTime(BookmarkFile bookmark, string uri, DateTime added);

    [LibraryImport(
        LibraryName.Glib,
        EntryPoint = "g_bookmark_file_set_application_info",
        StringMarshalling = StringMarshalling.Utf8
    )]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static partial bool SetApplicationInfo(
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
    public static partial void SetDescription(
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
    public static partial void SetGroups(
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
    public static partial void SetIcon(
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
    public static partial void SetIsPrivate(
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
    public static partial void SetMimeType(BookmarkFile bookmark, string uri, string mimeType);

    [LibraryImport(
        LibraryName.Glib,
        EntryPoint = "g_bookmark_file_set_modified_date_time",
        StringMarshalling = StringMarshalling.Utf8
    )]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void SetModifiedDateTime(
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
    public static partial void SetTitle(BookmarkFile bookmark, string? uri, string title);

    [LibraryImport(
        LibraryName.Glib,
        EntryPoint = "g_bookmark_file_set_visited_date_time",
        StringMarshalling = StringMarshalling.Utf8
    )]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void SetVisitedDateTime(
        BookmarkFile bookmark,
        string uri,
        DateTime visited
    );

    [LibraryImport(LibraryName.Glib, EntryPoint = "g_bookmark_file_to_data")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    [return: MarshalUsing(typeof(ArrayMarshaller<byte, byte>), CountElementName = nameof(length))]
    public static partial byte[] ToData(BookmarkFile bookmark, out nuint length, out nint error);

    [LibraryImport(
        LibraryName.Glib,
        EntryPoint = "g_bookmark_file_to_file",
        StringMarshalling = StringMarshalling.Utf8
    )]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static partial bool ToFile(BookmarkFile bookmark, string filename, out nint error);
}
