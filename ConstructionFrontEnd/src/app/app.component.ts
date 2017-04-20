import { Component } from '@angular/core';
import {ConstructionApi} from './servers/constructionApi';
import {RegisterModel} from '../Models/AccountModels';

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
    register.UserName = 'jawetzel';
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
}
