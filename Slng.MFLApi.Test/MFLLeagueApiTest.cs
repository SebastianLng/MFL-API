using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Slng.MFLApi.Test
{
    [TestClass]
    public class MFLLeagueApiTest
    {
        private const int testLeague = 63018;
        private const string testFranchise = "0003";
        private readonly MFLApiClient mflApiClient = new MFLApiClient(DateTime.Now.Year);
        private readonly MFLApiClient lastYearMflApiClient = new MFLApiClient(DateTime.Now.Year - 1);

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
            Assert.IsTrue(playerScores.GetMFLPlayerScores()?.Count <= 50);
        }

        [TestMethod]
        public async Task GetPlayerScores_Single()
        {
            var playerScores = await mflApiClient.GetPlayerScores(testLeague, 1);
            Assert.IsNotNull(playerScores);
            Assert.IsTrue(playerScores.GetMFLPlayerScores()?.Count <= 1);
        }

        [TestMethod]
        public async Task GetPlayerScores_Position()
        {
            var playerScoresQB = await lastYearMflApiClient.GetPlayerScores(testLeague, 50, "QB");
            var playerScoresWR = await lastYearMflApiClient.GetPlayerScores(testLeague, 50, "WR");
            Assert.IsNotNull(playerScoresQB);
            Assert.IsNotNull(playerScoresWR);

            var qbScores = playerScoresQB.GetMFLPlayerScores();

            foreach (var qbScore in qbScores)
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
    }
}
