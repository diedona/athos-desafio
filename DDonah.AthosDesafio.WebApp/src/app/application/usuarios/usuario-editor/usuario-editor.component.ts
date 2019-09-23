import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CondominioService } from 'src/app/services/condominio.service';
import { Subject } from 'rxjs';
import { THIS_EXPR } from '@angular/compiler/src/output/output_ast';
import { takeUntil } from 'rxjs/operators';
import { UsuarioService } from 'src/app/services/usuario.service';
import { MessageService } from 'src/app/utils/message.service';

@Component({
  selector: 'app-usuario-editor',
  templateUrl: './usuario-editor.component.html',
  styleUrls: ['./usuario-editor.component.scss']
})
export class UsuarioEditorComponent implements OnInit, OnDestroy {

  frmUsuario: FormGroup;
  modoFormulario: string;
  takeSubject = new Subject<boolean>();
  condominios: Array<any>;

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private fb: FormBuilder,
    private condominioService: CondominioService,
    private usuarioService: UsuarioService,
    private messageService: MessageService
  ) { }

  ngOnInit() {
    this.frmUsuario = this.generateForm();
    this.getCondominios();
    this.getCheckParams();
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
    if (!usuario.id) {
      this.saveUser(usuario);
    } else {
      this.updateUser(usuario);
    }
  }

  updateUser(usuario: any) {
    this.usuarioService.update(usuario)
      .pipe(takeUntil(this.takeSubject))
      .subscribe(() => {
        this.messageService.success('Salvo com sucesso!');
        this.onClickGoBack();
      }, (err) => {
        this.messageService.error(err);
      })
  }

  saveUser(usuario: any) {
    this.usuarioService.save(usuario)
      .pipe(takeUntil(this.takeSubject))
      .subscribe(() => {
        this.messageService.success('Salvo com sucesso!');
        this.onClickGoBack();
      }, (err) => {
        this.messageService.error(err);
      })
  }

  public get modoEditor(): string {
    return (this.modoFormulario);
  }

  // 
  // privates
  //

  getCheckParams(): void {
    this.route.params
      .pipe(takeUntil(this.takeSubject))
      .subscribe(x => {
        if (x.id) {
          this.modoFormulario = "Edição";
          this.loadUsuario(+x.id);
        } else {
          this.modoFormulario = "Criação";
        }
      })
  }

  loadUsuario(id: number): void {
    this.usuarioService.getByiId(id)
      .pipe(takeUntil(this.takeSubject))
      .subscribe(usuario => {
        this.fillFormData(usuario);
      })
  }

  fillFormData(usuario: any): void {
    this.frmUsuario.patchValue(usuario);
    this.frmUsuario.get('tipo').disable();
  }

  getCondominios(): void {
    this.condominioService.getAll()
      .pipe(takeUntil(this.takeSubject))
      .subscribe(data => {
        this.condominios = data;
      })
  }

  generateForm(): FormGroup {
    return this.fb.group({
      id: [{ value: '', disabled: true }, []],
      nome: ['', [Validators.required]],
      email: ['', [Validators.required, Validators.email]],
      condominioId: ['', Validators.required],
      tipo: ['', [Validators.required]]
    });
  }

}
