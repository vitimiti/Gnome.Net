// This file is part of the Gnome.Net project and is under the MIT license.
// See LICENSE.md for more information.

using System.Runtime.InteropServices.Marshalling;
using System.Text;

using Gnome.Net.GLib.CustomMarshalling;
using Gnome.Net.GLib.ErrorDomains;
using Gnome.Net.GLib.Errors;
using Gnome.Net.GLib.Imports;

using Microsoft.Win32.SafeHandles;

namespace Gnome.Net.GLib;

/// <summary>Represents a set of bookmarks.</summary>
[NativeMarshalling(typeof(SafeHandleMarshaller<BookmarkFile>))]
public class BookmarkFile : SafeHandleZeroOrMinusOneIsInvalid, ICloneable
{
    /// <summary>Gets the number of bookmarks inside the <see cref="BookmarkFile" />.</summary>
    /// <value>An <see cref="int" /> with the number of bookmarks.</value>
    public int Size => LibraryApi.BookmarkFileGetSize(this);

    /// <summary>Gets all URIs of the bookmarks in the bookmark file.</summary>
    /// <value>
    ///     An <see cref="System.Array" /> of <see cref="string" /> with the bookmark URIs, or <see langword="null" />.
    /// </value>
    public string[]? Uris => LibraryApi.BookmarkFileGetUris(this, out _);

    private BookmarkFile(nint preexistingHandle)
        : base(true)
    {
        handle = preexistingHandle;
    }

    /// <summary>Creates a new empty <see cref="BookmarkFile" /> object.</summary>
    /// <remarks>
    ///     Use <see cref="TryLoadFromFile" />, <see cref="TryLoadFromData" /> or
    ///     <see cref="TryLoadFromDataDirectories" /> to read an existing bookmark file.
    /// </remarks>
    public BookmarkFile()
        : base(true)
    {
        handle = LibraryApi.BookmarkFileNew();
    }

    /// <summary>Gets whether the private flag of the bookmark for <paramref name="uri" /> is set.</summary>
    /// <param name="uri">A <see cref="string" /> with the URI.</param>
    /// <param name="error">
    ///     An <see langword="out" /> value to a <see cref="BookmarkFileErrorQuark" /> with
    ///     <a href="https://docs.gtk.org/glib/error-reporting.html#rules-for-use-of-gerror">a recoverable error</a>,
    ///     or <see langword="null" /> if there was no error.
    /// </param>
    /// <returns><see langword="true" /> if the private flag is set, <see langword="false" /> otherwise.</returns>
    /// <remarks>
    ///     In the event the URI cannot be found, <see langword="false" /> is returned and <paramref name="error" /> is
    ///     set to <see cref="BookmarkFileError" />.<see cref="BookmarkFileError.UriNotFound" />. In the event that
    ///     the private flag cannot be found, <see langword="false" /> is returned and <paramref name="error" /> is set
    ///     to <see cref="BookmarkFileError" />.<see cref="BookmarkFileError.InvalidValue" />.
    /// </remarks>
    public bool IsPrivate(string uri, out IErrorQuark? error)
    {
        var result = LibraryApi.BookmarkFileGetIsPrivate(this, uri, out var errorHandle);
        error = ErrorMarshaller.FromUnmanaged(errorHandle);
        return result;
    }

    /// <summary>Sets the private flag of the bookmark for <paramref name="uri" />.</summary>
    /// <param name="uri">A <see cref="string" /> with the URI.</param>
    /// <param name="isPrivate">
    ///     <see langword="true" /> if the bookmark should be marked as private, <see langword="false" /> otherwise.
    /// </param>
    /// <remarks>If a bookmark for <paramref name="uri" /> cannot be found, then it is created.</remarks>
    public void SetIsPrivate(string uri, bool isPrivate)
    {
        LibraryApi.BookmarkFileSetIsPrivate(this, uri, isPrivate);
    }

    /// <summary>
    ///     Checks whether the bookmark for <paramref name="uri" /> inside the <see cref="BookmarkFile" /> has been
    ///     registered by the application with <paramref name="name" />.
    /// </summary>
    /// <param name="uri">A <see cref="string" /> with the URI.</param>
    /// <param name="name">A <see cref="string" /> with the application name.</param>
    /// <param name="error">
    ///     An <see langword="out" /> value to a <see cref="BookmarkFileErrorQuark" /> with
    ///     <a href="https://docs.gtk.org/glib/error-reporting.html#rules-for-use-of-gerror">a recoverable error</a>,
    ///     or <see langword="null" /> if there was no error.
    /// </param>
    /// <returns>
    ///     <see langword="true" /> if the application <paramref name="name" /> was found, <see langword="false" />
    ///     otherwise.
    /// </returns>
    /// <remarks>
    ///     In the event the URI cannot be found, <see langword="false" /> is returned and <paramref name="error" /> is
    ///     set to <see cref="BookmarkFileError" />.<see cref="BookmarkFileError.UriNotFound" />.
    /// </remarks>
    public bool HasApplication(string uri, string name, out IErrorQuark? error)
    {
        var result = LibraryApi.BookmarkFileHasApplication(this, uri, name, out var errorHandle);
        error = ErrorMarshaller.FromUnmanaged(errorHandle);
        return result;
    }

