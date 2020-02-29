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

    GetLetestNews() {
        return this.httpClient.get(this.config.APIUrl + 'News/NewsHeadlines/3');
    }
    GetTop20NewsForHome() {
        return this.httpClient.get(this.config.APIUrl + 'News/NewsHeadlines/4');
    }
    GetNewsDetail(newsId:any) {
        return this.httpClient.get(this.config.APIUrl + 'News/Detail/' + newsId);
    }
     
    GetNewsByType(newsTypeID: any, onlyVideos: boolean, pageNo: any) {
        return this.httpClient.get(this.config.APIUrl + 'News/NewsByType/' + newsTypeID + '/' + onlyVideos+'/' + pageNo);
    }
    SearchNews(PageNo: any, keyword: string) {
        return this.httpClient.get(this.config.APIUrl + 'news/search/'+PageNo+'/' + keyword);
    }
    GetTradingNews() {
        return this.httpClient.get(this.config.APIUrl + 'News/NewsHeadlines/5');
    }
}
