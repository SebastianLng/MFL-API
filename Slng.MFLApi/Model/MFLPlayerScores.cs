using Slng.MFLApi.Converter;
using System.Collections.Generic;
using System.Text.Json.Serialization;

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
        public int week { get; set; }

        [JsonConverter(typeof(ArrayOrSingleConverter))]
        public List<MFLPlayerScore> playerScore { get; set; }
    }

    public class MFLPlayerScore
    {
        public int id { get; set; }

        public int isAvailable { get; set; }

        public float score { get; set; }
    }
}
