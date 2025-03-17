import { Component, OnDestroy, OnInit } from '@angular/core';
import { Category } from '../../models/ICategory';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ActivatedRoute, NavigationEnd, Router } from '@angular/router';
import { DataService } from '../../data.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-category-edit',
  standalone: false,
  templateUrl: './category-edit.component.html',
  styleUrl: './category-edit.component.css'
})
export class CategoryEditComponent implements OnInit, OnDestroy {
  category: Category = {
      id: 0,
      categoryName: '',
      parentCategoryId: null,
      postedBlog: [],
      postedItem: []
  }

  isEditing: boolean = false;
  categoryForm: FormGroup = new FormGroup({});
  subscription: Subscription

  constructor(private data: DataService, private route: ActivatedRoute, private router: Router, private fb: FormBuilder) {
    this.subscription = this.router.events.subscribe(event => {
      if (event instanceof NavigationEnd) {
        this.getCategoryData();
      }
    })
  }
  



  ngOnInit(): void {
    this.initForm();
  }

  getCategoryData() {
    this.route.paramMap.subscribe(getId => {
      this.category.id = +getId.get('id')!;
    });

    if (this.category.id <= 0) {
      this.isEditing = false;
    } else {
      this.isEditing = true;
    }

    if (this.isEditing && this.category.id != null && this.category.id != 0) {
      this.data.getCategoryInfoById(this.category.id).subscribe((category: Category) => {
        this.category = category;

        this.loadForm(this.category);
      },
        error => console.error('Error fetching category:', error)
      );
    }
  }

  initForm() {
    this.categoryForm = this.fb.group({
      id: [0],
      categoryName: [''],
      parentCategoryId: [null],
      postedBlog: [],
      postedItem: []
    })
  }

  loadForm(category: Category) {
    this.categoryForm.patchValue({
      categoryName: category.categoryName,
      parentCategoryId: category.parentCategoryId,
      postedBlog: category.postedBlog,
      postedItem: category.postedItem
    });
  }

  onSave() {
    const savedCategory: Category = {
      id: this.category.id,
      categoryName: this.categoryForm.value.categoryName,
      parentCategoryId: this.categoryForm.value.parentCategoryId,
      postedBlog: this.categoryForm.value.postedBlog,
      postedItem: this.categoryForm.value.postedItem
    }

    if (this.isEditing) {
      this.data.UpdateCategory(this.category.id, savedCategory).subscribe(result => {
        this.router.navigate(['category'])
      });
    } else {
      this.data.CreateCategory(savedCategory).subscribe(result => {
        this.router.navigate(['category']);
      });
    }
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
    //throw new Error('Method not implemented.');
  }

}
