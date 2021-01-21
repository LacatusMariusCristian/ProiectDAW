import { Component, EventEmitter, Output, ViewChild } from '@angular/core';

import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ApiService } from '../../shared/api.service';
import { Album } from '../../shared/album.model';
import { ModalDirective } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-edit-album-modal',
  templateUrl: './edit-album-modal.component.html',
  styleUrls: ['./edit-album-modal.component.css']
})
export class EditAlbumModalComponent {
  @ViewChild('editAlbumModal') modal: ModalDirective;
  @Output() change: EventEmitter<string> = new EventEmitter<string>();
  editAlbumForm: FormGroup;
  currentAlbum = new Album();


  constructor(public fb: FormBuilder, private api: ApiService) { }

  show(id: number): void {
    this.modal.show();
    this.api.getAlbum(id)
      .subscribe((data: Album) => {
        this.currentAlbum = data;
        this.currentAlbum.id = id;
        this.initializeFrom(this.currentAlbum);
      },
        (error: Error) => {
          console.log('err', error);

        });
  }

  initializeFrom(currentAlbum: Album) {
    this.editAlbumForm = this.fb.group({
      name: [currentAlbum.name, Validators.required],
      releaseYear: [currentAlbum.releaseYear, Validators.required],
      price: [currentAlbum.price, Validators.required],
      studioId: [currentAlbum.studioId, Validators.required],
      artistId: ['', Validators.required],
      songId: ['', Validators.required],
      img: [currentAlbum.img],
    });
  }

  editAlbum() {
    const editedAlbum = new Album({
      id: this.currentAlbum.id,
      name: this.editAlbumForm.value.name,
      releaseYear: this.editAlbumForm.value.releaseYear,
      price: this.editAlbumForm.value.price,
      studioId: this.editAlbumForm.value.studioId,
      songId: this.transformInNumberArray(this.editAlbumForm.value.songId),
      artistId: this.transformInNumberArray(this.editAlbumForm.value.artistId),
      img: this.editAlbumForm.value.img
    });

    this.api.editAlbum(editedAlbum)
      .subscribe(() => {
        this.change.emit('album');
        this.modal.hide();
      },
        (error: Error) => {
          console.log('err', error);
        });
  }

  transformInNumberArray(string: string) {
    return JSON.parse('[' + string + ']');
  }

}
