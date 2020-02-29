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
    onlyVideos: boolean=false
    newsTypeID: any =0
    pageTitle: any
    apiResponse: any = {};

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
            } else if (this.newsType == "videos") {
                this.onlyVideos = true;
                this.pageTitle = "वीडियो";
            } else {
                this.pageTitle = "न्यूज़";
            }
        });
        this.GetNewsByType();
    }
     

    private GetNewsByType() {
        if (this.reCall) {
            this.newsService.GetNewsByType(this.newsTypeID, this.onlyVideos, this.pageNo).subscribe(res => {
                this.apiResponse = res;
                if (this.apiResponse != null && this.apiResponse.statusCode == "200") {
                this.PostResponce = this.apiResponse.collection;
                    this.lstNews = this.lstNews.concat(this.PostResponce);
                    this.reCall = this.PostResponce.length > 9;
                }
            });
        }
    }

    

    onScrollDown() {
        this.pageNo = this.pageNo + 1;
        this.GetNewsByType();
    }
}
