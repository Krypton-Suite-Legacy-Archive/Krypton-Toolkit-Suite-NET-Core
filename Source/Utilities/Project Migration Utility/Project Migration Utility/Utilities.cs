using System.IO;

namespace ProjectMigrationUtility
{
    internal class Utilities
    {
        public Utilities()
        {

        }

        public static void CompressFiles(string input, string output)
        {
            Compression.Compress.LZMA.Encoder encoder = new Compression.Compress.LZMA.Encoder();

            using (FileStream fs = new FileStream(input, FileMode.Open))
            {
                using (FileStream stream = new FileStream(output, FileMode.Create))
                {
                    encoder.Code(fs, stream, -1, -1, null);

                    stream.Flush();
                }
            }
        }
    }
}