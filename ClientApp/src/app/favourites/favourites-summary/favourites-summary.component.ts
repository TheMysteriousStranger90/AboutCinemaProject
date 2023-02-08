import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FavouriteFilm } from 'src/app/shared/models/favourites';
import { FavouritesService } from '../favourites.service';

@Component({
  selector: 'app-favourites-summary',
  templateUrl: './favourites-summary.component.html',
  styleUrls: ['./favourites-summary.component.scss']
})
export class FavouritesSummaryComponent {

  @Output() addMovie= new EventEmitter<FavouriteFilm>();
  @Output() removeMovie = new EventEmitter<{id: number}>();
  @Input() isFavourites = true;

  constructor(public favouritesService: FavouritesService) {}

  addFavouritesMovie(movie: FavouriteFilm) {
    this.addMovie.emit(movie);
  }

  removeFavouritesMovie(id: number) {
    this.removeMovie.emit({id});
  }
}
