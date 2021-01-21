import { Component, OnInit, ViewChild } from '@angular/core';
import { Album } from '../shared/album.model';
import { ApiService } from '../shared/api.service';
import { DetailModalComponent } from './detail-modal/detail-modal.component';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  albums: Album[] = [];
  searchText: string;
  title: string;




  constructor(private api: ApiService) { }

  ngOnInit() {
    this.api.getAlbums().subscribe((data: Album[]) => {

      for (let i = 0; i < data.length; i++) {
        this.api.getAlbum(data[i].id).subscribe((info: Album) => {
          info.id = data[i].id;
          if (!info.img) {
           info.img = 'https://i.ibb.co/JKjjDtx/vinyl-record-mid.jpg';
          }
        
          this.albums.push(info);
        },
          (e: Error) => {
            console.log('err', e);
          });
      }
    },
      (er: Error) => {
        console.log('err', er);
      });
  }


}
