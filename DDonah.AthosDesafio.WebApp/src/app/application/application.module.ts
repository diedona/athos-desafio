import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ApplicationRoutingModule } from './application.routing.module';
import { ApplicationComponent } from './application.component';
import { HomeComponent } from './home/home.component';
import { MaterialModule } from '../shared/material.module';
import { LayoutModule } from '../layout/layout.module';


@NgModule({
  declarations: [ApplicationComponent, HomeComponent],
  imports: [
    CommonModule,
    ApplicationRoutingModule,
    MaterialModule,
    LayoutModule
  ]
})
export class ApplicationModule { }
