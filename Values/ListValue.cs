using System.Collections.Generic;
using System.Linq;
using MiscUtil.Conversion;
using NbtEditor.Tags;

namespace NbtEditor.Values
{
    public sealed class ListValue : TagValue
    {
        public Tag.TagType ItemType { get; }
        public TagValue[] Value { get; }

        public ListValue(Tag.TagType itemType, TagValue[] value) : base()
        {
            ItemType = itemType;
            Value = value;
        }

        public override byte[] ToByteArray() =>
            new byte[] { (byte)ItemType }.Concat(BigEndianBitConverter.GetBytes(Value.Length)).Concat(Value.SelectMany(v => v.ToByteArray())).ToArray();

        public static ListValue Parse(byte[] data, int index, out int length)
        {
            Tag.TagType itemType = (Tag.TagType)data[index];
            int itemCount = BigEndianBitConverter.ToInt32(data, index + sizeof(byte));

            List<TagValue> items = new List<TagValue>(itemCount);

            length = sizeof(byte) + sizeof(int);
            for (int i = 0; i < itemCount; i++)
            {
                items.Add(Parse(itemType, data, index + length, out int valueLength));
                length += valueLength;
            }

            return new ListValue(itemType, items.ToArray());
        }
    }
}
