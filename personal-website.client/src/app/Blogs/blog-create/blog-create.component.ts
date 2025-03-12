import { Component } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { DataService } from '../../data.service';
import { Blogs } from '../../models/IBlogs';

@Component({
  selector: 'app-blog-create',
  standalone: false,
  templateUrl: './blog-create.component.html',
  styleUrl: './blog-create.component.css'
})
export class BlogCreateComponent {
  blogForm!: FormGroup;
  errorMessage = '';

  constructor(private fb: FormBuilder, private data: DataService, private router: Router) {
    this.blogForm = this.fb.group({
      id: 0,
      displayName: ['Taco'],
      title: ['Taco'],
      body: ['Lorem Ispum'],
      createdDate: [new Date()],
      updatedDate: [new Date()],
      Visibility: [0],
      categoriesId: [0],
      category: [{
        categoryId: 0,
        categoryName: ' ',
        parentCategoryId: 0,
        PostedBlogs: [],
        PostedItems: []
      }]
    });
  }

  OnCreate() {
    if (this.blogForm.valid) {
      //console.log(this.blogForm.value)
      this.errorMessage = '';
      let createdBlog: Blogs = {
          id: this.blogForm.value.id,
          displayName: this.blogForm.value.displayName,
          title: this.blogForm.value.title,
          body: this.blogForm.value.body,
          createdDate: new Date(),
          updatedDate: new Date(), 
          visibility: Number(this.blogForm.value.Visibility),
          categoryId: this.blogForm.value.categoriesId,
          category: this.blogForm.value.category

      }

      console.log("Created ->", createdBlog);

      this.data.createBlog(createdBlog).subscribe(result => {
        console.log("Created new Post", result);
        this.router.navigate(['blog'])
      })
    }
  }
}
