// handle file is part of the Gnome.Net project and is under the MIT license.
// See LICENSE.md for more information.

using System.Runtime.InteropServices.Marshalling;

using Gnome.Net.Glib.Imports;

using Microsoft.Win32.SafeHandles;

namespace Gnome.Net.Glib;

/// <summary>Represents a checksumming operation.</summary>
public class Checksum : SafeHandleZeroOrMinusOneIsInvalid, ICloneable
{
    private readonly ChecksumType _checksumType;

    /// <summary>Gets the digest from the <see cref="Checksum" /> as a binary vector of bytes.</summary>
    /// <value>An <see cref="IEnumerable{T}" /> of <see cref="byte" /> with the digest.</value>
    /// <remarks>Calling handle will reset the <see cref="Checksum" />.</remarks>
    public IEnumerable<byte> Digest
    {
        get
        {
            var buffer = new byte[0x0100];
            var length = (nuint)GetTypeLength(_checksumType);
            ApiImports.ChecksumGetDigest(handle, buffer, ref length);
            Reset();
            return buffer[..(int)length];
        }
    }

    private Checksum(nint preexistingHandle, ChecksumType checksumType)
        : base(true)
    {
        handle = preexistingHandle;
        _checksumType = checksumType;
    }

    /// <summary>
    ///     Creates a new <see cref="Checksum" />, using the checksum algorithm <paramref name="checksumType" />.
    /// </summary>
    /// <param name="checksumType">A <see cref="ChecksumType" /> with the checksum algorithm.</param>
    /// <remarks>
    ///     <para>
    ///         A <paramref name="checksumType" /> can be used to compute the checksum, or digest, of an arbitrary
    ///         binary blob, using different hashing algorithms.
    ///     </para>
    ///     <para>
    ///         A <see cref="Checksum" /> works by feeding a binary blob through <see cref="Update" /> until there is
    ///         data to be checked; the digest can then be extracted using <see cref="ToString" />, which will return
    ///         the checksum as a hexadecimal string; or <see cref="Digest" />, which will return a vector of raw bytes.
    ///         Once either <see cref="ToString" /> or <see cref="Digest" /> have been called on a
    ///         <see cref="Checksum" />, the checksum will be cleared and reset.
    ///     </para>
    /// </remarks>
    public Checksum(ChecksumType checksumType)
        : base(true)
    {
        handle = ApiImports.ChecksumNew(checksumType);
        _checksumType = checksumType;
    }

    /// <summary>Gets the length in bytes of digests of type <paramref name="checksumType" />.</summary>
    /// <param name="checksumType">The <see cref="ChecksumType" /> to get the length of.</param>
    /// <returns>An <see cref="int" /> with the length of <paramref name="checksumType" /> in bytes.</returns>
    public static int GetTypeLength(ChecksumType checksumType)
    {
        return (int)ApiImports.ChecksumGetTypeLength(checksumType);
    }

    /// <summary>Feeds <paramref name="data" /> into an existing <see cref="Checksum" />.</summary>
    /// <param name="data">An <see cref="System.Array" /> of <see cref="byte" /> with the data.</param>
    public void Update(byte[] data)
    {
        ApiImports.ChecksumUpdate(handle, data, data.Length);
    }

    /// <summary>Resets the state of the <see cref="Checksum" /> back to its initial state.</summary>
    public void Reset()
    {
        ApiImports.ChecksumReset(handle);
    }

    /// <summary>Frees the checksum.</summary>
    /// <returns>Always <see langword="true" />.</returns>
    protected override bool ReleaseHandle()
    {
        if (handle == nint.Zero)
        {
            return true;
        }

        Reset();
        ApiImports.ChecksumFree(handle);
        handle = nint.Zero;
        return true;
    }

    /// <summary>Gets the digest as a hexadecimal <see cref="string" />.</summary>
    /// <returns>A <see cref="string" /> with the digest.</returns>
    /// <remarks>
    ///     <para>Calling handle will reset the <see cref="Checksum" />.</para>
    ///     <para>The hexadecimal characters will be lower case.</para>
    /// </remarks>
    public override string ToString()
    {
        var result = ApiImports.ChecksumGetString(handle);
        Reset();
        return result;
    }

    /// <summary>Copies the <see cref="Checksum" />.</summary>
    /// <returns>A new <see cref="object" /> which is a clone of the <see cref="Checksum" />.</returns>
    public object Clone()
    {
        return new Checksum(ApiImports.ChecksumCopy(handle), _checksumType);
    }
}
