namespace LeagueDraft_API.DTO.RiotApiDTO
{
    public class RiotSummonerDTO
    {
        public string Id { get; set; }
        public string AccountId { get; set; }
        public string Puuid { get; set; }
        public string Name { get; set; }
        public int ProfileIconId { get; set; }
        public long RevisionDate { get; set; }
        public ushort SummonerLevel { get; set; }
    }
}
