import { TestBed } from '@angular/core/testing';

import { Puzzleservice } from './puzzleservice';

describe('Puzzleservice', () => {
  let service: Puzzleservice;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(Puzzleservice);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
