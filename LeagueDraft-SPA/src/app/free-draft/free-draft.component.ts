import {Component, OnInit} from '@angular/core';
import {ChampionService} from '../_services/champion.service';
import {ChampionInfo} from '../_models/champion-info';
import {
  CdkDrag,
  CdkDragDrop, CdkDragEnter, CdkDragExit,
  CdkDropList,
  moveItemInArray,
  transferArrayItem
} from '@angular/cdk/drag-drop';

@Component({
  selector: 'app-free-draft',
  templateUrl: './free-draft.component.html',
  styleUrls: ['./free-draft.component.css'],
})
export class FreeDraftComponent implements OnInit{
  championsInfo: ChampionInfo[];
  bluePicks: ChampionInfo[] = [];
  redPicks: ChampionInfo[] = [];
  championsSearchInput = '';
  blueTeamName = 'Blue Team';
  blueTeamNameCanEdit = false;
  redTeamName = 'Red Team';
  redTeamNameCanEdit = false;

  constructor(private championService: ChampionService) {
  }

  ngOnInit(): void {
    this.getChampionsInfo();
  }

  getChampionsInfo(): void {
    this.championService.getChampionsInfo().subscribe((champions: ChampionInfo[]) => {
      this.championsInfo = champions;
    }, error => {
      console.log(error);
    });
  }
  drop(data: ChampionInfo[], event: CdkDragDrop<ChampionInfo[]>): void {
    if (event.previousContainer === event.container) {
      moveItemInArray(
        event.container.data,
        event.previousIndex,
        event.currentIndex
      );
    } else {
      transferArrayItem(
        event.previousContainer.data,
        event.container.data,
        data.indexOf(event.item.data), // gets index of current dragging champion. Especially where the search filter is applied and indexes are different than in original array
        event.currentIndex
      );
      this.sortChampionsArray();
    }
  }

  canEnterPicksContainer(data: ChampionInfo[]) {
    return function(drag: CdkDrag, drop: CdkDropList): boolean
    {
      if (drop.data === data && data.length === 5) {  return false; }
      return true;
    };
  }

  private sortChampionsArray(): void {
    this.championsInfo.sort((a, b) => {
      if (a.name > b.name) { return 1; }
      if (a.name < b.name) { return -1; }
      return 0;
    });
  }
}
