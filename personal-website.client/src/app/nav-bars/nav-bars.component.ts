import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../Services/auth.service';
import { finalize, from } from 'rxjs';
import { ThemeService } from '../theme.service';

interface BlogLink {
  id: number;
  component: Component | undefined;
  displayName: string;
}

@Component({
  selector: 'app-nav-bars',
  standalone: false,
  templateUrl: './nav-bars.component.html',
  styleUrl: './nav-bars.component.css'
})
export class NavBarsComponent {
  loggingOutBool = false;
  darkMode = false;

  constructor(private auth: AuthService, private router: Router, private theme: ThemeService) { }

  isAuthenticated(): boolean {
    return this.auth.isAuthenticated();
  }

  logout(): void {
    this.loggingOutBool = true;
    this.auth.logout().pipe(
      finalize(() => this.loggingOutBool = false)
    ).subscribe({
      next: () => {
        this.router.navigate(['/']);
      },
      error: (errorMessage : any) => {
        console.error('Logout error:', errorMessage)
        this.router.navigate(['/'])
      }
    }

    )
  }

  EnableDarkMode(): void {
    this.darkMode = true;
    this.theme.enableDarkMode();
  }

  DisableDarkMode(): void {
    this.darkMode = false;
    this.theme.disableDarkMode();
  }

}
