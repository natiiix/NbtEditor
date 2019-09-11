using MiscUtil.Conversion;

namespace NbtEditor.Values
{
    public sealed class DoubleValue : TagValue
    {
        public double Value { get; }

        public DoubleValue(double value) : base() => Value = value;

        public override byte[] ToByteArray() => BigEndianBitConverter.GetBytes(Value);

        public static DoubleValue Parse(byte[] data, int index, out int length)
        {
            length = sizeof(double);
            return new DoubleValue(BigEndianBitConverter.ToDouble(data, index));
        }
    }
}
