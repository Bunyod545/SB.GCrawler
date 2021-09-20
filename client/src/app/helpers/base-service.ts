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
    get(url: string) {
        return this.httpClient.get(this.getRootUrl() + url);
    }

    /**
     * 
     * @param url 
     * @param body 
     */
    post(url: string, body: any): Observable<any> {
        return this.httpClient.post(this.getRootUrl() + url, body);
    }

    /**
     * 
     */
    getRootUrl() {
        return environment.rootUrl;
    }
}