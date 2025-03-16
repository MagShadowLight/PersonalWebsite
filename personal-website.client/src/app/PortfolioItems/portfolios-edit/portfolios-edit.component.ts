import { Component, OnInit } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { PortfolioItems } from '../../models/IPortfolioItems';
import { ActivatedRoute, NavigationEnd, Router } from '@angular/router';
import { DataService } from '../../data.service';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-portfolios-edit',
  standalone: false,
  templateUrl: './portfolios-edit.component.html',
  styleUrl: './portfolios-edit.component.css'
})
export class PortfoliosEditComponent implements OnInit {
  item: PortfolioItems = {
      id: 0,
      displayName: '',
      title: '',
      description: '',
      creationDate: new Date(),
      updatedDate: new Date(),
      version: '',
      links: '',
      categoryId: 0,
      category: {
          id: 0,
          categoryName: '',
          parentCategoryId: 0,
          postedBlog: [],
          postedItem: []
      },
      imageID: 0,
    image: {
        id: 0,
        name: '',
        description: '',
        path: '',
        fileSize: 0,
        portfolioId: 0
    }
  }
  isEditing: Boolean = false;

  itemForm: FormGroup = new FormGroup({});
  //id: number = 0;
  //item$: BehaviorSubject<PortfolioItems>

  constructor(private data: DataService, private router: Router, private route: ActivatedRoute, private fb: FormBuilder) {
    //this.item$ = this.data.portfolioItem$
    this.router.events.subscribe(event => {
      if (event instanceof NavigationEnd) {
        this.getItemData();
      }
    });
  }
  getItemData() {
    this.route.paramMap.subscribe(getId => {
      this.item.id = +getId.get('id')!;
    });
    console.log(this.item.id);

    if (this.item.id <= 0) {
      this.isEditing = false;
    } else {
      this.isEditing = true;
    }

    if (this.isEditing && this.item.id != null && this.item.id != 0) {
      this.data.getItemInfoById(this.item.id).subscribe((items: PortfolioItems) => {
        this.item = items;

        console.log(
          `Title: ${this.item.title}\n
          Description: ${this.item.description}`
        );
        this.loadForm(this.item);
      },
        error => console.error('Error fetching Items in Portfolio.', error)
      );
    }
    //throw new Error('Method not implemented.');
  }
  loadForm(item: PortfolioItems) {
    this.itemForm.patchValue({
      displayName: item.displayName,
      title: item.title,
      description: item.description,
      creationDate: item.creationDate,
      updatedDate: new Date(),
      version: item.version,
      links: item.links,
      categoryId: item.categoryId,
      imageId: item.imageID
    })
    //throw new Error('Method not implemented.');
  }

  ngOnInit(): void {
    //this.route.paramMap.subscribe(param => {
    //  this.id = +param.get('id')!;
    //  this.data.getPortfolioItemById(this.id);
    this.initForm()
  }


  initForm() {
    this.itemForm = this.fb.group({
      id: [this.item.id],
      displayName: [''],
      title: [''],
      description: [''],
      creationDate: [new Date()],
      updatedDate: [new Date()],
      version: [''],
      links: [''],
      categoryId: [0],
      category: this.fb.group({
        categoryId: [0],
        categoryName: [''],
        parentCategoryId: [0],
        PostedBlogs: [],
        PostedItems: []
      }),
      imageId: [0],
      image: this.fb.group({
        id: [0],
        name: [''],
        description: [''],
        path: [''],
        fileSize: [0],
        portfolioId: [0]
      })
    });
    //throw new Error('Method not implemented.');
  }

  onSave() {
    const savedItem: PortfolioItems = {
        id: this.itemForm.value.id,
        displayName: this.itemForm.value.displayName,
        title: this.itemForm.value.title,
        description: this.itemForm.value.description,
        creationDate: this.itemForm.value.creationDate,
        updatedDate: this.itemForm.value.updatedDate,
        version: this.itemForm.value.version,
        links: this.itemForm.value.links,
        categoryId: this.itemForm.value.categoryId,
        category: this.itemForm.value.category,
        imageID: this.itemForm.value.imageId,
        image: this.itemForm.value.image
    }

    console.log(savedItem);
    if (this.isEditing) {
      this.data.updateItem(this.item.id, savedItem).subscribe(result => {
        this.router.navigate(['/']);
      });
    } else {
      this.data.createItem(savedItem).subscribe(result => {
        this.router.navigate(['/']);
      },
        error => {
          console.error("Error: Unable to create Items")
        })
    }
  }
}
