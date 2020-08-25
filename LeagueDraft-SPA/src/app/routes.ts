import { Routes } from '@angular/router';
import {DashboardComponent} from "./dashboard/dashboard.component";
import {LiveDraftComponent} from "./live-draft/live-draft.component";
import {FreeDraftComponent} from "./free-draft/free-draft.component";
import {ChampionsComponent} from "./admin/champions/champions.component";
import {SummonerComponent} from "./summoner/summoner.component";

export const appRoutes: Routes = [
  { path: '', component: DashboardComponent },
  { path: 'live-draft', component: LiveDraftComponent },
  { path: 'free-draft', component: FreeDraftComponent },
  { path: 'admin/champions', component: ChampionsComponent },
  { path: 'summoner', component: SummonerComponent },
  { path: '**', redirectTo: '', pathMatch: 'full' }
];
