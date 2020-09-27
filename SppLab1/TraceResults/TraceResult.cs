using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SppLab1.TraceResults
{
    public class TraceResult : ITraceResult<ThreadInfo>
    {
        [XmlElement("thread")]
        [JsonProperty("thread")]
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
