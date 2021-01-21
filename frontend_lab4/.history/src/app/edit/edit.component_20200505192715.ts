import { Component, OnInit, ViewChild } from '@angular/core';
import { ApiService } from '../shared/api.service';
import { Album } from '../shared/album.model';
import { Artist } from '../shared/artist.model';
import { Song } from '../shared/song.model';
import { EditAlbumModalComponent } from './edit-album-modal/edit-album-modal.component';
import { EditArtistModalComponent } from './edit-artist-modal/edit-artist-modal.component';
import { EditSongModalComponent } from './edit-song-modal/edit-song-modal.component';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css']
})
export class EditComponent implements OnInit {
  albums: Album[] = [];
  artists: Artist[] = [];
  songs: Song[] = [];



  @ViewChild('editAlbumModal') editAlbumModal: EditAlbumModalComponent;
  @ViewChild('editArtistModal') editArtistModal: EditArtistModalComponent;
  @ViewChild('editSongModal') editSongModal: EditSongModalComponent;


  constructor(private api: ApiService) { }

  ngOnInit() {
    this.getAlbums();
    this.getArtists();
    this.getSongs();
  }

  getAlbums() {
    this.api.getAlbums()
      .subscribe((data: Album[]) => {
        this.albums = [];

        for (let i = 0; i < data.length; i++) {
          this.api.getAlbum(data[i].id)
            .subscribe((info: Album) => {
              info.id = data[i].id;
              this.albums.push(info);
            },
              (e: Error) => {
                console.log('err', e);
              });
        }

      },
        (error: Error) => {
          console.log('err', error);

        });
  }

  getArtists() {

    this.api.getArtists()
      .subscribe((data: Artist[]) => {
        this.artists = data;
      },
        (error: Error) => {
          console.log('err', error);
        });
  }

  getSongs() {
    this.api.getSongs()
      .subscribe((data: Song[]) => {
        this.songs = data;
      },
        (error: Error) => {
          console.log('err', error);

        });
  }

  deleteAlbum(id: number) {
    this.api.deleteAlbum(id)
      .subscribe(() => {
        this.albums = [];
        this.getAlbums();
      },
        (error: Error) => {
          console.log(error);
        });
  }

  deleteArtist(id: number) {
    this.api.deleteArtist(id)
      .subscribe(() => {
        this.getArtists();
      },
        (error: Error) => {
          console.log(error);
        });
  }

  deleteSong(id: number) {
    this.api.deleteSong(id)
      .subscribe(() => {
        this.getSongs();
      },
        (error: Error) => {
          console.log(error);
        });

  }

  showM1(id: number): void {
    this.editAlbumModal.show(id);
  }

  showM2(id: number): void {
    this.editArtistModal.show(id);
  }

  showM3(id: number): void {
    this.editSongModal.show(id);
  }

  changeE(event: string) {
    if (event === 'album') {
      this.getAlbums();
    }
    if (event === 'artist') {
      this.getArtists();
    }
    if (event === 'song') {
      this.getSongs();
    }


  }

}
