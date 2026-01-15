import { Component } from '@angular/core';
import { MatButton } from '@angular/material/button';
import { MatCard, MatCardActions, MatCardContent, MatCardHeader, MatCardTitle } from '@angular/material/card';
import { MatIcon } from '@angular/material/icon';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-component-error',
  imports: [MatButton, MatIcon, MatCard,MatCardActions,MatCardContent, MatCardTitle, MatCardHeader, RouterLink],
  templateUrl: './component-error.html',
  styleUrl: './component-error.scss',
})
export class ComponentError {

}
