using Newtonsoft.Json;
using SppLab1.TraceResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SppLab1.TraceResults
{
    public class MethodInfo : ITraceResult<MethodInfo>
    {
        [XmlElement("name")]
        [JsonProperty("name")]
        public string MethodName { get; set; }

        [XmlElement("time")]
        [JsonProperty("time")]
        public long ExecutionTime { get; set; }

        [XmlElement("class")]
        [JsonProperty("class")]
        public string ClassName { get; set; }

        [XmlElement("methods")]
        [JsonProperty("methods")]
        public List<MethodInfo> InnerMethods { get; }

        public MethodInfo(string className, string methodName)
        {
            MethodName = methodName;
            ClassName = className;
            ExecutionTime = 0;
            InnerMethods = new List<MethodInfo>();
        }

        public void AddInformation(MethodInfo innerMethod)
        {
            InnerMethods.Add(innerMethod);
        }

        public MethodInfo()
        {
        }
    }
}
