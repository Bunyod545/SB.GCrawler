import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BaseService } from '../../../common/services/base-service';
import { ApiResponse } from '../../models/responses/api-response';
import { TokenResult } from '../../models/token-result';
import { InitUserInfo } from '../../models/users/init-user-info';
import { LoginInfo } from './models/login-info';

/**
 * 
 */
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
  public initUser(info: InitUserInfo): Observable<ApiResponse<TokenResult>> {
    return this.post('/api/Users/InitUser', info);
  }
}
