import { Injectable } from '@angular/core';
import { AppConfig } from '../globals/app.config';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class CommentService {

    constructor(private httpClient: HttpClient , private config: AppConfig) { }
     
    SaveComment(CommentDetails: any) {
        const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
        return this.httpClient.post(this.config.APIUrl + 'Comment', CommentDetails, httpOptions);
    }
}
