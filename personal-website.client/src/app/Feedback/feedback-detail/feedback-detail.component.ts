import { Component, OnInit } from '@angular/core';
import { Feedback } from '../../models/IFeedback';
import { ActivatedRoute, Router } from '@angular/router';
import { BehaviorSubject } from 'rxjs';
import { DataService } from '../../data.service';

@Component({
  selector: 'app-feedback-detail',
  standalone: false,
  templateUrl: './feedback-detail.component.html',
  styleUrl: './feedback-detail.component.css'
})
export class FeedbackDetailComponent implements OnInit {
  id: number = 0;
  feedback: BehaviorSubject<Feedback>;

  constructor(private data: DataService, private route: ActivatedRoute, private router: Router) {
    this.feedback = this.data.feedback$;
  }

  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      this.id = +params.get('id')!;
      this.data.GetFeedbackById(this.id);
    });
  }

  DeleteFeedback() {
    let deletedFeedback = this.feedback;

    if (deletedFeedback != undefined) {
      this.data.DeleteFeedback(this.id).subscribe(result => {
        this.router.navigate(['feedback']);
      });
    }
  }
}
