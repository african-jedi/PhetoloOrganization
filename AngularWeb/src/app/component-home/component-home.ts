import { Component } from '@angular/core';
import { ComponentGameboard } from '../component-gameboard/component-gameboard';

@Component({
  selector: 'app-component-home',
  imports: [ComponentGameboard],
  templateUrl: './component-home.html',
  styleUrl: './component-home.scss',
})
export class ComponentHome {

}
