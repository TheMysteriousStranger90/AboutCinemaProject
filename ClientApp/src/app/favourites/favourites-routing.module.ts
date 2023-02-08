import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { FavouritesComponent } from './favourites.component';



const routes : Routes = [
  {path: '', component: FavouritesComponent}
];

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forChild(routes)
  ], exports : [
    RouterModule
  ]
})
export class FavouritesRoutingModule { }
