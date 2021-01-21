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
  sum = 0;

  constructor(private cartService: CartService) { }

  ngOnInit(): void {
  }

  show() {
    this.modal.show();
    this.products = this.cartService.get();
    for (let i = 0; i < this.products.length; i++) {
      this.sum += this.products[i].price;
    }
  }

  delete(id: number, price: number) {
    this.products.splice(id, 1);
    this.sum = this.sum - price;
  }
}
