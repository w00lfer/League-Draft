import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css']
})
export class SidebarComponent implements OnInit {
  public draftExpanderIcon:string = 'keyboard_arrow_down'
  public draftExpanderOpen: boolean = false;

  constructor() { }

  ngOnInit(): void {
  }

  changeDraftExpanderIcon(): void
  {
    this.draftExpanderOpen = !this.draftExpanderOpen;
    this.draftExpanderIcon = this.draftExpanderOpen? 'keyboard_arrow_up' : 'keyboard_arrow_down';
  }

}
