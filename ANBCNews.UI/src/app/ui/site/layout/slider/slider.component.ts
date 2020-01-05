import { Component } from '@angular/core';
import { NewsService } from '../../../../@core/services/news.service';

@Component({
    selector: 'site-slider',
    templateUrl: './slider.component.html',
})
export class SliderComponent {
    lstSliderNews: any = [];
    constructor(private newsService: NewsService) { }

    ngOnInit() {
        this.GetBreakingNews()
    }

    private GetBreakingNews() {
        this.newsService.GetSliderNews().subscribe(res => {
            this.lstSliderNews = res != null ? res : [];
        });
    }
}
