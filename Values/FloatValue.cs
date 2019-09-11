using MiscUtil.Conversion;

namespace NbtEditor.Values
{
    public sealed class FloatValue : TagValue
    {
        public float Value { get; }

        public FloatValue(float value) : base() => Value = value;

        public override byte[] ToByteArray() => BigEndianBitConverter.GetBytes(Value);

        public static FloatValue Parse(byte[] data, int index, out int length)
        {
            length = sizeof(float);
            return new FloatValue(BigEndianBitConverter.ToSingle(data, index));
        }
    }
}
