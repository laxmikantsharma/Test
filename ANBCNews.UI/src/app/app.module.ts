import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { AppRoutingModule } from './app-routing.module';
import { LayoutModule } from './ui/site/layout/layout.module';
import { LayoutComponent } from './ui/site/layout/layout.component';
import { AppConfig } from './@core/globals/app.config';
import { NewsService } from './@core/services/news.service';
import { HttpConfigInterceptor } from './@core/globals/http.config.interceptor';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';

@NgModule({
    declarations: [
    ],
    imports: [
        BrowserModule,
        RouterModule,
        LayoutModule,
        AppRoutingModule,
        HttpClientModule
    ],
    providers: [{ provide: HTTP_INTERCEPTORS, useClass: HttpConfigInterceptor, multi: true },
        AppConfig,
        NewsService],
    bootstrap: [LayoutComponent]
})
export class AppModule { }
