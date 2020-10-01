using NUnit.Framework;
using SppLab1;
using SppLab1.TraceResults;
using SppLab1.Serializers;
using System;
namespace NUnitTestProject
{
    class XmlSerializerTest
    {
        private XmlResultSerializer serializer;
        private const string res = "<?xml version=\"1.0\" encoding=\"utf-16\"?>\r\n<TraceResult xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" />";

        [SetUp]
        public void Setup()
        {
            serializer = new XmlResultSerializer();
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
