import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';


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

  getAlbums() {
    return this.http.get(this.baseUrl + '/album', { headers: this.header });
  }

  getStudio(id: number) {
    return this.http.get(this.baseUrl + '/studio/' + id.toString(), { headers: this.header });
  }
}

