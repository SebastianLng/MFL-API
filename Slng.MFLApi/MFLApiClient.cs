using Slng.MFLApi.Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Slng.MFLApi
{
    public class MFLApiClient
    {
        private readonly string baseApiUrl = "http://api.myfantasyleague.com";
        private readonly int year;
        private readonly bool cacheLeagueHost;

        private Dictionary<int, string> leagueHosts = new Dictionary<int, string>();

        public MFLApiClient(int year, bool cacheLeagueHost = true)
        {
            this.year = year;
            this.cacheLeagueHost = cacheLeagueHost;
        }

        public async Task<MFLLeagueResponseBody> GetLeague(int league)
        {
            var leagueResponse = await Get<MFLLeagueResponseBody>($"{baseApiUrl}/{year}/export?TYPE=league&L={league}&JSON=1");

            if  (cacheLeagueHost)
            {
                if (leagueHosts.ContainsKey(leagueResponse.league.id))
                {
                    leagueHosts[leagueResponse.league.id] = leagueResponse.league.baseURL;
                }
                else
                {
                    leagueHosts.Add(leagueResponse.league.id, leagueResponse.league.baseURL);
                }
            }

            return leagueResponse;
        }

        public async Task<MFLPlayerScoresResponseBody> GetPlayerScores(int league, int limit, string position = null, bool yearToDate = false)
        {
            string baseUrl = await GetLeagueHost(league);

            var url = $"{baseUrl}/{year}/export?TYPE=playerScores&L={league}&COUNT={limit}&JSON=1";

            if (!string.IsNullOrEmpty(position))
            {
                position = WebUtility.UrlEncode(position);
                url += "&POSITION=" + position;
            }

            if (yearToDate)
            {
                url += "&W=YTD";
            }


            return await Get<MFLPlayerScoresResponseBody>(url);
        }

        public async Task<MFLPlayerScoresResponseBody> GetPlayerScoresByWeek(int league, int limit, int week, string position = null, bool useLeagueRules = false)
        {
            string baseUrl = await GetLeagueHost(league);

            var url = $"{baseUrl}/{year}/export?TYPE=playerScores&L={league}&COUNT={limit}&JSON=1";

            if (!string.IsNullOrEmpty(position))
            {
                position = WebUtility.UrlEncode(position);
                url += "&POSITION=" + position;
            }

            url += "&W=" + week;

            if (useLeagueRules)
            {
                url += "&RULES=1";
            }

            return await Get<MFLPlayerScoresResponseBody>(url);
        }

        public async Task<MFLPlayersReponseBody> GetPlayers(bool details = false)
        {
            return await Get<MFLPlayersReponseBody>($"{baseApiUrl}/{year}/export?TYPE=players&DETAILS={ (details ? 1 : 0 )}&JSON=1");
        }

        public async Task<MFLPlayersReponseBody> GetPlayers(IList<int> playerIds, bool details = false)
        {
            string encodedPlayers = WebUtility.UrlEncode(string.Join(",", playerIds));
            return await Get<MFLPlayersReponseBody>($"{baseApiUrl}/{year}/export?TYPE=players&PLAYERS={encodedPlayers}&DETAILS={ (details ? 1 : 0)}&JSON=1");
        }

        public async Task<MFLFranchiseRosterResponseBody> GetFranchiseRoster(int league, string franchiseId)
        {
            string baseUrl = await GetLeagueHost(league);
            return await Get<MFLFranchiseRosterResponseBody>($"{baseUrl}/{year}/export?TYPE=rosters&L={league}&FRANCHISE={franchiseId}&JSON=1");
        }

        public async Task<MFLInjuriesResponseBody> GetInjuries(int? week = null)
        {
            var url = $"{baseApiUrl}/{year}/export?TYPE=injuries&JSON=1";
            if (week.HasValue)
            {
                url += "&W=" + week.Value;
            }

            return await Get<MFLInjuriesResponseBody>(url);
        }

        public async Task<MFLTopOwnsResponseBody> GetTopOwns(int? week = null)
        {
            var url = $"{baseApiUrl}/{year}/export?TYPE=topOwns&JSON=1";
            if (week.HasValue)
            {
                url += "&W=" + week.Value;
            }

            return await Get<MFLTopOwnsResponseBody>(url);
        }

        public async Task<MFLNFLScheduleResponseBody> GetNFLSchedule(int? week = null)
        {
            var url = $"{baseApiUrl}/{year}/export?TYPE=nflSchedule&JSON=1";
            if (week.HasValue)
            {
                url += "&W=" + week.Value;
            }

            return await Get<MFLNFLScheduleResponseBody>(url);
        }

        private async Task<TResponse> Get<TResponse>(string url)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var responseString = await httpClient.GetStringAsync(url);
                return JsonConvert.DeserializeObject<TResponse>(responseString);
            }
        }

        private async Task<string> GetLeagueHost(int league)
        {
            if (cacheLeagueHost && leagueHosts.ContainsKey(league))
            {
                return leagueHosts[league];
            }
            else
            {
                var leagueResponse = await GetLeague(league);
                return leagueResponse.league.baseURL;
            }
        }
    }
}
