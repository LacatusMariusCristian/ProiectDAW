import { Component, OnInit, ViewChild } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { Album } from '../../shared/album.model';
import { ApiService } from '../../shared/api.service';
import { CartService } from '../../shared/cart.service';

@Component({
  selector: 'app-detail-modal',
  templateUrl: './detail-modal.component.html',
  styleUrls: ['./detail-modal.component.css']
})
export class DetailModalComponent implements OnInit {
  @ViewChild('detailModal') modal: ModalDirective;
  album = new Album();
  studio: string;
 

  constructor(private api: ApiService, private cart: CartService) { }

  ngOnInit() {}

  initialize(id: number): void {
    this.getAlbum(id);
    this.modal.show();
  }

  getStudio(id: number) {
    this.api.getStudio(id)
      .subscribe((data: Abu) => {
        this.studio = data.name;
      },
        (err: Error) => {
          console.log('err', err);

        });
  }

  getAlbum(id: number) {
    this.api.getAlbum(id)
      .subscribe((data: Album) => {
        this.album = data;
        this.album.id = id;
        if (!data.img) {
          this.album.img = 'https://i.ibb.co/0cBJC3N/3.jpg';
        }
        this.getStudio(this.album.studioId);
      },
        (err: Error) => {
          console.log('err', err);

        });
  }

  addToCart(album: Album) {
    this.cart.add(album);
    this.modal.hide();
  }
}
