import { Component, OnDestroy, OnInit } from '@angular/core';
import { Category } from '../../models/ICategory';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ActivatedRoute, NavigationEnd, Router } from '@angular/router';
import { DataService } from '../../data.service';

@Component({
  selector: 'app-category-edit',
  standalone: false,
  templateUrl: './category-edit.component.html',
  styleUrl: './category-edit.component.css'
})
export class CategoryEditComponent implements OnInit, OnDestroy {
  category: Category = {
      categoryId: 0,
      categoryName: '',
      parentCategoryId: null,
      postedBlog: [],
      postedItem: []
  }

  isEditing: boolean = false;
  categoryForm: FormGroup = new FormGroup({});

  constructor(private data: DataService, private route: ActivatedRoute, private router: Router, private fb: FormBuilder) {
    this.router.events.subscribe(event => {
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
      this.category.categoryId = +getId.get('id')!;
    });

    if (this.category.categoryId <= 0) {
      this.isEditing = false;
    } else {
      this.isEditing = true;
    }

    if (this.isEditing && this.category.categoryId != null && this.category.categoryId != 0) {
      this.data.getCategoryInfoById(this.category.categoryId).subscribe((category: Category) => {
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
      categoryId: this.category.categoryId,
      categoryName: this.categoryForm.value.categoryName,
      parentCategoryId: this.categoryForm.value.parentCategoryId,
      postedBlog: this.categoryForm.value.postedBlog,
      postedItem: this.categoryForm.value.postedItem
    }

    if (this.isEditing) {
      this.data.UpdateCategory(this.category.categoryId, savedCategory).subscribe(result => {
        this.router.navigate(['category'])
      });
    } else {
      this.data.CreateCategory(savedCategory).subscribe(result => {
        this.router.navigate(['category']);
      });
    }
  }

  ngOnDestroy(): void {
    //throw new Error('Method not implemented.');
  }

}
