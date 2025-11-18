import { Component, OnInit, OnDestroy, signal, Input } from '@angular/core';

@Component({
  selector: 'app-component-timer',
  imports: [],
  templateUrl: './component-timer.html',
  styleUrl: './component-timer.scss',
})
export class ComponentTimer implements OnInit, OnDestroy {
  userTime = 1;
  displayTime = signal('');
  setTimeintervalObject = 0;
  @Input() stopTime = false;

  ngOnInit() {
    this.setTimeintervalObject = setInterval(() => this.timeHandler(), 1000);
  }

  ngOnDestroy() {
    if (this.setTimeintervalObject) {
      clearInterval(this.setTimeintervalObject);
    }
  }

  private _formatNumberToTime(): string {
    const dateObj = new Date(this.userTime * 1000);
    const hours = dateObj.getUTCHours();
    const minutes = dateObj.getUTCMinutes();
    const seconds = dateObj.getUTCSeconds();

    return `${hours.toString().padStart(2, '0')}:${minutes.toString().padStart(2, '0')}:${seconds.toString().padStart(2, '0')}`
  }

  timeHandler() {
      console.log("Update time", this.userTime);

      if (this.stopTime) {
        console.log("Stop time", this.userTime);
        clearInterval(this.setTimeintervalObject);
      } else {
        this.userTime++;
        this.displayTime.set(this._formatNumberToTime());
      }
  }

}
