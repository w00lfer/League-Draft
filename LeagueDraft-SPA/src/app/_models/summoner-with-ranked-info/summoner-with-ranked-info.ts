import {RankedInfo} from './ranked-info';
import {SummonerInfo} from './summoner-info';

export interface SummonerWithRankedInfo {
  rankedInfo: RankedInfo[];
  summonerInfo: SummonerInfo;
}
