using RestLesser.OData;
using RestLesser.OData.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestLesser.Tests
{
    public class ODataClientTests
    {
        private class Dummy
        {
            [PrimaryKey]
            public int Id { get; set; }

            public string? Name { get; set; }
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ODataClient_BuildValueUrlTest()
        {
            var builder = new ODataUrlBuilder<Dummy>("/dummy")
                .Key(1);

            var result = ODataClient.BuildValueUrl(builder, f => f.Name);
            Assert.That(result, Is.EqualTo("/dummy(1)/Name/$value"));
        }
    }
}
