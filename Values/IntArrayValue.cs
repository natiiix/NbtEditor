using System.Linq;
using MiscUtil.Conversion;

namespace NbtEditor.Values
{
    public sealed class IntArrayValue : TagValue
    {
        public int[] Value { get; }

        public IntArrayValue(int[] value) : base() => Value = value;

        public override byte[] ToByteArray() =>
            BigEndianBitConverter.GetBytes(Value.Length).Concat(Value.SelectMany(i => BigEndianBitConverter.GetBytes(i))).ToArray();

        public static IntArrayValue Parse(byte[] data, int index, out int length)
        {
            int arrayLength = BigEndianBitConverter.ToInt32(data, index);
            int[] array = new int[arrayLength];

            for (int i = 0; i < arrayLength; i++)
            {
                array[i] = BigEndianBitConverter.ToInt32(data, index + sizeof(int) + (i * sizeof(int)));
            }

            length = sizeof(int) + (arrayLength * sizeof(int));
            return new IntArrayValue(array);
        }
    }
}
