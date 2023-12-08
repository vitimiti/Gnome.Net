// This file is part of the Gnome.Net project and is under the MIT license.
// See LICENSE.md for more information.

namespace Gnome.Net.Glib;

/// <summary>Contains the public fields of an array.</summary>
public sealed class Array<T>
{
    /// <summary>Get/Set the data held by the array.</summary>
    /// <value>An <see cref="System.Array" /> of the given <typeparamref name="T" /> type.</value>
    public T[] Data { get; set; } = Array.Empty<T>();

    /// <summary>Get the length of the <see cref="Data" /> array.</summary>
    /// <value>A <see cref="uint" /> with the length of the <see cref="Data" /> array.</value>
    public uint Length => (uint)Data.Length;

    /// <summary>An indexer to directly access and modify the <see cref="Data" />.</summary>
    /// <param name="index">An <see cref="int" /> with the index of the array.</param>
    /// <value>
    ///     A value of the given <typeparamref name="T" /> type to get/set at the given <paramref name="index" />.
    /// </value>
    public T this[int index]
    {
        get => Data[index];
        set => Data[index] = value;
    }

    /// <summary>Create an empty data structure.</summary>
    /// <value>A new <see cref="Array{T}" /> with an empty data <see cref="System.Array" />.</value>
    /// <seealso cref="System.Array.Empty{T}" />
    public static Array<T> Empty => new() { Data = Array.Empty<T>() };
}
