import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ComponentHighlightNumber } from './component-highlight-number';

describe('ComponentHighlightNumber', () => {
  let component: ComponentHighlightNumber;
  let fixture: ComponentFixture<ComponentHighlightNumber>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ComponentHighlightNumber]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ComponentHighlightNumber);
    fixture.componentRef.setInput('answer', 1);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
