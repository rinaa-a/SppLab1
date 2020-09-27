using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SppLab1.TraceResults
{
    public class ThreadInfo : ITraceResult<MethodInfo>
    {
        [XmlElement("id")]
        [JsonProperty("id")]
        public long ThreadID { get; set; }

        [XmlElement("time")]
        [JsonProperty("time")]
        public long ExecutionTime
        {
            get
            {
                long time = 0;
                foreach (MethodInfo method in Methods)
                {
                    time += method.ExecutionTime;
                }
                return time;
            }
        }

        [XmlElement("methods")]
        [JsonProperty("methods")]
        public List<MethodInfo> Methods { get; }

        public void AddInformation(MethodInfo method)
        {
            Methods.Add(method);
        }

        public ThreadInfo(long threadID)
        {
            ThreadID = threadID;
            Methods = new List<MethodInfo>();
        }

        public ThreadInfo()
        {
        }
    }
}
