import { provideHttpClient, withInterceptorsFromDi } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavBarsComponent } from './nav-bars/nav-bars.component';
import { BlogListComponent } from './blogs/blog-list/blog-list.component';
import { BlogDetailComponent } from './blogs/blog-detail/blog-detail.component';
import { PortfoliosListComponent } from './PortfolioItems/portfolios-list/portfolios-list.component';
import { PortfoliosDetailComponent } from './PortfolioItems/portfolios-detail/portfolios-detail.component';
import { HomeComponent } from './home/home.component';
import { BlogEditComponent } from './blogs/blog-edit/blog-edit.component';
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
import { BlogDataService } from './Services/dataservices/blog-data.service';
import { ItemDataService } from './Services/dataservices/item-data.service';
import { CategoryDataService } from './Services/dataservices/category-data.service';
import { FeedbackDataService } from './Services/dataservices/feedback-data.service';
import { ItemImageDataService } from './Services/dataservices/item-image-data.service';

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
    FeedbackEditComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [
    BlogDataService,
    ItemDataService,
    CategoryDataService,
    FeedbackDataService,
    ItemImageDataService,
    provideHttpClient(withInterceptorsFromDi())
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
