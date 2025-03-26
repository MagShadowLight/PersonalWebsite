import { Component, OnDestroy, OnInit } from '@angular/core';
import { Feedback } from '../../models/IFeedback';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ActivatedRoute, NavigationEnd, Router } from '@angular/router';
import { DataService } from '../../data.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-feedback-edit',
  standalone: false,
  templateUrl: './feedback-edit.component.html',
  styleUrl: './feedback-edit.component.css'
})
export class FeedbackEditComponent implements OnInit, OnDestroy {
  feedback: Feedback = {
      id: 0,
      feedbackName: '',
      email: '',
      feedbackComment: '',
      neededResponse: false,
      isResolved: false
  }

  feedbackForm: FormGroup = new FormGroup({});
  subscription: Subscription;

  constructor(private data: DataService, private route: ActivatedRoute, private router: Router, private fb: FormBuilder) {
    this.subscription = this.router.events.subscribe((event : any) => {
      if (event instanceof NavigationEnd) {
        this.getFeedbackData();
      }
    })
  }

  ngOnInit(): void {
    this.initForm();
  }

  getFeedbackData() {
    this.route.paramMap.subscribe((getId : any) => {
      this.feedback.id = +getId.get('id')!;
    });

    this.data.GetFeedbackInfoById(this.feedback.id).subscribe((feedback: Feedback) => {
      this.feedback = feedback;

      this.loadForm(this.feedback);
    },
      (error : any) => console.error('Error fetching feedback:', error)
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
      feedbackName: feedback.feedbackName,
      email: feedback.email,
      comment: feedback.feedbackComment,
      responseRequired: feedback.neededResponse,
      isResolved: feedback.isResolved
    })
  }

  onSave() {
    const savedFeedback: Feedback = {
      id: this.feedback.id,
      feedbackName: this.feedbackForm.value.feedbackName,
      email: this.feedbackForm.value.email,
      feedbackComment: this.feedbackForm.value.comment,
      neededResponse: this.feedbackForm.value.responseRequired,
      isResolved: this.feedbackForm.value.isResolved
    };

    this.data.UpdateFeedback(this.feedback.id, savedFeedback).subscribe((result : any) => {
      this.router.navigate(['feedback']);
    });
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
    //throw new Error('Method not implemented.');
  }

}
