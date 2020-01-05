import { Injectable } from '@angular/core';
import { AppConfig } from '../globals/app.config';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class NewsService {

    constructor(private httpClient: HttpClient , private config: AppConfig) { }

    GetBreakingNews() {
        return this.httpClient.get(this.config.APIUrl + 'News/NewsHeadlines/1');
    }

    GetSliderNews() {
        return this.httpClient.get(this.config.APIUrl + 'News/NewsHeadlines/2');
    }
}
