import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import {RouterModule, Routes} from '@angular/router';

import { AppComponent } from './app.component';
import { HomeComponent } from './Pages/home/home.component';
import { ContactComponent } from './Pages/contact/contact.component';

import { ConstructionApi } from './ApiCalls/B2kConstructionApiCalls';
import { AdminRouteGuard } from './RouteGuards/AdminGuard';
import { TokenService } from './RouteGuards/TokenService';


const appRoutes: Routes = [
  { path: '', component: HomeComponent, canActivate: [AdminRouteGuard]},
  { path: 'contact', component: ContactComponent}
];


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    ContactComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    RouterModule.forRoot(appRoutes)
  ],
  providers: [
    ConstructionApi,
    TokenService,
    AdminRouteGuard
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
