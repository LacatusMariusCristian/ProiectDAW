import { Component, EventEmitter, OnInit, Output, ViewChild } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Artist } from '../../shared/Artist.model';
import { ApiService } from '../../shared/api.service';


@Component({
  selector: 'app-edit-artist-modal',
  templateUrl: './edit-artist-modal.component.html',
  styleUrls: ['./edit-artist-modal.component.css']
})
export class EditArtistModalComponent {
  @ViewChild('editArtistModal') modal: ModalDirective;
  @Output() change: EventEmitter<string> = new EventEmitter<string>();
  editArtistForm: FormGroup;
  currentArtist = new Artist();

  constructor(public fb: FormBuilder, private api: ApiService) { }

  show(id: number): void {
    this.modal.show();
    this.api.getArtist(id)
      .subscribe((data: Artist) => {
        this.currentArtist = data;
        this.initializeFrom(this.currentArtist);
      },
        (error: Error) => {
          console.log('err', error);

        });
  }

  initializeFrom(currentArtist: Artist) {
    this.editArtistForm = this.fb.group({
      name: [currentArtist.name, Validators.required],
      nationality: [currentArtist.nationality, Validators.required],
    });
  }

  editArtist() {
    const editedArtist = new Artist({
      id: this.currentArtist.id,
      name: this.editArtistForm.value.name,
      nationality: this.editArtistForm.value.nationality,
    });

    this.api.editArtist(editedArtist)
      .subscribe(() => {
        this.change.emit('artist');
        this.modal.hide();
      },
        (error: Error) => {
          console.log('err', error);
        });
  }

}



