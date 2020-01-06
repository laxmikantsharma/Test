import { Component, OnInit } from '@angular/core';
import { Router, NavigationEnd } from '@angular/router';

@Component({
    selector: 'site-layout',
    templateUrl: './layout.component.html',
})
export class LayoutComponent implements OnInit  {
    mainSlider: boolean = false;

    constructor(private router: Router ) {
        
    }
    ngOnInit() {
        this.router.events.subscribe((val) => {
            this.mainSlider = location.pathname == '/' || location.pathname.indexOf("/index") > 0 ; 
        });
    }
}
