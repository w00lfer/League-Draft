import {MatchInfoParticipantIdentity} from "./match-info-participant-identity";
import {ChampionInfo} from "../champion-info";

export interface MatchInfoParticipant {
  summoner: MatchInfoParticipantIdentity;
  championInfo: ChampionInfo
  teamId: number;
}
