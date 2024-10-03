import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { DataService } from '../services/data.service';
import { AuthService } from '../auth/services/auth.service';
import { UserCredentials } from '../models/user-creds';

@Component({
  selector: 'app-login-form',
  templateUrl: './login-form.component.html',
  styleUrls: ['./login-form.component.scss']
})
export class LoginFormComponent implements OnInit {
  @Input() type = 'full';

  loginForm = this.fb.group({
    username: [''],
    password: ['']
  });

  registerForm = this.fb.group({
    username: [''],
    password: [''],
    passwordConfirm: [''],
    policy: [false],
  });

  constructor(private fb: FormBuilder, private data: DataService, private auth: AuthService) { }

  ngOnInit(): void {
  }

  login(): void {
    const user = new UserCredentials(this.loginForm.get('username')?.value, this.loginForm.get('password')?.value);
    console.log(user.username + ' ' + user.password);
    this.auth.login(user).subscribe(result => {
      console.log(result);
    });
  }

  register(): void {

  }
}
