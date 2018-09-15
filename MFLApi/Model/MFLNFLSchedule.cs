using System.Collections.Generic;

namespace MFLApi.Model
{
    public class MFLNFLScheduleResponseBody : MFLResponseBody
    {
        public MFLNFLScheduleResponse nflSchedule { get; set; }
    }

    public class MFLNFLScheduleResponse
    {
        public List<MFLNFLMatchup> matchup { get; set; }

        public string week { get; set; }
    }

    public class MFLNFLMatchup
    {
        public string kickoff { get; set; }

        public string gameSecondsRemaining { get; set; }

        public List<MFLNFLTeam> team { get; set; }
    }

    public class MFLNFLTeam
    {
        public string inRedZone { get; set; }

        public string score { get; set; }

        public string hasPossession { get; set; }

        public string passOffenseRank { get; set; }

        public string rushOffenseRank { get; set; }

        public string passDefenseRank { get; set; }

        public string spread { get; set; }

        public string isHome { get; set; }

        public string id { get; set; }

        public string rushDefenseRank { get; set; }
    }
}
