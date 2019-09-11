using System.ComponentModel;
using NbtEditor.Tags;

namespace NbtEditor.Values
{
    public abstract class TagValue
    {
        public abstract byte[] ToByteArray();

        public static TagValue Parse(Tag.TagType valueType, byte[] data, int index, out int length) => valueType switch
        {
            Tag.TagType.End => EndTagValue.Parse(data, index, out length),
            Tag.TagType.Byte => ByteValue.Parse(data, index, out length),
            Tag.TagType.Short => ShortValue.Parse(data, index, out length),
            Tag.TagType.Int => IntValue.Parse(data, index, out length),
            Tag.TagType.Long => LongValue.Parse(data, index, out length),
            Tag.TagType.Float => FloatValue.Parse(data, index, out length),
            Tag.TagType.Double => DoubleValue.Parse(data, index, out length),
            Tag.TagType.ByteArray => ByteArrayValue.Parse(data, index, out length),
            Tag.TagType.String => StringValue.Parse(data, index, out length),
            Tag.TagType.List => ListValue.Parse(data, index, out length),
            Tag.TagType.Compound => CompoundValue.Parse(data, index, out length),
            Tag.TagType.IntArray => IntArrayValue.Parse(data, index, out length),
            Tag.TagType.LongArray => LongArrayValue.Parse(data, index, out length),
            _ => throw new InvalidEnumArgumentException(nameof(valueType), (int)valueType, typeof(Tag.TagType)),
        };
    }
}
