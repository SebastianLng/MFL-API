using System.Collections.Generic;

namespace MFLApi.Model
{
    public class MFLTopOwnsResponseBody : MFLResponseBody
    {
        public MFLTopOwnsResponse topOwns { get; set; }

        public List<MFLTopOwnsPlayer> GetMFLPlayers()
        {
            return topOwns?.player;
        }
    }

    public class MFLTopOwnsResponse
    {
        public int week { get; set; }

        public List<MFLTopOwnsPlayer> player { get; set; }
    }

    public class MFLTopOwnsPlayer
    {
        public int id { get; set; }

        public float percent { get; set; }
    }
}
