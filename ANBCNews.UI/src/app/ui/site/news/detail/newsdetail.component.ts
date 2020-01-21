import { Component } from '@angular/core';
import { NewsService } from '../../../../@core/services/news.service';
import { Router, NavigationStart, RoutesRecognized, ActivatedRoute } from '@angular/router';
import { filter } from 'rxjs/operators';
import { AppConfig } from '../../../../@core/globals/app.config';

@Component({
    selector: 'site-newsdetail',
    templateUrl: './newsdetail.component.html',
})
export class NewsDetailComponent {
    newsDetail: any = {};
    newsId: any;
    constructor(private newsService: NewsService, private route: ActivatedRoute, private router: Router, private config: AppConfig) { }
    ngOnInit() {
        this.route.paramMap.subscribe(params => {
            var str = params.get("newsId");
            if (str != "") {
                var strarr = str.split(/[\s-]+/);
                if (strarr.length > 0)
                    this.newsId = strarr[strarr.length - 1];
            }
            if (this.newsId != "") {
                this.GetNewsDetail()
            }
        });
        // this.config.IsVisibleComment = true;
    }
    ngAfterViewInit() {
        let node = document.createElement('script');
        node.innerText = " var VUUKLE_CONFIG = { apiKey: '4c33d842-fe9c-46f9-8c88-0b15b5f2f3f6', articleId: '" + this.newsId + "',host:'asianewsbroadcastingcompany.in'  }; (function () { var d = document,  s = d.createElement('script');s.id ='VUUKLE_CONFIG1';  s.src = 'https://cdn.vuukle.com/platform.js'; (d.head || d.body).appendChild(s); })(); VUUKLE_PLATFORM=undefined;";
        node.type = 'text/javascript';
        node.async = false;
        node.id = "VUUKLE_CONFIG";
        node.charset = 'utf-8';

        document.getElementsByTagName('head')[0].appendChild(node);

    }
    private GetNewsDetail() {
        this.newsService.GetNewsDetail(this.newsId).subscribe(res => {
            this.newsDetail = res != null ? res : {};
        });
    }
    ngOnDestroy() {
        //this.config.IsVisibleComment = false;
        document.getElementsByTagName('head')[0].removeChild(document.getElementById('VUUKLE_CONFIG'));
        document.getElementsByTagName('head')[0].removeChild(document.getElementById('VUUKLE_CONFIG1'));
    }
}
