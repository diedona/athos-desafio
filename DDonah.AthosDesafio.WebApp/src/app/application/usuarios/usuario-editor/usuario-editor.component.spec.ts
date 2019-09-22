import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UsuarioEditorComponent } from './usuario-editor.component';

describe('UsuarioEditorComponent', () => {
  let component: UsuarioEditorComponent;
  let fixture: ComponentFixture<UsuarioEditorComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UsuarioEditorComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UsuarioEditorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
