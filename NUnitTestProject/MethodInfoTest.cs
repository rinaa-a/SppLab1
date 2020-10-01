using NUnit.Framework;
using SppLab1;
using SppLab1.TraceResults;
using System;

namespace NUnitTestProject
{
    class MethodInfoTest
    {
        private MethodInfo methodInfo;
        private const string className = "class";
        private const string methodName = "method";
        private const long executionTime = 500L;

        [SetUp]
        public void Setup()
        {
            methodInfo = new MethodInfo(className, methodName);
        }

        [Test]
        public void TestGetMethodName()
        {
            Setup();
            var name = methodInfo.MethodName;
            Assert.AreEqual(methodName, name);
        }

        [Test]
        public void TestGetClassName()
        {
            Setup();
            var name = methodInfo.ClassName;
            Assert.AreEqual(className, name);
        }

        [Test]
        public void TestGetExecutionTime()
        {
            Setup();
            methodInfo.ExecutionTime = executionTime;
            var time = methodInfo.ExecutionTime;
            Assert.AreEqual(executionTime, time);
        }
    }
}
