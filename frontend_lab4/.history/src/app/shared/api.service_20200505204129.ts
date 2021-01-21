import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Song } from './song.model';
import { Artist } from './artist.model';
import { Album } from './album.model';


@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private http: HttpClient) {}

  header = new HttpHeaders({
    'Content-Type': 'application/json'
  });
  baseUrl = 'https://localhost:44344/api';
 
  getAlbum(id: number) {
    return this.http.get(this.baseUrl + '/album/' + id.toString(), { headers: this.header });
  }

  getSong(id: number) {
    return this.http.get(this.baseUrl + '/song/' + id.toString(), { headers: this.header });
  }

  getArtist(id: number) {
    return this.http.get(this.baseUrl + '/artist/' + id.toString(), { headers: this.header });
  }

  getStudio(id: number) {
    return this.http.get(this.baseUrl + '/studio/' + id.toString(), { headers: this.header });
  }



  getAlbums() {
    return this.http.get(this.baseUrl + '/album', { headers: this.header });
  }

  getSongs() {
    return this.http.get(this.baseUrl + '/song', { headers: this.header });
  }

  getArtists() {
    return this.http.get(this.baseUrl + '/artist', { headers: this.header });
  }



  addSong(song: Song) {
    return this.http.post(this.baseUrl + '/song', song, { headers: this.header });
  }

  addArtist(artist: Artist) {
    return this.http.post(this.baseUrl + '/artist', artist, { headers: this.header });
  }

  addAlbum(album) {
    return this.http.post(this.baseUrl + '/album', {
      'name': album.name,
      'releaseYear': album.releaseYear,
      'studioId': album.studioId,
      'artistId': JSON.parse('[' + album.artistId + ']'), 
      'songId': JSON.parse('[' + album.songId + ']'),
      'img': album.img
    }, { headers: this.header });

  }

  
  deleteAlbum(id: number) {
    return this.http.delete(this.baseUrl + '/album/' + id.toString(), { headers: this.header });
  }

  deleteSong(id: number) {
    return this.http.delete(this.baseUrl + '/song/' + id.toString(), { headers: this.header });
  }

  deleteArtist(id: number) {
    return this.http.delete(this.baseUrl + '/artist/' + id.toString(), { headers: this.header });
  }
  editAlbum(album: Album) {

    return this.http.put(this.baseUrl + '/album/' + album.id.toString(), album, { headers: this.header });
  }

  editArtist(artist: Artist) {
    return this.http.put(this.baseUrl + '/artist/' + artist.id.toString(), artist, { headers: this.header });
  }

  editSong(song: Song) {
    return this.http.put(this.baseUrl + '/song/' + song.id.toString(), song, { headers: this.header });
  }

}

