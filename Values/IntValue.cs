using MiscUtil.Conversion;

namespace NbtEditor.Values
{
    public sealed class IntValue : TagValue
    {
        public int Value { get; }

        public IntValue(int value) : base() => Value = value;

        public override byte[] ToByteArray() => BigEndianBitConverter.GetBytes(Value);

        public static IntValue Parse(byte[] data, int index, out int length)
        {
            length = sizeof(int);
            return new IntValue(BigEndianBitConverter.ToInt32(data, index));
        }
    }
}
