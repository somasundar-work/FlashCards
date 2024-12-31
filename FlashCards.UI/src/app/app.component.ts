import { Component } from '@angular/core';
import { HeaderComponent } from './layout/header/header.component';

@Component({
  selector: 'FlashCards-root',
  imports: [HeaderComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss',
})
export class AppComponent {
  title = 'FlashCards.UI';
}
