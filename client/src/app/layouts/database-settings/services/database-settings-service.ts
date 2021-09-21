import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { BaseService } from "src/app/helpers/base-service";
import { DatabaseConfigInfo } from "../models/database-config-info";

/**
 * 
 */
@Injectable({
    providedIn: 'root'
})
export class DatabaseSettingsService extends BaseService {

    /**
     *
     */
    constructor(httpClient: HttpClient) {
        super(httpClient);
    }

    /**
     * 
     * @param config 
     */
    validateAndSave(config: DatabaseConfigInfo): Observable<boolean> {
        return this.post("/api/DatabaseConfig/ValidateAndSave", config);
    }
}