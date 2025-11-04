import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-component-gameboard',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './component-gameboard.html',
  styleUrl: './component-gameboard.scss',
})
export class ComponentGameboard {
  firstNumber: number | undefined;
  secondNumber: number | undefined;
  numerationSymbol: string = '';
  numbers: [number, number, number, number, number, number, number, number] | undefined;

  constructor() {
    this.numbers = [9, 8, 5, 7, 8, 9, 10, 1];
  }

  numberClicked(event: Event) {
    console.log("number clicked:", event);
    const button = event.target as HTMLButtonElement;
    console.log('Button name:', button.value);

    //set first number in calculation section if availabe
    if(this.firstNumber === undefined)
      this.firstNumber=Number(button.value);
    //set second number in calculation section if available
    else if(this.secondNumber === undefined)
      this.secondNumber=Number(button.value);

    //send toast message:
    //numbers have been slected, select numeration symbol or click selected numbers to remove
    console.log(`numbers (${this.firstNumber} and ${this.secondNumber}) have been slected, select numeration symbol or click selected numbers to remove`);

  }

  numerationSymbolClicked(event: Event){
    console.log("numeration sybol clicked:", event);
    const button = event.target as HTMLButtonElement;
    console.log('Button name:', button.value);

    this.numerationSymbol= button.value;
  }

  private _Calculate(): void{
    //calculate the results

    //remove selected numbers
  }
}
