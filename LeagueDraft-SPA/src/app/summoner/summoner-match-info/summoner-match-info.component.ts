import {Component, Input, OnInit} from '@angular/core';
import {MatchInfo} from "../../_models/match-info/match-info";
import {MatchInfoParticipant} from "../../_models/match-info/match-info-participant";

@Component({
  selector: 'app-summoner-match-info',
  templateUrl: './summoner-match-info.component.html',
  styleUrls: ['./summoner-match-info.component.css']
})
export class SummonerMatchInfoComponent implements OnInit {
  @Input() match: MatchInfo;
  @Input() summonerName: string;
  @Input() summ: MatchInfoParticipant;

  firstTeam: MatchInfoParticipant[];
  secondTeam: MatchInfoParticipant[];
  summoner: MatchInfoParticipant;
  constructor() { }

  ngOnInit(): void {
    this.firstTeam = this.match.players.filter(x => x.teamId == 100)
    this.secondTeam = this.match.players.filter(x => x.teamId == 200)
    this.summoner = this.match.players.find(x => x.summoner.summonerName == this.summonerName)
  }

}
