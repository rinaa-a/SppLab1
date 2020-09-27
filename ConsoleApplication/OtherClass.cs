using SppLab1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication
{
    class OtherClass
    {
        private ITracer tracer;

        internal OtherClass(ITracer _tracer)
        {
            tracer = _tracer;
        }

        public void InnerMethod()
        {
            tracer.StartTrace();
            long sum = 0;
            for(int i = 0; i < 100; i++)
            {
                sum += i;
            }
            tracer.StopTrace();
        }
    }
}
