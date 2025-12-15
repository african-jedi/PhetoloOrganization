import { Component, inject} from '@angular/core';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { MatTooltipModule } from '@angular/material/tooltip';
import { ComponentTipsDialog } from '../component-tips-dialog/component-tips-dialog';
import { MatIconModule } from '@angular/material/icon';
import { CookieService } from 'ngx-cookie-service';
import { Constants } from '../models/constants';

@Component({
  selector: 'app-component-header',
  imports: [MatDialogModule, ComponentTipsDialog, MatIconModule, MatTooltipModule],
  templateUrl: './component-header.html',
  styleUrl: './component-header.scss',
})
export class ComponentHeader {
  showRestart = false;
  readonly cookieService = inject(CookieService);
  readonly constants = new Constants();
  constructor(public dialog: MatDialog) {
      const cookieObject = this.cookieService.get(this.constants.puzzleCookieName);

      if (!!cookieObject) {
        this.showRestart = true;
      }
  }

  DisplayTipsDialog(): void {
    const dialogRef = this.dialog.open(ComponentTipsDialog);
  }
}
