export class Album {
  id: number;
  name: string;
  releaseYear: number;
  price: number;
  studioId: number;
  artistName: string[];
  songName: string[];
  songId: number[];
  artistId: number[];
  img: string;

  constructor(input?: any) {
    Object.assign(this, input);
  }
}
