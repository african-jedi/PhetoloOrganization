import { Injectable, signal } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class GameBoardService {
  firstNumber = signal<string>('');
  secondNumber = signal<string>('');
  numerationSymbol = signal<string>('');

  calculate(): number {
    let calculation = 0;
    switch (this.numerationSymbol()) {
      case "+":
        return Number(this.firstNumber()) + Number(this.secondNumber());
        break;
      case "-":
        return Number(this.firstNumber()) - Number(this.secondNumber());
        break;
      case "x":
        return Number(this.firstNumber()) * Number(this.secondNumber());
        break;
      case "÷":
        return Number((Number(this.firstNumber()) / Number(this.secondNumber())).toFixed(2));
        break;
      default:
        throw new Error("Invalid numeration symbol");
    }
  }
}
