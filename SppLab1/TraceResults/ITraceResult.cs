using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SppLab1.TraceResults
{
    interface ITraceResult <T>
    {
        void AddInformation(T info);
    }
}
