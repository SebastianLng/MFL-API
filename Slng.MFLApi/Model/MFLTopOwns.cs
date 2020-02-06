using Newtonsoft.Json;
using Slng.MFLApi.Utils;
using System.Collections.Generic;

namespace Slng.MFLApi.Model
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
        public string week { get; set; }

        [JsonConverter(typeof(ArrayOrSingleConverter<MFLTopOwnsPlayer>))]
        public List<MFLTopOwnsPlayer> player { get; set; }
    }

    public class MFLTopOwnsPlayer
    {
        public string id { get; set; }

        public float percent { get; set; }
    }
}
