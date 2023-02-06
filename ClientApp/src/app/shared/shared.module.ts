import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PagingHeaderComponent } from './components/paging-header/paging-header.component';
import { PagerComponent } from './components/pager/pager.component';
import { TextInputComponent } from './components/text-input/text-input.component';
import { StepperComponent } from './components/stepper/stepper.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CdkStepperModule } from '@angular/cdk/stepper';
import { RouterModule } from '@angular/router';

import {PaginationModule} from 'ngx-bootstrap/pagination';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';



@NgModule({
  declarations: [
    PagingHeaderComponent,
    PagerComponent,
    TextInputComponent,
    StepperComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
    RouterModule,
    CdkStepperModule,
    PaginationModule.forRoot(),
    BsDropdownModule.forRoot()
  ],
  exports: [
    PagingHeaderComponent,
    PagerComponent,
    ReactiveFormsModule,
    TextInputComponent,
    StepperComponent,
    CdkStepperModule,
    BsDropdownModule,
    FormsModule,
  ]
})
export class SharedModule { }
