import { Component, OnInit } from '@angular/core';
import { Blogs } from '../../models/IBlogs';
import { ActivatedRoute, NavigationEnd, Router } from '@angular/router';
import { BehaviorSubject, switchMap } from 'rxjs';
import { DataService } from '../../data.service';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-blog-edit',
  standalone: false,
  templateUrl: './blog-edit.component.html',
  styleUrl: './blog-edit.component.css'
})
export class BlogEditComponent implements OnInit {
  blog: Blogs = {
      id: -1,
      displayName: 'Taco',
      title: 'Taco',
      body: 'Lorem Ispum',
      createdDate: new Date(),
      updatedDate: new Date(),
      visibility: 0,
      categoryId: 0,
      category: {
          categoryId: 0,
          categoryName: ' ',
          parentCategoryId: 0,
          postedBlog: [],
          postedItem: []
      }
  }
  isEditing: boolean = false;

  blogForm: FormGroup = new FormGroup({});
  constructor(private data: DataService, private route: ActivatedRoute, private router: Router, private formBuilder: FormBuilder) {
    //this.initFormAsEmpty();
    this.router.events.subscribe(event => {
      if (event instanceof NavigationEnd) {
        this.getBlogData();
      }
    });
  }

  ngOnInit(): void {
    this.initForm();
  }

  getBlogData() : void {
    this.route.paramMap.subscribe(getId => {
      this.blog.id = +getId.get('id')!;
    });

    this.isEditing = (this.blog.id == null || this.blog.id == -1) ? false : true;

    if (this.isEditing && this.blog.id != null && this.blog.id != -1) {
      this.data.getBlogInfoById(this.blog.id).subscribe((blogs : Blogs) => {
        this.blog = blogs;

        console.log(
          `Name: ${this.blog.title}\n
          Description: ${this.blog.body}`);
      },
      error => console.error('Error fetching Blogs.', error)
      );
    }
  }



  //initFormAsEmpty() {
  //  this.blogForm = this.formBuilder.group({
  //    id: [this.blog.id],
  //    displayName: ['Taco'],
  //    title: ['Taco'],
  //    body: ['Lorem Ispum'],
  //    createdDate: [new Date()],
  //    updatedDate: [new Date()],
  //    visibility: [0],
  //    categoryId: [0],
  //    category: [{
  //      categoryId: [0],
  //      categoryName: [' '],
  //      parentCategoryId: [0],
  //      PostedBlogs: [],
  //      PostedItems: []
  //    }]
  //  });

  //  this.isEditing = false;
  //}

  initForm() {
    this.blogForm.patchValue({
      title: new FormControl(this.blog.title),
      displayName: new FormControl(this.blog.displayName),
      body: new FormControl(this.blog.body),
      visibility: new FormControl(this.blog.visibility),

      createdDate: new FormControl(this.blog.createdDate),
      updatedDate: new FormControl(this.blog.updatedDate)
    })
  }

  onSaveButton() {
    const savedBlog: Blogs = { ...this.blog, ...this.blogForm.value };

    console.log(savedBlog);
    if (this.isEditing) {
      this.data.updateBlog(this.blog.id, savedBlog).subscribe(result => {
        this.router.navigate(['/']);
      });
    } else {
      this.data.createBlog(savedBlog).subscribe(result => {
        this.router.navigate(['/']);
      });
    }
  }

}
