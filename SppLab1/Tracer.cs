using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SppLab1.TraceResults;

namespace SppLab1
{
    public class Tracer : ITracer
    {
        private TraceResult TraceResult { get; }
        private static readonly object lockObject = new object();
        private Dictionary<long, ThreadTracer> Tracers { get; }

        public TraceResult GetTraceResult()
        {
            foreach(var tracerPair in Tracers)
            {
                TraceResult.AddInformation(tracerPair.Value.ThreadTraceInfo);
            }
            return TraceResult;
        }

        public void StartTrace()
        {
            lock(lockObject)
            {
                long id = Thread.CurrentThread.ManagedThreadId;
                if (Tracers.ContainsKey(id))
                {
                    ThreadTracer tracer = Tracers[id];
                    tracer.StartTrace();
                }
                else
                {
                    ThreadTracer tracer = new ThreadTracer();
                    Tracers.Add(id, tracer);
                    tracer.StartTrace();
                }
            }
        }

        public void StopTrace()
        {
            lock(lockObject)
            {
                long id = Thread.CurrentThread.ManagedThreadId;
                if (Tracers.ContainsKey(id))
                {
                    ThreadTracer tracer = Tracers[id];
                    tracer.StopTrace();
                }
            }
        
        }

        public Tracer()
        {
            TraceResult = new TraceResult();
            Tracers = new Dictionary<long, ThreadTracer>();
        }
    }
}
