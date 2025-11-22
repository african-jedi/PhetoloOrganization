import { Component, inject } from '@angular/core';
import { ComponentHighlightNumber } from '../component-highlight-number/component-highlight-number';
import { ActivatedRoute} from '@angular/router';
import { MatButtonModule } from '@angular/material/button';
import { MatTooltipModule} from '@angular/material/tooltip';
import { MatIconModule} from '@angular/material/icon';

@Component({
  selector: 'app-component-fail',
  imports: [ComponentHighlightNumber, MatIconModule, MatTooltipModule, MatButtonModule],
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
