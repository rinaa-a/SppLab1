using SppLab1.TraceResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SppLab1
{
    class MethodTracer
    {
        private Stack<MethodTracer> innerTracers;
        private MethodInfo methodTraceInfo;
        private long startTime = 0;
        public bool Active { get; set; } = false;

        public MethodTracer()
        {
            innerTracers = new Stack<MethodTracer>();
        }

        public MethodInfo GetTraceResult()
        {
            return methodTraceInfo;
        }

        public void StartTrace(string methodName, string className)
        {
            if(!Active)
            {
                Active = true;
                startTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
                methodTraceInfo = new MethodInfo(methodName, className);
            }
            else
            {
                MethodTracer innerTracer;
                if(innerTracers.Count == 0)
                {
                    innerTracer = new MethodTracer();
                    innerTracers.Push(innerTracer);
                }
                else
                {
                    innerTracer = innerTracers.Peek();
                }
                innerTracer.StartTrace(methodName, className);
            }
        }

        public void StopTrace()
        {
            if (Active)
            {
                if (innerTracers.Count != 0)
                {
                    MethodTracer innerTracer = innerTracers.Peek();
                    innerTracer.StopTrace();
                    if (!innerTracer.Active)
                    {
                        innerTracers.Pop();
                        MethodInfo innerMethodInfo = innerTracer.GetTraceResult();
                        methodTraceInfo.AddInformation(innerMethodInfo);
                    }
                }
                else
                {
                    long stopTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
                    long executionTime = stopTime - startTime;
                    methodTraceInfo.ExecutionTime = executionTime;
                    Active = false;
                }
            }
        }
    }
}
