import { Component, inject, OnChanges, SimpleChanges } from '@angular/core';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { MatTooltipModule } from '@angular/material/tooltip';
import { ComponentTipsDialog } from '../component-tips-dialog/component-tips-dialog';
import { MatIconModule } from '@angular/material/icon';
import { CookieService } from 'ngx-cookie-service';
import { Constants } from '../models/constants';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-component-header',
  imports: [MatDialogModule, ComponentTipsDialog, MatIconModule, MatTooltipModule, RouterLink],
  templateUrl: './component-header.html',
  styleUrl: './component-header.scss',
})
export class ComponentHeader implements OnChanges {
  showRestart = false;
  readonly cookieService = inject(CookieService);
  readonly constants = new Constants();
  constructor(public dialog: MatDialog) {
    const cookieObject = this.cookieService.get(this.constants.cookieName);

    if (!!cookieObject) {
      this.showRestart = true;
    }
  }

  ngOnChanges(changes: SimpleChanges): void {
    console.log("Header on change check - showRestart:", this.showRestart);
    const cookieObject = this.cookieService.get(this.constants.cookieName);
    if (!!cookieObject) {
      this.showRestart = true;
    } else {
      this.showRestart = false;
    }
  }

  DisplayTipsDialog(): void {
    const dialogRef = this.dialog.open(ComponentTipsDialog);
  }
}
