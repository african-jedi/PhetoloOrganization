import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ComponentPass } from './component-pass';
import { ActivatedRoute, provideRouter } from '@angular/router';

describe('ComponentPass', () => {
  let component: ComponentPass;
  let fixture: ComponentFixture<ComponentPass>;



  it('should create', () => {
   fixture = TestBed.configureTestingModule({
      imports: [ComponentPass],
      providers: [provideRouter([])]
    })
      .createComponent(ComponentPass);

    //fixture = TestBed.createComponent(ComponentPass);
    component = fixture.componentInstance;
    fixture.detectChanges();
    expect(component).toBeTruthy();
  });

  it('should have pass message', () => {
    const paramap=new Map<string,string>();

    fixture = TestBed.configureTestingModule({
      imports: [ComponentPass],
      providers: [{ provide: ActivatedRoute, useValue: {
          snapshot: {
            paramMap: {
              get: () => 28, // represents the bookId
            },
          },
        }, }]
    })
      .createComponent(ComponentPass);

    const compiled = fixture.nativeElement as HTMLElement;
    component = fixture.componentInstance;
    console.log('Answer:', component.answer);
    fixture.detectChanges();

    expect(compiled.querySelector('.message')?.textContent).toContain('Well, done!');
    expect(compiled.querySelector('.pass')?.textContent).toContain(paramap.get('total') || '28');
  });
});
