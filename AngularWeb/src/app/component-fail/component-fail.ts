import { Component, inject, OnInit } from '@angular/core';
import { ComponentHighlightNumber } from '../component-highlight-number/component-highlight-number';
import { ActivatedRoute } from '@angular/router';
import { MatButtonModule } from '@angular/material/button';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatIconModule } from '@angular/material/icon';
import { RouterLink } from '@angular/router';
import { SharedService } from '../service/sharedservice';
import { CookieNames } from '../models/cookieNames';
import { CookieService } from 'ngx-cookie-service';

@Component({
  selector: 'app-component-fail',
  imports: [ComponentHighlightNumber, MatIconModule, MatTooltipModule, MatButtonModule, RouterLink],
  templateUrl: './component-fail.html',
  styleUrl: './component-fail.scss',
})
export class ComponentFail implements OnInit {
  readonly answer: number;
  private route = inject(ActivatedRoute);
  isNewPuzzle: boolean = false;
  constants = new CookieNames();

  constructor(private sharedService: SharedService, private cookieService: CookieService) {
    this.answer = Number(this.route.snapshot.paramMap.get('total'));
    sharedService.updateShowRestart(false);
  }

  ngOnInit(): void {
    const cookieObject = this.cookieService.get(this.constants.puzzleCompleted);

    if (!!cookieObject) {
      console.log("Cookie exists");
      let completed: number[] = JSON.parse(cookieObject);
      if (completed.length > 0)
        this.isNewPuzzle = true;
    }
  }
}
