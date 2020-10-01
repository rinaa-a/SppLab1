using NUnit.Framework;
using SppLab1;
using SppLab1.TraceResults;
using System;

namespace NUnitTestProject
{
    class TracerTest
    {
        private Tracer tracer;
        [SetUp]
        public void Setup()
        {
            tracer = new Tracer();
        }

        [Test]
        public void TestInvalidStop()
        {
            Setup();
            Assert.Throws<InvalidOperationException>(tracer.StopTrace);
        }

        [Test]
        public void TestGetTraceResult()
        {
            Setup();
            tracer.StartTrace();
            tracer.StartTrace();
            tracer.StopTrace();
            tracer.StopTrace();
            var traceResult = tracer.GetTraceResult();
            Assert.NotNull(traceResult);
        }
    }
}
