using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZipDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            const string zipFilePath = @"..\..\Sample.zip";
            // 创建并添加被压缩文件
            using (FileStream zipFileToOpen = new FileStream(zipFilePath, FileMode.Create))
            using (ZipArchive archive = new ZipArchive(zipFileToOpen, ZipArchiveMode.Create))
            {
                System.Reflection.Assembly assemble = System.Reflection.Assembly.GetExecutingAssembly();
                string path = assemble.Location;
                string filename = System.IO.Path.GetFileName(path);

                ZipArchiveEntry readMeEntry = archive.CreateEntry(filename);
                using (System.IO.Stream stream = readMeEntry.Open())
                {
                    byte[] bytes = System.IO.File.ReadAllBytes(path);
                    stream.Write(bytes, 0, bytes.Length);
                }
            }
        }
    }
}
