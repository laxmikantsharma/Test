import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
    selector: 'site-header',
    templateUrl: './header.component.html',
})
export class HeaderComponent implements OnInit {
    public serachForm: FormGroup;
    constructor( private formBuilder: FormBuilder, private router: Router) { }

    ngOnInit() {
    } 
}

