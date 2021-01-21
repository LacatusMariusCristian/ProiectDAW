export class Song {
   id: number;
   name: string;
   style: string;

  constructor(input?: any) {
    Object.assign(this, input);
  }
}
