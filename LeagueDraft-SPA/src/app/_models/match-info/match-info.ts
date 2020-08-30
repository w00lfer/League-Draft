import {MatchInfoParticipant} from "./match-info-participant";

export interface MatchInfo {
  won: boolean;
  players: MatchInfoParticipant[];
}
