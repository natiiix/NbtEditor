using MiscUtil.Conversion;

namespace NbtEditor.Values
{
    public sealed class ShortValue : TagValue
    {
        public short Value { get; }

        public ShortValue(short value) : base() => Value = value;

        public override byte[] ToByteArray() => BigEndianBitConverter.GetBytes(Value);

        public static ShortValue Parse(byte[] data, int index, out int length)
        {
            length = sizeof(short);
            return new ShortValue(BigEndianBitConverter.ToInt16(data, index));
        }
    }
}
