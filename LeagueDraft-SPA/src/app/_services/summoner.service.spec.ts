import { TestBed } from '@angular/core/testing';

import { SummonerService } from './summoner.service';

describe('SummonerService', () => {
  let service: SummonerService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SummonerService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
