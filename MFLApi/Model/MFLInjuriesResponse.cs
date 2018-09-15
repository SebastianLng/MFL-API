using System.Collections.Generic;

namespace MFLApi.Model.Injuries
{
    public class MFLInjuriesResponseBody : MFLResponseBody
    {
        public MFLInjuriesResponse injuries { get; set; }

        public List<MFLInjury> GetMFLInjuries()
        {
            return injuries?.injury;
        }
    }

    public class MFLInjuriesResponse
    {
        public long timestamp { get; set; }

        public int week { get; set; }

        public List<MFLInjury> injury { get; set; }
    }

    public class MFLInjury
    {
        public int id { get; set; }

        public string status { get; set; }

        public string details { get; set; }
    }
}
