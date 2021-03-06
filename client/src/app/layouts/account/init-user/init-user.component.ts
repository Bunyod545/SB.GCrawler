import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { TokenHelper } from 'src/app/common/helpers/token-helper';
import { ApiResponse } from 'src/app/common/models/responses/api-response';
import { TokenResult } from 'src/app/common/models/token-result';
import { InitUserInfo } from 'src/app/common/models/users/init-user-info';
import { AccountService } from 'src/app/common/services/account/account.service';

@Component({
  selector: 'app-init-user',
  templateUrl: './init-user.component.html',
  styleUrls: ['./init-user.component.css']
})
export class InitUserComponent implements OnInit {


  /**
   * 
   */
   initUserInfo: InitUserInfo = new InitUserInfo();

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
     * @param tokenHelper 
     */
   constructor(private accountService: AccountService, 
    private tokenHelper: TokenHelper,
    private router: Router) { }
 
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
     setTimeout(() => this.initUser(), 1000);
   }
 
   /**
    * 
    */
   initUser() {
     this.accountService.initUser(this.initUserInfo).subscribe(
       res => this.onInitUserSuccess(res),
       err => this.onInitUserError(err)
     );
   }
 
   /**
    * 
    * @param res 
    */
   private onInitUserSuccess(res: ApiResponse<TokenResult>) {
     this.isLoading = false;
     if(!res.isSuccess) {
       this.onInitUserError(res.error.errorMessage);
       return;
     }

     this.tokenHelper.setToken(res.result.token);
     this.router.navigateByUrl('home');
   }
 
   /**
    * 
    * @param err 
    */
   private onInitUserError(err: any) {
     this.isLoading = false;
     this.isError = true;
     this.errorMessage = err;
   }
 
   /**
    * 
    */
   hideError() {
     this.isError = false;
   }

}
