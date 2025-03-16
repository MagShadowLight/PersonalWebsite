import { Component, OnInit} from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { Category } from '../../models/ICategory';
import { Router } from '@angular/router';
import { CategoryDataService } from '../../Services/dataservices/category-data.service';

@Component({
  selector: 'app-category-list',
  standalone: false,
  templateUrl: './category-list.component.html',
  styleUrl: './category-list.component.css'
})
export class CategoryListComponent implements OnInit {

  categories: BehaviorSubject<Category[]>;

  constructor(private data: CategoryDataService, private router: Router) {
    this.categories = this.data.categories$
  }

  ngOnInit(): void {
    this.data.getAllCategories();
    console.log(this.categories);
  }

  CreateCategory(): void {
    this.router.navigate(['category', 'create'])
  }
}
