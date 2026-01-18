import { ComponentFixture, TestBed } from '@angular/core/testing';
import { provideZonelessChangeDetection } from '@angular/core';
import { ComponentHome } from './component-home';
import { HttpClient } from '@angular/common/http';
import { provideHttpClientTesting } from '@angular/common/http/testing';
import { httpResource, provideHttpClient } from '@angular/common/http';

describe('ComponentHome', () => {
  let component: ComponentHome;
  let fixture: ComponentFixture<ComponentHome>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ComponentHome],
      providers: [
        provideZonelessChangeDetection(),
        provideHttpClient(),
        provideHttpClientTesting()
      ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ComponentHome);
    component = fixture.componentInstance;
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
