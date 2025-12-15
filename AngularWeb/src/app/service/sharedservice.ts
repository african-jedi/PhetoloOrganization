import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SharedService {
   private showRestartSubject = new BehaviorSubject<boolean>(false);
   showRestart$ = this.showRestartSubject.asObservable();
   
   constructor() { }
   
   updateShowRestart(value: boolean) {
     this.showRestartSubject.next(value);
   }

   getShowRestartValue(): boolean {
     return this.showRestartSubject.getValue();
   }
}