    /// <summary>
    ///     Checks whether <paramref name="group" /> appears in the list of groups to which the bookmark for
    ///     <paramref name="uri" /> belongs to.
    /// </summary>
    /// <param name="uri">A <see cref="string" /> with the URI.</param>
    /// <param name="group">A <see cref="string" /> with the group name to be searched.</param>
    /// <param name="error">
    ///     An <see langword="out" /> value to a <see cref="BookmarkFileErrorQuark" /> with
    ///     <a href="https://docs.gtk.org/glib/error-reporting.html#rules-for-use-of-gerror">a recoverable error</a>,
    ///     or <see langword="null" /> if there was no error.
    /// </param>
    /// <returns>
    ///     <see langword="true" /> if <paramref name="group" /> was found, <see langword="false" /> otherwise.
    /// </returns>
    /// <remarks>
    ///     In the event the URI cannot be found, <see langword="false" /> is returned and <paramref name="error" /> is
    ///     set to <see cref="BookmarkFileError" />.<see cref="BookmarkFileError.UriNotFound" />.
    /// </remarks>
    public bool HasGroup(string uri, string group, out IErrorQuark? error)
    {
        var result = LibraryApi.BookmarkFileHasGroup(this, uri, group, out var errorHandle);
        error = ErrorMarshaller.FromUnmanaged(errorHandle);
        return result;
    }

    /// <summary>Checks whether the desktop bookmark has an item with its URI set to <paramref name="uri" />.</summary>
    /// <param name="uri">A <see cref="string" /> with the URI.</param>
    /// <returns>
    ///     <see langword="true" /> if <paramref name="uri" /> is inside the <see cref="BookmarkFile" />,
    ///     <see langword="false" /> otherwise.
    /// </returns>
    public bool HasItem(string uri)
    {
        return LibraryApi.BookmarkFileHasItem(this, uri);
    }

    /// <inheritdoc cref="TryRemoveItem" />
    /// <summary>
    ///     Gets the time the bookmark for <paramref name="uri" /> was added to the <see cref="BookmarkFile" />.
    /// </summary>
    /// <returns>A new <see cref="DateTime" /> or <see langword="null" /> on error.</returns>
    /// <remarks>
    ///     In the event the URI cannot be found, <see langword="null" /> is returned and <paramref name="error" /> is
    ///     set to <see cref="BookmarkFileError" />.<see cref="BookmarkFileError.UriNotFound" />.
    /// </remarks>
    public DateTime? GetAddedDateTime(string uri, out IErrorQuark? error)
    {
        var result = LibraryApi.BookmarkFileGetAddedDateTime(this, uri, out var errorHandle);
        error = ErrorMarshaller.FromUnmanaged(errorHandle);
        return result == nint.Zero ? null : new DateTime(result);
    }

    /// <summary>
    ///     Sets the time the bookmark for <paramref name="uri" /> was added into the <see cref="BookmarkFile" />.
    /// </summary>
    /// <param name="uri">A <see cref="string" /> with the URI.</param>
    /// <param name="added">A <see cref="DateTime" /> with the added time.</param>
    /// <remarks>If no bookmark for <paramref name="uri" /> is found then it is created.</remarks>
    public void SetAddedDateTime(string uri, DateTime added)
    {
        LibraryApi.BookmarkFileSetAddedDateTime(this, uri, added);
    }

    /// <inheritdoc cref="TryRemoveItem" />
    /// <summary>Gets the time when the bookmark for <paramref name="uri" /> was last modified.</summary>
    /// <returns>A new <see cref="DateTime" />, or <see langword="null" />.</returns>
    /// <remarks>
    ///     In the event the URI cannot be found, <see langword="null" /> is returned and <paramref name="error" /> is
    ///     set to <see cref="BookmarkFileError" />.<see cref="BookmarkFileError.UriNotFound" />.
    /// </remarks>
    public DateTime? GetModifiedDateTime(string uri, out IErrorQuark? error)
    {
        var result = LibraryApi.BookmarkFileGetModifiedDateTime(this, uri, out nint errorHandle);
        error = ErrorMarshaller.FromUnmanaged(errorHandle);
        return result == nint.Zero ? null : new DateTime(result);
    }

    /// <summary>Sets the last time the bookmark for <paramref name="uri" /> was last modified.</summary>
    /// <param name="uri">A <see cref="string" /> with the URI of the application.</param>
    /// <param name="modified">A <see cref="DateTime" /> with the modified time.</param>
    /// <remarks>
    ///     <para>If no bookmark for <paramref name="uri" /> is found then it is created.</para>
    ///     <para>
    ///         The “modified” time should only be set when the bookmark’s meta-data was actually changed. Every
    ///         function of <see cref="BookmarkFile" /> that modifies a bookmark also changes the modification time,
    ///         except for <see cref="SetVisitedDateTime" />.
    ///     </para>
    /// </remarks>
    public void SetModifiedDateTime(string uri, DateTime modified)
    {
        LibraryApi.BookmarkFileSetModifiedDateTime(this, uri, modified);
    }

