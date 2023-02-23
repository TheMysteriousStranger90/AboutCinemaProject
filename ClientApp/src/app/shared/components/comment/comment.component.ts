import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { AccountService } from 'src/app/account/account.service';
import { Movie } from '../../models/movie';
import { User } from '../../models/user';
import { CommentService } from './comment.service';

@Component({
  selector: 'app-comment',
  templateUrl: './comment.component.html',
  styleUrls: ['./comment.component.scss']
})
export class CommentComponent {



  constructor(private fb: FormBuilder,
              private commentService: CommentService,
              private accountService: AccountService,
              private route: ActivatedRoute) { }




}
