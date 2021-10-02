import { ApiResponseError } from "./api-response-error";

/**
 * 
 */
export class ApiResponse<T> {
    
    /**
     * 
     */
    public result!: T; 

    /**
     * 
     */
    public error!: ApiResponseError;

    /**
     * 
     */
    public isSuccess!: boolean;

    /**
     * 
     * @param result 
     */
    constructor(result: T) {
        this.result = result;
        this.isSuccess = true;
    }
}