import { TitleCasePipe } from '@angular/common';
import { Component } from '@angular/core';
import { ComponentGameboard } from '../component-gameboard/component-gameboard';
import { ComponentGameboardCalc } from '../component-gameboard-calc/component-gameboard-calc';

@Component({
  selector: 'app-component-new-puzzle',
  imports: [TitleCasePipe, ComponentGameboard, ComponentGameboardCalc],
  templateUrl: './component-new-puzzle.html',
  styleUrl: './component-new-puzzle.scss',
})
export class ComponentNewPuzzle {
    title="new puzzle";
}
