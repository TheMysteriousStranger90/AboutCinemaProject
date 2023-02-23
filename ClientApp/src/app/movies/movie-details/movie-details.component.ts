import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormGroup } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AccountService } from 'src/app/account/account.service';
import { CommentService } from 'src/app/shared/components/comment/comment.service';
import { RatingService } from 'src/app/shared/components/rating/rating.service';
import { Movie } from 'src/app/shared/models/movie';
import { MovieRating } from 'src/app/shared/models/movie-rating';
import Swal from 'sweetalert2';
import { BreadcrumbService } from 'xng-breadcrumb';
import { MoviesService } from '../movies.service';
import {Comment} from '../../shared/models/comment'

@Component({
  selector: 'app-movie-details',
  templateUrl: './movie-details.component.html',
  styleUrls: ['./movie-details.component.scss']
})
export class MovieDetailsComponent implements OnInit{

  movie?: Movie;
  commentForm!: FormGroup;
  myMovieId : number | any
  comments: Comment[] = [];

  constructor(private moviesService: MoviesService, private activatedRoute: ActivatedRoute, private bcService: BreadcrumbService,
              private fb: FormBuilder,
              private accountService: AccountService, private ratingService: RatingService, private toastr: ToastrService, private commentService: CommentService,) {
    this.bcService.set('@movieDetails', ' ')
  }

  ngOnInit(): void {
    this.loadMovie()

    this.createForm();
  }

  loadMovie() {
    const id = this.activatedRoute.snapshot.paramMap.get('id');
    if (id) this.moviesService.getMovie(+id).subscribe({
      next: movie => {
        this.movie = movie;
        this.myMovieId! = parseInt(id);
        this.bcService.set('@movieDetails', movie.title);

      },
      error: error => console.log(error)
    })
  }

  createForm(){
    this.commentForm = this.fb.group({
      movieId: [this.movie?.id],
      text: [null]
    });
  }

  onRating(rate: number){
    const movieRating: MovieRating = {
      rate: rate,
      movieId: this.myMovieId
    }
    this.ratingService.rate(movieRating).subscribe({
      next: () => {this.toastr.success("Success", "Your vote has been received");},
      error: (err) => console.log(err)
    });
  }

  addComment(){
    if (!this.commentForm!.valid){
      return;
    }

    var comment = this.commentForm!.value;
    comment.movieId = this.movie!.id;

    this.commentForm!.reset();

    this.commentService.addComment(comment).subscribe(c =>
    {
      this.comments.unshift(c);
      this.ngOnInit();
    }, err => console.log(err));
  }

}
