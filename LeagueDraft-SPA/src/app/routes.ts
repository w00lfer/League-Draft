import { Routes } from '@angular/router';
import {DashboardComponent} from "./dashboard/dashboard.component";
import {LiveDraftComponent} from "./live-draft/live-draft.component";
import {FreeDraftComponent} from "./free-draft/free-draft.component";

export const appRoutes: Routes = [
  { path: '', component: DashboardComponent },
  { path: 'live-draft', component: LiveDraftComponent },
  { path: 'free-draft', component: FreeDraftComponent },
  { path: '**', redirectTo: '', pathMatch: 'full' }
];
