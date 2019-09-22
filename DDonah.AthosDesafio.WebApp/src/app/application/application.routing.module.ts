import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ApplicationComponent } from './application.component';
import { UsuarioComponent } from './usuarios/usuario/usuario.component';
import { UsuarioListComponent } from './usuarios/usuario-list/usuario-list.component';
import { UsuarioEditorComponent } from './usuarios/usuario-editor/usuario-editor.component';
import { CondominioComponent } from './condominios/condominio/condominio.component';
import { CondominioListComponent } from './condominios/condominio-list/condominio-list.component';


const routes: Routes = [
  {
    path: '', component: ApplicationComponent, children: [
      { path: '', redirectTo: 'home', pathMatch: 'full' },
      { path: 'home', component: HomeComponent },
      {
        path: 'usuarios', component: UsuarioComponent, children: [
          { path: '', component: UsuarioListComponent },
          { path: 'create', component: UsuarioEditorComponent },
          { path: 'edit/:id', component: UsuarioEditorComponent }
        ]
      },
      {
        path: 'condominios', component: CondominioComponent, children: [
          { path: '', component: CondominioListComponent }
        ]
      },
      { path: 'mensagens', component: HomeComponent }
    ]
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ApplicationRoutingModule { }
