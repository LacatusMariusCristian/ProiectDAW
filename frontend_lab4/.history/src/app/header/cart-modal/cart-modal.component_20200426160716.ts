import { Component, OnInit, ViewChild } from '@angular/core';
import { Album } from 'src/app/shared/album.model';
import { CartService } from 'src/app/shared/cart.service';
import { ModalDirective } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-cart-modal',
  templateUrl: './cart-modal.component.html',
  styleUrls: ['./cart-modal.component.css']
})
export class CartModalComponent implements OnInit {
  @ViewChild('cartModal') modal: ModalDirective;
  products: Album[] = [];


  constructor(private cartService: CartService) { }

  ngOnInit(): void {
  }

  initialize() {
    this.modal.show();
    this.products = this.cartService.get();
 
  }

  delete(id: number) {
    this.products.splice(id, 1);
 
  }
}
