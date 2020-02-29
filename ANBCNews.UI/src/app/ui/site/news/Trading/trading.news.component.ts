import { Component, OnInit } from '@angular/core';
import { NewsService } from '../../../../@core/services/news.service';
import { ActivatedRoute } from '@angular/router'; 
import { FormBuilder, Validators, ReactiveFormsModule, FormGroup } from '@angular/forms';

@Component({
    selector: 'site-trading-news',
    templateUrl: './trading.news.component.html',
})
export class TradingNewsComponent implements OnInit {
    lstTradingNews: any = [];
    apiResponse: any = {};

    constructor(private newsService: NewsService, private route: ActivatedRoute) { }

    ngOnInit() { 
        this.GetTradingNews();
    }

    private GetTradingNews() {
        this.newsService.GetTradingNews().subscribe(res => {
            this.apiResponse = res;
            if (this.apiResponse != null && this.apiResponse.statusCode == "10200")
                this.lstTradingNews = this.apiResponse.collection;   
        });
    }
     
}
