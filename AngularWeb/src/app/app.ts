import { Component} from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { ComponentHeader } from './component-header/component-header';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, ComponentHeader],
  templateUrl: './app.html',
  styleUrl: './app.scss'
})
export class App {
}
