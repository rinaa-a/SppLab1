using SppLab1.TraceResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace SppLab1
{
    public class ThreadTracer
    {
        public ThreadInfo ThreadTraceInfo { get; }
        private MethodTracer tracer;

        public ThreadTracer()
        {
            long id = Thread.CurrentThread.ManagedThreadId;
            ThreadTraceInfo = new ThreadInfo(id);
        }

        public void StartTrace()
        {
            StackTrace trace = new StackTrace();
            string methodName = trace.GetFrame(2).GetMethod().Name;
            string className = trace.GetFrame(2).GetMethod().DeclaringType.FullName;
            if (tracer == null)
            {
                tracer = new MethodTracer();
            }
            tracer.StartTrace(className, methodName);
        }

        public void StopTrace()
        {
            if (tracer != null)
            {
                tracer.StopTrace();
                if(!tracer.Active)
                {
                    MethodInfo methodInfo = tracer.GetTraceResult();
                    ThreadTraceInfo.AddInformation(methodInfo);
                    tracer = null;
                }
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
    }
}
