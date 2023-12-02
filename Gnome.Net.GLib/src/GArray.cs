// This file is part of the Gnome.Net project and is under the MIT license.
// See LICENSE.md for more information.

namespace Gnome.Net.GLib;

/// <summary>Contains the public fields of a GArray.</summary>
public sealed class GArray<T>
{
    /// <summary>The data held by the array.</summary>
    /// <value>A <see cref="Array" /> of the given <typeparamref name="T" /> type.</value>
    public T[] Data { get; private init; } = Array.Empty<T>();

    /// <summary>The length of the <see cref="Data" /> array.</summary>
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
    /// <value>A new <see cref="GArray{T}" /> with an empty data <see cref="Array" />.</value>
    /// <seealso cref="Array.Empty{T}" />
    public static GArray<T> Empty => new() { Data = Array.Empty<T>() };
}
