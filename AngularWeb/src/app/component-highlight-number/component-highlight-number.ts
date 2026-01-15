import { Component, input, inject, SimpleChanges, OnChanges } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';
import { CookieNames } from '../models/cookieNames';
import { ComponentTips } from '../component-tips/component-tips';
import { Router } from '@angular/router';

@Component({
  selector: 'app-component-highlight-number',
  imports: [ComponentTips],
  standalone: true,
  templateUrl: './component-highlight-number.html',
  styleUrl: './component-highlight-number.scss',
})
export class ComponentHighlightNumber implements OnChanges{
  answer = input.required<number>();
  answerClass = '';
  equation = '';
  readonly cookieService = inject(CookieService);
  readonly constants = new CookieNames();
  private router = inject(Router);

  constructor() {
    console.log("ComponentHighlightNumber: Constructor called before lifecycle hooks");
  }

  ngOnInit() {
    console.log("ComponentHighlightNumber: ngOnInit called after constructor and onChanges");
    this.equation = this.cookieService.get(this.constants.equation);
    console.log('Equation from cookie:', !this.equation);
    if(!this.equation){
      console.log('Error occurred');
      this.router.navigate(['/error']);
    }


    if (this.answer() === 28)
      this.cookieService.set(this.constants.puzzle, '');

    this.cookieService.set(this.constants.equation,'');
  }

  ngOnChanges(changes: SimpleChanges): void {
    console.log("ComponentHighlightNumber: ngOnChanges called after constructor");
  }
}
