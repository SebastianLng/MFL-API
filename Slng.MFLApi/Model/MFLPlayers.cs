using Newtonsoft.Json;
using Slng.MFLApi.Utils;
using System.Collections.Generic;

namespace Slng.MFLApi.Model
{
    public class MFLPlayersReponseBody : MFLResponseBody
    {
        public MFLPlayersResponse players { get; set; }

        public List<MFLPlayer> GetMFLPlayers()
        {
            return players?.player;
        }
    }

    public class MFLPlayersResponse
    {
        public long timestamp { get; set; }

        [JsonConverter(typeof(ArrayOrSingleConverter<MFLPlayer>))]
        public List<MFLPlayer> player { get; set; }
    }

    public class MFLPlayer
    {
        public string position { get; set; }

        public string name { get; set; }

        public string id { get; set; }

        public string team { get; set; }

        public string draft_year { get; set; }

        public string draft_round { get; set; }

        public string nfl_id { get; set; }

        public string rotoworld_id { get; set; }

        public string stats_id { get; set; }

        public string stats_global_id { get; set; }

        public string espn_id { get; set; }

        public string kffl_id { get; set; }

        public string weight { get; set; }

        public string birthdate { get; set; }

        public string draft_team { get; set; }

        public string draft_pick { get; set; }

        public string college { get; set; }

        public string height { get; set; }

        public string jersey { get; set; }

        public string sportsdata_id { get; set; }

        public string cbs_id { get; set; }
    }
}
