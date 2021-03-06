import { Component, OnInit } from '@angular/core';
import {SelectionModel} from '@angular/cdk/collections';
import {ChampionService} from '../../_services/champion.service';
import {ChampionInfo} from '../../_models/champion-info';

export interface Champion {
  name: string;
  position: number;
  iconUrl: string;
}

@Component({
  selector: 'app-champions',
  templateUrl: './champions.component.html',
  styleUrls: ['./champions.component.css']
})
export class ChampionsComponent implements OnInit {
  displayedColumns: string[] = ['position', 'championName', 'championIcon', 'championTileIcon', 'addChampion', 'editChampion', 'deleteChampion'];
  dataSource: ChampionInfo[] = [];
  selection = new SelectionModel<Champion>(false, []);

  constructor(private championService: ChampionService) { }

  ngOnInit(): void {
    this.getChampionsInfo();
    console.log(this.dataSource);
  }

  getChampionsInfo(): void{
    this.championService.getChampionsInfo().subscribe((champions: ChampionInfo[]) => {
      this.dataSource = champions;
    }, error => {
      console.log(error);
    });
  }

  addChampion(): void {

  }
  editChampion(): void {

  }

  deleteChampion(): void {

  }

}
