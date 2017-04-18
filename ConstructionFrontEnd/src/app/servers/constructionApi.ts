import {Injectable} from '@angular/core';
import {Http} from '@angular/http';
import {LoginViewModel} from '../../Models/UserViewModels';

@Injectable()
export class constructionApi{
  constructor(private http: Http) {}

  constructonServers(loginInfo: LoginViewModel) {
    return this.http.get('http://localhost:55258/api/user/CreateSession', 'hello');
  }
}
