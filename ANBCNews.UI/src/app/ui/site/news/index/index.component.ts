import { Component, OnInit } from '@angular/core';
import { NewsService } from '../../../../@core/services/news.service';

@Component({
    selector: 'site-index',
    templateUrl: './index.component.html',
})
export class IndexComponent implements OnInit  {
    lstLetestNews: any = [];
    lstTop20News: any = [];
    constructor(private newsService: NewsService) { }

    ngOnInit() {
        this.GetNews()
    }

    private GetNews() {
        this.newsService.GetLetestNews().subscribe(res => {
            this.lstLetestNews = res != null ? res : [];
        });
        this.newsService.GetTop20NewsForHome().subscribe(res => {
            this.lstTop20News = res != null ? res : [];
        });
    }
}
