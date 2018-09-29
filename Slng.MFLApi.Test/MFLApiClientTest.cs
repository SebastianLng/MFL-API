using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Slng.MFLApi.Test
{
    [TestClass]
    public class MFLApiClientTest
    {
        private const int testLeague = 35465;
        private const string testFranchise = "0003";
        private readonly MFLApiClient mflApiClient = new MFLApiClient(DateTime.Now.Year);

        [TestMethod]
        public async Task GetLeague()
        {
            var leagueResponse = await mflApiClient.GetLeague(testLeague);
            Assert.IsNotNull(leagueResponse?.league?.baseURL);
        }

        [TestMethod]
        public async Task GetFranchiseRoster()
        {
            var roster = await mflApiClient.GetFranchiseRoster(testLeague, testFranchise);
            Assert.IsNotNull(roster);
        }

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
            Assert.IsNotNull(injuries.GetMFLInjuries());

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
            Assert.IsTrue(schedule.nflSchedule.matchup.Count > 0);
        }
    }
}
