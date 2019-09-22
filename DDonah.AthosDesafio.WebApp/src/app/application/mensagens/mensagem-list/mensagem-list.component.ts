import { Component, OnInit, OnDestroy } from '@angular/core';
import { MatTableDataSource } from '@angular/material';
import { Subject } from 'rxjs';
import { Router } from '@angular/router';
import { MessageService } from 'src/app/utils/message.service';
import { MensagemService } from 'src/app/services/mensagem.service';
import { takeUntil } from 'rxjs/operators';

@Component({
  selector: 'app-mensagem-list',
  templateUrl: './mensagem-list.component.html',
  styleUrls: ['./mensagem-list.component.scss']
})
export class MensagemListComponent implements OnInit, OnDestroy {

  displayedColumns = ['id', 'usuarioEmissorId', 'entidadeResponsavelNome', 'assuntoId', 'actions'];
  mensagemDs = new MatTableDataSource<any>();
  takeSubject = new Subject<boolean>();

  constructor(
    private router: Router,
    private mensagemService: MensagemService,
    private messageService: MessageService,
  ) { }

  ngOnInit() {
    this.getMensagens();
  }

  ngOnDestroy() {
    this.takeSubject.next(true);
    this.takeSubject.unsubscribe();
  }

  //
  // PRIVATES
  //

  private getMensagens(): void {
    this.mensagemService.getAll()
      .pipe(takeUntil(this.takeSubject))
      .subscribe(msgs => {
        this.mensagemDs.data = msgs;
      })
  }
}
