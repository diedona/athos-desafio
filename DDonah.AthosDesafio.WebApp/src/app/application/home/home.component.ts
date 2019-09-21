import { Component, OnInit, OnDestroy } from '@angular/core';
import { AdministradoraService } from 'src/app/services/administradora.service';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit, OnDestroy {

  private subjectTake = new Subject<boolean>();

  constructor(
    private administradoraService: AdministradoraService
  ) { }

  ngOnInit() {
    console.log(this.administradoraService);
    this.administradoraService.getAll()
      .pipe(takeUntil(this.subjectTake))
      .subscribe(data => {
        console.log(data);
      });
  }

  ngOnDestroy() {
    this.subjectTake.next(true);
    this.subjectTake.unsubscribe();
  }

}
