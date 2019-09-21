import { NgModule } from '@angular/core';
import { MainNavComponent } from './main-nav/main-nav.component';
import { MaterialModule } from '../shared/material.module';
import { CommonModule } from '@angular/common';

@NgModule({
  declarations: [MainNavComponent],
  imports: [CommonModule, MaterialModule],
  exports: [MainNavComponent]
})
export class LayoutModule { }
