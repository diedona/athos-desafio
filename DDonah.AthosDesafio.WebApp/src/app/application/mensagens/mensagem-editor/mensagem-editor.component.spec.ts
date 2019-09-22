import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MensagemEditorComponent } from './mensagem-editor.component';

describe('MensagemEditorComponent', () => {
  let component: MensagemEditorComponent;
  let fixture: ComponentFixture<MensagemEditorComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MensagemEditorComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MensagemEditorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
