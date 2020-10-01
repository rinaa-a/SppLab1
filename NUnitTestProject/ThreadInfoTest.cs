using NUnit.Framework;
using SppLab1;
using SppLab1.TraceResults;
using System;

namespace NUnitTestProject
{
    class ThreadInfoTest
    {
        private const long ID = 1L;
        private const long executionTime = 1L;

        private MethodInfo methodInfo;
        private ThreadInfo threadInfo;

        private const string className = "class";
        private const string methodName = "method";

        [SetUp]
        public void Setup()
        {
            threadInfo = new ThreadInfo(ID);
            methodInfo = new MethodInfo(className, methodName) { ExecutionTime = executionTime };
            threadInfo.AddInformation(methodInfo);
        }

        [Test]
        public void TestGetThreadId()
        {
            Setup();
            var id = threadInfo.ThreadID;
            Assert.AreEqual(ID, id);
        }

        [Test]
        public void TestGetExecutionTime()
        {
            Setup();
            var time = threadInfo.ExecutionTime;
            Assert.AreEqual(executionTime, time);
        }

        [Test]
        public void TestGetInnerMethods()
        {
            Setup();
            var res = threadInfo.Methods[0];
            Assert.AreEqual(methodInfo, res);
        }

    }
}
