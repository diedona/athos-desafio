import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ApplicationComponent } from './application.component';


const routes: Routes = [
  {
    path: '', component: ApplicationComponent, children: [
      { path: '', redirectTo: 'home', pathMatch: 'full' },
      { path: 'home', component: HomeComponent },
      { path: 'usuarios', component: HomeComponent },
      { path: 'condominios', component: HomeComponent },
      { path: 'mensagens', component: HomeComponent }
    ]
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ApplicationRoutingModule { }
