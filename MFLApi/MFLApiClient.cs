using MFLApi.Model;
using MFLApi.Model.Franchise;
using MFLApi.Model.Injuries;
using MFLApi.Model.Player;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace MFLApi
{
    public class MFLApiClient
    {
        private readonly string baseUrl = "https://www60.myfantasyleague.com";
        private readonly int year;

        public MFLApiClient(int year)
        {
            this.year = year;
        }

        public async Task<MFLPlayerScoresResponseBody> GetPlayerScoresForPosition(string position, int league, int year, int count)
        {
            position = WebUtility.UrlEncode(position);
            return await Get<MFLPlayerScoresResponseBody>($"{baseUrl}/{year}/export?TYPE=playerScores&L={league}&W=YTD&POSITION={position}&RULES=1&COUNT={count}&JSON=1");
        }

        public async Task<MFLPlayersReponseBody> GetPlayers()
        {
            return await Get<MFLPlayersReponseBody>($"{baseUrl}/{year}/export?TYPE=players&JSON=1");
        }

        public async Task<MFLPlayersReponseBody> GetPlayers(IList<int> playerIds)
        {
            string encodedPlayers = WebUtility.UrlEncode(string.Join(",", playerIds));
            return await Get<MFLPlayersReponseBody>($"{baseUrl}/{year}/export?TYPE=players&PLAYERS={encodedPlayers}&JSON=1");
        }

        public async Task<MFLFranchiseRosterBody> GetFranchisePlayers(string franchiseId, int league)
        {
            return await Get<MFLFranchiseRosterBody>($"{baseUrl}/{year}/export?TYPE=rosters&L={league}&FRANCHISE={franchiseId}&JSON=1");
        }

        public async Task<MFLInjuriesResponseBody> GetInjuries(int? week = null)
        {
            var url = $"{baseUrl}/{year}/export?TYPE=injuries&JSON=1";
            if (week.HasValue)
            {
                url += "&W=" + week.Value;
            }

            return await Get<MFLInjuriesResponseBody>(url);
        }

        private async Task<TResponse> Get<TResponse>(string url)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var responseString = await httpClient.GetStringAsync(url);
                var response = JsonConvert.DeserializeObject<TResponse>(responseString);
                return response;
            }
        }
    }
}
