import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FreeDraftComponent } from './free-draft.component';

describe('FreeDraftComponent', () => {
  let component: FreeDraftComponent;
  let fixture: ComponentFixture<FreeDraftComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FreeDraftComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FreeDraftComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
