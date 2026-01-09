import { computed, Injectable, signal } from '@angular/core';
import { NumberDetails } from '../models/number-details';
import { httpResource } from '@angular/common/http';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PuzzleService {
  callApi=signal<boolean>(false);
  puzzleResource = httpResource<PuzzleAPIData>(() => this.callApi() ? `${environment.apiUrl}/Puzzle`: undefined);

  // getPuzzle(disabled: boolean = true): NumberDetails[] {
  //   let numbers = [{
  //     id: 1, value: "1", position: 1, disabledField: disabled, isNumber: true
  //   }, {
  //     id: 2, value: "8", position: 2, disabledField: disabled, isNumber: true
  //   }, {
  //     id: 3, value: "x", position: 3, disabledField: disabled, isNumber: false
  //   }, {
  //     id: 4, value: "÷", position: 4, disabledField: disabled, isNumber: false
  //   }, {
  //     id: 5, value: "2", position: 5, disabledField: disabled, isNumber: true
  //   }, {
  //     id: 6, value: "9", position: 6, disabledField: disabled, isNumber: true
  //   }, {
  //     id: 7, value: "-", position: 7, disabledField: disabled, isNumber: false
  //   }, {
  //     id: 8, value: "5", position: 8, disabledField: disabled, isNumber: true
  //   },
  //  {
  //     id: 9, value: "+", position: 9, disabledField: disabled, isNumber: false
  //   }];

  //   return numbers;
  // }

  todayPuzzle= computed(() => {
    console.log('Fetching new puzzle from API:', environment.apiUrl);
    return this.puzzleResource.value()?.items ?? [];
  });
}

export interface PuzzleAPIData {
  Generate: Date,
  items: NumberDetails[]
}

