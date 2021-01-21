
import {Injectable} from '@angular/core';
import {Album} from './album.model';

@Injectable({
  providedIn: 'root'
})
export class CartService {
  albums: Album[] =[];


  constructor() {

  }

  add(album: Album){
    this.albums.push(album);

  }

  get() {
    return this.albums;
  }


}
