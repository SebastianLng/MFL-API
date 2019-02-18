using Newtonsoft.Json;
using Slng.MFLApi.Utils;
using System.Collections.Generic;

namespace Slng.MFLApi.Model
{
    public class MFLPlayerScoresResponseBody : MFLResponseBody
    {
        public MFLPlayerScoresResponse playerScores { get; set; }

        public List<MFLPlayerScore> GetMFLPlayerScores()
        {
            return playerScores?.playerScore;
        }
    }

    public class MFLPlayerScoresResponse
    {
        public string week { get; set; }

        [JsonConverter(typeof(ArrayOrSingleConverter<MFLPlayerScore>))]
        public List<MFLPlayerScore> playerScore { get; set; }
    }

    public class MFLPlayerScore
    {
        public int id { get; set; }

        public int isAvailable { get; set; }

        public float score { get; set; }
    }
}
