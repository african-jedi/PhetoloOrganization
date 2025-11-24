import { TestBed } from '@angular/core/testing';

import { GameBoardService } from './game-board-service';

describe('GameBoardService', () => {
  let service: GameBoardService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(GameBoardService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('test firstNumber signal', () => {
    service.firstNumber.set('1');
    expect(service.firstNumber()).toBe('1');
  });

  it('test secondNumber signal', () => {
    service.secondNumber.set('1');
    expect(service.secondNumber()).toBe('1');
  });

  it('test numerationSymbol signal', () => {
    service.numerationSymbol.set('1');
    expect(service.numerationSymbol()).toBe('1');
  });

  it('should calculate addition correctly', () => {
    service.firstNumber.set('5');
    service.secondNumber.set('3');
    service.numerationSymbol.set('+');
    expect(service.calculate()).toBe(8);
  });

  it('should calculate subtraction correctly', () => {
    service.firstNumber.set('5');
    service.secondNumber.set('3');
    service.numerationSymbol.set('-');
    expect(service.calculate()).toBe(2);
  });

  it('should calculate multiplication correctly', () => {
    service.firstNumber.set('5');
    service.secondNumber.set('3');
    service.numerationSymbol.set('x');
    expect(service.calculate()).toBe(15);
  });

  it('should calculate division correctly', () => {
    service.firstNumber.set('6');
    service.secondNumber.set('3');
    service.numerationSymbol.set('÷');
    expect(service.calculate()).toBe(2);
  }); 

  it('should return a number with 2 decimals place', ()=>{
     service.firstNumber.set('30');
    service.secondNumber.set('9');
    service.numerationSymbol.set('÷');
    expect(service.calculate()).toBe(3.33);
  })
  
});
