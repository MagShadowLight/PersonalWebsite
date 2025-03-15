import { Component, OnDestroy, OnInit } from '@angular/core';
import { Feedback } from '../../models/IFeedback';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ActivatedRoute, NavigationEnd, Router } from '@angular/router';
import { DataService } from '../../data.service';

@Component({
  selector: 'app-feedback-edit',
  standalone: false,
  templateUrl: './feedback-edit.component.html',
  styleUrl: './feedback-edit.component.css'
})
export class FeedbackEditComponent implements OnInit, OnDestroy {
  feedback: Feedback = {
      FeedbackId: 0,
      FeedbackName: '',
      email: '',
      comment: '',
      responseRequired: false,
      isResolved: false
  }

  feedbackForm: FormGroup = new FormGroup({});

  constructor(private data: DataService, private route: ActivatedRoute, private router: Router, private fb: FormBuilder) {
    this.router.events.subscribe(event => {
      if (event instanceof NavigationEnd) {
        this.getFeedbackData();
      }
    })
  }

  ngOnInit(): void {
    this.initForm();
  }

  getFeedbackData() {
    this.route.paramMap.subscribe(getId => {
      this.feedback.FeedbackId = +getId.get('id')!;
    });

    this.data.GetFeedbackInfoById(this.feedback.FeedbackId).subscribe((feedback: Feedback) => {
      this.feedback = feedback;

      this.loadForm(this.feedback);
    },
      error => console.error('Error fetching feedback:', error)
    );
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

  loadForm(feedback: Feedback) {
    this.feedbackForm.patchValue({
      feedbackName: feedback.FeedbackName,
      email: feedback.email,
      comment: feedback.comment,
      responseRequired: feedback.responseRequired,
      isResolved: feedback.isResolved
    })
  }

  onSave() {
    const savedFeedback: Feedback = {
      FeedbackId: this.feedback.FeedbackId,
      FeedbackName: this.feedbackForm.value.feedbackName,
      email: this.feedbackForm.value.email,
      comment: this.feedbackForm.value.comment,
      responseRequired: this.feedbackForm.value.responseRequired,
      isResolved: this.feedbackForm.value.isResolved
    };

    this.data.UpdateFeedback(this.feedback.FeedbackId, savedFeedback).subscribe(result => {
      this.router.navigate(['feedback']);
    });
  }

  ngOnDestroy(): void {
    //throw new Error('Method not implemented.');
  }

}
