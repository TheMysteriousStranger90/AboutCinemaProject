import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FavouritesSummaryComponent } from './favourites-summary.component';

describe('FavouritesSummaryComponent', () => {
  let component: FavouritesSummaryComponent;
  let fixture: ComponentFixture<FavouritesSummaryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FavouritesSummaryComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FavouritesSummaryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
