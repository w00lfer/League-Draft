using System;

namespace LeagueDraft_API.DTO
{
    public class JwtToken
    {
        public string Token { get; set; }
        public DateTime Expires { get; set; }
    }
}
