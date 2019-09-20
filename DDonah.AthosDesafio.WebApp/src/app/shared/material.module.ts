import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatButtonModule } from '@angular/material/button';
import { MatCheckboxModule } from '@angular/material/checkbox';
import {MatCardModule} from '@angular/material/card';

const modules = [
  MatButtonModule, 
  MatCheckboxModule, 
  MatCardModule
]

@NgModule({
  declarations: [],
  imports: [ CommonModule, ...modules ], exports: [ modules ]
})
export class MaterialModule { }
