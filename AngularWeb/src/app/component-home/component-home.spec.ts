import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ComponentHome } from './component-home';

describe('ComponentHome', () => {
  let component: ComponentHome;
  let fixture: ComponentFixture<ComponentHome>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ComponentHome]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ComponentHome);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
