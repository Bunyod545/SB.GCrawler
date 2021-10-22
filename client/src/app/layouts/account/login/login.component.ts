import { Component, OnInit } from '@angular/core';
import { AccountService } from 'src/app/common/services/account/account.service';
import { LoginInfo } from 'src/app/common/services/account/models/login-info';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  /**
   * 
   */
  loginInfo: LoginInfo = new LoginInfo();

  /**
   * 
   */
  isError?: boolean;

  /**
   * 
   */
  isLoading?: boolean;

  /**
   * 
   */
  passwordVisible?: boolean;

  /**
   * 
   */
  constructor(private accountService: AccountService) { }

  /**
   * 
   */
  ngOnInit(): void {
  }

  /**
   * 
   */
  onNextClick() {
    if (!this.loginInfo.login || !this.loginInfo.password)
      return;
      
    this.isLoading = true;
    setTimeout(() => this.login(), 1000);
  }

  /**
   * 
   * @param info 
   */
  login() {
    this.isLoading = false;
  }

  /**
   * 
   */
  hideError() {
    this.isError = false;
  }
}
