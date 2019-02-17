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
        public async Task GetPlayerScores()
        {
            var playerScores = await mflApiClient.GetPlayerScores(testLeague, 50);
            Assert.IsNotNull(playerScores);
            Assert.AreEqual(50, playerScores.GetMFLPlayerScores()?.Count);
        }

        [TestMethod]
        public async Task GetPlayerScores_Position()
        {
            var playerScoresQB = await mflApiClient.GetPlayerScores(testLeague, 50, "QB");
            var playerScoresWR = await mflApiClient.GetPlayerScores(testLeague, 50, "WR");
            Assert.IsNotNull(playerScoresQB);
            Assert.IsNotNull(playerScoresWR);

            foreach (var qbScore in playerScoresQB.GetMFLPlayerScores())
            {
                Assert.IsFalse(playerScoresWR.GetMFLPlayerScores().Any(score => score.id == qbScore.id));
            }
        }

        [TestMethod]
        public async Task GetPlayerScores_Week()
        {
            var playerScores = await mflApiClient.GetPlayerScoresByWeek(testLeague, 50, 1);
            Assert.IsNotNull(playerScores);
            Assert.AreEqual("1", playerScores.playerScores.week);
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

        [TestMethod]
        public async Task GetPlayersSimple()
        {
            var injuries = await mflApiClient.GetInjuries();
            Assert.IsNotNull(injuries.GetMFLInjuries());

            var players = await mflApiClient.GetPlayers(injuries.GetMFLInjuries().Select(i => i.id).ToList());
            Assert.IsNotNull(players);

            // No details loaded
            foreach (var p in players.players.player)
            {
                Assert.IsTrue(string.IsNullOrEmpty(p.college));
            }

            Assert.AreEqual(injuries.GetMFLInjuries().Count, players.GetMFLPlayers().Count);
        }

        [TestMethod]
        public async Task GetPlayersDetails()
        {
            var injuries = await mflApiClient.GetInjuries();
            Assert.IsNotNull(injuries.GetMFLInjuries());

            var players = await mflApiClient.GetPlayers(injuries.GetMFLInjuries().Select(i => i.id).ToList(), true);
            Assert.IsNotNull(players);

            // details loaded
            foreach (var p in players.players.player)
            {
                Assert.IsFalse(string.IsNullOrEmpty(p.college));
            }

            Assert.AreEqual(injuries.GetMFLInjuries().Count, players.GetMFLPlayers().Count);
        }
    }
}
