import { Component, OnInit } from '@angular/core';
import { NewsService } from '../../../../@core/services/news.service';

@Component({
    selector: 'site-news-index',
    templateUrl: './index.component.html',
})
export class IndexComponent implements OnInit  { 
    lstTop20News: any = [];
    constructor(private newsService: NewsService) { }

    ngOnInit() {
        this.GetNews();
    }

    private GetNews() { 
        this.newsService.GetTop20NewsForHome().subscribe(res => {
            this.lstTop20News = res != null ? res : [];
        });
    }
}
