namespace LeagueDraft_API.Models
{
    public class Champion
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IconUrl { get; set; }
        public string TileIconUrl { get; set; }
        public int RiotId { get; set; }
    }
}
