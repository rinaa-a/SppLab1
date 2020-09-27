using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SppLab1.TraceResults;

namespace SppLab1.Serializers
{
    class JsonResultSerializer : IResultSerializer
    {
        public string Serialize(TraceResult result)
        {
            return JsonConvert.SerializeObject(result);
        }
    }
}
