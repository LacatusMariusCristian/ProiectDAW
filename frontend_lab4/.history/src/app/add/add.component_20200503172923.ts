import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ApiService } from '../shared/api.service';

@Component({
  selector: 'app-add',
  templateUrl: './add.component.html',
  styleUrls: ['./add.component.css']
})
export class AddComponent implements OnInit {
  options = ['Song', 'Artist', 'Album'];
  selectedOption = 'Album';
  currentFormRef: any;
  addAlbumForm: FormGroup;
  addArtistForm: FormGroup;
  addSongForm: FormGroup;
  success: boolean;

  constructor(public fb: FormBuilder, private api: ApiService) { }


  ngOnInit() {

    this.addAlbumForm = this.fb.group({
      name: [null, Validators.required],
      releaseYear: [null, Validators.required],
      price: [null, Validators.required],
      studioId: [null, Validators.required],
      artistId: [null, Validators.required],
      songId: [null, Validators.required],
      img: [null]
    });
    this.addArtistForm = this.fb.group({
      name: [null, Validators.required],
      nationality: [null, Validators.required],
    });
    this.addSongForm = this.fb.group({
      name: [null, Validators.required],
      style: [null, Validators.required],
    });

    this.currentFormRef = this.addAlbumForm;

  }

  radioChange(event: any) {
    this.selectedOption = event.target.value;
    this.currentFormRef = this['add' + this.selectedOption + 'Form'];
    /*
      notatiile this.api si this[api] sunt echivalente

     folosind paratenze putem utiliza variabile

     this['add' + this.selectedOption + 'Form'] = this['addAlbumForm']  = this.addAlbumForm sau
                                                                        = this.addSongForm sau
                                                                        = this.addArtist
    */
  }

  add() {
    /*


    this.api['add' + this.selectedOption] = this.api['addAlbum'] = this.api.addAlbum() sau
                                          = this.api['addSong] sau
                                          = this.api['addArtist]
    */
    this.api['add' + this.selectedOption](this.currentFormRef.value).subscribe(() => {

      this.currentFormRef.reset();
      this.success = true;
      setTimeout(() => {
        this.success = null;
      }, 3000);
    },
      (error: Error) => {
        console.log(error);
        this.currentFormRef.reset();
        this.success = false;
        setTimeout(() => {
          this.success = null;
        }, 3000);
      });

  }
}
