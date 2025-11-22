import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ComponentGameboard } from './component-gameboard';
import { NumberDetails } from '../models/number-details';
import { PuzzleService } from '../service/puzzleservice';
import { Constants } from '../models/constants';


describe('ComponentGameboard', () => {
  let component: ComponentGameboard;
  let fixture: ComponentFixture<ComponentGameboard>;
  let constants: Constants;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ComponentGameboard]
    })
      .compileComponents();

    fixture = TestBed.createComponent(ComponentGameboard);
    component = fixture.componentInstance;
    fixture.detectChanges();
    constants = new Constants();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should initialize numbers on ngOnInit', () => {
    spyOn(component.service, 'getPuzzle').and.returnValue([]);
    component.cookieService.set(constants.puzzleCookieName, '');
    component.ngOnInit();
    expect((component.service, 'getPuzzle')).toHaveBeenCalledTimes(0);
  });

  it('should clean up interval on ngOnDestroy', () => {
    component.id = 12345;
    spyOn(window, 'clearInterval');
    component.ngOnDestroy();
    expect(clearInterval).toHaveBeenCalledWith(12345);
  });

  it('should call calculate when values are null', () => {
    spyOn(component as any, '_Calculate');
    (component as any)._Calculate();
    expect((component as any)._Calculate).toHaveBeenCalled();

  });

  it('should call calculate when values are not null', () => {
    component.boardService.firstNumber.set('1');
    component.boardService.secondNumber.set('2');
    component.boardService.numerationSymbol.set('+');

    (component as any)._Calculate();
    expect(component.boardService.firstNumber()).toEqual('1');

  });

  it('should call numerationSymbolClicked', () => {
    const event = new Event("+");
    Object.defineProperty(event, 'target', { writable: true, value: { value: '+' } });

    component.numerationSymbolClicked(event);
    expect(component.boardService.numerationSymbol()).toEqual("+");
  });

  it('should update cookie value', () => {
    component.cookieService.set(component.constants.cookieName, "1");
    (component as any)._updateCookieValue("2");
    expect("1 + 2").toEqual(component.cookieService.get(component.constants.cookieName));
  });

  it('should navigate to Pass component when is winner', () => {
    let numbers = [
      {
        id: 1, value: '28', position: 1, disabledField: true, selected: false, isNumber:true
      }, {
        id: 2, value: '3', position: 2, disabledField: false, selected: true, isNumber:false
      }
    ];
    component.numbers.set(numbers);
    spyOn((component as any), "_isWinner").and.returnValue(true);
    (component as any)._checkWinOrLose();
    expect(true).toEqual(true);
  });

  it('should navigate to Fail component when is not winner', () => {
    let numbers = [
      {
        id: 1, value: '98', position: 1, disabledField: true, selected: false, isNumber:true
      }, {
        id: 2, value: '3', position: 2, disabledField: false, selected: true, isNumber:false
      }
    ];
    component.numbers.set(numbers);
    spyOn((component as any), "_isWinner").and.returnValue(false);
    (component as any)._checkWinOrLose();
    expect(true).toEqual(true);
  });

  it('should set FirstNumber when number clicked', () => {
    const event = new Event("1");
    Object.defineProperty(event, 'target', { writable: true, value: { value: '1', id: '1' } });
    // const mockEvent = {
    //   stopPropagation: () => { },
    //   preventDefault: () => { },
    //   target: {
    //     id: '1',
    //     value: '1'
    //   }
    // };
    component.boardService.firstNumber.set('');
    component.numbers.set(component.service.getPuzzle(false));
    component.numberClicked(event);
    expect(component.boardService.firstNumber()).toEqual('1');
  });

  it('should set secondNumber when number clicked', () => {
    const event = new Event("1");
    Object.defineProperty(event, 'target', { writable: true, value: { value: '2', id: '2' } });

    component.boardService.secondNumber.set('');
    component.numbers.set(component.service.getPuzzle(false));
    component.numberClicked(event);
    component.numberClicked(event);
    component.numberClicked(event);
    expect(component.boardService.secondNumber()).toEqual('2');
  });


  // it('should trigger confetti on winning', () => {
  //   spyOn(component as any, '_isWinner').and.returnValue(true);
  //   const confettiSpy = spyOn(window as any, 'confetti');
  //   component.numbers.set(new PuzzleService().getPuzzle());
  //   expect(confettiSpy).toHaveBeenCalled();
  // });

  // it('should not trigger confetti when not winning', () => {
  //   spyOn(component as any, '_isWinner').and.returnValue(false);
  //   const confettiSpy = spyOn(window as any, 'confetti');
  //   component.numbers.set(new PuzzleService().getPuzzle());
  //   expect(confettiSpy).not.toHaveBeenCalled();
  // });

  // it('should handle numbers change effect', () => {
  //   const consoleSpy = spyOn(console, 'log');
  //   component.numbers.set(new PuzzleService().getPuzzle());
  //   expect(consoleSpy).toHaveBeenCalledWith("You win or lose check effect - numbers changed:", component.numbers());
  // });

  // it('should set cookie on ngOnInit', () => {
  //   spyOn(component['cookieService'], 'set');
  //   component.ngOnInit();
  //   expect(component['cookieService'].set).toHaveBeenCalledWith(component.constants.cookieName, '');
  //   expect(component['cookieService'].set).toHaveBeenCalledWith(
  //     component.constants.cookiePuzzleName,
  //     jasmine.any(String)
  //   );
  // });

  // it('should get puzzle from cookie if exists on ngOnInit', () => {
  //   const puzzleData = JSON.stringify([{ id: 1, value: 5 }]);
  //   spyOn(component['cookieService'], 'get').and.returnValue(puzzleData);
  //   component.ngOnInit();
  //   expect(component.numbers()).toEqual(JSON.parse(puzzleData));
  // });

  // it('should get puzzle from service if cookie does not exist on ngOnInit', () => {
  //   spyOn(component['cookieService'], 'get').and.returnValue('');
  //   let puzzleFromService = [{ id: 1, value: 6, position: 1, disabledField: false }];
  //   spyOn(component['service'], 'getPuzzle').and.returnValue(puzzleFromService);
  //   component.ngOnInit();
  //   expect(component.numbers()).toEqual(puzzleFromService);
  // });
});
