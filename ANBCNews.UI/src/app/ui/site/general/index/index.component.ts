import { Component, OnInit } from '@angular/core';
import { NewsService } from '../../../../@core/services/news.service';

@Component({
    selector: 'site-index',
    templateUrl: './index.component.html',
})
export class IndexComponent implements OnInit  {
    lstLetestNews: any = [];
    lstTop20News: any = [];
    apiResponse: any = {};
    constructor(private newsService: NewsService) { }

    ngOnInit() {
        this.GetNews()
    }

    private GetNews() {
        this.newsService.GetLetestNews().subscribe(res => {
            this.apiResponse = res;
            if (this.apiResponse != null && this.apiResponse.statusCode == "200")
                this.lstLetestNews = this.apiResponse.collection;
        });
        this.newsService.GetTop20NewsForHome().subscribe(res => {
            this.apiResponse = res;
            if (this.apiResponse != null && this.apiResponse.statusCode == "200")
                this.lstTop20News = this.apiResponse.collection;  
        });
    }
}
