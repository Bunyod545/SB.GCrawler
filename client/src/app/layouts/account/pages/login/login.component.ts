import { Component, OnInit } from '@angular/core';
import { LoginInfo } from '../../models/login-info';

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
  constructor() { }

  /**
   * 
   */
  ngOnInit(): void {
  }

  /**
   * 
   */
  onNextClick() {
    this.isLoading = true;
    setTimeout(()=>this.login(this.loginInfo), 1000);
  }

  login(info: LoginInfo) {
    
  }

  hideError() {
    this.isError = false;
  }
}
