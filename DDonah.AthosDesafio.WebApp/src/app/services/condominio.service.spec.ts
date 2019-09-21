import { TestBed } from '@angular/core/testing';

import { CondominioService } from './condominio.service';

describe('CondominioService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: CondominioService = TestBed.get(CondominioService);
    expect(service).toBeTruthy();
  });
});
