import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NewsRoutingModule } from './news-routing.module';
import { IndexComponent } from './index/index.component';
import { NewsDetailComponent } from './detail/newsdetail.component';


@NgModule({
    declarations: [IndexComponent, NewsDetailComponent],
  imports: [
    CommonModule,
    NewsRoutingModule
  ]
})
export class NewsModule { }
