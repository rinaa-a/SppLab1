using SppLab1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication
{
    class SomeClass
    {
        private OtherClass otherClass;
        private ITracer tracer;

        internal SomeClass(ITracer _tracer)
        {
            tracer = _tracer;
            otherClass = new OtherClass(tracer);
        }

        public void MyMethod()
        {
            tracer.StartTrace();
            int sum = 0;
            for(int i = 0; i < 200; i++)
            {
                sum += i;
            }
            otherClass.InnerMethod();
            tracer.StopTrace();
        }

        public void OtherMethod()
        {
            int sum = 0;
            for(int i = 0; i < 10; i++)
            {
                sum += i;
            }
        }
    }
}
