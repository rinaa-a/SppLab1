using NUnit.Framework;
using SppLab1;
using SppLab1.TraceResults;
using System;

namespace NUnitTestProject
{
    public class ThreadTracerTest
    {
        private ThreadTracer threadTracer;
        [SetUp]
        public void Setup()
        {
            threadTracer = new ThreadTracer();
        }

        [Test]
        public void TestThreadTrace()
        {
            Setup();
            threadTracer.StartTrace();
            threadTracer.StopTrace();
            ThreadInfo res = threadTracer.ThreadTraceInfo;
            Assert.That(res.Methods, Is.Not.Empty);
        }

        [Test]
        public void TestInvalidStop()
        {
            Setup();
            Assert.Throws<InvalidOperationException>(threadTracer.StopTrace);
        }
    }
}