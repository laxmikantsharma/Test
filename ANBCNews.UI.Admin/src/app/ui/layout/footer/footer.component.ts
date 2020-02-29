import { Component } from '@angular/core';
import { AppConfig } from '../../../@core/globals/app.config';

@Component({
  selector: 'site-footer',
    templateUrl: './footer.component.html',
})
export class FooterComponent {
    constructor(public config: AppConfig) { }
   
}
