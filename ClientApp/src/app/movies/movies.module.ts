import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MoviesComponent } from './movies.component';
import { SharedModule } from '../shared/shared.module';
import { MoviesRoutingModule } from './movies-routing.module';
import { MovieItemComponent } from './movie-item/movie-item.component';



@NgModule({
  declarations: [
    MoviesComponent,
    MovieItemComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    MoviesRoutingModule
  ]
})
export class MoviesModule { }
