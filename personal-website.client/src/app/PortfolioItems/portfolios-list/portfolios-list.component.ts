
import { Component, OnInit } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { DataService } from '../../data.service';
import { PortfolioItems } from '../../models/IPortfolioItems';
import { Router } from '@angular/router';
import { AuthService } from '../../Services/auth.service';
import { environment } from '../../../environments/environment.development';

@Component({
  selector: 'app-portfolios-list',
  standalone: false,
  templateUrl: './portfolios-list.component.html',
  styleUrl: './portfolios-list.component.css'
})
export class PortfoliosListComponent implements OnInit {
  private readonly serverBaseUrl = `${environment.apiUrl}/Images`;
  

  portfolioItems$: BehaviorSubject<PortfolioItems[]>;

  constructor(private data: DataService, private router: Router, private auth: AuthService) {
    this.portfolioItems$ = this.data.portfolioItems$;
    console.log(this.portfolioItems$);
  }

  ngOnInit(): void {
    this.data.getAllPortfolioItems();
  }

  isAuthenticated(): boolean {
    return this.auth.isAuthenticated();
  }

  CreateItem(): void {
    this.router.navigate(['portfolio', 'create'])
  }

  getServerPath(path: string | undefined) : string {
    if (!path)
      return '';
    const filename = path.replace(/\\/g, "/").split('/').pop();
    return filename ? `${this.serverBaseUrl}/${filename.replace(/\.[^/.]+$/,'.jpg')}` : '';
  }
}
