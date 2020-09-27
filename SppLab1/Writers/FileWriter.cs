using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SppLab1.Writers
{
    public class FileWriter : IResultWriter
    {
        public void WriteResult(string result, string name)
        {
            string extension = name.Remove(0, 6);
            string filePath = "result." + extension.ToLower();
            using(StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine(result);
            }
        }
    }
}
