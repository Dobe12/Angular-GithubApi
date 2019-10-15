import { TestBed } from '@angular/core/testing';

import { WebApiServiceService } from './web-api-service.service';

describe('WebApiServiceService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: WebApiServiceService = TestBed.get(WebApiServiceService);
    expect(service).toBeTruthy();
  });
});
