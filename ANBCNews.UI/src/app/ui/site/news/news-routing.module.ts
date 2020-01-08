import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { NewsDetailComponent } from './detail/newsdetail.component';
import { IndexComponent } from './index/index.component';


const routes: Routes = [{ path: 'story/:newsId', component: NewsDetailComponent },
    { path: '', component: IndexComponent },
    { path: 'index', component: IndexComponent }];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class NewsRoutingModule { }
