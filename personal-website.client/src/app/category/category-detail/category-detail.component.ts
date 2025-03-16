import { Component, OnInit } from '@angular/core';
import { Category } from '../../models/ICategory';
import { BehaviorSubject } from 'rxjs';
import { ActivatedRoute, Router } from '@angular/router';
import { CategoryDataService } from '../../Services/dataservices/category-data.service';

@Component({
  selector: 'app-category-detail',
  standalone: false,
  templateUrl: './category-detail.component.html',
  styleUrl: './category-detail.component.css'
})
export class CategoryDetailComponent implements OnInit{
  id: number = 0;
  category: BehaviorSubject<Category>;

  constructor(private data: CategoryDataService, private route: ActivatedRoute, private router: Router) {
    this.category = this.data.category$;
  }

  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      this.id = +params.get('id')!;
      this.data.getCategoryById(this.id);
    });
  }

  DeleteCategory() {
    let deletedCategory = this.category;

    if (deletedCategory != undefined) {
      this.data.DeleteCategory(this.id).subscribe(result => {
        this.router.navigate(['category']);
      });
    }
  }

}
