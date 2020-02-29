import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { AppRoutingModule } from './app-routing.module';
import { LayoutModule } from './ui/layout/layout.module';
import { LayoutComponent } from './ui/layout/layout.component';
import { AppConfig } from './@core/globals/app.config';
import { NewsService } from './@core/services/news.service';
import { HttpConfigInterceptor } from './@core/globals/http.config.interceptor';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { CommentService } from './@core/services/comment.service';
import { ContactService } from './@core/services/contact.service';
import { Safe } from './@core/pipes/custom.Pipes';
import { AppComponent } from './app.component';

@NgModule({
    declarations: [
        AppComponent

    ],
    imports: [
        BrowserModule,
        RouterModule,
        LayoutModule,
        AppRoutingModule,
        HttpClientModule,
    ],
    providers: [{ provide: HTTP_INTERCEPTORS, useClass: HttpConfigInterceptor, multi: true },
        AppConfig,
        NewsService,
        CommentService,
        ContactService],
    bootstrap: [AppComponent]
})
export class AppModule { }
