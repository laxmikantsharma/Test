import { Component, OnInit } from '@angular/core';
import { NewsService } from '../../../../@core/services/news.service';
import { ActivatedRoute } from '@angular/router'; 
import { FormBuilder, Validators, ReactiveFormsModule, FormGroup } from '@angular/forms';

@Component({
    selector: 'site-news-search',
    templateUrl: './search.component.html',
})
export class SearchComponent implements OnInit {
    strKeyword: string;
    lstsearchNews: any = [];
    config: any;

    constructor(private newsService: NewsService, private route: ActivatedRoute) { }

    ngOnInit() {
        this.config = {
            itemsPerPage: 10,
            currentPage: 1,
            totalItems: 0
        };
        this.route.paramMap.subscribe(params => {
            this.strKeyword = params.get("key");
            this.SearchNews();
        });
    }

    private SearchNews() {
        if (this.strKeyword != "") {
            this.newsService.SearchNews(this.config.currentPage,this.strKeyword).subscribe(res => {
                this.lstsearchNews = res != null ? res : [];
                if (this.lstsearchNews.length > 0)
                    this.config.totalItems = this.lstsearchNews[0].totalRecored;
            });
        }
    }

    pageChanged(event) {
        this.config.currentPage = event;
        this.SearchNews();
    }


}
