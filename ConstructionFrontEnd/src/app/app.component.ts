import { Component } from '@angular/core';
import {ConstructionApi} from './servers/constructionApi';
import {LoginModel, RegisterModel} from '../Models/AccountModels';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  constructor(private _server: ConstructionApi) {
  }
  register() {
    const register = new RegisterModel;
    register.Email = 'jawetzel615@gmail.com';
    register.Password = 'icewater';
    register.ConfirmPassword = 'icewater';

    this._server.Register(register).subscribe(
      result => {
        console.log(result);
      },
      error => {
        console.log(error);
      }
    );
  }
  login() {
    const login = new LoginModel;
    login.UserName = 'jawetzel615@gmail.com';
    login.Password = 'icewater';

    this._server.Login(login).subscribe(
      result => {
        console.log(result);
      },
      error => {
        console.log(error);
      }
    );
  }
}
