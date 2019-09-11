using System.Linq;
using MiscUtil.Conversion;

namespace NbtEditor.Values
{
    public sealed class LongArrayValue : TagValue
    {
        public long[] Value { get; }

        public LongArrayValue(long[] value) : base() => Value = value;

        public override byte[] ToByteArray() =>
            BigEndianBitConverter.GetBytes(Value.Length).Concat(Value.SelectMany(i => BigEndianBitConverter.GetBytes(i))).ToArray();

        public static LongArrayValue Parse(byte[] data, int index, out int length)
        {
            int arrayLength = BigEndianBitConverter.ToInt32(data, index);
            long[] array = new long[arrayLength];

            for (int i = 0; i < arrayLength; i++)
            {
                array[i] = BigEndianBitConverter.ToInt32(data, index + sizeof(int) + (i * sizeof(long)));
            }

            length = sizeof(int) + (arrayLength * sizeof(long));
            return new LongArrayValue(array);
        }
    }
}
