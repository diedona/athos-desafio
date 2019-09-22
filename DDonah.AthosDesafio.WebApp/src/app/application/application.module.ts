import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ApplicationRoutingModule } from './application.routing.module';
import { ApplicationComponent } from './application.component';
import { HomeComponent } from './home/home.component';
import { MaterialModule } from '../shared/material.module';
import { LayoutModule } from '../layout/layout.module';
import { UsuarioComponent } from './usuarios/usuario/usuario.component';
import { UsuarioListComponent } from './usuarios/usuario-list/usuario-list.component';
import { FlexLayoutModule } from "@angular/flex-layout";
import { UsuarioEditorComponent } from './usuarios/usuario-editor/usuario-editor.component';
import { SharedModule } from '../shared/shared.module';
import { CondominioComponent } from './condominios/condominio/condominio.component';
import { CondominioListComponent } from './condominios/condominio-list/condominio-list.component';


@NgModule({
  declarations: [
    ApplicationComponent, 
    HomeComponent, 
    UsuarioComponent,
    UsuarioListComponent,
    UsuarioEditorComponent,
    CondominioComponent,
    CondominioListComponent
  ],
  imports: [
    CommonModule,
    ApplicationRoutingModule,
    MaterialModule,
    SharedModule,
    FlexLayoutModule,
    LayoutModule
  ]
})
export class ApplicationModule { }
