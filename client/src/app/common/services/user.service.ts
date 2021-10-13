import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BaseService } from './base-service';
import { InitUserInfo } from '../models/users/init-user-info';
import { Observable } from 'rxjs';
import { ApiResponse } from '../models/responses/api-response';
import { TokenResult } from '../models/token-result';

@Injectable({
  providedIn: 'root'
})
export class UserService extends BaseService {

  /**
   * 
   * @param httpClient 
   */
  constructor(httpClient: HttpClient) {
    super(httpClient);
   }

   /**
    * 
    */
   public anyUserExists() {
     return this.get('/api/Users/AnyUserExists');
   }

   /**
    * 
    * @param info 
    */
   public initUser(info: InitUserInfo): Observable<ApiResponse<TokenResult>> {
     return this.post('/api/Users/InitUser', info);
   }
}
