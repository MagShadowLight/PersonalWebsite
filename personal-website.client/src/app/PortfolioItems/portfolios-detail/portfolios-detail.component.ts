import { Component, OnInit } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { ActivatedRoute, Router } from '@angular/router';
import { PortfolioItems } from '../../models/IPortfolioItems';
import { AuthService } from '../../Services/auth.service';
import { ItemDataService } from '../../Services/dataservices/item-data.service';

@Component({
  selector: 'app-portfolios-detail',
  standalone: false,
  templateUrl: './portfolios-detail.component.html',
  styleUrl: './portfolios-detail.component.css'
})
export class PortfoliosDetailComponent implements OnInit{
  id: number = 0;
  portfolioItem$: BehaviorSubject<PortfolioItems>;

  constructor(private data1: ItemDataService, private route: ActivatedRoute, private router: Router, private auth: AuthService) {
    this.portfolioItem$ = this.data1.portfolioItem$;
  }

  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      this.id = +params.get('id')!;
      this.data1.getPortfolioItemById(this.id);
    });
  }

  DeleteItem() {
    let item = this.portfolioItem$
    console.log(item.value, this.id)

    if (item != undefined) {
      this.data1.deleteItem(this.id).subscribe(result => {
        this.router.navigate(['/portfolio']);
      });
    }
  }

  isAuthenticated(): boolean {
    return this.auth.isAuthenticated();
  }

}
