import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';


const routes: Routes = [
    { path: '', loadChildren: () => import('./ui/site/general/general.module').then(m => m.GeneralModule) },
    { path: 'story', loadChildren: () => import('./ui/site/news/news.module').then(m => m.NewsModule) }
];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
