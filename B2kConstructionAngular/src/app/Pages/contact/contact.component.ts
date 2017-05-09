import { Component, OnInit } from '@angular/core';
import {NgForm} from '@angular/forms';
import {ConstructionApi} from '../../ApiCalls/B2kConstructionApiCalls';
@Component({
  selector: 'app-contact',
  templateUrl: './contact.component.html',
  styleUrls: ['./contact.component.css', '../../shared/shared.css']
})


export class ContactComponent implements OnInit {

  formSubmitted = false;
  formSuccess = false;

  constructor(private _server: ConstructionApi) { }

  ngOnInit() {
  }

  submitOrder(orderForm: NgForm) {

    const body = orderForm.value;

    orderForm.reset();

    this._server.NewOrderRequest(body).subscribe(
      result => {
        this.formSubmitted = true;
        this.formSuccess = true;
      },
      error => {
        this.formSuccess = false;
      }
    );
  }

}
