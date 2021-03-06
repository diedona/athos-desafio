import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MensagemListComponent } from './mensagem-list.component';

describe('MensagemListComponent', () => {
  let component: MensagemListComponent;
  let fixture: ComponentFixture<MensagemListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MensagemListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MensagemListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
