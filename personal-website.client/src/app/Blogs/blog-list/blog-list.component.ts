import { Component, OnInit } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { Blogs } from '../../models/IBlogs';
import { Category } from '../../models/ICategory';
import { Router } from '@angular/router';
import { AuthService } from '../../Services/auth.service';
import { BlogDataService } from '../../Services/dataservices/blog-data.service';
import { CategoryDataService } from '../../Services/dataservices/category-data.service';

//interface BlogList extends Blogs {
//  Id: number;
//  displayName: string;
//  title: string;
//  body: string;
//  createdDate: Date;
//  updatedDate: Date;
//  Visibility: number;
//  categoryId: number;
//  category: Category;
//}


@Component({
  selector: 'app-blog-list',
  standalone: false,
  templateUrl: './blog-list.component.html',
  styleUrl: './blog-list.component.css'
})


export class BlogListComponent implements OnInit {

  blogs$: BehaviorSubject<Blogs[]>;
  categories$: BehaviorSubject<Category[]>;
  

  constructor(private data1: BlogDataService, private router: Router, private auth: AuthService, private data2: CategoryDataService) {
    this.blogs$ = this.data1.blogs$;
    this.categories$ = this.data2.categories$

    //this.data.getAllBlogs().subscribe(data => {
    //  this.blogs = data;
    console.log(this.blogs$);
    //})
     
  }

  ngOnInit(): void {
    this.data1.getAllBlogs();
    this.data2.getAllCategories();
  }

  isAuthenticated(): boolean {
    return this.auth.isAuthenticated();
  }

  CreateBlog(): void {
    this.router.navigate(['blog', 'create'])
  }
}
