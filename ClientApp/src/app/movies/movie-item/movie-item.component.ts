import { Component, Input } from '@angular/core';
import { FavouritesService } from 'src/app/favourites/favourites.service';
import { Movie } from 'src/app/shared/models/movie';

@Component({
  selector: 'app-movie-item',
  templateUrl: './movie-item.component.html',
  styleUrls: ['./movie-item.component.scss']
})
export class MovieItemComponent {

  @Input() movie?: Movie;

  constructor(private favouritesService: FavouritesService) { }

  addMovieToFavourites() {
    this.movie && this.favouritesService.addMovieToFavourites(this.movie);
  }
}
