import { Component, OnInit } from '@angular/core';
import { Feedback } from '../../models/IFeedback';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { DataService } from '../../data.service';
import { delay } from 'rxjs';

@Component({
  selector: 'app-feedback-form',
  standalone: false,
  templateUrl: './feedback-form.component.html',
  styleUrl: './feedback-form.component.css'
})
export class FeedbackFormComponent implements OnInit {
  feedback: Feedback = {
    id: 0,
    feedbackName: '',
    email: '',
    feedbackComment: '',
    neededResponse: false,
    isResolved: false
  };

  feedbackForm: FormGroup = new FormGroup({});

  isCreated: Boolean = false;
  

  constructor(private data: DataService, private router: Router, private fb: FormBuilder) { }

  ngOnInit(): void {
    this.initForm();
  }

  initForm() {
    this.feedbackForm = this.fb.group({
      feedbackId: [0],
      feedbackName: [''],
      email: [''],
      comment: [''],
      responseRequired: [false],
      isResolved: [false]
    });
  }

  onSave() {
    const savedFeedback: Feedback = {
      id: this.feedbackForm.value.feedbackId,
      feedbackName: this.feedbackForm.value.feedbackName,
      email: this.feedbackForm.value.email,
      feedbackComment: this.feedbackForm.value.comment,
      neededResponse: this.feedbackForm.value.responseRequired,
      isResolved: this.feedbackForm.value.isResolved
    };
    this.isCreated = true;
    this.data.CreateFeedback(savedFeedback).pipe(
      delay(3000)
    ).subscribe(result => {
      this.isCreated = false;
    });
    
  }

}
