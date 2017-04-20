import {Injectable} from '@angular/core';
import {Http, RequestOptions, Headers} from '@angular/http';
import {OrderRequestModel} from '../../Models/OrderRequestModel';
import {RegisterModel} from "../../Models/AccountModels";

const url = 'http://localhost:65293';
// const url = 'http://localhost:65293';
@Injectable()
export class ConstructionApi {
  constructor ( private http: Http ) {
  }
  NewOrder(content: OrderRequestModel) {
    const route = '/api/newOrder';
    const headers = new Headers({
      'Content-Type': 'application/json',
    });
    const options = new RequestOptions({
      headers: headers
    });
    return this.http.post(url + route, content, options);
  }

  Register(content: RegisterModel) {
    const route = '/api/register';
    const headers = new Headers({
      'Content-Type': 'application/json',
    });
    const options = new RequestOptions({
      headers: headers
    });
    return this.http.post(url + route, content, options);
  }


}

