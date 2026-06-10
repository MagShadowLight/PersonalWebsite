import { Component, OnInit } from '@angular/core';
import { DataService } from '../../data.service';
import { BehaviorSubject } from 'rxjs';
import { Blogs } from '../../models/IBlogs';
import { Category } from '../../models/ICategory';
import { Router } from '@angular/router';
import { AuthService } from '../../Services/auth.service';
import { environment } from '../../../environments/environment.development';

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
  private readonly serverBaseUrl = `${environment.apiUrl}/Images`;
  
  blogs$: BehaviorSubject<Blogs[]>;
  categories$: BehaviorSubject<Category[]>;
  

  constructor(private data: DataService, private router: Router, private auth: AuthService) {
    this.blogs$ = this.data.blogs$;
    this.categories$ = this.data.categories$

    //this.data.getAllBlogs().subscribe(data => {
    //  this.blogs = data;
    console.log(this.blogs$);
    //})
     
  }

  ngOnInit(): void {
    this.data.getAllBlogs();
    this.data.getAllCategories();
  }

  isAuthenticated(): boolean {
    return this.auth.isAuthenticated();
  }

  CreateBlog(): void {
    this.router.navigate(['blog', 'create'])
  }

  getServerPath(path: string | undefined) : string {
    if (!path)
      return '';
    const filename = path.replace(/\\/g, "/").split('/').pop();
    return filename ? `${this.serverBaseUrl}/${filename.replace(/\.[^/.]+$/,'.jpg')}` : '';
  }
}
