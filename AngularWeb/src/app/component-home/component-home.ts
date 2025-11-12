import { Component } from '@angular/core';
import { ComponentGameboard } from '../component-gameboard/component-gameboard';
import { ComponentGameboardCalc } from '../component-gameboard-calc/component-gameboard-calc';

@Component({
  selector: 'app-component-home',
  imports: [ComponentGameboard, ComponentGameboardCalc],
  templateUrl: './component-home.html',
  styleUrl: './component-home.scss',
})
export class ComponentHome {

}
