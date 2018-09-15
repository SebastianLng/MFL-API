using System.Collections.Generic;

namespace MFLApi.Model.Player
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

        public List<MFLPlayer> player { get; set; }
    }

    public class MFLPlayer
    {
        public string position { get; set; }

        public string name { get; set; }

        public int id { get; set; }

        public string team { get; set; }
    }
}
