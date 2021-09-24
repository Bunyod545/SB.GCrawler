import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BaseService } from '../../../common/helpers/base-service';
import { LoginInfo } from '../models/login-info';
import { RegisterInfo } from '../models/register-info';

@Injectable({
  providedIn: 'root'
})
export class AccountService extends BaseService {

  /**
   * 
   * @param httpClient 
   */
  constructor(httpClient: HttpClient) {
    super(httpClient);
   }
   
   /**
    * 
    * @param info 
    */
  public login(info: LoginInfo) {
     return this.post('/api/Account/Login', info);
   }

   /**
    * 
    * @param info 
    */
  public createAccount(info: RegisterInfo) {
     return this.post('/api/Account/CreateAccount', info);
   }
}
