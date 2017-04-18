import {Component, OnInit} from '@angular/core';
import {OrderRequestModel} from '../../../Models/UserViewModels';
import {ConstructionApi} from 'app/servers/constructionApi';
import {NgForm} from '@angular/forms';

@Component({
  selector: 'app-contact',
  templateUrl: './contact.component.html',
  styleUrls: ['./contact.component.css']
})
export class ContactComponent implements OnInit {
  formSubmitted = false;
  formSuccess = false;
  constructor(private _server: ConstructionApi) {
  }

  ngOnInit() {
  }
  submitOrder(orderForm: NgForm) {
    const body = new OrderRequestModel();
    body.Name = orderForm.value.Name;
    body.Email = orderForm.value.Email;
    body.PhoneNumber = orderForm.value.PhoneNumber;
    body.AddressStreet = orderForm.value.AddressStreet;
    body.AddressCity = orderForm.value.AddressCity;
    body.AddressZip = orderForm.value.AddressZip;
    body.OrderDescription = orderForm.value.OrderDescription;
    body.Called = false;
    orderForm.reset();
    this.formSuccess = true;
    this._server.NewOrder(body).subscribe(
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
