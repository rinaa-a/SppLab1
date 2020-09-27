using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SppLab1.TraceResults
{
    class TraceResult : ITraceResult<ThreadInfo>
    {
        [XmlElement("threads")]
        [JsonProperty("threads")]
        public List<ThreadInfo> Threads { get; }

        public void AddInformation(ThreadInfo thread)
        {
            Threads.Add(thread);
        }

        public TraceResult()
        {
            Threads = new List<ThreadInfo>();
        }
    }
}
