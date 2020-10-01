using NUnit.Framework;
using SppLab1;
using SppLab1.TraceResults;
using System;

namespace NUnitTestProject
{
    class MethodTracerTest
    {
        private const string className = "class";
        private const string methodName = "method";
        private const string innerClassName = "innerClass";
        private const string innerMethodName = "innerMethod";

        private MethodTracer methodTracer;
        [SetUp]
        public void Setup()
        {
            methodTracer = new MethodTracer();
        }

        [Test]
        public void TestInvalidStop()
        {
            Setup();
            Assert.Throws<InvalidOperationException>(methodTracer.StopTrace);
        }

        [Test]
        public void TestMethodTrace()
        {
            Setup();
            methodTracer.StartTrace(className, methodName);
            methodTracer.StartTrace(innerClassName, innerMethodName);
            methodTracer.StopTrace();
            methodTracer.StopTrace();
            MethodInfo res = methodTracer.GetTraceResult();
            Assert.AreEqual(className, res.ClassName);
            Assert.AreEqual(methodName, res.MethodName);
            MethodInfo innerRes = res.InnerMethods[0];
            Assert.AreEqual(innerClassName, innerRes.ClassName);
            Assert.AreEqual(innerMethodName, innerRes.MethodName);
        }
    }
}
