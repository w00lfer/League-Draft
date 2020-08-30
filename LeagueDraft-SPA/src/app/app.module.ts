import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatButtonModule} from '@angular/material/button';
import { FooterComponent } from './shared/Components/footer/footer.component';
import { NavbarComponent } from './shared/Components/navbar/navbar.component';
import { MatInputModule } from '@angular/material/input';
import { MatDividerModule } from '@angular/material/divider';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import { FlexLayoutModule } from '@angular/flex-layout';
import {_MatMenuDirectivesModule, MatMenuModule } from '@angular/material/menu';
import { DashboardComponent } from './dashboard/dashboard.component';
import { MatSidenavModule } from '@angular/material/sidenav';
import { SidebarComponent } from './shared/Components/sidebar/sidebar.component';
import { MatListModule } from '@angular/material/list';
import { MatExpansionModule} from '@angular/material/expansion';
import { FreeDraftComponent } from './free-draft/free-draft.component';
import { LiveDraftComponent } from './live-draft/live-draft.component';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { ChampionsComponent } from './admin/champions/champions.component';
import { MatTableModule } from '@angular/material/table';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { HttpClientModule } from '@angular/common/http';
import { ChampionsFilterPipe } from './_pipes/champions-filter.pipe';
import { FormsModule } from '@angular/forms';
import { DragDropModule } from '@angular/cdk/drag-drop';
import { SummonerComponent } from './summoner/summoner.component';
import {MatSelectModule} from '@angular/material/select';
import { RegisterComponent } from './register/register.component';
import { SignInDialogComponent } from './shared/Components/navbar/sign-in-dialog/sign-in-dialog.component';
import { MatDialogModule} from '@angular/material/dialog';
import { SummonerSearchBarComponent } from './summoner/summoner-search-bar/summoner-search-bar.component';
import { SummonerMatchInfoComponent } from './summoner/summoner-match-info/summoner-match-info.component';

@NgModule({
  declarations: [
    AppComponent,
    FooterComponent,
    NavbarComponent,
    DashboardComponent,
    SidebarComponent,
    FreeDraftComponent,
    LiveDraftComponent,
    ChampionsComponent,
    ChampionsFilterPipe,
    SummonerComponent,
    RegisterComponent,
    SignInDialogComponent,
    SummonerSearchBarComponent,
    SummonerMatchInfoComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatButtonModule,
    MatDividerModule,
    MatToolbarModule,
    MatIconModule,
    FlexLayoutModule,
    _MatMenuDirectivesModule,
    MatMenuModule,
    MatSidenavModule,
    MatListModule,
    MatExpansionModule,
    MatCardModule,
    MatFormFieldModule,
    MatInputModule,
    MatTableModule,
    MatCheckboxModule,
    HttpClientModule,
    FormsModule,
    DragDropModule,
    MatSelectModule,
    MatDialogModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
