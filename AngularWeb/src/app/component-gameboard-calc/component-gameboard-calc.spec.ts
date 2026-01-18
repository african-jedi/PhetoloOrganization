import { ComponentFixture, TestBed } from '@angular/core/testing';
import { provideZonelessChangeDetection } from '@angular/core';

import { ComponentGameboardCalc } from './component-gameboard-calc';

describe('ComponentGameboardCalc', () => {
  let component: ComponentGameboardCalc;
  let fixture: ComponentFixture<ComponentGameboardCalc>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ComponentGameboardCalc],
      providers: [
        provideZonelessChangeDetection()
      ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ComponentGameboardCalc);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
