import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { MovieRating } from '../../models/movie-rating';

@Injectable({
  providedIn: 'root'
})
export class RatingService {

  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  public rate(movieRating: MovieRating){
    console.log(movieRating)
    return this.http.post(this.baseUrl + 'movierating', movieRating);
  }

}
