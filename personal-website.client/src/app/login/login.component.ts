import { AfterViewInit, Component, ElementRef, OnDestroy, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Subscription } from 'rxjs';
import { AuthService } from '../Services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  standalone: false,
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent implements OnDestroy, AfterViewInit {
  @ViewChild('email') email!: ElementRef;

  formLogin!: FormGroup;

  errorMessage = '';

  showPassword = false;

  private loginSubscribe: Subscription | null = null;

  constructor(
    private formBuilder: FormBuilder,
    private auth: AuthService,
    private router: Router
  ) {
    this.formLogin = this.formBuilder.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', Validators.required],
      staySignedIn: [false]
    });
  }

  ngOnDestroy(): void {
    if (this.loginSubscribe) {
      this.loginSubscribe.unsubscribe();
    }
  }
  ngAfterViewInit(): void {
    setTimeout(() => {
      this.email.nativeElement.focus()
    })
  }

  Error(fieldLabel: string): boolean {
    const fieldValue = this.formLogin.get(fieldLabel);

    return fieldValue ? fieldValue.invalid && fieldValue.touched : false;
  }

  OnSubmitButton(): void {

    if (this.formLogin.valid) {

      this.errorMessage = '';

      this.loginSubscribe = this.auth.login(this.formLogin.value).pipe(

      ).subscribe({
        next: () => {
          this.router.navigate(['/'])
        },
        error: (error : any) => {
          if (error.status === 400 || error.status === 401) {
            this.errorMessage = 'Error: Email or password are Invalid. Type in the correct email and password.'
          } else if (error.status === 0) {
            this.errorMessage = 'Error: Unable to connect to server. Check your connection and try again'
          } else {
            this.errorMessage = 'Error: An unexpected error occurred. Try again later.'
          }
          console.log('Error: ', error, '\n Error Message: ', this.errorMessage);
        }
      });
    } else {
      Object.keys(this.formLogin.controls).forEach(keys => {
        const controlLogin = this.formLogin.get(keys)
        controlLogin?.markAsTouched();
      })
    }

  }

}
