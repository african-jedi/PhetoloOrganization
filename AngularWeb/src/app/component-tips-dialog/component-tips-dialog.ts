import { Component, inject } from '@angular/core';
import { ComponentTips } from '../component-tips/component-tips';
import { MatButton } from '@angular/material/button';
import {
  MatDialogModule,
  MatDialogRef,
  MAT_DIALOG_DATA,
} from '@angular/material/dialog';

@Component({
  selector: 'app-component-tips-dialog',
  imports: [MatDialogModule, ComponentTips, MatButton],
  templateUrl: './component-tips-dialog.html',
  styleUrl: './component-tips-dialog.scss',
})
export class ComponentTipsDialog {
  constructor(public dialogRef: MatDialogRef<ComponentTipsDialog>) {
  }

  onExit(): void {
    this.dialogRef.close();
  }
}
