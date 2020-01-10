import { Injectable } from "@angular/core";
import { environment } from '../../../environments/environment';
@Injectable()
export class AppConfig {
    public APIUrl: string = environment.APIUrl;
    public DomainName: string = environment.DomainName;
    public IsVisibleComment: boolean = false;
    constructor() {
    }
}
