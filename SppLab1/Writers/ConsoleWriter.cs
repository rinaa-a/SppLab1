using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SppLab1.Writers
{
    public class ConsoleWriter : IResultWriter
    {
        public void WriteResult(string result, string name = "")
        {
            Console.WriteLine(result);
        }
    }
}
