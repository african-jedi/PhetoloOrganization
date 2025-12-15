import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ComponentTips } from './component-tips';

describe('ComponentTips', () => {
  let component: ComponentTips;
  let fixture: ComponentFixture<ComponentTips>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ComponentTips]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ComponentTips);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
