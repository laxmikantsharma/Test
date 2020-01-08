import { Component } from '@angular/core';
import { NewsService } from '../../../../@core/services/news.service';
import { Router, NavigationStart, RoutesRecognized, ActivatedRoute } from '@angular/router';
import { filter } from 'rxjs/operators';

@Component({
    selector: 'site-newsdetail',
    templateUrl: './newsdetail.component.html',
})
export class NewsDetailComponent {
    newsDetail: any = {};
    newsId: any;
    constructor(private newsService: NewsService, private route: ActivatedRoute, private router: Router) { }

    ngOnInit() {
        this.route.paramMap.subscribe(params => {
            this.newsId = params.get("newsId");
            if (this.newsId!="") {
                this.GetNewsDetail()
            }
        });
        
    }

    private GetNewsDetail() {
        this.newsService.GetNewsDetail(this.newsId).subscribe(res => {
            this.newsDetail = res != null ? res : {};
        });
    }
}
