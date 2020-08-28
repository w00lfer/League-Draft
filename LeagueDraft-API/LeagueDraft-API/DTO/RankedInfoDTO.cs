namespace LeagueDraft_API.DTO
{
    public class RankedInfoDTO
    {
        public string QueueType { get; set; }
        public string TierAndRank { get; set; }
        public int LeaguePoints { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
    }
}