    /// <inheritdoc cref="TryRemoveItem" />
    /// <summary>Gets the time the bookmark for <paramref name="uri" /> was last visited.</summary>
    /// <returns>A <see cref="DateTime" /> with the last visited time.</returns>
    /// <remarks>
    ///     In the event the URI cannot be found, <see langword="null" /> is returned and <paramref name="error" /> is
    ///     set to <see cref="BookmarkFileError" />.<see cref="BookmarkFileError.UriNotFound" />.
    /// </remarks>
    public DateTime? GetVisitedDateTime(string uri, out IErrorQuark? error)
    {
        var result = LibraryApi.BookmarkFileGetVisitedDateTime(this, uri, out nint errorHandle);
        error = ErrorMarshaller.FromUnmanaged(errorHandle);
        return result == nint.Zero ? null : new DateTime(result);
    }

    /// <summary>Sets the time the bookmark for <paramref name="uri" /> was last visited.</summary>
    /// <param name="uri">A <see cref="string" /> with the URI of the application.</param>
    /// <param name="visited">A <see cref="DateTime" /> with the visited time.</param>
    /// <remarks>
    ///     <para>If no bookmark for <paramref name="uri" /> is found then it is created.</para>
    ///     <para>
    ///         The “visited” time should only be set if the bookmark was launched, either using the command line
    ///         retrieved by <see cref="GetApplicationInfo" /> or by the default application for the bookmark’s MIME
    ///         type, retrieved using <see cref="GetMimeType" /> . Changing the “visited” time does not affect the
    ///         “modified” time.
    ///     </para>
    /// </remarks>
    public void SetVisitedDateTime(string uri, DateTime visited)
    {
        LibraryApi.BookmarkFileSetVisitedDateTime(this, uri, visited);
    }

    /// <inheritdoc cref="TryRemoveItem" />
    /// <summary>
    ///     Gets the names of the applications that have registered the bookmark for <paramref name="uri" />.
    /// </summary>
    /// <returns>
    ///     An <see cref="System.Array" /> of <see cref="string" /> with the applications names, or <see langword="null" />.
    /// </returns>
    /// <remarks>
    ///     In the event the URI cannot be found, <see langword="null" /> is returned and <paramref name="error" /> is
    ///     set to <see cref="BookmarkFileError" />.<see cref="BookmarkFileError.UriNotFound" />.
    /// </remarks>
    public string[]? GetApplications(string uri, out IErrorQuark? error)
    {
        var result = LibraryApi.BookmarkFileGetApplications(this, uri, out _, out var errorHandle);
        error = ErrorMarshaller.FromUnmanaged(errorHandle);
        return result;
    }

    /// <summary>
    ///     Gets the registration information of <paramref name="name" /> for the bookmark for <paramref name="uri" />.
    /// </summary>
    /// <param name="uri">A <see cref="string" /> with the URI of the application.</param>
    /// <param name="name">A <see cref="string" /> with the name of the application.</param>
    /// <param name="error">
    ///     An <see langword="out" /> value to a <see cref="BookmarkFileErrorQuark" /> with
    ///     <a href="https://docs.gtk.org/glib/error-reporting.html#rules-for-use-of-gerror">a recoverable error</a>,
    ///     or <see langword="null" /> if there was no error.
    /// </param>
    /// <returns>
    ///     A tuple made of (<see cref="string" />?, <see cref="uint" />, <see cref="DateTime" />?) with the command
    ///     line of the application, or <see langword="null" />; the registration count and the
    ///     <see cref="DateTime" /> for the last registration time, or <see langword="null" />; respectively.
    /// </returns>
    /// <remarks>
    ///     In the event the URI cannot be found, <see langword="null" /> will be returned and <paramref name="error" />
    ///     is set to <see cref="BookmarkFileError" />.<see cref="BookmarkFileError.UriNotFound" />. In the event that
    ///     no application with <paramref name="name" /> has registered a bookmark for <paramref name="uri" />,
    ///     <see langword="null" /> is returned and <paramref name="error" /> is set to
    ///     <see cref="BookmarkFileError" />.<see cref="BookmarkFileError.AppNotRegistered" />. In the event that
    ///     unquoting the command line fails, an error of the <see cref="ShellError" /> domain is set and
    ///     <see langword="null" /> is returned.
    /// </remarks>
    /// <seealso cref="TrySetApplicationInfo" />
    public (string? Exec, uint Count, DateTime? stamp)? GetApplicationInfo(
        string uri,
        string name,
        out IErrorQuark? error
    )
    {
        var result = LibraryApi.BookmarkFileGetApplicationInfo(
            this,
            uri,
            name,
            out var exec,
            out var count,
            out var stamp,
            out var errorHandle
        );

        error = ErrorMarshaller.FromUnmanaged(errorHandle);
        if (result == false)
        {
            return null;
        }

        return (exec, count, stamp == nint.Zero ? null : new DateTime(stamp));
    }

    /// <inheritdoc cref="TryRemoveItem" />
    /// <summary>Gets the title of the bookmark for <paramref name="uri" />.</summary>
    /// <returns>A <see cref="string" /> with the title, or <see langword="null" />.</returns>
    /// <remarks>
    ///     <para>If <paramref name="uri" /> is <see langword="null" />, the title of the bookmark is returned.</para>
    ///     <para>
    ///         In the event the URI cannot be found, <see langword="null" /> is returned and <paramref name="error" />
    ///         is set to <see cref="BookmarkFileError" />.<see cref="BookmarkFileError.UriNotFound" />.
    ///     </para>
    /// </remarks>
    public string? GetTitle(string? uri, out IErrorQuark? error)
    {
        var result = LibraryApi.BookmarkFileGetTitle(this, uri, out nint errorHandle);
        error = ErrorMarshaller.FromUnmanaged(errorHandle);
        return result;
    }

