import { ComponentFixture, TestBed } from '@angular/core/testing';
import { provideZonelessChangeDetection } from '@angular/core';
import { routes } from '../app.routes';
import { ComponentHighlightNumber } from './component-highlight-number';
import { provideRouter} from '@angular/router';

describe('ComponentHighlightNumber', () => {
  let component: ComponentHighlightNumber;
  let fixture: ComponentFixture<ComponentHighlightNumber>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ComponentHighlightNumber],
      providers: [
        provideZonelessChangeDetection(),
        provideRouter(routes)
      ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ComponentHighlightNumber);
    fixture.componentRef.setInput('answer', 1);
    component = fixture.componentInstance;
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should display 28 when 28 is passed', () => {
    fixture.componentRef.setInput('answer', 28);
    fixture.detectChanges();
    console.log('Component Input Answer:', component.answer());
    const compiled = fixture.nativeElement as HTMLElement;
    expect(compiled.querySelector('.pass')?.textContent).toBe('28');
  });

});
