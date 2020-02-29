import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SigninComponent } from './signin/signin.component';
import { AccountRoutingModule } from './account-routing.module';  
import { FormsModule, ReactiveFormsModule } from '@angular/forms';


@NgModule({
    declarations: [SigninComponent],
  imports: [
    CommonModule,
    AccountRoutingModule,
    FormsModule,
    ReactiveFormsModule 
  ]
})
export class AccountlModule { }
