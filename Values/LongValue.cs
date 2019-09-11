using MiscUtil.Conversion;

namespace NbtEditor.Values
{
    public sealed class LongValue : TagValue
    {
        public long Value { get; }

        public LongValue(long value) : base() => Value = value;

        public override byte[] ToByteArray() => BigEndianBitConverter.GetBytes(Value);

        public static LongValue Parse(byte[] data, int index, out int length)
        {
            length = sizeof(long);
            return new LongValue(BigEndianBitConverter.ToInt64(data, index));
        }
    }
}
