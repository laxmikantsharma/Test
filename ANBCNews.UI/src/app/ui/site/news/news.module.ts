import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NewsRoutingModule } from './news-routing.module';
import { NewsDetailComponent } from './detail/newsdetail.component';
import { IndexComponent } from './index/index.component';
import { Safe } from '../../../@core/pipes/custom.Pipes';


@NgModule({
    declarations: [NewsDetailComponent, IndexComponent, Safe],
  imports: [
    CommonModule,
    NewsRoutingModule
  ]
})
export class NewsModule { }
