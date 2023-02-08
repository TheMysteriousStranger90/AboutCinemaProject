import * as cuid from 'cuid';

export interface FavouriteFilm  {
  id: number;
  movieTitle: string;
  pictureUrl: string;
  movieCountry: string;
  movieGenre: string;
}

export interface Favourites {
  id: string;
  favouriteFilms: FavouriteFilm[];
  clientSecret?: string;
}

export class Favourites implements Favourites {
  id = cuid();
  favouriteFilms: FavouriteFilm[] = [];
}
