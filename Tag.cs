using System.Linq;
using NbtEditor.Values;

namespace NbtEditor.Tags
{
    public sealed class Tag
    {
        public enum TagType
        {
#pragma warning disable CA1720 // Identifier contains type name
            End,
            Byte,
            Short,
            Int,
            Long,
            Float,
            Double,
            ByteArray,
            String,
            List,
            Compound,
            IntArray,
            LongArray
#pragma warning restore CA1720 // Identifier contains type name
        }

        public static Tag EndTag => new Tag(TagType.End, StringValue.Null, new EndTagValue());

        public TagType Type { get; }
        public StringValue Name { get; }
        public TagValue Value { get; }

        public Tag(TagType type, StringValue name, TagValue value)
        {
            Type = type;
            Name = name;
            Value = value;
        }

        public Tag(TagType type, string name, TagValue value) : this(type, new StringValue(name), value) { }

        public byte[] ToByteArray() =>
            new byte[] { (byte)Type }.Concat(Name.ToByteArray()).Concat(Value.ToByteArray()).ToArray();

        public static Tag Parse(byte[] data, int index, out int length)
        {
            TagType id = (TagType)data[index];
            length = sizeof(byte);

            if (id == TagType.End)
            {
                return EndTag;
            }

            StringValue name = StringValue.Parse(data, index + sizeof(byte), out int nameLength);
            length += nameLength;

            TagValue value = TagValue.Parse(id, data, index + length, out int valueLength);
            length += valueLength;

            return new Tag(id, name, value);
        }
    }
}
