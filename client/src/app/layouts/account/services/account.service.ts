import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BaseService } from '../../../common/services/base-service';
import { LoginInfo } from '../models/login-info';

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
    */
   public getToken() {
     return localStorage.getItem('access_token');
   }
}
