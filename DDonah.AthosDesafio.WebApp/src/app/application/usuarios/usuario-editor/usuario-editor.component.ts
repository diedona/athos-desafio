import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CondominioService } from 'src/app/services/condominio.service';
import { Subject } from 'rxjs';
import { THIS_EXPR } from '@angular/compiler/src/output/output_ast';
import { takeUntil } from 'rxjs/operators';

@Component({
  selector: 'app-usuario-editor',
  templateUrl: './usuario-editor.component.html',
  styleUrls: ['./usuario-editor.component.scss']
})
export class UsuarioEditorComponent implements OnInit, OnDestroy {

  frmUsuario: FormGroup;
  takeSubject = new Subject<boolean>();
  condominios: Array<any>;

  constructor(
    private router: Router,
    private fb: FormBuilder,
    private condominioService: CondominioService
  ) { }

  ngOnInit() {
    this.frmUsuario = this.generateForm();
    this.getCondominios();
  }

  ngOnDestroy() {
    this.takeSubject.next(true);
    this.takeSubject.unsubscribe();
  }

  onClickGoBack(): void {
    this.router.navigate(['app/usuarios']);
  }

  onFormSubmit(): void {
    if (this.frmUsuario.invalid) {
      this.frmUsuario.markAllAsTouched();
      return;
    }

    const usuario = this.frmUsuario.getRawValue();
    console.log(usuario);
  }

  // 
  // privates
  //

  getCondominios(): void {
    this.condominioService.getAll()
      .pipe(takeUntil(this.takeSubject))
      .subscribe(data => {
        this.condominios = data;
      })
  }

  generateForm(): FormGroup {
    return this.fb.group({
      id: ['', []],
      nome: ['', [Validators.required]],
      email: ['', [Validators.required, Validators.email]],
      condominioId: ['', Validators.required],
      tipo: ['', [Validators.required]]
    });
  }

}
