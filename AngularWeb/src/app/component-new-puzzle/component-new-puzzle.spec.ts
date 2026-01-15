import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ComponentNewPuzzle } from './component-new-puzzle';

describe('ComponentNewPuzzle', () => {
  let component: ComponentNewPuzzle;
  let fixture: ComponentFixture<ComponentNewPuzzle>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ComponentNewPuzzle]
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
