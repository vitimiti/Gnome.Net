// This file is part of the Gnome.Net project and is under the MIT license.
// See LICENSE.md for more information.

namespace Gnome.Net.GLib;

/// <summary>Contains the public fields of a byte array.</summary>
public sealed class ByteArray
{
    /// <summary>Get/Set the data held by the array.</summary>
    /// <value>An <see cref="System.Array" /> of <see cref="byte" />.</value>
    public byte[] Data { get; set; } = Array.Empty<byte>();

    /// <summary>Get the length of the <see cref="Data" /> array.</summary>
    /// <value>A <see cref="uint" /> with the length of the <see cref="Data" /> array.</value>
    public uint Length => (uint)Data.Length;

    /// <summary>An indexer to directly access and modify the <see cref="Data" />.</summary>
    /// <param name="index">An <see cref="int" /> with the index of the array.</param>
    /// <value>
    ///     A <see cref="byte" /> to get/set at the given <paramref name="index" />.
    /// </value>
    public byte this[int index]
    {
        get => Data[index];
        set => Data[index] = value;
    }

    /// <summary>Create an empty data structure.</summary>
    /// <value>A new <see cref="ByteArray" /> with an empty data <see cref="System.Array" />.</value>
    /// <seealso cref="System.Array.Empty{T}" />
    public static ByteArray Empty => new() { Data = Array.Empty<byte>() };
}
