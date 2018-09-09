namespace MFLApi.Model
{
    public class MFLPlayerScoresResponseBody : MFLResponseBody
    {
        public MFLPlayerScoresResponse playerScores { get; set; }

        public MFLPlayerScore[] GetMFLPlayerScores()
        {
            return playerScores?.playerScore;
        }
    }

    public class MFLPlayerScoresResponse
    {
        public string week { get; set; }

        public MFLPlayerScore[] playerScore { get; set; }
    }

    public class MFLPlayerScore
    {
        public int id { get; set; }

        public int isAvailable { get; set; }

        public float score { get; set; }
    }
}
