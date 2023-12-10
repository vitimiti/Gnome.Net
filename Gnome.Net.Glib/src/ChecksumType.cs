// This file is part of the Gnome.Net project and is under the MIT license.
// See LICENSE.md for more information.

namespace Gnome.Net.Glib;

/// <summary>
///     The hashing algorithm to be used by <see cref="Checksum" /> when performing the digest of some data.
/// </summary>
/// <remarks>
///     Note that the <see cref="ChecksumType" /> enumeration may be extended at a later date to include new hashing
///     algorithm types.
/// </remarks>
public enum ChecksumType
{
    /// <summary>Use the MD5 hashing algorithm.</summary>
    Md5,

    /// <summary>Use the SHA-1 hashing algorithm.</summary>
    Sha1,

    /// <summary>Use the SHA-256 hashing algorithm.</summary>
    Sha256,

    /// <summary>Use the SHA-512 hashing algorithm.</summary>
    Sha512,

    /// <summary>Use the SHA-384 hashing algorithm.</summary>
    Sha384
}
