using System;
using System.IO;
using System.IO.Compression;

namespace NbtEditor
{
    public static class GZip
    {
        public static void Compress(string path, byte[] data)
        {
            using FileStream fs = File.Create(path);
            using GZipStream gs = new GZipStream(fs, CompressionMode.Compress);

            gs.Write(data);
        }

        public static byte[] Decompress(string path)
        {
            using FileStream fs = File.OpenRead(path);
            using GZipStream gs = new GZipStream(fs, CompressionMode.Decompress);

            byte[] data = new byte[0x10000];
            int totalLength = 0;

            while (true)
            {
                int remainingCapacity = data.Length - totalLength;
                int count = gs.Read(data, totalLength, remainingCapacity);
                totalLength += count;

                if (count == 0)
                {
                    break;
                }
                else if (count == remainingCapacity)
                {
                    Array.Resize(ref data, data.Length * 2);
                }
            }

            Array.Resize(ref data, totalLength);
            return data;
        }
    }
}
