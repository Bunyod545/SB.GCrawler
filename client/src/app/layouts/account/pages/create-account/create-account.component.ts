import { Component, OnInit } from '@angular/core';
import { AccountTokenResult } from '../../models/account-token-result';
import { RegisterInfo } from '../../models/register-info';
import { AccountService } from '../../services/account.service';

@Component({
  selector: 'app-create-account',
  templateUrl: './create-account.component.html',
  styleUrls: ['./create-account.component.css']
})
export class CreateAccountComponent implements OnInit {

  /**
   * 
   */
  registerInfo: RegisterInfo = new RegisterInfo();

  /**
   * 
   */
   isError?: boolean;

   /**
    * 
    */
   isLoading?:boolean;
 
  /**
   * 
   */
   passwordVisible?: boolean;

   /**
    * 
    */
   errorMessage?: string;

   /**
    * 
    * @param accountService 
    */
  constructor(private accountService: AccountService) { }

  /**
   * 
   */
  ngOnInit(): void {
  }

  onNextClick() {
    this.isLoading = true;
    setTimeout(() => this.createAccount(), 1000);
  }

  createAccount() {
    this.accountService.createAccount(this.registerInfo).subscribe(
      res => this.onCreateAccountSuccess(res),
      err => this.onCreateAccountError(err)
    );
  }

  /**
   * 
   * @param res 
   */
  private onCreateAccountSuccess(res: any) {
    this.isLoading = false;
    this.isError = !res.isSuccess;

    console.log('Success');
    console.log(res);
  }

  /**
   * 
   * @param err 
   */
  private onCreateAccountError(err: any) {
    this.isLoading = false;
    this.isError = true;
    this.errorMessage = err.error.error.errorMessage;


    console.log('Error');
    console.log(err.error.error.errorMessage);
  }

  /**
   * 
   */
  hideError() {
    this.isError = false;
  }
}
