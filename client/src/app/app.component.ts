import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { ScoreboardComponent } from './scoreboard/scoreboard.component';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { GameComponent } from './game/game.component';
import { LoginComponent } from './login/login.component';
import { AuthService } from './services/auth.service';
import { NgIf } from '@angular/common';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    NgIf,
    RouterOutlet,
    ScoreboardComponent,
    MatDialogModule,
    GameComponent,
  ],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
})
export class AppComponent {
  constructor(public dialog: MatDialog, private authService: AuthService) {}

  openLoginDialog(): void {
    this.dialog.open(LoginComponent, {
      width: '300px',
    });
  }

  isAuthenticated(): boolean {
    return this.authService.isAuthenticated(); // Check if user is logged in
  }

  logOut() {
    this.authService.logout();
  }
}
