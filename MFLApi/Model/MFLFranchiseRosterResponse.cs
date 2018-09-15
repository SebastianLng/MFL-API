namespace MFLApi.Model.Franchise
{
    public class MFLFranchiseRosterBody : MFLResponseBody
    {
        public MFLFranchiseRoster rosters { get; set; }

        public MFLFranchise GetMFLFranchise()
        {
            return rosters?.franchise;
        }
    }

    public class MFLFranchiseRoster
    {
        public MFLFranchise franchise { get; set; }
    }

    public class MFLFranchise
    {
        public string id { get; set; }

        public MFLFranchisePlayer[] player { get; set; }
    }

    public class MFLFranchisePlayer
    {
        public int id { get; set; }

        public string status { get; set; }
    }
}
