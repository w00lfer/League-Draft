import { ChampionsFilterPipe } from './champions-filter.pipe';

describe('FilterPipe', () => {
  it('create an instance', () => {
    const pipe = new ChampionsFilterPipe();
    expect(pipe).toBeTruthy();
  });
});
