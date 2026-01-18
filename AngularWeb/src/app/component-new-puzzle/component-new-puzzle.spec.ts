import { ComponentFixture, TestBed } from '@angular/core/testing';
import { provideZonelessChangeDetection } from '@angular/core';
import { provideHttpClientTesting } from '@angular/common/http/testing';
import { httpResource, provideHttpClient } from '@angular/common/http';

import { ComponentNewPuzzle } from './component-new-puzzle';

describe('ComponentNewPuzzle', () => {
  let component: ComponentNewPuzzle;
  let fixture: ComponentFixture<ComponentNewPuzzle>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ComponentNewPuzzle],
      providers: [
        provideZonelessChangeDetection(),
        provideHttpClient(),
        provideHttpClientTesting()
      ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ComponentNewPuzzle);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
