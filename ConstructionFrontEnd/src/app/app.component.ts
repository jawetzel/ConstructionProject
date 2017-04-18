import { Component } from '@angular/core';
import {LoginViewModel, RegisterViewModel} from '../Models/UserViewModels';
import {constructionApi} from './servers/constructionApi';
import {NgForm} from '@angular/forms';
import {Http, RequestMethod, RequestOptions, Headers} from '@angular/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  loginClicked = false;
  disabledContent = false;
  constructor(private serverService: constructionApi, private http: Http ){
  }
  toggleLoginFields() {
    this.loginClicked = true;
  }
  attemptLogin(form: NgForm) {
    console.log(form.value.username);
    console.log(form.value.password);
    this.loginClicked = false;

    // login code here
  }
  login() {
    const user: RegisterViewModel = new RegisterViewModel();
    user.UserName = 'jawetzel';
    user.Password = 'icewater';
    user.ConfirmPassword = 'icewater';
    user.Email = 'jawetzel615@gmail.com';
    user.FirstName = 'joshua';
    user.LastName = 'wetzel';
    user.StreetAddress = '1234 my street';
    user.CityAddress = 'denham springs';
    user.StateAddress = 'louisiana';
    user.ZipAddress = '70706';
    user.ApptNumberAddress = 'B';
    let body = '';
    body += 'UserName=' + user.UserName + '&';
    body += 'Password=' + user.Password + '&';
    body += 'ConfirmPassword=' + user.ConfirmPassword + '&';
    body += 'Email=' + user.Email + '&';
    body += 'FirstName=' + user.FirstName + '&';
    body += 'LastName=' + user.LastName + '&';
    body += 'StreetAddress=' + user.StreetAddress + '&';
    body += 'CityAddress=' + user.CityAddress + '&';
    body += 'StateAddress=' + user.StateAddress + '&';
    body += 'ZipAddress=' + user.ZipAddress + '&';
    body += 'ApptNumberAddress=' + user.ApptNumberAddress + '&';

    const url = 'http://localhost:55258/api/Account';
    const headers = new Headers({
      'Content-Type': 'application/json',
      'Accept': 'application/json'
    });
    const options = new RequestOptions({
      method: RequestMethod.Post,
      url: url,
      headers: headers,
      body: body
    });
    this.http.request(url, options).subscribe(
      result => console.log(result),
      error => console.log(error)
    );
  }
}
