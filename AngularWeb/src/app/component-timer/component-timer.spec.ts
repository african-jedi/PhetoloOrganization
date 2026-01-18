import { ComponentFixture, TestBed } from '@angular/core/testing';
import { provideZonelessChangeDetection } from '@angular/core';

import { ComponentTimer } from './component-timer';

describe('ComponentTimer', () => {
  let component: ComponentTimer;
  let fixture: ComponentFixture<ComponentTimer>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ComponentTimer],
      providers: [
        provideZonelessChangeDetection()
      ]
    })
      .compileComponents();

    fixture = TestBed.createComponent(ComponentTimer);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should clean up interval on ngOnInit', () => {
    spyOn(window, 'setInterval');
    component.ngOnInit();
    expect(setInterval).toHaveBeenCalled();
  });

  it('should clean up interval on ngOnDestroy', () => {
    component.setTimeintervalObject = 12345;
    spyOn(window, 'clearInterval');
    component.ngOnDestroy();
    expect(clearInterval).toHaveBeenCalledWith(12345);
  });

  it('should format time correctly', () => {
    component.userTime = 3661;
    const formattedTime = (component as any)._formatNumberToTime();
    expect(formattedTime).toBe('01:01:01');
  });

  it('should stop the timer when stopTime is true', () => {
    component.stopTime = true;
    spyOn(window, 'clearInterval');
    component.timeHandler();
    expect(clearInterval).toHaveBeenCalledWith(component.setTimeintervalObject);
  });

  it('should increment userTime and update displayTime when stopTime is false', () => {
    component.stopTime = false;
    const initialUserTime = component.userTime;
    component.timeHandler();
    expect(component.userTime).toBe(initialUserTime + 1);
    expect(component.displayTime()).toBe(component['_formatNumberToTime']());
  });

});
