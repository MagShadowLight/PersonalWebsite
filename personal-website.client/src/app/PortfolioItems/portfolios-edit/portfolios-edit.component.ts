import { Component, OnInit } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { PortfolioItems } from '../../models/IPortfolioItems';
import { ActivatedRoute, Router } from '@angular/router';
import { DataService } from '../../data.service';

@Component({
  selector: 'app-portfolios-edit',
  standalone: false,
  templateUrl: './portfolios-edit.component.html',
  styleUrl: './portfolios-edit.component.css'
})
export class PortfoliosEditComponent implements OnInit {

  id: number = 0;
  item$: BehaviorSubject<PortfolioItems>

  constructor(private data: DataService, private route: ActivatedRoute, private router: Router) {
    this.item$ = this.data.portfolioItem$
  }

  ngOnInit(): void {
    this.route.paramMap.subscribe(param => {
      this.id = +param.get('id')!;
      this.data.getPortfolioItemById(this.id);
    })
  }

}