    /// <summary>Sets <paramref name="title" /> as the title of the bookmark for uri inside the bookmark file.</summary>
    /// <param name="uri">
    ///     A <see cref="string" /> with the URI, or <see langword="nulL" />, or <see langword="null" />.
    /// </param>
    /// <param name="title">A <see cref="string" /> with the title.</param>
    /// <remarks>
    ///     <para>If <paramref name="uri" /> is <see langword="null" />, the title of the bookmark is set.</para>
    ///     <para>If a bookmark for <paramref name="uri" /> cannot be found then it is created.</para>
    /// </remarks>
    public void SetTitle(string? uri, string title)
    {
        LibraryApi.BookmarkFileSetTitle(this, uri, title);
    }

    /// <inheritdoc cref="TryRemoveItem" />
    /// <summary>Gets the description of the bookmark for <paramref name="uri" />.</summary>
    /// <returns>A <see cref="string" /> with the description, or <see langword="null" />.</returns>
    /// <remarks>
    ///     In the event the URI cannot be found, <see langword="null" /> is returned and <paramref name="error" /> is
    ///     set to <see cref="BookmarkFileError" />.<see cref="BookmarkFileError.UriNotFound" />.
    /// </remarks>
    public string? GetDescription(string uri, out IErrorQuark? error)
    {
        var result = LibraryApi.BookmarkFileGetDescription(this, uri, out var errorHandle);
        error = ErrorMarshaller.FromUnmanaged(errorHandle);
        return result;
    }

    /// <summary>
    ///     Sets <paramref name="description" /> as the description of the bookmark for <paramref name="uri" />.
    /// </summary>
    /// <param name="uri">A <see cref="string" /> with the URI, or <see langword="nulL" />.</param>
    /// <param name="description">A <see cref="string"/> with the description.</param>
    /// <remarks>
    ///     <para>
    ///         If <paramref name="uri" /> is <see langword="null" />, the description of the
    ///         <see cref="BookmarkFile" /> is set.
    ///     </para>
    ///     <para>
    ///         If a bookmark for <paramref name="uri" /> cannot be found, then it is created.
    ///     </para>
    /// </remarks>
    public void SetDescription(string? uri, string description)
    {
        LibraryApi.BookmarkFileSetDescription(this, uri, description);
    }

    /// <inheritdoc cref="TryRemoveItem" />
    /// <summary>Gets the list of group names of the bookmark for <paramref name="uri" />.</summary>
    /// <returns>An <see cref="System.Array" /> of <see cref="string" /> with the groups, or <see langword="null" />.</returns>
    /// <remarks>
    ///     In the event the URI cannot be found, <see langword="null" /> is returned and <paramref name="error" /> is
    ///     set to <see cref="BookmarkFileError" />.<see cref="BookmarkFileError.UriNotFound" />.
    /// </remarks>
    public string[]? GetGroups(string uri, out IErrorQuark? error)
    {
        var result = LibraryApi.BookmarkFileGetGroups(this, uri, out var _, out var errorHandle);
        error = ErrorMarshaller.FromUnmanaged(errorHandle);
        return result;
    }

    /// <summary>Sets a list of group names for the item with URI <paramref name="uri" />.</summary>
    /// <param name="uri">A <see cref="string" /> with the URI, or <see langword="nulL" />.</param>
    /// <param name="groups">
    ///     An <see cref="System.Array" /> of <see cref="string" /> with the group names, or <see langword="null" /> to remove
    ///     all groups.
    /// </param>
    /// <remarks>
    ///     <para>Each previously set group name list is removed.</para>
    ///     <para>If <paramref name="uri" /> cannot be found then an item for it is created.</para>
    /// </remarks>
    public void SetGroups(string uri, string[]? groups)
    {
        LibraryApi.BookmarkFileSetGroups(this, uri, groups, (nuint)(groups?.Length ?? 0));
    }

    /// <inheritdoc cref="TryRemoveItem" />
    /// <summary>Gets the icon of the bookmark for <paramref name="uri" />.</summary>
    /// <returns>
    ///     A tuple of (<see cref="string" />?, <see cref="string" />?) with the location and mime type of the icon
    ///     (or <see langword="null" /> if they couldn't be found), or <see langword="null" /> if the icon couldn't be
    ///     found at all.
    /// </returns>
    /// <remarks>
    ///     In the event the URI cannot be found, <see langword="null" /> is returned and <paramref name="error" /> is
    ///     set to <see cref="BookmarkFileError" /><see cref="BookmarkFileError.UriNotFound" />.
    /// </remarks>
    public (string? HRef, string? MimeType)? GetIcon(string uri, out IErrorQuark? error)
    {
        var result = LibraryApi.BookmarkFileGetIcon(
            this,
            uri,
            out var href,
            out var mimeType,
            out nint errorHandle
        );

        error = ErrorMarshaller.FromUnmanaged(errorHandle);
        return result ? (href, mimeType) : null;
    }

