import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CondominioEditorComponent } from './condominio-editor.component';

describe('CondominioEditorComponent', () => {
  let component: CondominioEditorComponent;
  let fixture: ComponentFixture<CondominioEditorComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CondominioEditorComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CondominioEditorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
