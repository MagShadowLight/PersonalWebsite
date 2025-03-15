import { Component, OnInit } from '@angular/core';
import { Feedback } from '../../models/IFeedback';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { DataService } from '../../data.service';

@Component({
  selector: 'app-feedback-form',
  standalone: false,
  templateUrl: './feedback-form.component.html',
  styleUrl: './feedback-form.component.css'
})
export class FeedbackFormComponent implements OnInit {
  feedback: Feedback = {
    FeedbackId: 0,
    FeedbackName: '',
    email: '',
    comment: '',
    responseRequired: false,
    isResolved: false
  };

  feedbackForm: FormGroup = new FormGroup({});

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
      FeedbackId: this.feedbackForm.value.feedbackId,
      FeedbackName: this.feedbackForm.value.feedbackName,
      email: this.feedbackForm.value.email,
      comment: this.feedbackForm.value.comment,
      responseRequired: this.feedbackForm.value.responseRequired,
      isResolved: this.feedbackForm.value.isResolved
    };

    this.data.CreateFeedback(savedFeedback).subscribe(result => {
      this.router.navigate(['/']);
    });
  }

}
