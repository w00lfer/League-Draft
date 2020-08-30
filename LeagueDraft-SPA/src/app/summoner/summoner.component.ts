import {Component, OnInit, ViewEncapsulation} from '@angular/core';
import {SummonerService} from '../_services/summoner.service';
import {SummonerWithRankedInfo} from '../_models/summoner-with-ranked-info/summoner-with-ranked-info';
import {MatchInfo} from "../_models/match-info/match-info";

@Component({
  selector: 'app-summoner',
  templateUrl: './summoner.component.html',
  styleUrls: ['./summoner.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class SummonerComponent implements OnInit {
  private searchBarPositionAlignmentS = 'center center';
  private searchBarFxFlex = '10';
  public summonerInfo: SummonerWithRankedInfo;
  public matchlist: MatchInfo[];

  constructor(private summonerService: SummonerService) { }

  ngOnInit(): void {
    this.getSummonerInfo();

}

  getSummonerInfo(): void {
    this.summonerService.getSummonerInfo().subscribe((summoner: SummonerWithRankedInfo) => {
      this.summonerInfo = summoner;
      this.getMatchlistForSummoner();
    }, error => {
      console.log(error);
    });
  }

  getMatchlistForSummoner(): void {
    this.summonerService.getMatchlistForSummoner(this.summonerInfo.summonerInfo.accountId).subscribe((matchlist: MatchInfo[]) => {
      this.matchlist = matchlist;
      console.log(matchlist);
    }, error => {
      console.log(error)
    });
  }

}
