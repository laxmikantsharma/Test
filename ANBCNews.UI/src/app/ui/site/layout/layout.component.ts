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
        this.router.routeReuseStrategy.shouldReuseRoute = function () {
            return false;
        };

        this.router.events.subscribe((evt) => {
            if (evt instanceof NavigationEnd) {
                this.router.navigated = false;
                window.scrollTo(0, 0);
            }
        });
    }
}
