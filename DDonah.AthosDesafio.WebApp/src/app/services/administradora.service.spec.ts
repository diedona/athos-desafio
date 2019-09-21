import { TestBed } from '@angular/core/testing';

import { AdministradoraService } from './administradora.service';

describe('AdministradoraService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: AdministradoraService = TestBed.get(AdministradoraService);
    expect(service).toBeTruthy();
  });
});
