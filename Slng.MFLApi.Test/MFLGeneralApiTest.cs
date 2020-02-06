using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Slng.MFLApi.Test
{
    [TestClass]
    public class MFLGeneralApiTest
    {
        private readonly MFLApiClient mflApiClient = new MFLApiClient(DateTime.Now.Year);

        [TestMethod]
        public async Task GetInjuries()
        {
            var injuries = await mflApiClient.GetInjuries();
            Assert.IsNotNull(injuries);
            Assert.IsNotNull(injuries.injuries);
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
        public async Task GetPlayersSimple_Single()
        {
            var injuries = await mflApiClient.GetInjuries();
            Assert.IsNotNull(injuries.GetMFLInjuries());

            var players = await mflApiClient.GetPlayers(new List<string>() { injuries.GetMFLInjuries().Select(i => i.id).First() });
            Assert.IsNotNull(players);

            // No details loaded
            foreach (var p in players.players.player)
            {
                Assert.IsTrue(string.IsNullOrEmpty(p.college));
            }

            Assert.AreEqual(1, players.GetMFLPlayers().Count);
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

        [TestMethod]
        public async Task GetPlayersDetails_Single()
        {
            var injuries = await mflApiClient.GetInjuries();
            Assert.IsNotNull(injuries.GetMFLInjuries());

            List<string> playerInput = new List<string>() { injuries.GetMFLInjuries().Select(i => i.id).First() };
            var players = await mflApiClient.GetPlayers(playerInput, true);
            Assert.IsNotNull(players);

            // details loaded
            foreach (var p in players.players.player)
            {
                Assert.IsFalse(string.IsNullOrEmpty(p.college));
            }

            Assert.AreEqual(playerInput.Count, players.GetMFLPlayers().Count);
        }
    }
}
