using NUnit.Framework;
using SppLab1;
using SppLab1.TraceResults;
using SppLab1.Serializers;
using System;

namespace NUnitTestProject
{
    class JsonSerializerTest
    {
        private JsonResultSerializer serializer;
        private const string res = "{\"thread\":[]}";

        [SetUp]
        public void Setup()
        {
            serializer = new JsonResultSerializer();
        }

        [Test]
        public void TestSerializer()
        {
            Setup();
            TraceResult result = new TraceResult();
            var serRes = serializer.Serialize(result);
            Assert.AreEqual(res, serRes);
        }
    }
}
