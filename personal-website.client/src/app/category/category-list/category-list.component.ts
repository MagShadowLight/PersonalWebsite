import { Component, OnInit} from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { Category } from '../../models/ICategory';
import { DataService } from '../../data.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-category-list',
  standalone: false,
  templateUrl: './category-list.component.html',
  styleUrl: './category-list.component.css'
})
export class CategoryListComponent implements OnInit {

  categories: BehaviorSubject<Category[]>;

  constructor(private data: DataService, private router: Router) {
    this.categories = this.data.categories$
  }

  ngOnInit(): void {
    this.data.getAllCategories();
  }
  
}
