import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { RatingService } from './rating.service';

@Component({
  selector: 'app-rating',
  templateUrl: './rating.component.html',
  styleUrls: ['./rating.component.scss']
})
export class RatingComponent implements OnInit{

  constructor() {
  }

  @Input()
  maxRating = 5;
  @Input()
  selectedRate = 0;
  @Output()
  onRating: EventEmitter<number> = new EventEmitter<number>();
  previousRate = 0;
  maxRatingArr : any[] = [];

  ngOnInit(): void {
    this.maxRatingArr = Array(this.maxRating).fill(0);
  }

  handleMouseEnter(index: number) {
    this.selectedRate = index + 1;
  }

  handleMouseLeave() {
    if (this.previousRate !== 0) {
      this.selectedRate = this.previousRate;
    } else {
      this.selectedRate = 0;
    }
  }

  rate(index: number){
      this.selectedRate = index + 1;
      this.previousRate = this.selectedRate;
      this.onRating.emit(this.selectedRate);
    }

}
