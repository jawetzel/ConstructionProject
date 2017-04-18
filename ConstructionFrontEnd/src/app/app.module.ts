import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';

import { AppComponent } from './app.component';
import {constructionApi} from './servers/constructionApi';

import {RouterModule, Routes} from '@angular/router';
import { RegisterComponent } from './ContentPages/register/register.component';
import { AboutComponent } from './ContentPages/about/about.component';
import { HomeComponent } from './ContentPages/home/home.component';
import { ContactComponent } from './ContentPages/contact/contact.component';

const appRoutes: Routes = [
  { path: '', component: HomeComponent},
  { path: 'register', component: RegisterComponent},
  { path: 'about', component: AboutComponent},
  { path: 'contact', component: ContactComponent}
];


@NgModule({
  declarations: [
    AppComponent,
    RegisterComponent,
    AboutComponent,
    HomeComponent,
    ContactComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    RouterModule.forRoot(appRoutes)
  ],
  providers: [constructionApi],
  bootstrap: [AppComponent]
})
export class AppModule { }
