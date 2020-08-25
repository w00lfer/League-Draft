using AutoMapper;
using LeagueDraft_API.DTO;
using LeagueDraft_API.DTO.RiotApiDTO;
using System.Linq;

namespace LeagueDraft_API.Mappings
{
    public class MatchInfoWonResolver : IValueResolver<RiotMatchDTO, MatchInfoDTO, bool>
    {
        public bool Resolve(RiotMatchDTO riotMatchDto, MatchInfoDTO matchInfoDto,
            bool won, ResolutionContext context)
        {
            var accountId = (string)context.Items["AccountId"];
            var participantId = riotMatchDto.ParticipantIdentities.SingleOrDefault(p => p.Player.AccountId == accountId).ParticipantId;
            bool haveWon = riotMatchDto.Participants.FirstOrDefault(p => p.ParticipantId == participantId).TeamId ==
                        riotMatchDto.Teams.FirstOrDefault(t => t.Win == "Win").TeamId;
            return haveWon;
        }
    }
}
