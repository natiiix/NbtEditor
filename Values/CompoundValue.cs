using System.Collections.Generic;
using System.Linq;
using NbtEditor.Tags;

namespace NbtEditor.Values
{
    public sealed class CompoundValue : TagValue
    {
        public Tag[] Value { get; }

        public CompoundValue(Tag[] value) : base() => Value = value;

        public override byte[] ToByteArray() => Value.SelectMany(t => t.ToByteArray()).Concat(Tag.EndTag.ToByteArray()).ToArray();

        public static CompoundValue Parse(byte[] data, int index, out int length)
        {
            List<Tag> tags = new List<Tag>();

            length = 0;
            while (true)
            {
                Tag tag = Tag.Parse(data, index + length, out int tagLength);
                length += tagLength;

                if (tag.Type == Tag.TagType.End)
                {
                    break;
                }
                else
                {
                    tags.Add(tag);
                }
            }

            return new CompoundValue(tags.ToArray());
        }
    }
}
