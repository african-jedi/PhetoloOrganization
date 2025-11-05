import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { NumberDetails } from '../models/number-details';

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
  numbers: NumberDetails[] | undefined;
  errorMsg: string | undefined;

  constructor() {
    this.numbers = [{
      id: 1, value: 6, position: 1, disabledField: false
    }, {
      id: 2, value: 3, position: 2, disabledField: false
    }, {
      id: 3, value: 5, position: 3, disabledField: false
    }, {
      id: 4, value: 4, position: 4, disabledField: false
    }, {
      id: 5, value: 8, position: 5, disabledField: false
    }, {
      id: 6, value: 9, position: 6, disabledField: false
    }, {
      id: 7, value: 10, position: 7, disabledField: false
    }, {
      id: 8, value: 7, position: 8, disabledField: false
    }];
  }

  numberClicked(event: Event) {
    console.log("number clicked:", event);
    const button = event.target as HTMLButtonElement;
    console.log('Button name:', button.value);
    console.log('Button id:', button.id);

    //set first number in calculation section if availabe
    if (this.firstNumber === undefined) {
      this.firstNumber = Number(button.value);
      this._DisableButton(Number(button.id));
      this._Calculate();
    }
    //set second number in calculation section if available
    else if (this.secondNumber === undefined) {
      this.secondNumber = Number(button.value);
      this._DisableButton(Number(button.id));
      this._Calculate();
    } else {
      //send toast message:
      //numbers have been slected, select numeration symbol or click selected numbers to remove
      console.log(`numbers (${this.firstNumber} and ${this.secondNumber}) have been slected, select numeration symbol or click selected numbers to remove`);
    }
  }

  numerationSymbolClicked(event: Event) {
    console.log("numeration sybol clicked:", event);
    const button = event.target as HTMLButtonElement;
    console.log('Button name:', button.value);

    this.numerationSymbol = button.value;
    this._Calculate();
  }

  private _Calculate(): void {
    //calculate the results
    let calculation = 0;
    if (this.firstNumber !== undefined && this.secondNumber !== undefined && this.numerationSymbol !== '') {
      switch (this.numerationSymbol) {
        case "+":
          calculation = this.firstNumber + this.secondNumber;
          break;
        case "-":
          calculation = this.firstNumber - this.secondNumber;
          break;
        case "x":
          calculation = this.firstNumber * this.secondNumber;
          break;
        case "÷":
          calculation = this.firstNumber / this.secondNumber;
          break;
        default:
          this.errorMsg = "Calculation failed";
      }
      console.log(calculation);
      console.log(this.numerationSymbol);
      this._removeButton();
      this._addButton(calculation);
    }
  }

  private _DisableButton(id: number): void {
    const selectedNumber = this.numbers?.find(c => c.id === id);
    if (selectedNumber?.id === id) {
      selectedNumber.disabledField = true;
      selectedNumber.selected=true;
    }
  }

  private _removeButton(): void {
    const selectedNumbers = this.numbers?.filter(c => c.selected === true);
    if (selectedNumbers?.length === 2) {
      selectedNumbers[0].calculated = selectedNumbers[1].calculated = true;
      selectedNumbers[0].selected = selectedNumbers[1].selected = false;
      this.firstNumber=this.secondNumber=undefined;
      this.numerationSymbol='';
    } else {
      this.errorMsg = "More than 2 items disabled";
      console.log(this.errorMsg);
      console.log(this.numbers);
    }
  }

  private _addButton(total:number): void{
    console.log("add button");
     this.numbers?.push({
       id: this.numbers.length+1,
       value: total,
       disabledField: false,
       position: this.numbers.length+1
     });

     console.log(this.numbers);
  }
}
