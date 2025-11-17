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
        calculation = Number(this.firstNumber()) + Number(this.secondNumber());
        break;
      case "-":
        calculation = Number(this.firstNumber()) - Number(this.secondNumber());
        break;
      case "x":
        calculation = Number(this.firstNumber()) * Number(this.secondNumber());
        break;
      case "÷":
        calculation = Number(this.firstNumber()) / Number(this.secondNumber());
        break;
      default:
        throw new Error("Invalid numeration symbol");
    }
    return calculation;
  }
}
