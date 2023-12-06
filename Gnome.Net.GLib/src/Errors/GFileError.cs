// This file is part of the Gnome.Net project and is under the MIT license.
// See LICENSE.md for more information.

namespace Gnome.Net.GLib.Errors;

using ErrorDomains;

/// <summary>Error codes corresponding to <c>errno</c> codes returned from file operations on UNIX.</summary>
/// <remarks>
///     Unlike <c>errno</c> codes, <see cref="GFileError" /> values are available on all systems, even Windows. The
///     exact meaning of each code depends on what sort of file operation you were performing; the UNIX documentation
///     gives more details. The following error code descriptions come from the GNU C Library manual, and are under the
///     copyright of that manual.
/// </remarks>
public enum GFileError
{
    /// <summary>
    ///     Operation not permitted; only the owner of the file (or other resource) or processes with special privileges
    ///     can perform the operation.
    /// </summary>
    Exist,

    /// <summary>
    ///     File is a directory; you cannot open a directory for writing, or create or remove hard links to it.
    /// </summary>
    IsDir,

    /// <summary>Permission denied; the file permissions do not allow the attempted operation.</summary>
    Access,

    /// <summary>Filename too long.</summary>
    NameTooLong,

    /// <summary>
    ///     No such file or directory. This is a “file doesn’t exist” error for ordinary files that are referenced in
    ///     contexts where they are expected to already exist.
    /// </summary>
    NoEnt,

    /// <summary>A file that isn’t a directory was specified when a directory is required.</summary>
    NotDir,

    /// <summary>
    ///     No such device or address. The system tried to use the device represented by a file you specified, and it
    ///     couldn’t find the device. This can mean that the device file was installed incorrectly, or that the physical
    ///     device is missing or not correctly attached to the computer.
    /// </summary>
    NxIo,

    /// <summary>The underlying file system of the specified file does not support memory mapping.</summary>
    NoDev,

    /// <summary>
    ///     The directory containing the new link can’t be modified because it’s on a read-only file system.
    /// </summary>
    RoFs,

    /// <summary>Text file busy.</summary>
    TxtBsy,

    /// <summary>
    ///     You passed in a pointer to bad memory. (GLib won’t reliably return this, don’t pass in pointers to bad
    ///     memory).
    /// </summary>
    Fault,

    /// <summary>
    ///     Too many levels of symbolic links were encountered in looking up a file name. This often indicates a cycle
    ///     of symbolic links.
    /// </summary>
    Loop,

    /// <summary>No space left on device; write operation on a file failed because the disk is full.</summary>
    NoSpc,

    /// <summary>
    ///     No memory available. The system cannot allocate more virtual memory because its capacity is full.
    /// </summary>
    NoMem,

    /// <summary>
    ///     The current process has too many files open and can’t open any more. Duplicate descriptors do count toward
    ///     this limit.
    /// </summary>
    MFile,

    /// <summary>There are too many distinct file openings in the entire system.</summary>
    NFile,

    /// <summary>
    ///     Bad file descriptor; for example, I/O on a descriptor that has been closed or reading from a descriptor open
    ///     only for writing (or vice versa).
    /// </summary>
    BadF,

    /// <summary>
    ///     Invalid argument. This is used to indicate various kinds of problems with passing the wrong argument to a
    ///     library function.
    /// </summary>
    Inval,

    /// <summary>
    ///     Broken pipe; there is no process reading from the other end of a pipe. Every library function that returns
    ///     this error code also generates a ‘SIGPIPE’ signal; this signal terminates the program if not handled or
    ///     blocked. Thus, your program will never actually see this code unless it has handled or blocked ‘SIGPIPE’.
    /// </summary>
    Pipe,

    /// <summary>Resource temporarily unavailable; the call might work if you try again later.</summary>
    Again,

    /// <summary>
    ///     Interrupted function call; an asynchronous signal occurred and prevented completion of the call. When this
    ///     happens, you should try the call again.
    /// </summary>
    Intr,

    /// <summary>
    ///     Input/output error; usually used for physical read or write errors. i.e. the disk or other physical device
    ///     hardware is returning errors.
    /// </summary>
    Io,

    /// <summary>
    ///     Operation not permitted; only the owner of the file (or other resource) or processes with special privileges
    ///     can perform the operation.
    /// </summary>
    Perm,

    /// <summary>Function not implemented; this indicates that the system is missing some functionality.</summary>
    NoSys,

    /// <summary>
    ///     Does not correspond to a UNIX error code; this is the standard “failed for unspecified reason” error code
    ///     present in all <see cref="IErrorQuark" /> error code enumerations. Returned if no specific code applies.
    /// </summary>
    Failed
}
