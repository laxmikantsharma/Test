import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NewsRoutingModule } from './news-routing.module';
import { NewsDetailComponent } from './detail/newsdetail.component';
import { IndexComponent } from './index/index.component';
import { Safe } from '../../../@core/pipes/custom.Pipes';
import { SearchComponent } from './search/search.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgxPaginationModule } from 'ngx-pagination';
import { InfiniteScrollModule } from 'ngx-infinite-scroll';
import { TradingNewsComponent } from './Trading/trading.news.component'; 
import { VgCoreModule } from 'videogular2/compiled/core';
import { VgControlsModule } from 'videogular2/compiled/controls';
import { VgOverlayPlayModule } from 'videogular2/compiled/overlay-play';
import { VgBufferingModule } from 'videogular2/compiled/buffering';
import { NgxYoutubePlayerModule } from 'ngx-youtube-player';

@NgModule({
    declarations: [NewsDetailComponent, IndexComponent, Safe, SearchComponent, TradingNewsComponent],
  imports: [
    CommonModule,
      NewsRoutingModule,
      FormsModule,
      ReactiveFormsModule,
      NgxPaginationModule,
      InfiniteScrollModule,
      VgCoreModule,
      VgControlsModule,
      VgOverlayPlayModule,
      VgBufferingModule,
      NgxYoutubePlayerModule.forRoot()
  ]
})
export class NewsModule { }
