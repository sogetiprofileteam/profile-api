using NUnit.Framework;
using sogeti_portfolio_api.Services;

namespace Tests
{
    [TestFixture]
    public class CosmosTests
    {
        [Test]
        public void TestCosmos()
        {
            var service = new ConsultantService();
            var result = service.GetConsultants();
        }
    }
}