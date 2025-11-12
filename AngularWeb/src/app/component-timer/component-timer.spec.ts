import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ComponentTimer } from './component-timer';

describe('ComponentTimer', () => {
  let component: ComponentTimer;
  let fixture: ComponentFixture<ComponentTimer>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ComponentTimer]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ComponentTimer);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
