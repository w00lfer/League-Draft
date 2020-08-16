import { Pipe, PipeTransform } from '@angular/core';
import {ChampionInfo} from "../_models/ChampionInfo";

@Pipe({
  name: 'ChampionsFilter',
  pure: false
})
export class ChampionsFilterPipe implements PipeTransform {
  transform(items: ChampionInfo[], searchText: string): any[] {
    if(!items) return [];
    if(!searchText) return items;
    searchText = searchText.toLowerCase();
    return items.filter( it => {
      return it.name.toLowerCase().includes(searchText);
    });
  }
}
