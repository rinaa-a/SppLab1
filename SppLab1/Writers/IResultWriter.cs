using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SppLab1.Writers
{
    public interface IResultWriter
    {
        void WriteResult(string result, string name = "");
    }
}
