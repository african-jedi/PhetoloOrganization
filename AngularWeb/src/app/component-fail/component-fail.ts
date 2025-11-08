import { Component, inject } from '@angular/core';
import { ComponentHighlightNumber } from '../component-highlight-number/component-highlight-number';
import { ActivatedRoute, ActivatedRouteSnapshot } from '@angular/router';

@Component({
  selector: 'app-component-fail',
  imports: [ComponentHighlightNumber],
  templateUrl: './component-fail.html',
  styleUrl: './component-fail.scss',
})
export class ComponentFail {
readonly answer: number;
   private route = inject(ActivatedRoute);

   constructor(){
     this.answer = Number(this.route.snapshot.paramMap.get('total'));
   }
}