    /// <summary>Sets the icon for the bookmark for <paramref name="uri" />.</summary>
    /// <param name="uri">A <see cref="string" /> with the URI, or <see langword="nulL" />.</param>
    /// <param name="href">
    ///     A <see cref="string" /> with the URI of the icon for the bookmark, or <see langword="null" />.
    /// </param>
    /// <param name="mimeType">A <see cref="string" /> with the MIME type of the icon for the bookmark.</param>
    /// <remarks>
    ///     <para>
    ///         If <paramref name="href" /> is <see langword="null" />, unsets the currently set icon.
    ///         <paramref name="href" /> can either be a full URL for the icon file or the icon name following the Icon
    ///         Naming specification.
    ///     </para>
    ///     <para>If no bookmark for <paramref name="uri" /> is found, one is created.</para>
    /// </remarks>
    public void SetIcon(string uri, string? href, string mimeType)
    {
        LibraryApi.BookmarkFileSetIcon(this, uri, href, mimeType);
    }

    /// <inheritdoc cref="TryRemoveItem" />
    /// <summary>Gets the MIME type of the resource pointed by <paramref name="uri" />.</summary>
    /// <returns>A <see cref="string" /> with the MIME type or <see langword="null" />.</returns>
    /// <remarks>
    ///     In the event the URI cannot be found, <see langword="null" /> is returned and <paramref name="error" /> is
    ///     set to <see cref="BookmarkFileError" />.<see cref="BookmarkFileError.UriNotFound" />. In the event that
    ///     the MIME type cannot be found, <see langword="null" /> is returned and <paramref name="error" /> is set to
    ///     <see cref="BookmarkFileError" />.<see cref="BookmarkFileError.InvalidValue" />.
    /// </remarks>
    public string? GetMimeType(string uri, out IErrorQuark? error)
    {
        var result = LibraryApi.BookmarkFileGetMimeType(this, uri, out nint errorHandle);
        error = ErrorMarshaller.FromUnmanaged(errorHandle);
        return result;
    }

    /// <summary>
    ///     Sets the <paramref name="mimeType" /> as the MIME type of the bookmark for <paramref name="uri" />.
    /// </summary>
    /// <param name="uri">A <see cref="string" /> with the URI, or <see langword="nulL" />.</param>
    /// <param name="mimeType">A <see cref="string" /> with the MIME type.</param>
    /// <remarks>If a bookmark for <paramref name="uri" /> cannot be found then it is created.</remarks>
    public void SetMimeType(string uri, string mimeType)
    {
        LibraryApi.BookmarkFileSetMimeType(this, uri, mimeType);
    }

    /// <summary>
    ///     Adds the application with <paramref name="name" /> and <paramref name="exec" /> to the list of applications
    ///     that have registered a bookmark for <paramref name="uri" /> into the bookmark.
    /// </summary>
    /// <param name="uri">A <see cref="string" /> with a valid URI.</param>
    /// <param name="name">
    ///     A <see cref="string" /> with the name of the application registering the bookmark, or
    ///     <see langword="null" />.
    /// </param>
    /// <param name="exec">
    ///     A <see cref="string" /> with the command line to be used to launch the bookmark, or <see langword="null" />.
    /// </param>
    /// <remarks>
    ///     <para>
    ///         Every bookmark inside a <see cref="BookmarkFile" /> must have at least an application registered. Each
    ///         application must provide a name, a command line useful for launching the bookmark, the number of times
    ///         the bookmark has been registered by the application and the last time the application registered this
    ///         bookmark.
    ///     </para>
    ///     <para>
    ///         If <paramref name="name" /> is <see langword="null" />, the name of the application will be the same
    ///         returned by <see cref="Information.ApplicationName" />; if <paramref name="exec" /> is
    ///         <see langword="null" />, the command line will be a composition of the program name as returned by
    ///         <see cref="Information.ProgramName" /> and the “%u” modifier, which will be expanded to the bookmark’s
    ///         URI.
    ///     </para>
    ///     <para>
    ///         This function will automatically take care of updating the registrations count and timestamping in case
    ///         an application with the same <paramref name="name" /> had already registered a bookmark for
    ///         <paramref name="uri" /> inside the bookmark.
    ///     </para>
    ///     <para>If no bookmark for <paramref name="uri" /> is found, one is created.</para>
    /// </remarks>
    public void AddApplication(string uri, string? name, string? exec)
    {
        LibraryApi.BookmarkFileAddApplication(this, uri, name, exec);
    }

    /// <summary>
    ///     Adds <paramref name="group" /> to the list of groups to which the bookmark for <paramref name="uri" />
    ///     belongs to.
    /// </summary>
    /// <param name="uri">A <see cref="string" /> with a valid URI.</param>
    /// <param name="group">A <see cref="string" /> with the group name to be added.</param>
    public void AddGroup(string uri, string group)
    {
        LibraryApi.BookmarkFileAddGroup(this, uri, group);
    }

