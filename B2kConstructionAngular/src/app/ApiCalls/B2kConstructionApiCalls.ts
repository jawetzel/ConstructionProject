import {Injectable} from '@angular/core';
import {Http, RequestOptions, Headers} from '@angular/http';


const url = 'http://localhost:65293';

@Injectable()
export class ConstructionApi {
  constructor ( private http: Http ) {
  }

  NewOrderRequest(content) {
    const route = '/api/newOrder';
    const headers = new Headers({
      'Content-Type': 'application/json',
    });
    const options = new RequestOptions({
      headers: headers
    });
    return this.http.post(url + route, content, options);
  }
}
