import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ComponentPass } from './component-pass';
import { provideRouter } from '@angular/router';

describe('ComponentPass', () => {
  let component: ComponentPass;
  let fixture: ComponentFixture<ComponentPass>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ComponentPass],
      providers: [provideRouter([])]
    })
      .compileComponents();

    fixture = TestBed.createComponent(ComponentPass);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
