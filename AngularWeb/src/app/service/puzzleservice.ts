import { Injectable } from '@angular/core';
import { NumberDetails } from '../models/number-details';

@Injectable({
  providedIn: 'root'
})
export class PuzzleService {
   getPuzzle():NumberDetails[]{
     let numbers = [{
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

    return numbers;
   }
}
