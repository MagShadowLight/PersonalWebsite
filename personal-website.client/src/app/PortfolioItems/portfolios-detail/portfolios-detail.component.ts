import { Component, OnInit } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { DataService } from '../../data.service';
import { ActivatedRoute, Router } from '@angular/router';
import { PortfolioItems } from '../../models/IPortfolioItems';
import { AuthService } from '../../Services/auth.service';

@Component({
  selector: 'app-portfolios-detail',
  standalone: false,
  templateUrl: './portfolios-detail.component.html',
  styleUrl: './portfolios-detail.component.css'
})
export class PortfoliosDetailComponent implements OnInit{
  id: number = 0;
  portfolioItem$: BehaviorSubject<PortfolioItems>;

  constructor(private data: DataService, private route: ActivatedRoute, private router: Router, private auth: AuthService) {
    this.portfolioItem$ = this.data.portfolioItem$;
  }

  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      this.id = +params.get('id')!;
      this.data.getPortfolioItemById(this.id);
    });
  }

  DeleteItem() {
    let item = this.portfolioItem$
    console.log(item.value, this.id)

    if (item != undefined) {
      this.data.deleteItem(this.id).subscribe(result => {
        this.router.navigate(['/portfolio']);
      });
    }
  }

  isAuthenticated(): boolean {
    return this.auth.isAuthenticated();
  }

}
