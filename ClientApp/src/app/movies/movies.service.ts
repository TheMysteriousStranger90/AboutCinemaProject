import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import {map, Observable, of } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Country } from '../shared/models/country';
import { Genre } from '../shared/models/genre';
import { Movie } from '../shared/models/movie';
import { MoviesParams } from '../shared/models/movies-params';
import { Pagination } from '../shared/models/pagination';

@Injectable({
  providedIn: 'root'
})
export class MoviesService {

  baseUrl = environment.apiUrl;
  movies: Movie[] = [];
  countries: Country[] = [];
  genres: Genre[] = [];
  pagination?: Pagination<Movie[]>;
  moviesParams = new MoviesParams();
  moviesCache = new Map<string, Pagination<Movie[]>>();

  constructor(private http: HttpClient) { }

  getMovies(useCache = true): Observable<Pagination<Movie[]>> {

    if (!useCache) this.moviesCache = new Map();

    if (this.moviesCache.size > 0 && useCache) {
      if (this.moviesCache.has(Object.values(this.moviesParams).join('-'))) {
        this.pagination = this.moviesCache.get(Object.values(this.moviesParams).join('-'));
        if(this.pagination) return of(this.pagination);
      }
    }

    let params = new HttpParams();

    if (this.moviesParams.genreId > 0) params = params.append('genreId', this.moviesParams.genreId);
    if (this.moviesParams.countryId) params = params.append('countryId', this.moviesParams.countryId);
    params = params.append('sort', this.moviesParams.sort);
    params = params.append('pageIndex', this.moviesParams.pageNumber);
    params = params.append('pageSize', this.moviesParams.pageSize);
    if (this.moviesParams.search) params = params.append('search', this.moviesParams.search);

    return this.http.get<Pagination<Movie[]>>(this.baseUrl + 'movies', {params}).pipe(
      map(response => {
        this.moviesCache.set(Object.values(this.moviesParams).join('-'), response)
        this.pagination = response;
        return response;
      })
    )
  }

  setMoviesParams(params: MoviesParams) {
    this.moviesParams = params;
  }

  getMoviesParams() {
    return this.moviesParams;
  }

  getMovie(id: number) {
    const movie = [...this.moviesCache.values()]
      .reduce((acc, paginatedResult) => {
        return {...acc, ...paginatedResult.data.find(x => x.id === id)}
      }, {} as Movie)

    if (Object.keys(movie).length !== 0) return of(movie);

    return this.http.get<Movie>(this.baseUrl + 'movies/' + id);
  }

  getCountries() {
    if (this.countries.length > 0) return of(this.countries);

    return this.http.get<Country[]>(this.baseUrl + 'movies/countries').pipe(
      map(countries => this.countries = countries)
    );
  }

  getGenres() {
    if (this.genres.length > 0) return of(this.genres);

    return this.http.get<Genre[]>(this.baseUrl + 'movies/genres').pipe(
      map(genres => this.genres = genres)
    );
  }
}
