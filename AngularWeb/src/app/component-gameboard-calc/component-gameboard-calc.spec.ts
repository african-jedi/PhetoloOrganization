import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ComponentGameboardCalc } from './component-gameboard-calc';

describe('ComponentGameboardCalc', () => {
  let component: ComponentGameboardCalc;
  let fixture: ComponentFixture<ComponentGameboardCalc>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ComponentGameboardCalc]
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
