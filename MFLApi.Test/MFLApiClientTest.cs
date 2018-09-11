using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading.Tasks;

namespace MFLApi.Test
{
    [TestClass]
    public class MFLApiClientTest
    {
        private readonly MFLApiClient mflApiClient = new MFLApiClient(2018);

        [TestMethod]
        public async Task GetInjuries()
        {
            var injuries = await mflApiClient.GetInjuries();
            Assert.IsNotNull(injuries);
        }

        [TestMethod]
        public async Task GetInjuredPlayers()
        {
            var injuries = await mflApiClient.GetInjuries();
            Assert.IsNotNull(injuries);

            var players = await mflApiClient.GetPlayers(injuries.GetMFLInjuries().Select(i => i.id).ToList());
            Assert.IsNotNull(players);

            Assert.AreEqual(injuries.GetMFLInjuries().Length, players.GetMFLPlayers().Length);
        }

        [TestMethod]
        public async Task GetTopOwns()
        {
            var topOwns = await mflApiClient.GetTopOwns();
            Assert.IsNotNull(topOwns);
            Assert.IsNotNull(topOwns.GetMFLPlayers());
        }
    }
}
