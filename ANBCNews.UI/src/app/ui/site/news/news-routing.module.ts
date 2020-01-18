import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { NewsDetailComponent } from './detail/newsdetail.component';
import { IndexComponent } from './index/index.component';
import { SearchComponent } from './search/search.component';


const routes: Routes = [{ path: 'story/:newsId', component: NewsDetailComponent },
    { path: '', component: IndexComponent },
    { path: ':newsType', component: IndexComponent },
    { path: 'index', component: IndexComponent },
    { path: 'search/:key', component: SearchComponent }];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class NewsRoutingModule { }
