import { TestBed } from '@angular/core/testing';

import { SharedService } from './sharedservice';

describe('SharedService', () => {
  let service: SharedService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SharedService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  //test updateShowRestart and showRestart$
  it('should update and get showRestart value', (done: DoneFn) => {
    service.updateShowRestart(true);
    service.showRestart$.subscribe((value: boolean) => {
      expect(value).toBeTrue();
      done();
    });
  });

  //test getShowRestartValue
  it('should get current showRestart value', () => {
    service.updateShowRestart(false);
    const currentValue = service.getShowRestartValue();
    expect(currentValue).toBeFalse();
  });

  //test updateRestart and restart$
  it('should update and get restart value', (done: DoneFn) => {
    service.updateRestart(true);
    service.restart$.subscribe((value: boolean) => {
      expect(value).toBeTrue();
      done();
    });

  });

});
