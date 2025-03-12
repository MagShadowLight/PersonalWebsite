import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BlogListComponent } from './Blogs/blog-list/blog-list.component';
import { BlogDetailComponent } from './Blogs/blog-detail/blog-detail.component';
import { PortfoliosListComponent } from './PortfolioItems/portfolios-list/portfolios-list.component';
import { PortfoliosDetailComponent } from './PortfolioItems/portfolios-detail/portfolios-detail.component';
import { HomeComponent } from './home/home.component';
import { NavBarsComponent } from './nav-bars/nav-bars.component';
import { FooterComponent } from './footer/footer.component';
import { BlogEditComponent } from './Blogs/blog-edit/blog-edit.component';
import { PortfoliosEditComponent } from './PortfolioItems/portfolios-edit/portfolios-edit.component';
import { LoginComponent } from './login/login.component';
import { authGuardGuard } from './Guards/auth-guard.guard';
//import { BlogCreateComponent } from './Blogs/blog-create/blog-create.component';
import { PortfolioCreateComponent } from './PortfolioItems/portfolio-create/portfolio-create.component';

const routes: Routes = [
  { path: "", component: HomeComponent},
  { path: "blog", component: BlogListComponent },
  { path: "blog/create", component: BlogEditComponent, canActivate: [authGuardGuard] },
  { path: "blog/:id", component: BlogDetailComponent },
  { path: "blog/edit/:id", component: BlogEditComponent, canActivate: [authGuardGuard]},
  { path: "portfolio", component: PortfoliosListComponent },
  { path: "portfolio/create", component: PortfolioCreateComponent, canActivate: [authGuardGuard] },
  { path: "portfolio/:id", component: PortfoliosDetailComponent },
  { path: "portfolio/edit/:id", component: PortfoliosEditComponent, canActivate: [authGuardGuard]},
  { path: "login", component: LoginComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
