using System;
using System.IO;
using System.Runtime.InteropServices;

namespace Nmpq.Parsing
{
    public static class BinaryReaderExtensions
    {
        public static T ReadStruct<T>(this BinaryReader reader)
        {
            if (reader == null) throw new ArgumentNullException("reader");

            var size = Marshal.SizeOf(typeof (T));
            var bytes = new byte[size];

            reader.Read(bytes, 0, size);

            var pinned = GCHandle.Alloc(bytes, GCHandleType.Pinned);
            var structure = (T) Marshal.PtrToStructure(pinned.AddrOfPinnedObject(), typeof (T));
            pinned.Free();

            return structure;
        }

        public static void SkipBytes(this BinaryReader reader, int count)
        {
            if (reader == null) throw new ArgumentNullException("reader");

            for (var i = 0; i < count; i++)
                reader.ReadByte();
        }
    }
}