    /// <summary>Loads a desktop bookmark file into the <see cref="BookmarkFile" /> structure.</summary>
    /// <param name="filename">
    ///     A <see cref="string" /> with the path of a filename to load, in the GLib file name encoding.
    /// </param>
    /// <param name="error">
    ///     An <see langword="out" /> value to a <see cref="BookmarkFileErrorQuark" /> with
    ///     <a href="https://docs.gtk.org/glib/error-reporting.html#rules-for-use-of-gerror">a recoverable error</a>,
    ///     or <see langword="null" /> if there was no error.
    /// </param>
    /// <returns>
    ///     <see langword="true" /> if a desktop bookmark file could be loaded, <see langword="false "/> otherwise.
    /// </returns>
    /// <remarks>
    ///     If the file could not be loaded then <paramref name="error" /> is set to either a <see cref="FileError" />
    ///     or <see cref="BookmarkFileError" />.
    /// </remarks>
    public bool TryLoadFromFile(string filename, out IErrorQuark? error)
    {
        var result = LibraryApi.BookmarkFileLoadFromFile(this, filename, out nint errorHandle);
        error = ErrorMarshaller.FromUnmanaged(errorHandle);
        return result;
    }

    /// <summary>
    ///     Tries to load a bookmark file from memory into an empty <see cref="BookmarkFile" /> structure.
    /// </summary>
    /// <param name="data">
    ///     An <see cref="System.Array" /> of <see cref="byte" /> with the desktop bookmarks loaded in memory.
    /// </param>
    /// <param name="error">
    ///     An <see langword="out" /> value to a <see cref="BookmarkFileErrorQuark" /> with
    ///     <a href="https://docs.gtk.org/glib/error-reporting.html#rules-for-use-of-gerror">a recoverable error</a>,
    ///     or <see langword="null" /> if there was no error.
    /// </param>
    /// <returns>
    ///     <see langword="true" /> if a desktop bookmark could be loaded, <see langword="false" /> otherwise.
    /// </returns>
    /// <remarks>
    ///     If the object cannot be created, then <paramref name="error" /> is set to a
    ///     <see cref="BookmarkFileError" />.
    /// </remarks>
    public bool TryLoadFromData(byte[] data, out IErrorQuark? error)
    {
        var result = LibraryApi.BookmarkFileLoadFromData(
            this,
            data,
            (nuint)data.Length,
            out var errorHandle
        );

        error = ErrorMarshaller.FromUnmanaged(errorHandle);
        return result;
    }

    /// <summary>
    ///     This function looks for a desktop bookmark file named <paramref name="file" /> in the paths returned from
    ///     <see cref="Information.UserDataDir" /> and <see cref="Information.SystemDataDirs" />, loads the file into
    ///     the <see cref="BookmarkFile"/> and returns the file's full path in <paramref name="fullPath" />.
    /// </summary>
    /// <param name="file">A <see cref="string" /> with a valid path to a filename to open and parse.</param>
    /// <param name="fullPath">
    ///     An <see langword="out" /> <see cref="string" /> with the full path of the <paramref name="file" />, or
    ///     <see langword="null" />.
    /// </param>
    /// <param name="error">
    ///     An <see langword="out" /> value to a <see cref="BookmarkFileErrorQuark" /> with
    ///     <a href="https://docs.gtk.org/glib/error-reporting.html#rules-for-use-of-gerror">a recoverable error</a>,
    ///     or <see langword="null" /> if there was no error.
    /// </param>
    /// <returns>
    ///     <see langword="true" /> if a key file could be loaded, <see langword="false" /> otherwise.
    /// </returns>
    /// <remarks>
    ///     If the file could not be loaded, then <paramref name="error" /> is set to either a <see cref="FileError" />
    ///     or <see cref="BookmarkFileError" />.
    /// </remarks>
    public bool TryLoadFromDataDirectories(
        string file,
        out string? fullPath,
        out IErrorQuark? error
    )
    {
        var result = LibraryApi.BookmarkFileLoadFromDataDirs(
            this,
            file,
            out fullPath,
            out nint errorHandle
        );

        error = ErrorMarshaller.FromUnmanaged(errorHandle);
        return result;
    }

    /// <summary>
    ///     Tries to change the URi of a bookmark item from <paramref name="oldUri" /> to <paramref name="newUri" />.
    /// </summary>
    /// <param name="oldUri">A <see cref="string" /> with the old URI.</param>
    /// <param name="newUri">A <see cref="string" /> with the new URI, or <see langword="null" />.</param>
    /// <param name="error">
    ///     An <see langword="out" /> value to a <see cref="BookmarkFileErrorQuark" /> with
    ///     <a href="https://docs.gtk.org/glib/error-reporting.html#rules-for-use-of-gerror">a recoverable error</a>,
    ///     or <see langword="null" /> if there was no error.
    /// </param>
    /// <returns>
    ///     <see langword="true" /> if the URI was successfully changed, <see langword="false "/> otherwise.
    /// </returns>
    /// <remarks>
    ///     <para>
    ///         Any existing bookmark for <paramref name="newUri" /> will be overwritten. If <paramref name="newUri" />
    ///         is <see langword="null" />, then the bookmark is removed.
    ///     </para>
    ///     <para>
    ///         In the event the URI cannot be found, <see langword="false" /> is returned, and
    ///         <paramref name="error" /> is set to
    ///         <see cref="BookmarkFileError" />.<see cref="BookmarkFileError.UriNotFound" />.
    ///     </para>
    /// </remarks>
    public bool TryMoveItem(string oldUri, string? newUri, out IErrorQuark? error)
    {
        var result = LibraryApi.BookmarkFileMoveItem(this, oldUri, newUri, out var errorHandle);
        error = ErrorMarshaller.FromUnmanaged(errorHandle);
        return result;
    }

