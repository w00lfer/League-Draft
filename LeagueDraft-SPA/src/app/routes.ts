import { Routes } from '@angular/router';
import {DashboardComponent} from './dashboard/dashboard.component';
import {LiveDraftComponent} from './live-draft/live-draft.component';
import {FreeDraftComponent} from './free-draft/free-draft.component';
import {ChampionsComponent} from './admin/champions/champions.component';
import {SummonerComponent} from './summoner/summoner.component';
import {RegisterComponent} from './register/register.component';
import {AuthGuard} from './_guards/auth.guard';
import {AdminGuard} from "./_guards/admin.guard";

export const appRoutes: Routes = [
  { path: '', component: DashboardComponent },
  {
    path: '',
    runGuardsAndResolvers: 'always',
    canActivate: [AuthGuard],
    children: [
      { path: 'live-draft', component: LiveDraftComponent },
      { path: 'free-draft', component: FreeDraftComponent },
      { path: 'summoner', component: SummonerComponent },
    ]
  },
  {
    path: 'admin/champions', component: ChampionsComponent,
    runGuardsAndResolvers: 'always',
    canActivate: [AdminGuard],
    canLoad: [AdminGuard]
  },
  { path: 'register', component: RegisterComponent },
  { path: '**', redirectTo: '', pathMatch: 'full' }
];
