import { Component, OnInit } from '@angular/core';
import { NewsService } from '../../../../@core/services/news.service';

@Component({
    selector: 'site-header',
    templateUrl: './header.component.html',
})
export class HeaderComponent implements OnInit {
    lstBreakingNews: any = [];
    constructor(private newsService: NewsService) { }

    ngOnInit() {
        this.GetBreakingNews()
    }

    private GetBreakingNews() {
        this.newsService.GetBreakingNews().subscribe(res => {
            this.lstBreakingNews = res != null ? res : [];
        });
    }
}
