using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SppLab1;
using SppLab1.TraceResults;
using SppLab1.Serializers;
using SppLab1.Writers;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            ITracer tracer = new Tracer();
            SomeClass someClass = new SomeClass(tracer);
            OtherClass otherClass = new OtherClass(tracer);
            Thread thread = new Thread(new ThreadStart(someClass.MyMethod));
            thread.Start();
            tracer.StartTrace();
            someClass.OtherMethod();
            tracer.StopTrace();
            while (thread.IsAlive) { }
            TraceResult result = tracer.GetTraceResult();
            JsonResultSerializer JsonSerializer = new JsonResultSerializer();
            XmlResultSerializer XmlSerializer = new XmlResultSerializer();
            string resultJson = JsonSerializer.Serialize(result);
            string resultXml = XmlSerializer.Serialize(result);
            ConsoleWriter consoleWriter = new ConsoleWriter();
            FileWriter fileWriter = new FileWriter();
            consoleWriter.WriteResult(resultXml);
            consoleWriter.WriteResult(resultJson);
            fileWriter.WriteResult(resultXml, nameof(resultXml));
            fileWriter.WriteResult(resultJson, nameof(resultJson));
        }
    }
}
