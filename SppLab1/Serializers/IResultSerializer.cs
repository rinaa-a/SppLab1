using SppLab1.TraceResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SppLab1.Serializers
{
    interface IResultSerializer
    {
        string Serialize(TraceResult result);
    }
}
