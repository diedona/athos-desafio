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


@NgModule({
  declarations: [
    ApplicationComponent, 
    HomeComponent, 
    UsuarioComponent,
    UsuarioListComponent,
    UsuarioEditorComponent
  ],
  imports: [
    CommonModule,
    ApplicationRoutingModule,
    MaterialModule,
    FlexLayoutModule,
    LayoutModule
  ]
})
export class ApplicationModule { }
