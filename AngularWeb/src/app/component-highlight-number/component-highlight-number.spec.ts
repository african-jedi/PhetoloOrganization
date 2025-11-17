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

  it('should set passOrFail to "fail" for incorrect answer', () => {
    fixture.componentRef.setInput('answer', 10);
    fixture.detectChanges();
    component.ngOnInit();
    expect(component.passOrFail).toBe('fail');
  });

  it('should set passOrFail to "pass" for correct answer', () => {
    fixture.componentRef.setInput('answer', 28);
    fixture.detectChanges();
    component.ngOnInit();
    expect(component.passOrFail).toBe('pass');
  });
  
});
