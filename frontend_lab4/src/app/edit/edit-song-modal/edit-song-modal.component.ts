import { Component, EventEmitter, OnInit, Output, ViewChild } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Song } from '../../shared/Song.model';
import { ApiService } from '../../shared/api.service';

@Component({
  selector: 'app-edit-song-modal',
  templateUrl: './edit-song-modal.component.html',
  styleUrls: ['./edit-song-modal.component.css']
})
export class EditSongModalComponent {
  @ViewChild('editSongModal') modal: ModalDirective;
  @Output() change: EventEmitter<string> = new EventEmitter<string>();
  editSongForm: FormGroup;
  currentSong = new Song();

  constructor(public fb: FormBuilder, private api: ApiService) {}

  initialize(id: number): void {

    this.modal.show();
    this.api.getSong(id)
      .subscribe((data: Song) => {
        this.currentSong = data;
        this.initializeFrom(this.currentSong);
      },
        (error: Error) => {
          console.log('err', error);
        });
  }

  initializeFrom(currentSong: Song) {
    this.editSongForm = this.fb.group({
      name: [currentSong.name, Validators.required],
      style: [currentSong.style, Validators.required],
    });
  }

  editSong() {
    const editedSong = new Song({
      id: this.currentSong.id,
      name: this.editSongForm.value.name,
      style: this.editSongForm.value.style
    });

    this.api.editSong(editedSong)
      .subscribe(() => {
        this.change.emit('song');
        this.modal.hide();
      },
        (error: Error) => {
          console.log('err', error);
        });

  }

}
