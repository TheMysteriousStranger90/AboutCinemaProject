import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import {Comment} from '../../models/comment'

@Injectable({
  providedIn: 'root'
})
export class CommentService {

  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getAllComments() : Observable<Comment[]>{
    return this.http.get<Comment[]>(this.baseUrl + 'comments');
  }

  getCommentsByMovieId(id: number): Observable<Comment[]>{
    return this.http.get<Comment[]>(this.baseUrl + 'comments/movies/' + id);
  }

  addComment(comment: Comment){
    const headers = {
      headers: new HttpHeaders({
        'Content-Type' : 'application/json'
      })
    };

    console.log(comment)
    return this.http.post<Comment>(this.baseUrl + 'comments', comment, headers);
  }

  deleteComment(id: number){
    return this.http.delete(this.baseUrl + 'comments/' + id);
  }
}
