import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CreatePersonComponent } from './person/create-person/create-person.component';
import { ListPersonComponent } from './shared/components/person/list/list-person.component';
import { SearchBoxComponent } from './shared/components/person/search-box/search-box.component';
import { SearchPersonComponent } from './person/search-person/search-person.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { PersonDataService } from './person/services/person.data.service';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CreatePersonComponent,
    ListPersonComponent,
    SearchPersonComponent,
    SearchBoxComponent,
    FetchDataComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'search', component: SearchPersonComponent },
      { path: 'addPerson', component: CreatePersonComponent }
    ])
  ],
  providers: [PersonDataService],
  bootstrap: [AppComponent]
})
export class AppModule { }
