using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Nmpq.Parsing
{
    [StructLayout(LayoutKind.Explicit, Pack = 1)]
    public struct ArchiveHeader
    {
        public bool IsMagicValid
        {
            get
            {
                var bytes = BitConverter.GetBytes(Magic);
                var mpq = Encoding.UTF8.GetString(bytes, 0, 3);
                return mpq == "MPQ" && bytes[3] == 0x1a;
            }
        }

        [FieldOffset(0x00)] public uint Magic;

        [FieldOffset(0x04)] public uint HeaderSize;

        [FieldOffset(0x08)] public uint ArchiveSize;

        [FieldOffset(0x0c)] public ushort FormatVersion;

        [FieldOffset(0x0e)] public byte SectorSizeShift;

        [FieldOffset(0x10)] public uint HashTableOffset;

        [FieldOffset(0x14)] public uint BlockTableOffset;

        [FieldOffset(0x18)] public uint HashTableEntryCount;

        [FieldOffset(0x1c)] public uint BlockTableEntryCount;

        [FieldOffset(0x20)] public ulong ExtendedBlockTableOffset;

        [FieldOffset(0x28)] public ushort HashTableOffsetHigh;

        [FieldOffset(0x2a)] public ushort BlockTableOffsetHigh;
    }
}