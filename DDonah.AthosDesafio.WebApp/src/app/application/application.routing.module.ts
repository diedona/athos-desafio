import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ApplicationComponent } from './application.component';
import { UsuarioComponent } from './usuarios/usuario/usuario.component';
import { UsuarioListComponent } from './usuarios/usuario-list/usuario-list.component';
import { UsuarioEditorComponent } from './usuarios/usuario-editor/usuario-editor.component';
import { CondominioComponent } from './condominios/condominio/condominio.component';
import { CondominioListComponent } from './condominios/condominio-list/condominio-list.component';
import { CondominioEditorComponent } from './condominios/condominio-editor/condominio-editor.component';
import { MensagemComponent } from './mensagens/mensagem/mensagem.component';
import { MensagemListComponent } from './mensagens/mensagem-list/mensagem-list.component';
import { MensagemEditorComponent } from './mensagens/mensagem-editor/mensagem-editor.component';


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
          { path: '', component: CondominioListComponent },
          { path: 'create', component: CondominioEditorComponent },
          { path: 'edit/:id', component: CondominioEditorComponent }
        ]
      },
      {
        path: 'mensagens', component: MensagemComponent, children: [
          { path: '', component: MensagemListComponent },
          { path: 'create', component: MensagemEditorComponent },
          { path: 'details/:id', component: MensagemEditorComponent }
        ]
      }
    ]
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ApplicationRoutingModule { }
