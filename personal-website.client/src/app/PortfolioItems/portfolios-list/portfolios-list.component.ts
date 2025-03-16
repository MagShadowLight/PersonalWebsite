
import { Component, OnInit } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { PortfolioItems } from '../../models/IPortfolioItems';
import { Router } from '@angular/router';
import { AuthService } from '../../Services/auth.service';
import { ItemDataService } from '../../Services/dataservices/item-data.service';

@Component({
  selector: 'app-portfolios-list',
  standalone: false,
  templateUrl: './portfolios-list.component.html',
  styleUrl: './portfolios-list.component.css'
})
export class PortfoliosListComponent implements OnInit {

  portfolioItems$: BehaviorSubject<PortfolioItems[]>;

  constructor(private data1: ItemDataService, private router: Router, private auth: AuthService) {
    this.portfolioItems$ = this.data1.portfolioItems$;
    console.log(this.portfolioItems$);
  }

  ngOnInit(): void {
    this.data1.getAllPortfolioItems();
  }

  isAuthenticated(): boolean {
    return this.auth.isAuthenticated();
  }

  CreateItem(): void {
    this.router.navigate(['portfolio', 'create'])
  }

}
