import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SummonerMatchInfoComponent } from './summoner-match-info.component';

describe('SummonerMatchInfoComponent', () => {
  let component: SummonerMatchInfoComponent;
  let fixture: ComponentFixture<SummonerMatchInfoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SummonerMatchInfoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SummonerMatchInfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
