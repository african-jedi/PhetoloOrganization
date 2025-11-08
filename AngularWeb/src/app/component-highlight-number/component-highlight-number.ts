import { Component, Input, inject } from '@angular/core';
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
  @Input() answer = 0;
  passOrfail = '';
  equation = '';
  readonly cookieService = inject(CookieService);
  readonly constants = new Constants();

  ngOnInit() {
    this.passOrfail = this.answer === 28 ? 'pass' : 'fail';
    this.equation=this.cookieService.get(this.constants.cookieName);
  }
}
