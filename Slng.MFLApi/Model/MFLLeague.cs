using Newtonsoft.Json;
using Slng.MFLApi.Utils;
using System.Collections.Generic;

namespace Slng.MFLApi.Model
{
    public class MFLLeagueResponseBody : MFLResponseBody
    {
        public MFLLeague league { get; set; }
    }

    public class MFLLeague
    {
        public string currentWaiverType { get; set; }

        public string playerLimitUnit { get; set; }

        public string taxiSquad { get; set; }

        public string endWeek { get; set; }

        public string maxWaiverRounds { get; set; }

        public string lockout { get; set; }

        public string nflPoolStartWeek { get; set; }

        public MFLLeagueFranchises franchises { get; set; }

        public string standingsSort { get; set; }

        public string id { get; set; }

        public string minBid { get; set; }

        public string nflPoolType { get; set; }

        public MFLLeagueHistory history { get; set; }

        public string rosterSize { get; set; }

        public string name { get; set; }

        public MFLLeagueRosterLimits rosterLimits { get; set; }

        public string includeIRWithSalary { get; set; }

        public MFLLeagueStarters starters { get; set; }

        public string includeTaxiWithSalary { get; set; }

        public string nflPoolEndWeek { get; set; }

        public string bestLineup { get; set; }

        public string precision { get; set; }

        public string lastRegularSeasonWeek { get; set; }

        public string survivorPool { get; set; }

        public string usesContractYear { get; set; }

        public string minKeepers { get; set; }

        public string injuredReserve { get; set; }

        public string startWeek { get; set; }

        public string salaryCapAmount { get; set; }

        public string survivorPoolStartWeek { get; set; }

        public string survivorPoolEndWeek { get; set; }

        public string rostersPerPlayer { get; set; }

        public string h2h { get; set; }

        public string usesSalaries { get; set; }

        public string backupPlayers { get; set; }

        public string maxKeepers { get; set; }

        public MFLLeagueDivisions divisions { get; set; }

        public string baseURL { get; set; }

        public string bidIncrement { get; set; }

        public string loadRosters { get; set; }
    }

    public class MFLLeagueFranchises
    {
        public string count { get; set; }

        [JsonConverter(typeof(ArrayOrSingleConverter<MFLLeagueFranchise>))]
        public List<MFLLeagueFranchise> franchise { get; set; }
    }

    public class MFLLeagueFranchise
    {
        public string icon { get; set; }

        public string division { get; set; }

        public string name { get; set; }

        public string waiverSortOrder { get; set; }

        public string auctionStartAmount { get; set; }

        public string logo { get; set; }

        public string salaryCapAmount { get; set; }

        public string id { get; set; }

        public string abbrev { get; set; }
    }

    public class MFLLeagueHistory
    {
        public List<MFLLeagueHistoryInfo> league { get; set; }
    }

    public class MFLLeagueHistoryInfo
    {
        public string url { get; set; }

        public string year { get; set; }
    }

    public class MFLLeagueRosterLimits
    {
        public List<MFLLeaguePosition> position { get; set; }
    }

    public class MFLLeagueStarters
    {
        public string count { get; set; }
        public List<MFLLeaguePosition> position { get; set; }
        public string idp_starters { get; set; }
    }

    public class MFLLeaguePosition
    {
        public string name { get; set; }

        public string limit { get; set; }
    }

    public class MFLLeagueDivisions
    {
        public string count { get; set; }

        public List<MFLLeagueDivision> division { get; set; }
    }

    public class MFLLeagueDivision
    {
        public string name { get; set; }

        public string id { get; set; }
    }
}
