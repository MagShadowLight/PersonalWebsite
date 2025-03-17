import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PortfoliosListComponent } from './PortfolioItems/portfolios-list/portfolios-list.component';
import { PortfoliosDetailComponent } from './PortfolioItems/portfolios-detail/portfolios-detail.component';
import { HomeComponent } from './home/home.component';
import { NavBarsComponent } from './nav-bars/nav-bars.component';
import { FooterComponent } from './footer/footer.component';
import { PortfoliosEditComponent } from './PortfolioItems/portfolios-edit/portfolios-edit.component';
import { LoginComponent } from './login/login.component';
import { authGuardGuard } from './Guards/auth-guard.guard';
import { BlogDetailComponent } from './blogs/blog-detail/blog-detail.component';
import { BlogEditComponent } from './blogs/blog-edit/blog-edit.component';
import { BlogListComponent } from './blogs/blog-list/blog-list.component';
import { CategoryListComponent } from './category/category-list/category-list.component';
import { CategoryDetailComponent } from './category/category-detail/category-detail.component';
import { CategoryEditComponent } from './category/category-edit/category-edit.component';
import { FeedbackListComponent } from './Feedback/feedback-list/feedback-list.component';
import { FeedbackEditComponent } from './Feedback/feedback-edit/feedback-edit.component';
import { FeedbackDetailComponent } from './Feedback/feedback-detail/feedback-detail.component';
import { FeedbackFormComponent } from './Feedback/feedback-form/feedback-form.component';

const routes: Routes = [
  { path: "", component: HomeComponent},
  { path: "blog", component: BlogListComponent },
  { path: "blog/create", component: BlogEditComponent, canActivate: [authGuardGuard] },
  { path: "blog/:id", component: BlogDetailComponent },
  { path: "blog/edit/:id", component: BlogEditComponent, canActivate: [authGuardGuard]},
  { path: "portfolio", component: PortfoliosListComponent },
  { path: "portfolio/create", component: PortfoliosEditComponent, canActivate: [authGuardGuard] },
  { path: "portfolio/:id", component: PortfoliosDetailComponent },
  { path: "portfolio/edit/:id", component: PortfoliosEditComponent, canActivate: [authGuardGuard]},
  { path: "login", component: LoginComponent },
  { path: "category", component: CategoryListComponent, canActivate: [authGuardGuard]},
  { path: "category/create", component: CategoryEditComponent, canActivate: [authGuardGuard] },
  { path: "category/:id", component: CategoryDetailComponent, canActivate: [authGuardGuard] },
  { path: "category/edit/:id", component: CategoryEditComponent, canActivate: [authGuardGuard] },
  { path: "feedback", component: FeedbackListComponent, canActivate: [authGuardGuard] },
  { path: "feedback/create", component: FeedbackEditComponent, canActivate: [authGuardGuard] },
  { path: "feedback/:id", component: FeedbackDetailComponent, canActivate: [authGuardGuard] },
  { path: "feedback/edit/:id", component: FeedbackEditComponent, canActivate: [authGuardGuard] }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
