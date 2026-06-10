import { Component, OnInit } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { DataService } from '../../data.service';
import { ActivatedRoute, Router } from '@angular/router';
import { PortfolioItems } from '../../models/IPortfolioItems';
import { AuthService } from '../../Services/auth.service';
import { environment } from '../../../environments/environment.development';

@Component({
  selector: 'app-portfolios-detail',
  standalone: false,
  templateUrl: './portfolios-detail.component.html',
  styleUrl: './portfolios-detail.component.css'
})
export class PortfoliosDetailComponent implements OnInit{
  private readonly serverBaseUrl = `${environment.apiUrl}/Images`;
  id: number = 0;
  portfolioItem$: BehaviorSubject<PortfolioItems>;
  portfolioItems$: BehaviorSubject<PortfolioItems[]>;

  constructor(private data: DataService, private route: ActivatedRoute, private router: Router, private auth: AuthService) {
    this.portfolioItem$ = this.data.portfolioItem$;
    this.portfolioItems$ = this.data.portfolioItems$
  }

  ngOnInit(): void {
    this.route.paramMap.subscribe((params : any) => {
      this.id = +params.get('id')!;
      this.data.getPortfolioItemById(this.id);
    });
    this.data.getAllPortfolioItems();
  }

  DeleteItem() {
    let item = this.portfolioItem$
    console.log(item.value, this.id)

    if (item != undefined) {
      this.data.deleteItem(this.id).subscribe((result : any) => {
        this.router.navigate(['/portfolio']);
      });
    }
  }

  isAuthenticated(): boolean {
    return this.auth.isAuthenticated();
  }

  getServerPath(path: string | undefined) : string {
    if (!path)
      return '';
    const filename = path.replace(/\\/g, "/").split('/').pop();
    return filename ? `${this.serverBaseUrl}/${filename.replace(/\.[^/.]+$/,'.jpg')}` : '';
  }
}
