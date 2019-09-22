import { Component, OnInit, OnDestroy } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { UsuarioService } from 'src/app/services/usuario.service';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import { THIS_EXPR } from '@angular/compiler/src/output/output_ast';
import { Router } from '@angular/router';

@Component({
  selector: 'app-usuario-list',
  templateUrl: './usuario-list.component.html',
  styleUrls: ['./usuario-list.component.scss']
})
export class UsuarioListComponent implements OnInit, OnDestroy {

  displayedColumns = ['id', 'nome', 'email', 'actions'];
  usuariosDs = new MatTableDataSource<any>();
  takeSubject = new Subject<boolean>();

  constructor(
    private router: Router,
    private usuarioService: UsuarioService
  ) { }

  ngOnInit() {
    this.getUsuarios();
  }

  ngOnDestroy() {
    this.takeSubject.next(true);
    this.takeSubject.unsubscribe();
  }

  onClickCreateNew(): void {
    this.router.navigate(['app/usuarios/create']);
  }

  onClickEdit(data: any): void {
    this.router.navigate([`app/usuarios/edit/${data.id}`]);
  }

  onClickConfirmDelete(usuario: any): void {
    if (confirm(`Deseja realmente deletar ${usuario.nome}?`)) {
      this.deleteUsuario(usuario);
    }
  }

  //
  // PRIVATES
  //

  getUsuarios(): void {
    this.usuarioService.getAll()
      .pipe(takeUntil(this.takeSubject))
      .subscribe(data => {
        this.usuariosDs.data = data;
      });
  }

  deleteUsuario(usuario: any): void {
    this.usuarioService.delete(usuario.id)
      .pipe(takeUntil(this.takeSubject))
      .subscribe(() => {
        this.getUsuarios();
      }, err => {
        alert('erro!');
      })
  }
}
