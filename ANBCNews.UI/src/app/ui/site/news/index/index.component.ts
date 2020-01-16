import { Component, OnInit } from '@angular/core';
import { NewsService } from '../../../../@core/services/news.service';
import { ActivatedRoute } from '@angular/router';
import { AppConfig } from '../../../../@core/globals/app.config';

@Component({
    selector: 'site-news-index',
    templateUrl: './index.component.html',
})
export class IndexComponent implements OnInit {
    lstNews: any = [];
    reCall: boolean = true;
    pageNo: any = 1;
    private PostResponce: any = [];
    newsType: string
    newsTypeID: any
    pageTitle: any

    constructor(private newsService: NewsService, private route: ActivatedRoute, private appConfig: AppConfig) { }

    ngOnInit() {

        this.route.paramMap.subscribe(params => {
            this.newsType = params.get("newsType");
            if (this.newsType == "elections") {
                this.newsTypeID = 15;
                this.pageTitle = "चुनाव";
            } else if (this.newsType == "sports") {
                this.newsTypeID = 12;
                this.pageTitle = "खेल";
            } else if (this.newsType == "entertainment") {
                this.newsTypeID = 11;
                this.pageTitle = "मनोरंजन";
            } else if (this.newsType == "viral") {
                this.newsTypeID = 16;
                this.pageTitle = "वायरल केंद्र";
            } else if (this.newsType == "crime") {
                this.newsTypeID = 6;
                this.pageTitle = "क्राइम";
            }
        });
        this.pageLoad();
    }

    private pageLoad() {
        if (this.newsTypeID>0) { 
            this.GetNewsByType();
        } else {
            this.pageTitle = "न्यूज़";
            this.GetAllLatestNews();
        }
    }

    private GetNewsByType() {
        if (this.reCall) {
            this.newsService.GetNewsByType(this.newsTypeID, this.pageNo).subscribe(res => {
                this.PostResponce = res != null ? res : [];
                this.lstNews = this.lstNews.concat(this.PostResponce);
                this.reCall = this.PostResponce.length > 9;
            });
        }
    }

    private GetAllLatestNews() {
        if (this.reCall) {
            this.newsService.GetAllLatestNews(this.pageNo).subscribe(res => {
                this.PostResponce = res != null ? res : [];
                this.lstNews = this.lstNews.concat(this.PostResponce);
                this.reCall = this.PostResponce.length > 9;
            });
        }
    }

    onScrollDown() {
        this.pageNo = this.pageNo + 1;
        this.pageLoad();
    }
}
