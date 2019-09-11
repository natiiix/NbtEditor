using System;
using NbtEditor.Tags;

namespace NbtEditor
{
    internal class Program
    {
        private static void Main(string[] _)
        {
            byte[] rawData = GZip.Decompress("level.dat");
            Tag tag = Tag.Parse(rawData, 0, out int length);
            Console.WriteLine($"Data Length: {rawData.Length}{Environment.NewLine}Tag Type: {tag.Type}{Environment.NewLine}Tag Length: {length}{Environment.NewLine}Tag Name: \"{tag.Name.Value}\"{Environment.NewLine}Tag Value: \"{tag.Value}\"");
            GZip.Compress("level_copy.dat", tag.ToByteArray());
        }
    }
}
