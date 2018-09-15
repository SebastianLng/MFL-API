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

            Assert.AreEqual(injuries.GetMFLInjuries().Count, players.GetMFLPlayers().Count);
        }

        [TestMethod]
        public async Task GetTopOwns()
        {
            var topOwns = await mflApiClient.GetTopOwns();
            Assert.IsNotNull(topOwns);
            Assert.IsNotNull(topOwns.GetMFLPlayers());
        }

        [TestMethod]
        public async Task GetNFLSchedule()
        {
            var schedule = await mflApiClient.GetNFLSchedule();
            Assert.IsNotNull(schedule);
            Assert.IsNotNull(schedule?.nflSchedule?.matchup);
            Assert.AreEqual(16, schedule.nflSchedule.matchup.Count);
        }
    }
}
