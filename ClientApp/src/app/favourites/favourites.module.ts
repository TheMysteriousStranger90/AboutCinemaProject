import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FavouritesComponent } from './favourites.component';
import { SharedModule } from '../shared/shared.module';
import { FavouritesRoutingModule } from './favourites-routing.module';
import { FavouritesSummaryComponent } from './favourites-summary/favourites-summary.component';



@NgModule({
  declarations: [
    FavouritesComponent,
    FavouritesSummaryComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    FavouritesRoutingModule
  ],
  exports: [
    FavouritesSummaryComponent
  ]
})
export class FavouritesModule { }
