export class Artist {
  id: number;
  name: string;
  nationality: string;
  artistAlbum: string;

  constructor(input?: any) {
    Object.assign(this, input);
  }
}
