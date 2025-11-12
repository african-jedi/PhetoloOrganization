import { Injectable, signal } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class GameBoardService {
  firstNumber = signal<string>('');
  secondNumber = signal<string>('');
  numerationSymbol = signal<string>('');
}
