import { Component } from '@angular/core';
import { GameBoardService } from '../service/game-board-service';

@Component({
  selector: 'app-component-gameboard-calc',
  imports: [],
  templateUrl: './component-gameboard-calc.html',
  styleUrl: './component-gameboard-calc.scss',
})
export class ComponentGameboardCalc {
    constructor(public boardService: GameBoardService){
    }
}
