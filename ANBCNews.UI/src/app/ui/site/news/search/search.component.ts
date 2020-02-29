import { Component, OnInit } from '@angular/core';
import { NewsService } from '../../../../@core/services/news.service';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, Validators, ReactiveFormsModule, FormGroup } from '@angular/forms';
import { AppConfig } from '../../../../@core/globals/app.config';

@Component({
    selector: 'site-news-search',
    templateUrl: './search.component.html',
})
export class SearchComponent implements OnInit {
    strKeyword: string;
    lstsearchNews: any = [];
    config: any;
    apiResponse: any = {};

    constructor(private newsService: NewsService, private route: ActivatedRoute, private router: Router, private appConfig: AppConfig) { }

    ngOnInit() {
        this.config = {
            itemsPerPage: 10,
            currentPage: 1,
            totalItems: 0
        };
        this.route.paramMap.subscribe(params => {
            this.strKeyword = params.get("key");
            var str = params.get("key");
            if (str != "") {
                var strarr = str.split(/[\s-]+/);
                if (strarr.length > 1) {
                    if (strarr[strarr.length - 2] == "page" && this.appConfig.isNormalInteger(strarr[strarr.length - 1])) {
                        this.config.currentPage = strarr[strarr.length - 1];
                        if (strarr.length > 2)
                            this.strKeyword = strarr[strarr.length - 3];
                    }
                }

                if (this.strKeyword == "")  
                    this.strKeyword = str;
            }
            this.SearchNews();
        });
    }

    private SearchNews() {
        if (this.strKeyword != "") {
            this.newsService.SearchNews(this.config.currentPage, this.strKeyword).subscribe(res => {
                this.apiResponse = res;
                if ( this.apiResponse != null && this.apiResponse.statusCode == "10200")
                    this.lstsearchNews = this.apiResponse.collection; 
                if (this.lstsearchNews.length > 0)
                    this.config.totalItems = this.lstsearchNews[0].totalRecored;
            });
        }
    }

    pageChanged(event) {
        this.config.currentPage = event;
        this.router.navigate(['/news/search/' + this.strKeyword + '-page-' + this.config.currentPage]);
        this.SearchNews();
    }


}
