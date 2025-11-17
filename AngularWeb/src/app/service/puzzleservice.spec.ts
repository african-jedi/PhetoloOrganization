import { TestBed } from '@angular/core/testing';

import { PuzzleService } from './puzzleservice';

describe('Puzzleservice', () => {
  let service: PuzzleService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PuzzleService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should return puzzle numbers', () => {
    const pieces = service.getPuzzle();
    expect(pieces.length).toBeGreaterThan(0);
  });
});
