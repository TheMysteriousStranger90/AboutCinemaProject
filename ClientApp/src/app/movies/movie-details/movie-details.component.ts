import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormGroup } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { AccountService } from 'src/app/account/account.service';
import { Movie } from 'src/app/shared/models/movie';
import { BreadcrumbService } from 'xng-breadcrumb';
import { MoviesService } from '../movies.service';

@Component({
  selector: 'app-movie-details',
  templateUrl: './movie-details.component.html',
  styleUrls: ['./movie-details.component.scss']
})
export class MovieDetailsComponent implements OnInit{

  movie?: Movie;
  commentForm?: FormGroup;

  constructor(private moviesService: MoviesService, private activatedRoute: ActivatedRoute, private bcService: BreadcrumbService,
              private fb: FormBuilder,
              private accountService: AccountService) {
    this.bcService.set('@movieDetails', ' ')
  }

  ngOnInit(): void {
    this.loadProduct()

    this.createForm();
  }

  loadProduct() {
    const id = this.activatedRoute.snapshot.paramMap.get('id');
    if (id) this.moviesService.getMovie(+id).subscribe({
      next: movie => {
        this.movie = movie;
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
}
