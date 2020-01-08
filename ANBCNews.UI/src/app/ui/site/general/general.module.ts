import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { IndexComponent } from './index/index.component';
import { GeneralRoutingModule } from './general-routing.module'; 
import { AboutComponent } from './about/about.component';
import { ContactComponent } from './contact/contact.component';


@NgModule({
    declarations: [IndexComponent, AboutComponent, ContactComponent],
  imports: [
    CommonModule,
      GeneralRoutingModule
  ]
})
export class GeneralModule { }
