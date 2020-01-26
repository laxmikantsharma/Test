import { Injectable } from "@angular/core";
import { environment } from '../../../environments/environment';
@Injectable()
export class AppConfig {
    public APIUrl: string = environment.APIUrl;
    public DomainName: string = environment.DomainName;
    public IsVisibleComment: boolean = false;
     
 
    constructor() {
     
    }
    public isNormalInteger(str) {
        return /^\+?(0|[1-9]\d*)$/.test(str);
    }
}
 
