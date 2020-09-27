using SppLab1.TraceResults;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SppLab1.Serializers
{
    class XmlResultSerializer : IResultSerializer
    {
        public string Serialize(TraceResult result)
        {
            XmlSerializer serializer = new XmlSerializer(result.GetType());
            using(StringWriter writer = new StringWriter())
            {
                serializer.Serialize(writer, result);
                return writer.ToString();
            }
        }
    }
}
