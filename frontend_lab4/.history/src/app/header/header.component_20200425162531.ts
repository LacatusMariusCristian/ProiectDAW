import { Component, OnInit, ViewChild } from '@angular/core';
import { CartModalComponent } from './cart-modal/cart-modal.component';



@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  @ViewChild('cartModal') detailModal: CartModalComponent;

  constructor() {}

  ngOnInit() {}
  

  openCart() {
    this.detailModal.show();
  }
}


