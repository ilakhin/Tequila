using System.IO;

namespace IL.Tequila
{
    public static class DirectoryInfoExtensions
    {
        public static void Clear(this DirectoryInfo directoryInfo)
        {
            foreach (var file in directoryInfo.EnumerateFiles())
            {
                file.Delete();
            }

            foreach (var directory in directoryInfo.EnumerateDirectories())
            {
                directory.Delete(true);
            }
        }
    }
}
