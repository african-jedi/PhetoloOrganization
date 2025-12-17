import { Component, OnDestroy, inject, OnInit } from '@angular/core';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { MatTooltipModule } from '@angular/material/tooltip';
import { ComponentTipsDialog } from '../component-tips-dialog/component-tips-dialog';
import { MatIconModule } from '@angular/material/icon';
import { SharedService } from '../service/sharedservice';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import { Router } from '@angular/router';
import { SignalRService } from '../service/signalrservice';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-component-header',
  imports: [MatDialogModule, MatIconModule, MatTooltipModule],
  templateUrl: './component-header.html',
  styleUrl: './component-header.scss',
})
export class ComponentHeader implements OnInit, OnDestroy {
  showRestart = false;
  private destroy$ = new Subject<void>();

  constructor(public dialog: MatDialog
    , private sharedService: SharedService
    , private router: Router
    , private signalRService: SignalRService
    , private snackBar: MatSnackBar) {
    console.log("ComponentHeader: Constructor called");
    // subscribe to changes in shared service when showRestart is updated
    this.sharedService.showRestart$
      .pipe(takeUntil(this.destroy$))
      .subscribe(value => {
        this.showRestart = value;
        console.log("ComponentHeader: showRestart updated to", value);
      });
  }

  ngOnInit(): void {
    console.log("ComponentHeader: ngOnInit called");
    this.signalRService.startConnection();
    this.signalRService.addWinnerNotificationListener((message: string) => {
       this.snackBar.open(message, 'close',{
        duration: 5000
      });
    });
  }

  ngOnDestroy(): void {
    this.destroy$.next();
    this.destroy$.complete();
  }

  DisplayTipsDialog(): void {
    const dialogRef = this.dialog.open(ComponentTipsDialog);
  }

  RestartGame(): void {

    this.sharedService.updateShowRestart(false);
    // Re-run initialization
    // todo: find better solution to reset the game without reloading
    //location.reload();
    this.sharedService.updateRestart(true);
  }
}
