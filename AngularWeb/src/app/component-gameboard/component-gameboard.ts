import { Component, OnInit, OnDestroy, inject, signal, effect, SimpleChanges, OnChanges } from '@angular/core';
import { NumberDetails } from '../models/number-details';
import { Router } from '@angular/router';
import { PuzzleService } from '../service/puzzleservice';
import { CookieService } from 'ngx-cookie-service';
import { Constants } from '../models/constants';
import confetti from 'canvas-confetti';
import { ComponentTimer } from '../component-timer/component-timer';
import { GameBoardService } from '../service/game-board-service';
import { SharedService } from '../service/sharedservice';

@Component({
  selector: 'app-component-gameboard',
  standalone: true,
  imports: [ComponentTimer],
  templateUrl: './component-gameboard.html',
  styleUrl: './component-gameboard.scss',
})
export class ComponentGameboard implements OnInit, OnDestroy, OnChanges {
  readonly service = inject(PuzzleService);
  readonly cookieService = inject(CookieService);
  numbers = signal<NumberDetails[]>([]);
  errorMsg = '';
  id = 0;
  endGame = false;

  private router = inject(Router);
  readonly constants = new Constants();

  constructor(public boardService: GameBoardService, private sharedService: SharedService) {
    console.log("ComponentGameboard: Constructor called before lifecycle hooks");
    this.initializeGameBoard();
    effect(() => {
      console.log("You win or lose check effect - numbers changed:", this.numbers());

      //set showRestart in shared service
      var result = this.numbers().filter(c => c.calculated === true);
      if (result.length > 0)
        this.sharedService.updateShowRestart(true);

      //trigger confetti if winner
      if (this._isWinner()) {
        confetti({
          particleCount: 100,
          spread: 160,
          origin: { y: 0.6 },
        });
      }

      if (this.endGame) {
        this.id = setInterval(() => {
          this._checkWinOrLose();
        }, 3000);
      }

      setInterval(() => {
        this._Calculate();
      }, 500);
    });
  }

  ngOnChanges(changes: SimpleChanges): void {
    //this should not print since the are no input bindings in the component
    console.log("ComponentGameboard: ngOnChanges called after constructor");
  }

  ngOnInit() {
    console.log("ComponentGameboard: ngOnInit called after constructor because component has no input; it will not call ngOnChanges life cycle hook!");
  }

  ngOnDestroy() {
    if (this.id) {
      clearInterval(this.id);
    }
  }

  initializeGameBoard() {
    const cookieObject = this.cookieService.get(this.constants.puzzleCookieName);
    let puzzleNumbers: NumberDetails[] = [];

    if (!!cookieObject) {
      console.log("Cookie exists");
      puzzleNumbers = JSON.parse(cookieObject);
      console.log("Puzzle numbers:", JSON.stringify(puzzleNumbers));
    } else
      puzzleNumbers = this.service.getPuzzle(false);
    //puzzleNumbers = this.service.getTodaysPuzzle();

    //reset: equation cookie
    this.cookieService.set(this.constants.cookieName, '');

    if (puzzleNumbers.length === 0) {
      this.cookieService.set(this.constants.puzzleCookieName, '');
      this.numbers?.set([]);
    } else {
      this.numbers?.set(puzzleNumbers);

      this.cookieService.set(this.constants.puzzleCookieName, JSON.stringify(puzzleNumbers));
      console.log("Puzzle numbers:", JSON.stringify(puzzleNumbers));
    }
  }

  numberClicked(event: Event) {
    console.log('number clicked:', event);
    const button = event.target as HTMLButtonElement;
    console.log('Button name:', button.value);
    console.log('Button id:', button.id);

    const activeNumbers = this.numbers().filter(c => c.disabledField === false || c.selected == true);
    if (activeNumbers !== undefined && activeNumbers.length >= 2) {
      //set first number in calculation section if availabe
      if (this.boardService.firstNumber() === '') {
        this.boardService.firstNumber.set(button.value);
        this._DisableButton(Number(button.id));
      }
      //set second number in calculation section if available
      else if (this.boardService.secondNumber() === '') {
        this.boardService.secondNumber.set(button.value);
        this._DisableButton(Number(button.id));
      } else {
        //send toast message:
        //numbers have been slected, select numeration symbol or click selected numbers to remove
        console.log(`numbers (${this.boardService.firstNumber()} and ${this.boardService.secondNumber()}) have been slected, select numeration symbol or click selected numbers to remove`);
      }
    }
  }

