import { Component, OnInit, OnDestroy } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Subject } from 'rxjs';
import { UsuarioService } from 'src/app/services/usuario.service';
import { CondominioService } from 'src/app/services/condominio.service';
import { Router, ActivatedRoute } from '@angular/router';
import { takeUntil } from 'rxjs/operators';
import { AdministradoraService } from 'src/app/services/administradora.service';
import { MatSnackBar } from '@angular/material';

@Component({
  selector: 'app-condominio-editor',
  templateUrl: './condominio-editor.component.html',
  styleUrls: ['./condominio-editor.component.scss']
})
export class CondominioEditorComponent implements OnInit, OnDestroy {

  frmCondominio: FormGroup;
  modoFormulario: string;
  usuarios: Array<any>;
  administradoras: Array<any>;
  takeSubject = new Subject<boolean>();

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private fb: FormBuilder,
    private snackBar: MatSnackBar,
    private usuarioService: UsuarioService,
    private condominioService: CondominioService,
    private administradoraService: AdministradoraService
  ) { }

  ngOnInit() {
    this.frmCondominio = this.generateForm();
    this.getCheckParams();
    this.carregarUsuarios();
    this.carregarAdministradoras();
  }

  ngOnDestroy() {
    this.takeSubject.next(true);
    this.takeSubject.unsubscribe();
  }

  onClickGoBack(): void {
    this.router.navigate(['app/condominios']);
  }

  onFormSubmit(): void {

    if (this.frmCondominio.invalid) {
      this.frmCondominio.markAllAsTouched();
      return;
    }

    const condominio = this.frmCondominio.getRawValue();
    if (!condominio.id) {
      this.save(condominio);
    } else {
      this.update(condominio);
    }

  }

  public get modoEditor(): string {
    return (this.modoFormulario);
  }



  //
  // PRIVATES
  //

  generateForm(): FormGroup {
    return this.fb.group({
      id: [{ value: '', disabled: true }, []],
      nome: ['', [Validators.required]],
      administradoraId: ['', [Validators.required]],
      responsavelId: ['', []]
    });
  }

  getCheckParams(): void {
    this.route.params
      .pipe(takeUntil(this.takeSubject))
      .subscribe(params => {
        if (params.id) {
          this.modoFormulario = "Edição";
          this.carregarCondominio(+params.id);
        } else {
          this.modoFormulario = "Criação";
        }
      })
  }

  carregarCondominio(id: number): void {
    this.condominioService.getById(id)
      .pipe(takeUntil(this.takeSubject))
      .subscribe(data => {
        this.frmCondominio.patchValue(data);
      })
  }

  carregarUsuarios(): void {
    this.usuarioService.getResponsaveis()
      .pipe(takeUntil(this.takeSubject))
      .subscribe(data => {
        this.usuarios = data;
      })
  }

  carregarAdministradoras(): void {
    this.administradoraService.getAll()
      .pipe(takeUntil(this.takeSubject))
      .subscribe(data => {
        this.administradoras = data;
      })
  }

  save(condominio: any): void {
    this.condominioService.save(condominio)
      .pipe(takeUntil(this.takeSubject))
      .subscribe(() => {
        this.onClickGoBack();
      }, err => {
        this.snackBar.open(err.error, 'x', { panelClass: 'danger-snackbar' });
      });
  }

  update(condominio: any): void {
    this.condominioService.update(condominio)
      .pipe(takeUntil(this.takeSubject))
      .subscribe(() => {
        this.onClickGoBack();
      }, err => {
        this.snackBar.open(err.error, 'fechar', { panelClass: 'danger-snackbar' });
      });
  }

}
