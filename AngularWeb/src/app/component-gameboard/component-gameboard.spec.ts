import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ComponentGameboard } from './component-gameboard';

describe('ComponentGameboard', () => {
  let component: ComponentGameboard;
  let fixture: ComponentFixture<ComponentGameboard>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ComponentGameboard]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ComponentGameboard);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
