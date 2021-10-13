import { Injectable } from "@angular/core";
import jwt_decode from "jwt-decode";

/**
 * 
 */
@Injectable({
    providedIn: 'root'
})
export class TokenHelper {

    /**
     * 
     */
    public static ACCESS_TOKEN = 'access_token';

    /**
     * 
     */
    public getToken() {
        return localStorage.getItem(TokenHelper.ACCESS_TOKEN);
    }

    /**
     * 
     * @param token 
     */
    public setToken(token: string) {
        localStorage.setItem(TokenHelper.ACCESS_TOKEN, token);
    }

    /**
     * 
     */
    public isAuthorized() {
        let tokenInfo = this.getTokenInfo();
        if(!tokenInfo)
            return false;

        let token = this.getToken();
        if(this.tokenExpired(token ?? ''))
            return false;
        else
            return true;
    }

    /**
     * 
     * @param token 
     */
    private tokenExpired(token: string) {
        const expiry = (JSON.parse(atob(token.split('.')[1]))).exp;
        return (Math.floor((new Date).getTime() / 1000)) >= expiry;
    }

    /**
     * 
     */
    public getTokenInfo() {
        let token = this.getToken();
        if(!token)
            return undefined;
        
        return jwt_decode(token);
    }
}