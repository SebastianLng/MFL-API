namespace MFLApi.Model
{
    public class MFLTopOwnsResponseBody : MFLResponseBody
    {
        public MFLTopOwnsResponse topOwns { get; set; }

        public MFLTopOwnsPlayer[] GetPlayers()
        {
            return topOwns?.player;
        }
    }

    public class MFLTopOwnsResponse
    {
        public int week { get; set; }

        public MFLTopOwnsPlayer[] player { get; set; }
    }

    public class MFLTopOwnsPlayer
    {
        public int id { get; set; }

        public float percent { get; set; }
    }
}
