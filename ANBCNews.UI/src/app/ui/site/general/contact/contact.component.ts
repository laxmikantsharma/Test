import { Component, OnInit } from '@angular/core'; 
import { AppConfig } from '../../../../@core/globals/app.config';

@Component({
    selector: 'site-contact',
    templateUrl: './contact.component.html',
})
export class ContactComponent implements OnInit  { 
    constructor( private config: AppConfig) { }
    ngOnInit() {
        this.config.IsVisibleComment = true;
    }
    ngOnDestroy() {
        this.config.IsVisibleComment = false;
    }
}
