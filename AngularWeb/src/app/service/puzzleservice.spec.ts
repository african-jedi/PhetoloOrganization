import { TestBed } from '@angular/core/testing';
import { provideZonelessChangeDetection } from '@angular/core';
import { provideHttpClientTesting } from '@angular/common/http/testing';
import { httpResource, provideHttpClient } from '@angular/common/http';

import { PuzzleService } from './puzzleservice';
import { environment } from '../../environments/environment';

describe('Puzzleservice', () => {
  let service: PuzzleService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [
        provideZonelessChangeDetection(),
        provideHttpClient(),
        provideHttpClientTesting()
      ],
      imports: []
    });
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
