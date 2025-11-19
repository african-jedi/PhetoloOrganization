import { Component, input, inject } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';
import { Constants } from '../models/constants';

@Component({
  selector: 'app-component-highlight-number',
  imports: [],
  standalone: true,
  templateUrl: './component-highlight-number.html',
  styleUrl: './component-highlight-number.scss',
})
export class ComponentHighlightNumber {
  answer = input.required<number>();
  answerClass = '';
  equation = '';
  readonly cookieService = inject(CookieService);
  readonly constants = new Constants();

  ngOnInit() {
    this.answerClass = this.answer() === 28 ? 'pass' : 'fail';
    this.equation = this.cookieService.get(this.constants.cookieName);

    if (this.answerClass === 'pass')
      this.cookieService.set(this.constants.cookiePuzzleName, '');
  }
}
