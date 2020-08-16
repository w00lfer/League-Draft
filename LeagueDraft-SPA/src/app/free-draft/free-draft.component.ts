import { Component, OnInit } from '@angular/core';
import {ChampionService} from "../_services/champion.service";
import {ChampionInfo} from "../_models/ChampionInfo";
import {
  CdkDragDrop,
  CdkDragEnter,
  CdkDragExit, CdkDragStart,
  copyArrayItem,
  moveItemInArray,
  transferArrayItem
} from "@angular/cdk/drag-drop";

@Component({
  selector: 'app-free-draft',
  templateUrl: './free-draft.component.html',
  styleUrls: ['./free-draft.component.css']
})
export class FreeDraftComponent implements OnInit {
  championsInfo: ChampionInfo[];

  bluePicks: ChampionInfo[] = [

  ];
  redPicks: ChampionInfo[] = [

  ];


  championsSearchInput: string;

  constructor(private championService: ChampionService) {
  }

  ngOnInit(): void {
    this.getChampionsInfo();
  }

  getChampionsInfo() {
    this.championService.getChampionsInfo().subscribe((champions: ChampionInfo[]) => {
      this.championsInfo = champions
    }, error => {
      console.log(error);
    });
  }

  drop(event: CdkDragDrop<ChampionInfo[]>) {
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
        event.previousIndex,
        event.currentIndex
      );
    }
  }
}
