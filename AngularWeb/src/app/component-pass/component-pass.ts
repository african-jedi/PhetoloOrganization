import { Component, inject} from '@angular/core';
import { ComponentHighlightNumber } from '../component-highlight-number/component-highlight-number';
import { ActivatedRoute, ActivatedRouteSnapshot } from '@angular/router';

@Component({
  selector: 'app-component-pass',
  standalone: true,
  imports: [ComponentHighlightNumber],
  templateUrl: './component-pass.html',
  styleUrl: './component-pass.scss',
})
export class ComponentPass {
   readonly answer: number;
   private route = inject(ActivatedRoute);

   constructor(){
     this.answer = Number(this.route.snapshot.paramMap.get('total'));
   }
}
