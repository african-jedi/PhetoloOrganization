import { ComponentFixture, TestBed } from '@angular/core/testing';
import{ provideZonelessChangeDetection } from '@angular/core';

import { ComponentSignalR } from './component-signal-r';

describe('ComponentSignalR', () => {
  let component: ComponentSignalR;
  let fixture: ComponentFixture<ComponentSignalR>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ComponentSignalR],
      providers: [
        provideZonelessChangeDetection()
      ]
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
