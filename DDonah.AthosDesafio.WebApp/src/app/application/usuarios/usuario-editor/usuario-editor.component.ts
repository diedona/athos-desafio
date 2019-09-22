import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-usuario-editor',
  templateUrl: './usuario-editor.component.html',
  styleUrls: ['./usuario-editor.component.scss']
})
export class UsuarioEditorComponent implements OnInit {

  constructor(
    private router: Router
  ) { }

  ngOnInit() {
  }

  onClickGoBack(): void {
    this.router.navigate(['app/usuarios']);
  }

}
