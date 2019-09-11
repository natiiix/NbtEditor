using System;
using System.Linq;
using MiscUtil.Conversion;

namespace NbtEditor.Values
{
    public sealed class ByteArrayValue : TagValue
    {
        public byte[] Value { get; }

        public ByteArrayValue(byte[] value) : base() => Value = value;

        public override byte[] ToByteArray() => BigEndianBitConverter.GetBytes(Value.Length).Concat(Value).ToArray();

        public static ByteArrayValue Parse(byte[] data, int index, out int length)
        {
            int arrayLength = BigEndianBitConverter.ToInt32(data, index);
            byte[] array = new byte[arrayLength];

            Buffer.BlockCopy(data, index + sizeof(int), array, 0, arrayLength);

            length = sizeof(int) + arrayLength;
            return new ByteArrayValue(array);
        }
    }
}