    /// <summary>
    ///     Tries to remove the bookmark for <paramref name="uri" /> from the bookmark file in the
    ///     <see cref="BookmarkFile" />.
    /// </summary>
    /// <param name="uri">A <see cref="string" /> with the URI.</param>
    /// <param name="error">
    ///     An <see langword="out" /> value to a <see cref="BookmarkFileErrorQuark" /> with
    ///     <a href="https://docs.gtk.org/glib/error-reporting.html#rules-for-use-of-gerror">a recoverable error</a>,
    ///     or <see langword="null" /> if there was no error.
    /// </param>
    /// <returns>
    ///     <see langword="true" /> if the bookmark was removed successfully, <see langword="false" /> otherwise.
    /// </returns>
    public bool TryRemoveItem(string uri, out IErrorQuark? error)
    {
        var result = LibraryApi.BookmarkFileRemoveItem(this, uri, out var errorHandle);
        error = ErrorMarshaller.FromUnmanaged(errorHandle);
        return result;
    }

    /// <summary>
    ///     Tries to set the meta-data of application <paramref name="name" /> inside the list of applications that have
    ///     registered a bookmark for <paramref name="uri" /> inside the <see cref="BookmarkFile" />.
    /// </summary>
    /// <param name="uri">A <see cref="string" /> with the URI.</param>
    /// <param name="name">A <see cref="string" /> with the application name.</param>
    /// <param name="exec">A <see cref="string" /> with the application's command line.</param>
    /// <param name="count">An <see cref="int" /> with the number of registrations done for this application.</param>
    /// <param name="stamp">
    ///     A <see cref="DateTime" /> with the time of the last registration for this application, which may be
    ///     <see langword="null" /> if <paramref name="count" /> is 0.
    /// </param>
    /// <param name="error">
    ///     An <see langword="out" /> value to a <see cref="BookmarkFileErrorQuark" /> with
    ///     <a href="https://docs.gtk.org/glib/error-reporting.html#rules-for-use-of-gerror">a recoverable error</a>,
    ///     or <see langword="null" /> if there was no error.
    /// </param>
    /// <returns>
    ///     <see langword="true" /> if the application's meta-data was successfully changed, <see langword="false" />
    ///     otherwise.
    /// </returns>
    /// <remarks>
    ///     <para>
    ///         You should rarely use this function; use <see cref="AddApplication" /> and
    ///         <see cref="TryRemoveApplication" /> instead.
    ///     </para>
    ///     <para>
    ///         <paramref name="name" /> can be any UTF-8 encoded string used to identify an application.
    ///         <paramref name="exec" /> can have one of these two modifiers: “\%f”, which will be expanded as the local
    ///         file name retrieved from the bookmark’s URI; “\%u”, which will be expanded as the bookmark’s URI. The
    ///         expansion is done automatically when retrieving the stored command line using the
    ///         <see cref="GetApplicationInfo" /> function. <paramref name="count" /> is the number of times the
    ///         application has registered the bookmark; if is <![CDATA[<]]> 0, the current registration count will be
    ///         increased by one, if is 0, the application with <paramref name="name" /> will be removed from the list
    ///         of registered applications. <paramref name="stamp" /> is the Unix time of the last registration.
    ///     </para>
    ///     <para>
    ///         If you try to remove an application by setting its registration count to zero, and no bookmark for
    ///         <paramref name="uri" /> is found, <see langword="false" /> is returned and <paramref name="error" /> is
    ///         set to <see cref="BookmarkFileError" />.<see cref="BookmarkFileError.UriNotFound" />; similarly, in
    ///         the event that no application <paramref name="name" /> has registered a bookmark for
    ///         <paramref name="uri" />, <see langword="false" /> is returned and error is set to
    ///         <see cref="BookmarkFileError" />.<see cref="BookmarkFileError.AppNotRegistered" />. Otherwise, if no
    ///         bookmark for <paramref name="uri" /> is found, one is created.
    ///     </para>
    /// </remarks>
    public bool TrySetApplicationInfo(
        string uri,
        string name,
        string exec,
        int count,
        DateTime? stamp,
        out IErrorQuark? error
    )
    {
        var result = LibraryApi.BookmarkFileSetApplicationInfo(
            this,
            uri,
            name,
            exec,
            count,
            stamp,
            out var errorHandle
        );

        error = ErrorMarshaller.FromUnmanaged(errorHandle);
        return result;
    }

