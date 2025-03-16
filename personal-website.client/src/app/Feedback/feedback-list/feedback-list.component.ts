import { Component, OnInit } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { Feedback } from '../../models/IFeedback';
import { Router } from '@angular/router';
import { FeedbackDataService } from '../../Services/dataservices/feedback-data.service';

@Component({
  selector: 'app-feedback-list',
  standalone: false,
  templateUrl: './feedback-list.component.html',
  styleUrl: './feedback-list.component.css'
})
export class FeedbackListComponent implements OnInit {
  feedback: BehaviorSubject<Feedback[]>

  constructor(private data: FeedbackDataService, private router: Router) {
    this.feedback = this.data.feedbacks$;
  }

  ngOnInit(): void {
    this.data.GetAllFeedback();
  }
}
