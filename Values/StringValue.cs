using System;
using System.Linq;
using System.Text;
using MiscUtil.Conversion;

namespace NbtEditor.Values
{
    public sealed class StringValue : TagValue
    {
        public static StringValue Null => new StringValue(null);

        public string Value { get; }

        public StringValue(string value) : base() => Value = value;

        public override byte[] ToByteArray()
        {
            if (Value is null)
            {
                return Array.Empty<byte>();
            }

            byte[] valueBytes = Encoding.UTF8.GetBytes(Value);
            return BigEndianBitConverter.GetBytes((short)valueBytes.Length).Concat(valueBytes).ToArray();
        }

        public static StringValue Parse(byte[] data, int index, out int length)
        {
            short stringLength = BigEndianBitConverter.ToInt16(data, index);
            string str = Encoding.UTF8.GetString(data, index + sizeof(short), stringLength);

            length = sizeof(short) + stringLength;
            return new StringValue(str);
        }
    }
}
