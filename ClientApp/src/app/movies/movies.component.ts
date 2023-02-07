import { Component, ElementRef, ViewChild } from '@angular/core';
import { Country } from '../shared/models/country';
import { Genre } from '../shared/models/genre';
import { Movie } from '../shared/models/movie';
import { MoviesParams } from '../shared/models/movies-params';
import { MoviesService } from './movies.service';

@Component({
  selector: 'app-movies',
  templateUrl: './movies.component.html',
  styleUrls: ['./movies.component.scss']
})
export class MoviesComponent {

  @ViewChild('search') searchTerm?: ElementRef;
  movies: Movie[] = [];
  countries: Country[] = [];
  genres: Genre[] = [];
  moviesParams = new MoviesParams();
  sortOptions = [
    {name: 'Alphabetical', value: 'title'},
    {name: 'Year: Low to high', value: 'yearAsc'},
    {name: 'Year: High to low', value: 'yearDesc'},
  ];
  totalCount = 0;

  constructor(private moviesService: MoviesService) {
    this.moviesParams = moviesService.getMoviesParams();
  }

  ngOnInit(): void {
    this.getMovies();
    this.getCountries();
    this.getGenres();
  }

  getMovies() {
    this.moviesService.getMovies().subscribe({
      next: response => {
        this.movies = response.data;
        this.totalCount = response.count;
      },
      error: error => console.log(error)
    })
  }

  getCountries() {
    this.moviesService.getCountries().subscribe({
      next: response => this.countries = [{id: 0, name: 'All'}, ...response],
      error: error => console.log(error)
    })
  }

  getGenres() {
    this.moviesService.getGenres().subscribe({
      next: response => this.genres = [{id: 0, name: 'All'}, ...response],
      error: error => console.log(error)
    })
  }

  onCountrySelected(countryId: number) {
    const params = this.moviesService.getMoviesParams();
    params.countryId = countryId;
    params.pageNumber = 1;
    this.moviesService.setMoviesParams(params);
    this.moviesParams = params;
    this.getMovies();
  }

  onGenreSelected(genreId: number) {
    const params = this.moviesService.getMoviesParams();
    params.genreId = genreId;
    params.pageNumber = 1;
    this.moviesService.setMoviesParams(params);
    this.moviesParams = params;
    this.getMovies();
  }

  onSortSelected(event: any) {
    const params = this.moviesService.getMoviesParams();
    params.sort = event.target.value;
    this.moviesService.setMoviesParams(params);
    this.moviesParams = params;
    this.getMovies();
  }

  onPageChanged(event: any) {
    const params = this.moviesService.getMoviesParams();
    if (params.pageNumber !== event) {
      params.pageNumber = event;
      this.moviesService.setMoviesParams(params);
      this.moviesParams = params;
      this.getMovies();
    }
  }

  onSearch() {
    const params = this.moviesService.getMoviesParams();
    params.search = this.searchTerm?.nativeElement.value;
    params.pageNumber = 1;
    this.moviesService.setMoviesParams(params);
    this.moviesParams = params;
    this.getMovies();
  }

  onReset() {
    if (this.searchTerm) this.searchTerm.nativeElement.value = '';
    this.moviesParams = new MoviesParams();
    this.moviesService.setMoviesParams(this.moviesParams);
    this.getMovies();
  }

}
