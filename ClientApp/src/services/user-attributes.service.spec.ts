import { TestBed } from '@angular/core/testing';

import { UserAttributesService } from './user-attributes.service';

describe('UserAttributesService', () => {
  let service: UserAttributesService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(UserAttributesService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
