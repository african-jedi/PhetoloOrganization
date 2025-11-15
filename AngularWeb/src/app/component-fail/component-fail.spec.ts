import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ComponentFail } from './component-fail';
import { provideRouter} from '@angular/router';

describe('ComponentFail', () => {
  let component: ComponentFail;
  let fixture: ComponentFixture<ComponentFail>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ComponentFail],
      providers: [provideRouter([])]
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
