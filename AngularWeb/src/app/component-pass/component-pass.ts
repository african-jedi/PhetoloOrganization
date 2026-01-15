import { Component, inject, OnInit } from '@angular/core';
import { ComponentHighlightNumber } from '../component-highlight-number/component-highlight-number';
import { ActivatedRoute, ActivatedRouteSnapshot, RouterLink } from '@angular/router';
import { MatButtonModule } from '@angular/material/button';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatIconModule } from '@angular/material/icon';
import { SharedService } from '../service/sharedservice';
import { CookieService } from 'ngx-cookie-service';
import { CookieNames } from '../models/cookieNames';

@Component({
  selector: 'app-component-pass',
  standalone: true,
  imports: [ComponentHighlightNumber, MatIconModule, MatTooltipModule, MatButtonModule, RouterLink],
  templateUrl: './component-pass.html',
  styleUrl: './component-pass.scss',
})
export class ComponentPass implements OnInit {
  readonly answer: number;
  private route = inject(ActivatedRoute);
  readonly constants = new CookieNames();

  constructor(private sharedService: SharedService, private cookieService: CookieService) {
    this.answer = Number(this.route.snapshot.paramMap.get('total'));
    sharedService.updateShowRestart(false);
  }

  ngOnInit(): void {
    const cookieObject = this.cookieService.get(this.constants.puzzleCompleted);

    if (!!cookieObject) {
      console.log("Cookie exists");
      let completed: number[] = JSON.parse(cookieObject);
      let newCompleted: number[]=[...completed, completed.length];
      console.log('Completed puzzle', JSON.stringify(newCompleted));

      this.cookieService.set(this.constants.puzzleCompleted, JSON.stringify(newCompleted));
    }else
       this.cookieService.set(this.constants.puzzleCompleted, JSON.stringify([0]));
  }
}
