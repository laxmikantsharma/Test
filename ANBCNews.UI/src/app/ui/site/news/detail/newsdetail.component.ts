import { Component } from '@angular/core';
import { NewsService } from '../../../../@core/services/news.service';
import { Router, NavigationStart } from '@angular/router';
import { filter } from 'rxjs/operators';

@Component({
    selector: 'site-newsdetail',
    templateUrl: './newsdetail.component.html',
})
export class NewsDetailComponent {
    objNewsDetail: any = {};
    constructor(private newsService: NewsService, private router: Router) { }

    ngOnInit() {
        this.GetNewsDetail()
    }

    private GetNewsDetail() {
        this.router.events.pipe(filter(e => e instanceof NavigationStart)).subscribe(e => {
            const navigation = this.router.getCurrentNavigation();
            console.log(navigation)
        });
        //this.newsService.GetNewsDetail().subscribe(res => {
        //    this.objNewsDetail = res != null ? res : {};
        //});
    }
}
