using System;

namespace NbtEditor.Values
{
    public sealed class EndTagValue : TagValue
    {
        public EndTagValue() : base() { }

        public override byte[] ToByteArray() => Array.Empty<byte>();

#pragma warning disable IDE0060 // Remove unused parameter
#pragma warning disable CA1801 // Review unused parameters
        public static EndTagValue Parse(byte[] data, int index, out int length)
#pragma warning restore CA1801 // Review unused parameters
#pragma warning restore IDE0060 // Remove unused parameter
        {
            length = 0;
            return new EndTagValue();
        }
    }
}
