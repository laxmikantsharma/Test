import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NewsRoutingModule } from './news-routing.module';
import { NewsDetailComponent } from './detail/newsdetail.component';
import { IndexComponent } from './index/index.component';


@NgModule({
    declarations: [NewsDetailComponent,IndexComponent],
  imports: [
    CommonModule,
    NewsRoutingModule
  ]
})
export class NewsModule { }
