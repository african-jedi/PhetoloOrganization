import { ComponentFixture, TestBed } from '@angular/core/testing';
import { provideZonelessChangeDetection } from '@angular/core';
import { ComponentFail } from './component-fail';
import { provideRouter} from '@angular/router';
import { routes } from '../app.routes';


describe('ComponentFail', () => {
  let component: ComponentFail;
  let fixture: ComponentFixture<ComponentFail>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ComponentFail],
      providers: [provideRouter(routes), provideZonelessChangeDetection()]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ComponentFail);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
