import { Component, OnInit, OnDestroy } from '@angular/core';
import { MatTableDataSource, MatSnackBar } from '@angular/material';
import { Subject } from 'rxjs';
import { CondominioService } from 'src/app/services/condominio.service';
import { Router } from '@angular/router';
import { takeUntil } from 'rxjs/operators';

@Component({
  selector: 'app-condominio-list',
  templateUrl: './condominio-list.component.html',
  styleUrls: ['./condominio-list.component.scss']
})
export class CondominioListComponent implements OnInit, OnDestroy {

  displayedColumns = ['id', 'nome', 'administradoraId', 'responsavelId', 'actions'];
  condominioDs = new MatTableDataSource<any>();
  takeSubject = new Subject<boolean>();

  constructor(
    private router: Router,
    private condominioService: CondominioService,
    private snackBar: MatSnackBar
  ) { }

  ngOnInit() {
    this.getCondominios();
  }

  ngOnDestroy() {
    this.takeSubject.next(true);
    this.takeSubject.unsubscribe();
  }

  onClickCreateNew(): void {
    this.router.navigate(['app/condominios/create']);
  }

  onClickEdit(data: any): void {
    this.router.navigate([`app/condominios/edit/${data.id}`]);
  }

  onClickConfirmDelete(condominio: any): void {
    if (confirm(`Deseja realmente deletar ${condominio.nome}?`)) {
      // 
    }
  }

  //
  // PRIVATES
  //

  getCondominios(): void {
    this.condominioService.getAll()
      .pipe(takeUntil(this.takeSubject))
      .subscribe(data => {
        this.condominioDs.data = data;
      })
  }

}
