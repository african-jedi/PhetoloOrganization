import { Component, inject} from '@angular/core';
import { ComponentHighlightNumber } from '../component-highlight-number/component-highlight-number';
import { ActivatedRoute, ActivatedRouteSnapshot } from '@angular/router';
import { MatButtonModule } from '@angular/material/button';
import { MatTooltipModule} from '@angular/material/tooltip';
import { MatIconModule} from '@angular/material/icon';
import { SharedService } from '../service/sharedservice';

@Component({
  selector: 'app-component-pass',
  standalone: true,
  imports: [ComponentHighlightNumber, MatIconModule, MatTooltipModule, MatButtonModule],
  templateUrl: './component-pass.html',
  styleUrl: './component-pass.scss',
})
export class ComponentPass {
   readonly answer: number;
   private route = inject(ActivatedRoute);

   constructor(private sharedService: SharedService) {
     this.answer = Number(this.route.snapshot.paramMap.get('total'));
     sharedService.updateShowRestart(false);
   }
}
