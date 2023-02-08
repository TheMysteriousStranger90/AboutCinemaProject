import { Component } from '@angular/core';
import { FavouriteFilm } from '../shared/models/favourites';
import { FavouritesService } from './favourites.service';

@Component({
  selector: 'app-favourites',
  templateUrl: './favourites.component.html',
  styleUrls: ['./favourites.component.scss']
})
export class FavouritesComponent {

  constructor(public favouritesService: FavouritesService) {}

  incrementQuantity(movie: FavouriteFilm) {
    this.favouritesService.addMovieToFavourites(movie);
  }

  removeMovie(event: {id: number}) {
    this.favouritesService.removeMovieFromFavourites(event.id);
  }


}
