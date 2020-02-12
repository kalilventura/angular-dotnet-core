import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../auth.service';
import { MatSnackBar } from '@angular/material';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {
  registerForm: FormGroup = this.fb.group({
    email: ['', [Validators.required, Validators.email]],
    username: ['', [Validators.required, Validators.minLength(4)]],
    password: ['', [Validators.required, Validators.minLength(6)]],
    fullname: ['', [Validators.required, Validators.minLength(3)]]
  });

  constructor(
    private fb: FormBuilder,
    private authService: AuthService,
    private router: Router,
    private snackBar: MatSnackBar
  ) { }
  loading = false;

  ngOnInit() {
  }

  onSubmit() {
    const registerUser = this.registerForm.value;
    this.loading = true;
    this.authService.register(registerUser)
      .subscribe(
        (message) => {
          console.log(message);
          this.snackBar.open(`${message}`, 'OK', { duration: 5000 });
          this.loading = false;
        },
        (err) => {
          this.snackBar.open(`${err.error.message}`, 'OK', { duration: 5000 });
          this.loading = false;
        }
      );
  }

}
