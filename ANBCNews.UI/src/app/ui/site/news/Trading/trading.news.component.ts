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

    constructor(private newsService: NewsService, private route: ActivatedRoute) { }

    ngOnInit() { 
        this.GetTradingNews();
    }

    private GetTradingNews() {
        this.newsService.GetTradingNews().subscribe(res => {
            this.lstTradingNews = res != null ? res : [];
        });
    }
     
}
