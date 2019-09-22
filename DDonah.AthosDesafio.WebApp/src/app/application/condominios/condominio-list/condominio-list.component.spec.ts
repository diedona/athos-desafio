import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CondominioListComponent } from './condominio-list.component';

describe('CondominioListComponent', () => {
  let component: CondominioListComponent;
  let fixture: ComponentFixture<CondominioListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CondominioListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CondominioListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
