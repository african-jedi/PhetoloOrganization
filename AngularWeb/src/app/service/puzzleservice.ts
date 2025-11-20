import { Injectable } from '@angular/core';
import { NumberDetails } from '../models/number-details';
import { httpResource } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class PuzzleService {
  getPuzzle(disabled: boolean = true): NumberDetails[] {
    let numbers = [{
      id: 1, value: "1", position: 1, disabledField: disabled, isNumber: true
    }, {
      id: 2, value: "8", position: 2, disabledField: disabled, isNumber: true
    }, {
      id: 3, value: "x", position: 3, disabledField: disabled, isNumber: false
    }, {
      id: 4, value: "÷", position: 4, disabledField: disabled, isNumber: false
    }, {
      id: 5, value: "2", position: 5, disabledField: disabled, isNumber: true
    }, {
      id: 6, value: "9", position: 6, disabledField: disabled, isNumber: true
    }, {
      id: 7, value: "-", position: 7, disabledField: disabled, isNumber: false
    }, {
      id: 8, value: "5", position: 8, disabledField: disabled, isNumber: true
    },
   {
      id: 9, value: "+", position: 9, disabledField: disabled, isNumber: false
    }];

    return numbers;
  }

  getTodaysPuzzle(): NumberDetails[] {
    const numbers = httpResource<PuzzleAPIData>(() => 'api/getTodayPuzzle');
    return numbers.value()?.numbers ?? [];
  }
}

interface PuzzleAPIData {
  errorMsg: string,
  dateTime: Date,
  hasWinner: boolean,
  numbers: NumberDetails[]
}
