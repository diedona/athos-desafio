import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ApplicationRoutingModule } from './application.routing.module';
import { ApplicationComponent } from './application.component';
import { HomeComponent } from './home/home.component';


@NgModule({
  declarations: [ApplicationComponent, HomeComponent],
  imports: [
    CommonModule,
    ApplicationRoutingModule
  ]
})
export class ApplicationModule { }
