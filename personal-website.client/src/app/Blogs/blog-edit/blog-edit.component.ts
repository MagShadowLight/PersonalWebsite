import { Component, OnDestroy, OnInit } from '@angular/core';
import { Blogs } from '../../models/IBlogs';
import { ActivatedRoute, NavigationEnd, Router } from '@angular/router';
import { BehaviorSubject, Subscription, switchMap } from 'rxjs';
import { DataService } from '../../data.service';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { Category } from '../../models/ICategory';

@Component({
  selector: 'app-blog-edit',
  standalone: false,
  templateUrl: './blog-edit.component.html',
  styleUrl: './blog-edit.component.css'
})
export class BlogEditComponent implements OnInit, OnDestroy {
  blog: Blogs = {
      id: 0,
      displayName: '',
      title: '',
      body: 'Lorem Ispum',
      createdDate: new Date(),
      updatedDate: new Date(),
      visibility: 0,
      categoryId: 0,
      category: {
          id: 0,
          categoryName: ' ',
          parentCategoryId: 0,
          postedBlog: [],
          postedItem: []
      },
      blogsScreenshotId: 0,
      blogsScreenshot: {
        blogsScreenshotId: 0,
        path: '',
        description: ''
      }
  }
  //category: Category = {
  //    categoryId: 0,
  //    categoryName: '',
  //    parentCategoryId: null,
  //    postedBlog: [],
  //    postedItem: []
  //}
  isEditing: boolean = false;

  blogForm: FormGroup = new FormGroup({});
  subscription: Subscription
  constructor(private data: DataService, private route: ActivatedRoute, private router: Router, private formBuilder: FormBuilder) {
    //this.initFormAsEmpty();
    this.subscription = this.router.events.subscribe((event : any) => {
      if (event instanceof NavigationEnd) {
        this.getBlogData();
      }
    });

  }
  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }

  ngOnInit(): void {


    
    this.initForm();
    
  }

  getBlogData() : void {
    this.route.paramMap.subscribe((getId : any) => {
      this.blog.id = +getId.get('id')!;
    });
    console.log(this.blog.id)

    //this.isEditing = (this.blog.id == null || this.blog.id == -1) ? false : true;

    if (this.blog.id <= 0) {
      this.isEditing = false;
    } else {
      this.isEditing = true;
    }
    
    console.log(this.isEditing)
    if (this.isEditing && this.blog.id != null && this.blog.id != 0) {
      this.data.getBlogInfoById(this.blog.id).subscribe((blogs : Blogs) => {
        this.blog = blogs;

        console.log(
          `Title: ${this.blog.title}\n
          Body: ${this.blog.body}`);
        this.loadForm(this.blog);
      },
      (error : any) => console.error('Error fetching Blogs.', error)
      );
    }
  }



  initForm() {
    this.blogForm = this.formBuilder.group({
      id: [this.blog.id],
      displayName: [''],
      title: ['Taco'],
      body: ['Lorem Ispum'],
      createdDate: [new Date()],
      updatedDate: [new Date()],
      visibility: [0],
      categoryId: [0],
      category: this.formBuilder.group({
        categoryId: [0],
        categoryName: [' '],
        parentCategoryId: [0],
        PostedBlogs: [],
        PostedItems: []
      }),
      blogScreenshotId: [0],
      blogScreenshot: this.formBuilder.group({
        blogScreenshotId:[0],
        path: [' '],
        description: [' ']
      })
    });
  }

  loadForm(blogData : Blogs) {
    this.blogForm.patchValue({
      title: blogData.title,
      displayName: blogData.displayName,
      body: blogData.body,
      visibility: blogData.visibility,
      categoryId: blogData.categoryId,
      createdDate: blogData.createdDate,
      updatedDate: new Date()
    })
  }

  onSaveButton() {
    const savedBlog: Blogs = {
        id: this.blogForm.value.id,
        displayName: this.blogForm.value.displayName,
        title: this.blogForm.value.title,
        body: this.blogForm.value.body,
        createdDate: this.blogForm.value.createdDate,
        updatedDate: this.blogForm.value.updatedDate,
        visibility: this.blogForm.value.visibility,
        categoryId: Number(this.blogForm.value.categoryId),
        category: this.blogForm.value.category,
        blogsScreenshotId: Number(this.blogForm.value.blogScreenshotId),
        blogsScreenshot: this.blogForm.value.blogScreenshot
    }


    console.log(savedBlog);
    if (this.isEditing) {
      this.data.updateBlog(this.blog.id, savedBlog).subscribe((result : any) => {
        this.router.navigate(['/']);
      });
    } else {
      //if (savedBlog.categoryId > 0) {
      //  // get CategoryId from blog
      //  const id = savedBlog.categoryId
      //  console.log(id)
      //  // get Category from CategoryId
      //  this.data.getCategoryInfoById(id).subscribe((category : Category) => {
      //    this.category = category;
      //    console.log(this.category);
      //  })
      //  console.log(this.category);
      //  // place Category in Blogs
      //  savedBlog.category = this.category;
      this.blog = savedBlog
      this.data.createBlog(savedBlog).subscribe((result : any) => {
        //console.log('Data should go through with category')
        this.router.navigate(['/blog']);
      },
      (error : any) => {
        console.error("Error: Unable to create Blogs")
      });
    }
  }

}
