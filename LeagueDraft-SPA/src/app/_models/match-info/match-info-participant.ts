import {MatchInfoParticipantIdentity} from "./match-info-participant-identity";
import {ChampionInfo} from "../champion-info";
import {MatchInfoParticipantStats} from "./match-info-participant-stats";

export interface MatchInfoParticipant {
  summoner: MatchInfoParticipantIdentity;
  championInfo: ChampionInfo
  teamId: number;
  stats: MatchInfoParticipantStats
}
