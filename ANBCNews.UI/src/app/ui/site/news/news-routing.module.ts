import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { IndexComponent } from './index/index.component';
import { NewsDetailComponent } from './detail/newsdetail.component';


const routes: Routes = [{ path: '', component: IndexComponent },
    { path: 'index', component: IndexComponent },
    { path: 'story/:newsId', component: NewsDetailComponent },];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class NewsRoutingModule { }
