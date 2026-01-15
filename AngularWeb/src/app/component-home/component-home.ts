import { Component } from '@angular/core';
import { ComponentGameboard } from '../component-gameboard/component-gameboard';
import { ComponentGameboardCalc } from '../component-gameboard-calc/component-gameboard-calc';
import { TitleCasePipe } from '@angular/common';

@Component({
  selector: 'app-component-home',
  imports: [ComponentGameboard, ComponentGameboardCalc, TitleCasePipe],
  templateUrl: './component-home.html',
  styleUrl: './component-home.scss',
})
export class ComponentHome {
   title="todays puzzle";
}
