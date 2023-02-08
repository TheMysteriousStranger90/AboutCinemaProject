import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NotFoundComponent } from './core/not-found/not-found.component';
import { ServerErrorComponent } from './core/server-error/server-error.component';
import { TestErrorComponent } from './core/test-error/test-error.component';
import { HomeComponent } from './home/home/home.component';

const routes: Routes = [
  {path: '', component: HomeComponent, data: {breadcrumb: 'Home'}},
  {path: 'test-error', component: TestErrorComponent, data: {breadcrumb: 'Test Errors'}},
  {path: 'not-found', component: NotFoundComponent, data: {breadcrumb: 'Not Found'}},
  {path: 'server-error', component: ServerErrorComponent, data: {breadcrumb: 'Server Errors'}},
  {path: 'movies', loadChildren: () => import('./movies/movies.module').then(m => m.MoviesModule),
    data: {breadcrumb: 'Movies'}
  },
  {path: 'favourites', loadChildren: () => import('./favourites/favourites.module').then(m => m.FavouritesModule),
    data: {breadcrumb: 'Favourites'}
  },

  {path: 'account', loadChildren: () => import('./account/account.module').then(m => m.AccountModule), data: {breadcrumb: {skip: true}}},
  {path: '**', redirectTo: '', pathMatch: 'full'},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
