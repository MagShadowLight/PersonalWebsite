import { provideHttpClient, withInterceptorsFromDi } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavBarsComponent } from './nav-bars/nav-bars.component';
import { PortfoliosListComponent } from './PortfolioItems/portfolios-list/portfolios-list.component';
import { PortfoliosDetailComponent } from './PortfolioItems/portfolios-detail/portfolios-detail.component';
import { HomeComponent } from './home/home.component';
import { DataService } from './data.service';
import { PortfoliosEditComponent } from './PortfolioItems/portfolios-edit/portfolios-edit.component';
import { LoginComponent } from './login/login.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { FooterComponent } from './footer/footer.component';
import { CategoryDetailComponent } from './category/category-detail/category-detail.component';
import { CategoryEditComponent } from './category/category-edit/category-edit.component';
import { CategoryListComponent } from './category/category-list/category-list.component';
import { FeedbackDetailComponent } from './Feedback/feedback-detail/feedback-detail.component';
import { FeedbackEditComponent } from './Feedback/feedback-edit/feedback-edit.component';
import { FeedbackFormComponent } from './Feedback/feedback-form/feedback-form.component';
import { FeedbackListComponent } from './Feedback/feedback-list/feedback-list.component';
import { BlogDetailComponent } from './Blogs/blog-detail/blog-detail.component';
import { BlogEditComponent } from './Blogs/blog-edit/blog-edit.component';
import { BlogListComponent } from './Blogs/blog-list/blog-list.component';
import { AboutComponent } from './about/about.component';
import { ContactComponent } from './contact/contact.component';

@NgModule({
  declarations: [
    AppComponent,
    NavBarsComponent,
    BlogListComponent,
    BlogDetailComponent,
    PortfoliosListComponent,
    PortfoliosDetailComponent,
    HomeComponent,
    BlogEditComponent,
    PortfoliosEditComponent,
    LoginComponent,
    FooterComponent,
    CategoryListComponent,
    CategoryDetailComponent,
    CategoryEditComponent,
    FeedbackFormComponent,
    FeedbackListComponent,
    FeedbackDetailComponent,
    FeedbackEditComponent,
    AboutComponent,
    ContactComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [
    DataService,
    provideHttpClient(withInterceptorsFromDi())
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
