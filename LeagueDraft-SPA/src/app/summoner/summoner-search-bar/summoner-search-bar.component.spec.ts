import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SummonerSearchBarComponent } from './summoner-search-bar.component';

describe('SummonerSearchBarComponent', () => {
  let component: SummonerSearchBarComponent;
  let fixture: ComponentFixture<SummonerSearchBarComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SummonerSearchBarComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SummonerSearchBarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
