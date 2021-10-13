import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { TokenHelper } from "./token-helper";

/**
 * 
 */
@Injectable()
export class JwtInterceptor implements HttpInterceptor {

    /**
     * 
     * @param tokenHelper 
     */
    constructor(public tokenHelper: TokenHelper) { }

    /**
     * 
     * @param req 
     * @param next 
     */
    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        const accessToken = this.tokenHelper.getToken();
        if (accessToken) {
            req = req.clone({
                setHeaders: {
                    Authorization: `Bearer ${accessToken}`
                }
            });
        }

        return next.handle(req);
    }

}