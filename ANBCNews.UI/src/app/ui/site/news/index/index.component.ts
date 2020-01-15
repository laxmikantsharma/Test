import { Component, OnInit } from '@angular/core';
import { NewsService } from '../../../../@core/services/news.service';

@Component({
    selector: 'site-news-index',
    templateUrl: './index.component.html',
})
export class IndexComponent implements OnInit  { 
    lstNews: any = [];
    reCall: boolean=true; 
    pageNo: any = 1;
    private PostResponce: any = [];

    constructor(private newsService: NewsService) { }

    ngOnInit() {
        this.GetAllLatestNews();
    }
    
    private GetAllLatestNews() {
        if (this.reCall) {
            this.newsService.GetAllLatestNews(this.pageNo).subscribe(res => {
                this.PostResponce = res != null ? res : [];
                this.lstNews=    this.lstNews.concat(this.PostResponce);
                this.reCall = this.PostResponce.length > 9;
            });
        }
    }
    onScrollDown( ) { 
        this.pageNo = this.pageNo + 1;
        this.GetAllLatestNews();
    }
}
