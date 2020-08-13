import { Component, OnInit } from '@angular/core';
import {SelectionModel} from "@angular/cdk/collections";

export interface Champion {
  name: string;
  position: number;
  iconUrl: string;
}
const ELEMENT_DATA: Champion[] = [
  {position: 1, name: 'Ahri', iconUrl: 'assets/img/Champions/Ahri.png'},
  {position: 2, name: 'Nami', iconUrl: 'assets/img/Champions/Nami.png'},
  {position: 3, name: 'Sett', iconUrl: 'assets/img/Champions/Sett.png'},
  {position: 4, name: 'Lucian', iconUrl: 'assets/img/Champions/Lucian.png'},
]

@Component({
  selector: 'app-champions',
  templateUrl: './champions.component.html',
  styleUrls: ['./champions.component.css']
})
export class ChampionsComponent implements OnInit {
  displayedColumns: string[] = ['position', 'championName', 'championIcon', 'addChampion', 'editChampion', 'deleteChampion'];
  dataSource = ELEMENT_DATA;
  selection = new SelectionModel<Champion>(false, []);

  constructor() { }

  ngOnInit(): void {
  }

  addChampion() {

  }
  editChampion() {

  }

  deleteChampion() {

  }


}
