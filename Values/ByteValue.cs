namespace NbtEditor.Values
{
    public sealed class ByteValue : TagValue
    {
        public byte Value { get; }

        public ByteValue(byte value) : base() => Value = value;

        public override byte[] ToByteArray() => new byte[] { Value };

        public static ByteValue Parse(byte[] data, int index, out int length)
        {
            length = sizeof(byte);
            return new ByteValue(data[index]);
        }
    }
}
