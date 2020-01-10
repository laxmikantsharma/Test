import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LayoutComponent } from './layout.component';
import { SliderComponent } from './slider/slider.component';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';
import { RouterModule } from '@angular/router';
import { CommentComponent } from './comments/comment.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@NgModule({
    declarations: [LayoutComponent,
        SliderComponent,
        HeaderComponent,
        FooterComponent,
        CommentComponent],
  imports: [
      CommonModule,
      RouterModule,
      FormsModule,
      ReactiveFormsModule  
  ]
})
export class LayoutModule { }
