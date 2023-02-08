import { Component, OnInit } from '@angular/core';
import { AccountService } from './account/account.service';
import { FavouritesService } from './favourites/favourites.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'AboutCinema';

  constructor(private favouritesService: FavouritesService, private accountService: AccountService) {}

  ngOnInit(): void {
    this.loadFavourites()
    this.loadCurrentUser();
  }


  loadFavourites() {
    const favouritesId = localStorage.getItem('favourites_id');
    if (favouritesId) this.favouritesService.getFavourites(favouritesId);
  }

  loadCurrentUser() {
    const token = localStorage.getItem('token');
    this.accountService.loadCurrentUser(token).subscribe();
  }
}
