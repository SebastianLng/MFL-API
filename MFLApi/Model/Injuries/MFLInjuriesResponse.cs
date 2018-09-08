namespace MFLApi.Model.Injuries
{
    public class MFLInjuriesResponse
    {
        public long timestamp { get; set; }

        public int week { get; set; }

        public MFLInjury[] injury { get; set; }
    }
}
