import { ComponentFixture, TestBed } from '@angular/core/testing';
import { provideZonelessChangeDetection } from '@angular/core';
import { ComponentPass } from './component-pass';
import { ActivatedRoute, provideRouter } from '@angular/router';
import { routes } from '../app.routes';
import { ComponentHighlightNumber } from '../component-highlight-number/component-highlight-number';

describe('ComponentPass', () => {
  let component: ComponentPass;
  let fixture: ComponentFixture<ComponentPass>;



  it('should create', () => {
   fixture = TestBed.configureTestingModule({
      imports: [ComponentPass, ComponentHighlightNumber],
      providers: [provideRouter(routes), provideZonelessChangeDetection()]
    })
      .createComponent(ComponentPass);

    //fixture = TestBed.createComponent(ComponentPass);
    component = fixture.componentInstance;
    expect(component).toBeTruthy();
  });

  it('should have pass message', () => {
    fixture = TestBed.configureTestingModule({
      imports: [ComponentPass],
      providers: [{ provide: ActivatedRoute, useValue: {
          snapshot: {
            paramMap: {
              get: () => 28, // represents the bookId
            },
          },
        }, }, provideZonelessChangeDetection()]
    })
      .createComponent(ComponentPass);

    const compiled = fixture.nativeElement as HTMLElement;
    component = fixture.componentInstance;
    console.log('Answer:', component.answer);

    expect(compiled.querySelector('.message')?.textContent).toContain('Well, done!');
    let answer = Number(fixture.debugElement.injector.get(ActivatedRoute).snapshot.paramMap.get('total') ?? 0);
    expect(28).toBe(answer);
  });
});
