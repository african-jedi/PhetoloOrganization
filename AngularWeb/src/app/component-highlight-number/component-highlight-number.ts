import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-component-highlight-number',
  imports: [],
  standalone: true,
  templateUrl: './component-highlight-number.html',
  styleUrl: './component-highlight-number.scss',
})
export class ComponentHighlightNumber {
  @Input() answer = 0;
  passOrfail = "";

  ngOnInit() {
    this.passOrfail = this.answer === 28 ? 'pass' : 'fail';
  }
}
