import { Component } from '@angular/core';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatLabel } from '@angular/material/form-field';
import { MatSidenavModule } from '@angular/material/sidenav';
import {
  MatSlideToggleChange,
  MatSlideToggleModule,
} from '@angular/material/slide-toggle';
import { MatListModule } from '@angular/material/list';
import { RouterLink, RouterLinkActive, RouterOutlet } from '@angular/router';

@Component({
  selector: 'FlashCards-header',
  imports: [
    MatToolbarModule,
    MatButtonModule,
    MatIconModule,
    MatLabel,
    MatSidenavModule,
    MatSlideToggleModule,
    RouterOutlet,
    MatListModule,
    RouterLink,
    RouterLinkActive,
  ],
  templateUrl: './header.component.html',
  styleUrl: './header.component.scss',
})
export class HeaderComponent {
  isDarkTheme = false;

  onThemeChange($event: MatSlideToggleChange) {
    this.isDarkTheme = $event.checked;
    const element = document.getElementsByClassName('custom-theme')[0];
    if (this.isDarkTheme) {
      element.classList.add('dark-theme');
      element.classList.remove('light-theme');
    } else {
      element.classList.add('light-theme');
      element.classList.remove('dark-theme');
    }
  }
}
