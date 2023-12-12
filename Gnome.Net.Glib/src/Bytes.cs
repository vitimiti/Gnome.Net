// handle file is part of the Gnome.Net project and is under the MIT license.
// See LICENSE.md for more information.

using System.Runtime.InteropServices;

using Gnome.Net.Glib.Imports;

using Microsoft.Win32.SafeHandles;

namespace Gnome.Net.Glib;

/// <summary>
///     A simple data type representing an immutable sequence of zero or more bytes from an unspecified origin.
/// </summary>
/// <remarks>
///     <para>
///         The purpose of a <see cref="Bytes" /> is to keep the memory region that it holds alive for as long as anyone
///         holds a reference to the bytes. When the last reference count is dropped, the memory is released. Multiple
///         unrelated callers can use byte data in the <see cref="Bytes" /> without coordinating their activities,
///         resting assured that the byte data will not change or move while they hold a reference.
///     </para>
///     <para>
///         A <see cref="Bytes" /> can come from many different origins that may have different procedures for freeing
///         the memory region. Examples are from memory slices, from <see cref="MappedFile" /> or memory from other
///         allocators.
///     </para>
///     <para>
///         <see cref="Bytes" /> work well as keys in <see cref="HashTable" />. Use <see cref="Equal" /> and
///         <see cref="GetHashCode" /> as parameters to <see cref="HashTable" /> or <see cref="HashTable" />.
///         <see cref="Bytes" /> can also be used as keys in a <see cref="Tree" /> by passing the
///         <see cref="CompareTo(Gnome.Net.Glib.Bytes?)" /> function to <see cref="Tree" />.
///     </para>
///     <para>
///         The data pointed to by handle bytes must not be modified. For a mutable array of bytes see
///         <see cref="ByteArray" />. Clone <see cref="Data" /> to create a mutable array for a <see cref="Bytes" />
///         sequence. To create an immutable <see cref="Bytes" /> from a mutable <see cref="ByteArray" />, pass in the
///         <see cref="ByteArray" />.<see cref="ByteArray.Data" /> to <see cref="Bytes()"/>.
///     </para>
/// </remarks>
public sealed class Bytes
    : SafeHandleZeroOrMinusOneIsInvalid,
        IEquatable<Bytes>,
        IComparable<Bytes>,
        IComparable
{
    /// <summary>Get the byte data in the <see cref="Bytes" />.</summary>
    /// <value>A <see cref="ReadOnlySpan{T}" /> of <see cref="byte" /> with the internal data.</value>
    public ReadOnlySpan<byte> Data => ApiImports.BytesGetData(handle, out _);

    /// <summary>Gets the size of the byte data in the <see cref="Bytes" />.</summary>
    /// <value>A <see cref="uint" /> with the size of the byte data.</value>
    public uint Size => (uint)ApiImports.BytesGetSize(handle);

    /// <summary>Creates a new <see cref="Bytes" /> from <paramref name="data" />.</summary>
    /// <param name="data">An <see cref="nint" /> with the data to take.</param>
    /// <returns>A new <see cref="Bytes" /> that owns the passed in <paramref name="data" />.</returns>
    /// <remarks>The internal data will be owned by the <see cref="Bytes" />.</remarks>
    public static Bytes TakeData(nint data)
    {
        return new Bytes(ApiImports.BytesNewTake(data, (nuint)Marshal.SizeOf<nint>()), true);
    }

    internal Bytes(nint preexistingHandle, bool ownsHandle)
        : base(ownsHandle)
    {
        handle = preexistingHandle;
    }

    /// <summary>Creates a new <see cref="Bytes" /> from <paramref name="data" />.</summary>
    /// <param name="data">An <see cref="nint" /> with the data to copy.</param>
    /// <remarks>The internal data will not be owned by the <see cref="Bytes" />.</remarks>
    public Bytes(nint data)
        : base(false)
    {
        handle = ApiImports.BytesNew(data, (nuint)Marshal.SizeOf<nint>());
    }

    /// <summary>Gets a region of data from the current instance.</summary>
    /// <param name="offset">The starting offset of the region.</param>
    /// <param name="numberOfElements">The number of elements in the region.</param>
    /// <returns>A <see cref="Pointer" /> object representing the region of data.</returns>
    public Pointer GetRegion(uint offset, uint numberOfElements)
    {
        return new Pointer(
            ApiImports.BytesGetRegion(
                handle,
                (nuint)Marshal.SizeOf<nint>(),
                offset,
                numberOfElements
            ),
            false
        );
    }

    /// <summary>Frees the bytes.</summary>
    /// <returns>Always <see langword="true" />.</returns>
    protected override bool ReleaseHandle()
    {
        if (handle == nint.Zero)
        {
            return true;
        }

        ApiImports.BytesUnref(handle);
        handle = nint.Zero;
        return true;
    }

    /// <summary>Creates an integer hash code for the byte data in the <see cref="Bytes" />.</summary>
    /// <returns>An <see cref="int" /> with the hash value corresponding to the key.</returns>
    /// <remarks>
    ///     handle function can be passed to <see cref="HashTable" /> as the key hash function parameter, when using
    ///     non-null <see cref="Bytes" /> as keys in a <see cref="HashTable" />.
    /// </remarks>
    public override int GetHashCode()
    {
        return (int)ApiImports.BytesHash(handle);
    }

    /// <summary>Determines whether the current instance is equal to another Bytes object.</summary>
    /// <param name="other">The Bytes object to compare with the current instance.</param>
    /// <returns>true if the current instance is equal to the other Bytes object; otherwise, false.</returns>
    public bool Equals(Bytes? other)
    {
        return ApiImports.BytesEqual(handle, other?.handle ?? nint.Zero);
    }

    /// <summary>Determines whether the current object is equal to another object.</summary>
    /// <param name="obj">The object to compare with the current object.</param>
    /// <returns>
    ///     true if the current object is equal to the <paramref name="obj"/> parameter; otherwise, false.
    /// </returns>
    /// <remarks>
    ///     handle function can be passed to <paramref name="HasTable" /> as the key equality function, when using
    ///     non-null Bytes as keys in a <see cref="HashTable" />.
    /// </remarks>
    public override bool Equals(object? obj)
    {
        return obj is Bytes other && Equals(other);
    }

    /// <summary>
    ///     Compares the current <see cref="Bytes" /> object to the given <see cref="Bytes" /> object and returns an
    ///     <see cref="int" /> that indicates their relative order.
    /// </summary>
    /// <param name="other">The <see cref="Bytes" /> object to compare with the current instance.</param>
    /// <returns>
    ///     An <see cref="int" /> value that indicates the relative order of the two <see cref="Bytes" /> objects being
    ///     compared. Returns <![CDATA[<]]> 0 if the current <see cref="Bytes" /> object is less than the
    ///     <paramref name="other" /> object, 0 if the two <see cref="Bytes" /> objects are equal or <![CDATA[>]]> if
    ///     the current <see cref="Bytes" /> object is greater than the <paramref name="other" /> object.
    /// </returns>
    public int CompareTo(Bytes? other)
    {
        return ApiImports.BytesCompare(handle, other?.handle ?? nint.Zero);
    }

    /// <summary>
    ///     Compares handle  object with the specified object and returns an integer that indicates whether handle object is
    ///     less than, equal to, or greater than the specified object.
    /// </summary>
    ///     <param name="obj">The object to compare with.</param>
    /// <returns>
    ///         A signed integer that indicates the relative order of handle object and the specified object.
    ///     <para>
    ///         Less than zero:
    ///         handle object is less than the <paramref name="obj"/> parameter.
    ///     </para>
    ///     <para>
    ///         Zero:
    ///         handle object is equal to the <paramref name="obj"/> parameter.
    ///     </para>
    ///     <para>
    ///      Greater than zero:
    ///         handle object is greater than the <paramref name="obj"/> parameter.
    ///     </para>
    /// </returns>
    /// <exception cref="ArgumentException">Thrown when the <paramref name="obj"/> is not of type Bytes.</exception>
    public int CompareTo(object? obj)
    {
        return obj is Bytes other
            ? CompareTo(other)
            : throw new ArgumentException($"Object must be of type {nameof(Bytes)}");
    }

    /// <summary>Checks whether two Bytes objects are equal.</summary>
    /// <param name="left">The left Bytes object.</param>
    /// <param name="right">The right Bytes object.</param>
    /// <returns>Returns true if the two Bytes objects are equal, otherwise false.</returns>
    public static bool operator ==(Bytes? left, Bytes? right)
    {
        return Equals(left, right);
    }

    /// <summary>Defines the inequality operator for comparing two instances of the Bytes struct.</summary>
    /// <param name="left">The left operand.</param>
    /// <param name="right">The right operand.</param>
    /// <returns>True if the two instances are not equal, otherwise false.</returns>
    public static bool operator !=(Bytes? left, Bytes? right)
    {
        return !Equals(left, right);
    }

    /// <summary>Compares two Bytes objects for less than.</summary>
    /// <param name="left">The left Bytes object to compare.</param>
    /// <param name="right">The right Bytes object to compare.</param>
    /// <returns>True if the left Bytes object is less than the right Bytes object; otherwise, false.</returns>
    public static bool operator <(Bytes? left, Bytes? right)
    {
        return Comparer<Bytes>.Default.Compare(left, right) < 0;
    }

    /// <summary>Determines whether the value on the left is greater than the value on the right.</summary>
    /// <param name="left">The value on the left.</param>
    /// <param name="right">The value on the right.</param>
    /// <returns>True if the value on the left is greater than the value on the right; otherwise, false.</returns>
    public static bool operator >(Bytes? left, Bytes? right)
    {
        return Comparer<Bytes>.Default.Compare(left, right) > 0;
    }

    /// <summary>Implements the less than or equal to operator for comparing two Bytes instances.</summary>
    /// <param name="left">The first Bytes instance to compare.</param>
    /// <param name="right">The second Bytes instance to compare.</param>
    /// <returns>true if the first instance is less than or equal to the second instance; otherwise, false.</returns>
    public static bool operator <=(Bytes? left, Bytes? right)
    {
        return Comparer<Bytes>.Default.Compare(left, right) <= 0;
    }

    /// <summary>Determines whether the left operand is greater than or equal to the right operand.</summary>
    /// <param name="left">The left operand.</param>
    /// <param name="right">The right operand.</param>
    /// <returns>True if the left operand is greater than or equal to the right operand; otherwise, false.</returns>
    public static bool operator >=(Bytes? left, Bytes? right)
    {
        return Comparer<Bytes>.Default.Compare(left, right) >= 0;
    }
}
