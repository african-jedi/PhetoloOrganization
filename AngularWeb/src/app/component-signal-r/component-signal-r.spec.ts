import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ComponentSignalR } from './component-signal-r';

describe('ComponentSignalR', () => {
  let component: ComponentSignalR;
  let fixture: ComponentFixture<ComponentSignalR>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ComponentSignalR]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ComponentSignalR);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
