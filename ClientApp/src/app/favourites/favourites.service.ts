import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { environment } from 'src/environments/environment';
import {FavouriteFilm, Favourites } from '../shared/models/favourites';
import { Movie } from '../shared/models/movie';

@Injectable({
  providedIn: 'root'
})
export class FavouritesService {

  baseUrl = environment.apiUrl;

  private favouritesSource = new BehaviorSubject<Favourites | null>(null);
  favouritesSource$ = this.favouritesSource.asObservable();

  constructor(private http: HttpClient) { }

  getFavourites(id: string) {
    return this.http.get<Favourites>(this.baseUrl + 'favourites?id=' + id).subscribe({
      next: favourites => {
        this.favouritesSource.next(favourites);

      }
    })
  }

  setFavourites(favourites: Favourites) {
    return this.http.post<Favourites>(this.baseUrl + 'favourites', favourites).subscribe({
      next: favourites => {
        this.favouritesSource.next(favourites);

      }
    })
  }

  getCurrentFavouritesValue() {
    return this.favouritesSource.value;
  }

  addMovieToFavourites(movie: Movie | FavouriteFilm) {
    if (this.isMovie(movie)) movie = this.mapMovieToFavouriteFilm(movie);
    const favourites = this.getCurrentFavouritesValue() ?? this.createFavourites();
    favourites.favouriteFilms = this.addOrUpdateItem(favourites.favouriteFilms, movie);
    this.setFavourites(favourites);
  }

  removeMovieFromFavourites(id: number) {
    const favourites = this.getCurrentFavouritesValue();
    if (!favourites) return;
    const movie = favourites.favouriteFilms.find(x => x.id === id);

    if (favourites.favouriteFilms) {
      favourites.favouriteFilms.forEach( (item, index) => {
        if(item === movie) favourites.favouriteFilms.splice(index,1);
      });
    }
    this.setFavourites(favourites);
  }

  deleteFavourites(favourites: Favourites) {
    return this.http.delete(this.baseUrl + 'favourites?id=' + favourites.id).subscribe({
      next: () => {
        this.deleteLocalFavourites()
      }
    })
  }

  deleteLocalFavourites() {
    this.favouritesSource.next(null);
    localStorage.removeItem('favourites_id');
  }

  private addOrUpdateItem(movies: FavouriteFilm[], movieToAdd: FavouriteFilm): FavouriteFilm[] {
    const movie = movies.find(x => x.id === movieToAdd.id);
    if (movie) {
      this.removeMovieFromFavourites(movie.id);
    }
    else {
      movies.push(movieToAdd);
    }
    return movies;
  }

  private createFavourites(): Favourites {
    const favourites = new Favourites();
    localStorage.setItem('favourites_id', favourites.id);
    return favourites;
  }

  private mapMovieToFavouriteFilm(movie: Movie): FavouriteFilm {
    return {
      id: movie.id,
      movieTitle: movie.title,
      pictureUrl: movie.pictureUrl,
      movieCountry: movie.movieCountry,
      movieGenre: movie.movieGenre
    }
  }

  private isMovie(movie: Movie | FavouriteFilm): movie is Movie {
    return (movie as Movie).movieGenre !== undefined;
  }




  private RemoveOrUpdateItem(movies: FavouriteFilm[], movieToRemove: FavouriteFilm): FavouriteFilm[] {
    const movie = movies.find(x => x.id === movieToRemove.id);
    if (movie) {
      movies.forEach( (item, index) => {
        if(item === movie) movies.splice(index,1);
      });
    }
    return movies;
  }
}
