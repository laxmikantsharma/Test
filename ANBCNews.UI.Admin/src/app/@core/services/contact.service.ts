import { Injectable } from '@angular/core';
import { AppConfig } from '../globals/app.config';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ContactService {

    constructor(private httpClient: HttpClient , private config: AppConfig) { }
     
  SaveComment(ContactDetails: any) {
        const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
      return this.httpClient.post(this.config.APIUrl + 'Contact', ContactDetails, httpOptions);
    }
}
