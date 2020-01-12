import { Component, OnInit } from '@angular/core';
import { NewsService } from '../../../../@core/services/news.service';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
    selector: 'site-header',
    templateUrl: './header.component.html',
})
export class HeaderComponent implements OnInit {
    lstBreakingNews: any = [];
    strKeyword: string
    public serachForm: FormGroup;
    constructor(private newsService: NewsService, private formBuilder: FormBuilder, private router: Router) { }

    ngOnInit() {
        this.serachForm = this.formBuilder.group({keyword: ['', [Validators.required]]});
        this.GetBreakingNews();
    }

    private GetBreakingNews() {
        this.newsService.GetBreakingNews().subscribe(res => {
            this.lstBreakingNews = res != null ? res : [];
        });
    }

    Search() {
        if (this.serachForm.value.keyword != "") {
            this.strKeyword = this.serachForm.value.keyword.replace(/[&\/\\#,+()$~%.'":*?<>{}]/g, '');
            if (this.strKeyword != "")
                this.router.navigate(['/news/search/' + this.strKeyword]);
        }
    }
}

