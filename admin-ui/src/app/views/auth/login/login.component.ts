import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AdminApiAuthApiClient, AuthenticateResult, LoginRequest } from 'src/app/api/admin-api.service.generated';
import { AlertService } from 'src/app/shared/services/alert.service';
import { UrlConstants } from 'src/app/shared/constants/url.constants';

import { TokenStorageService } from 'src/app/shared/services/token-storage.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {
  loginForm: FormGroup;

  constructor(private fb: FormBuilder, private authApiClient: AdminApiAuthApiClient,private alertService: AlertService, private router: Router,  private tokenSerivce: TokenStorageService ) 
  {
    this.loginForm = this.fb.group({
      userName: new FormControl('',Validators.required),
      password: new FormControl('',Validators.required),
    });
  }

  public login(): void{
    let request: LoginRequest = new LoginRequest({
      userName: this.loginForm.controls['userName'].value,
      password: this.loginForm.controls['password'].value
    });

    this.authApiClient.login(request).subscribe({
      next:(res:AuthenticateResult) => {
        this.tokenSerivce.saveToken(res.token);
        this.tokenSerivce.saveRefreshToken(res.refreshToken);
        this.tokenSerivce.saveUser(res);

        this.router.navigate([UrlConstants.HOME]);
      },
      error:(error: any) => {
        console.log(error); 
        this.alertService.showError('Đăng nhập không đúng.');
      }
    });
  }
}
