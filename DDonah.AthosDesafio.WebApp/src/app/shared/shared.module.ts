import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ReactiveFormsModule } from '@angular/forms';

const modules = [
  BrowserAnimationsModule,
  ReactiveFormsModule
]

@NgModule({
  declarations: [],
  imports: [CommonModule, ...modules],
  exports: [modules]
})
export class SharedModule { }
