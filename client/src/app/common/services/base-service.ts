import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { environment } from "src/environments/environment";

/**
 * 
 */
export class BaseService {

    /**
     *
     */
    constructor(private httpClient: HttpClient) {

    }

    /**
     * 
     * @param url 
     */
    public get<T>(url: string): Observable<T> {
        return this.httpClient.get<T>(this.getRootUrl() + url);
    }

    /**
     * 
     * @param url 
     * @param body 
     */
    public post<T>(url: string, body: object): Observable<T> {
        return this.httpClient.post<T>(this.getRootUrl() + url, body);
    }

    /**
     * 
     */
    public getRootUrl() {
        return environment.rootUrl;
    }
}