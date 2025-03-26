import { Component, OnInit } from '@angular/core';
import { DataService } from '../../data.service';
import { ActivatedRoute, Router } from '@angular/router';
import { BehaviorSubject } from 'rxjs';
import { Blogs } from '../../models/IBlogs';
import { AuthService } from '../../Services/auth.service';

@Component({
  selector: 'app-blog-detail',
  standalone: false,
  templateUrl: './blog-detail.component.html',
  styleUrl: './blog-detail.component.css'
})
export class BlogDetailComponent implements OnInit{

  id: number = 0;
  blog$: BehaviorSubject<Blogs>;
  constructor(private data: DataService, private route: ActivatedRoute, private router: Router, private auth: AuthService ) {
    //  this.id = 0;
    //this.blog = {
    //  Id: 0,
    //  displayName: '',
    //  title: '',
    //  body: '',
    //  createdDate: new Date(),
    //  updatedDate: new Date(),
    //  Visibility: 0,
    //  categoryId: 0,
    //  category: {
    //    categoryId: 0,
    //    categoryName: '',
    //    parentCategoryId: null
    //  }
    //};
    this.blog$ = this.data.blog$;
  }
  ngOnInit(): void {
    this.route.paramMap.subscribe((params : any) => {
      this.id = +params.get('id')!;
      this.data.getBlogsbyId(this.id);
    });
  }

  DeletePost() {
    let blog = this.blog$
    console.log(blog.value, this.id)

    if (blog != undefined) {
      this.data.deleteBlog(this.id).subscribe((result : any) => {
        this.router.navigate(['/blog']);
      });
    }
  }

  isAuthenticated() : boolean {
    return this.auth.isAuthenticated();
  }
}