  numerationSymbolClicked(event: Event) {
    //if clicked again - you need to deselect the selected numeration
    if (this.boardService.numerationSymbol() !== '') {
      //get all list of non numbers and set disabled and selected to true
      const selectedNumerators = this.numbers().filter(c => c.selected === true && c.isNumber === false);

      selectedNumerators.forEach(element => {
        element.disabledField = false;
        element.selected = false;
      });
    }

    console.log("numeration symbol clicked:", event);
    const button = event.target as HTMLButtonElement;
    console.log('Button name:', button.value);

    this.boardService.numerationSymbol.set(button.value);
    this._DisableButton(Number(button.id));
  }

  private _Calculate(): void {
    //calculate the results
    let calculation = 0;
    if (this.boardService.firstNumber() !== '' && this.boardService.secondNumber() !== '' && this.boardService.numerationSymbol() !== '') {

      calculation = this.boardService.calculate();
      console.log(`calculation result: ${this.boardService.firstNumber()} ${this.boardService.numerationSymbol()} ${this.boardService.secondNumber()} = ${calculation}`);

      this._updateCookieValue(`(${this.boardService.firstNumber()} ${this.boardService.numerationSymbol()} ${Number(this.boardService.secondNumber())})`);
      this._removeButton();
      this._addButton(calculation);
    }
  }

  private _NavigateToComponent(url: string, total: number) {
    if (this.id) {
      clearInterval(this.id);
    }

    this.router.navigate([url, total]);
  }

  private _DisableButton(id: number): void {
    console.log(`Disable button with id: ${id}`);
    const selectedNumber = this.numbers().find(c => c.id === id);
    if (selectedNumber?.id === id) {
      selectedNumber.disabledField = true;
      selectedNumber.selected = true;
      console.log("Selected number:", selectedNumber);
    }
  }

  private _removeButton(): void {
    const selectedNumbers = this.numbers().filter(c => c.selected === true);
    if (selectedNumbers?.length === 3) {
      selectedNumbers[0].calculated = selectedNumbers[1].calculated = selectedNumbers[2].calculated = true;
      selectedNumbers[0].selected = selectedNumbers[1].selected = selectedNumbers[2].selected = false;
      this.boardService.firstNumber.set('');
      this.boardService.secondNumber.set('');
      this.boardService.numerationSymbol.set('');
    } else {
      this.errorMsg = "More than 2 items disabled";
      console.log(this.errorMsg);
      console.log(this.numbers);
    }
  }

  private _addButton(total: number): void {
    console.log("add button");
    let colour = 'black';
    const activeNumbers = this.numbers().filter(c => c.disabledField === false);
    console.log(`active number:${activeNumbers}`);
    if (activeNumbers?.length == 0) {
      this.endGame = true;
      if (total !== 28) {
        colour = 'red';
        this.errorMsg = `${total} is not equal to 28 - You lost!`;
      } if (total === 28)
        colour = 'green';
    }

    this.numbers.set([...this.numbers(), {
      id: this.numbers().length + 1,
      value: total.toString(),
      disabledField: false,
      position: this.numbers().length + 1,
      colour: colour,
      isNumber: true
    }]);

    console.log("New button:", total);
  }

  private _checkWinOrLose() {
    console.log('Check win or lose every Five Seconds.', new Date());
    let total = this._finalNumber();
    console.log(`Final number: ${total}`);
    if (total) {
      if (this._isWinner()) {
        this._NavigateToComponent("/pass", total ? total : 0);
      } else {
        this._NavigateToComponent("/fail", total ? total : 0);
      }
    }
  }

  private _updateCookieValue(equation: string) {
    let value = this.cookieService.get(this.constants.cookieName);
    if (value === '')
      this.cookieService.set(this.constants.cookieName, equation, 1);
    else
      this.cookieService.set(this.constants.cookieName, `${value} + ${equation}`, 1);

    console.log(`Cookie value: ${this.cookieService.get(this.constants.cookieName)}`);
  }

  private _finalNumber(): number | undefined {
    const activeNumbers = this.numbers().filter(c => c.disabledField === false || c.selected == true);
    if (activeNumbers !== undefined && activeNumbers.length === 1) {
      return Number(activeNumbers[0].value);
    }
    return undefined;
  }

  private _isWinner(): boolean {
    let finalNumber = this._finalNumber();

    return finalNumber === 28;
  }
}
