import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Subject } from 'rxjs';
import { MensagemService } from 'src/app/services/mensagem.service';
import { takeUntil } from 'rxjs/operators';
import { UsuarioService } from 'src/app/services/usuario.service';
import { MessageService } from 'src/app/utils/message.service';
import { CondominioService } from 'src/app/services/condominio.service';

@Component({
  selector: 'app-mensagem-editor',
  templateUrl: './mensagem-editor.component.html',
  styleUrls: ['./mensagem-editor.component.scss']
})
export class MensagemEditorComponent implements OnInit, OnDestroy {

  frmMensagem: FormGroup;
  usuarios: Array<any>;
  assuntos: Array<any>;
  condominios: Array<any>;
  takeSubject = new Subject<boolean>();

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private fb: FormBuilder,
    private mensagemService: MensagemService,
    private usuarioService: UsuarioService,
    private condominioService: CondominioService,
    private messageService: MessageService
  ) { }

  ngOnInit() {
    this.frmMensagem = this.gerarFormulario();
    this.getCheckParams();
    this.carregarAssuntos();
    this.carregarUsuarios();
    this.carregarCondominios();
  }

  ngOnDestroy() {
    this.takeSubject.next(true);
    this.takeSubject.unsubscribe();
  }

  onClickGoBack(): void {
    this.router.navigate(['app/mensagens']);
  }

  onFormSubmit(): void {
    if (this.frmMensagem.invalid) {
      this.frmMensagem.markAllAsTouched();
      return;
    }

    const mensagem = this.frmMensagem.getRawValue();
    if (mensagem.id) {
      return;
    }

    this.save(mensagem);
  }

  //

  public get getCondominioEmissor(): string {

    const usuarioEmissorId = this.frmMensagem.get('usuarioEmissorId').value;
    if (!usuarioEmissorId) {
      return '';
    }

    const usuario = this.usuarios.find(x => x.id === usuarioEmissorId);
    if (!usuario) {
      return '';
    }

    const condominio = this.condominios.find(x => x.id === usuario.condominioId);
    if (!condominio) {
      return '';
    } else {
      return condominio.nome;
    }
  }


  //
  // PRIVATES
  //

  private gerarFormulario(): FormGroup {
    return this.fb.group({
      id: [{ value: '', disabled: true }, []],
      assuntoId: ['', [Validators.required]],
      usuarioEmissorId: ['', [Validators.required]],
      usuarioResponsavelId: [{ value: '', disabled: true }],
      administradoraResponsavelId: [{ value: '', disabled: true }],
      texto: ['', [Validators.required]],
      dateCreated: [{ value: '', disabled: true }],
      entidadeResponsavelNome: [{ value: '', disabled: true }]
    });
  }

  private getCheckParams(): void {
    this.route.params
      .pipe(takeUntil(this.takeSubject))
      .subscribe(params => {
        if (params.id) {
          this.carregarMensagem(+params.id);
        } else {
        }
      })
  }

  private carregarMensagem(id: number): void {
    this.mensagemService.getById(id)
      .pipe(takeUntil(this.takeSubject))
      .subscribe(data => {
        this.frmMensagem.patchValue(data);
        this.frmMensagem.disable();
      })
  }

  private carregarAssuntos() {
    this.mensagemService.getAssuntos()
      .pipe(takeUntil(this.takeSubject))
      .subscribe(assuntos => {
        this.assuntos = assuntos;
      })
  }

  private carregarUsuarios() {
    this.usuarioService.getMoradores()
      .pipe(takeUntil(this.takeSubject))
      .subscribe(usuarios => {
        this.usuarios = usuarios;
      })
  }

  private carregarCondominios() {
    this.condominioService.getAll()
      .pipe(takeUntil(this.takeSubject))
      .subscribe(data => {
        this.condominios = data;
      })
  }

  private save(mensagem: any): void {
    this.mensagemService.save(mensagem)
      .pipe(takeUntil(this.takeSubject))
      .subscribe(msg => {
        this.frmMensagem.patchValue(msg);
        this.messageService.success('Mensagem enviada com sucesso!');
      }, err => {
        this.messageService.error(err);
      })
  }

}
