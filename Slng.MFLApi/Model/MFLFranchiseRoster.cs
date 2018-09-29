using System.Collections.Generic;

namespace Slng.MFLApi.Model
{
    public class MFLFranchiseRosterResponseBody : MFLResponseBody
    {
        public MFLFranchiseRosters rosters { get; set; }

        public MFLFranchiseRoster GetMFLFranchise()
        {
            return rosters?.franchise;
        }
    }

    public class MFLFranchiseRosters
    {
        public MFLFranchiseRoster franchise { get; set; }
    }

    public class MFLFranchiseRoster
    {
        public string id { get; set; }

        public List<MFLFranchisePlayer> player { get; set; }
    }

    public class MFLFranchisePlayer
    {
        public int id { get; set; }

        public string status { get; set; }
    }
}