    /// <summary>
    ///     Tries to remove the application registered with <paramref name="name" /> from the list of applications that
    ///     have registered a bookmark for <paramref name="uri" /> inside the <see cref="BookmarkFile" />.
    /// </summary>
    /// <param name="uri">A <see cref="string" /> with the URI.</param>
    /// <param name="name">A <see cref="string" /> with the application name.</param>
    /// <param name="error">
    ///     An <see langword="out" /> value to a <see cref="BookmarkFileErrorQuark" /> with
    ///     <a href="https://docs.gtk.org/glib/error-reporting.html#rules-for-use-of-gerror">a recoverable error</a>,
    ///     or <see langword="null" /> if there was no error.
    /// </param>
    /// <returns>
    ///     <see langword="true" /> if the application was successfully removed, <see langword="false" /> otherwise.
    /// </returns>
    /// <remarks>
    ///     In the event the URI cannot be found, <see langword="false" /> is returned and <paramref name="error" /> is
    ///     set to <see cref="BookmarkFileError" />.<see cref="BookmarkFileError.UriNotFound" />. In the event that no
    ///     application with <paramref name="name" /> has registered a bookmark for <paramref name="uri" />,
    ///     <see langword="false" /> is returned and <paramref name="error" /> is set to
    ///     <see cref="BookmarkFileError" />.<see cref="BookmarkFileError.AppNotRegistered" />.
    /// </remarks>
    public bool TryRemoveApplication(string uri, string name, out IErrorQuark? error)
    {
        var result = LibraryApi.BookmarkFileRemoveApplication(this, uri, name, out var errorHandle);
        error = ErrorMarshaller.FromUnmanaged(errorHandle);
        return result;
    }

    /// <summary>
    ///     Tries to remove <paramref name="group" /> from the list of groups to which the <see cref="BookmarkFile" />
    ///     for <paramref name="uri" /> belongs to.
    /// </summary>
    /// <param name="uri">A <see cref="string" /> with the URI.</param>
    /// <param name="group">A <see cref="string" /> with the group name.</param>
    /// <param name="error">
    ///     An <see langword="out" /> value to a <see cref="BookmarkFileErrorQuark" /> with
    ///     <a href="https://docs.gtk.org/glib/error-reporting.html#rules-for-use-of-gerror">a recoverable error</a>,
    ///     or <see langword="null" /> if there was no error.
    /// </param>
    /// <returns>
    ///     <see langword="true" /> if <paramref name="group" /> was successfully removed, <see langword="false" />
    ///     otherwise.
    /// </returns>
    /// <remarks>
    ///     In the event the URI cannot be found, <see langword="false" /> is returned and <paramref name="error" /> is
    ///     set to <see cref="BookmarkFileError" />.<see cref="BookmarkFileError.UriNotFound" />. In the event no
    ///     <paramref name="group" /> was defined, <see langword="false" /> is returned and error is set to
    ///     <see cref="BookmarkFileError" />.<see cref="BookmarkFileError.InvalidValue" />.
    /// </remarks>
    public bool TryRemoveGroup(string uri, string group, out IErrorQuark? error)
    {
        var result = LibraryApi.BookmarkFileRemoveGroup(this, uri, group, out var errorHandle);
        error = ErrorMarshaller.FromUnmanaged(errorHandle);
        return result;
    }

    /// <summary>This function outputs the <see cref="BookmarkFile" /> as a string.</summary>
    /// <param name="error">
    ///     An <see langword="out" /> value to a <see cref="BookmarkFileErrorQuark" /> with
    ///     <a href="https://docs.gtk.org/glib/error-reporting.html#rules-for-use-of-gerror">a recoverable error</a>,
    ///     or <see langword="null" /> if there was no error.
    /// </param>
    /// <returns>A <see cref="string" /> holding the contents of the <see cref="BookmarkFile" />.</returns>
    public string ToData(out IErrorQuark? error)
    {
        var result = LibraryApi.BookmarkFileToData(this, out _, out var errorHandle);
        error = ErrorMarshaller.FromUnmanaged(errorHandle);
        return Encoding.Default.GetString(result);
    }

    /// <summary>This function outputs the bookmark into a file.</summary>
    /// <param name="filename">A <see cref="string" /> with the file name.</param>
    /// <param name="error">
    ///     An <see langword="out" /> value to a <see cref="BookmarkFileErrorQuark" /> with
    ///     <a href="https://docs.gtk.org/glib/error-reporting.html#rules-for-use-of-gerror">a recoverable error</a>,
    ///     or <see langword="null" /> if there was no error.
    /// </param>
    /// <returns>
    ///     <see langword="true" /> if the file was successfully written, <see langword="false" /> otherwise.
    /// </returns>
    /// <remarks>
    ///     The write process is guaranteed to be atomic by using
    ///     <see cref="Io.TrySetFileContents(string,string,out Gnome.Net.GLib.ErrorDomains.IErrorQuark?)" />.
    /// </remarks>
    public bool ToFile(string filename, out IErrorQuark? error)
    {
        var result = LibraryApi.BookmarkFileToFile(this, filename, out var errorHandle);
        error = ErrorMarshaller.FromUnmanaged(errorHandle);
        return result;
    }

    /// <summary>Frees the bookmark.</summary>
    /// <returns>Always <see langword="true" />.</returns>
    protected override bool ReleaseHandle()
    {
        if (handle == nint.Zero)
        {
            return true;
        }

        LibraryApi.BookmarkFileFree(handle);
        handle = nint.Zero;
        return true;
    }

    /// <summary>Deeply copies the bookmark object to a new one.</summary>
    /// <returns>A new <see cref="object" /> which is a <see cref="BookmarkFile" /> copy of this bookmark.</returns>
    public object Clone()
    {
        return new BookmarkFile(LibraryApi.BookmarkFileCopy(this));
    }
}