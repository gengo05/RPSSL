import { Component } from '@angular/core';
import { GameService } from '../services/game.service';
import { GameResult } from '../DTOs/game-result.model';
import { NgFor } from '@angular/common';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-scoreboard',
  standalone: true,
  imports: [NgFor],
  templateUrl: './scoreboard.component.html',
  styleUrl: './scoreboard.component.css',
})
export class ScoreboardComponent {
  results: GameResult[] = [];
  isDialogOpen: boolean = false;

  constructor(private gameService: GameService, private dialog: MatDialog) {}

  ngOnInit(): void {
    this.loadScoreboard();
    this.gameService.scoreboardUpdated$.subscribe(() => {
      this.loadScoreboard();
    });
  }

  loadScoreboard(): void {
    this.gameService.getScoreboard().subscribe(
      (data) => {
        this.results = data;
      },
      (error) => {
        throw new Error(
          'An error occurred while fetching the scoreboard data. Please try again later. '
        );
      }
    );
  }

  resetScoreboard(): void {
    this.gameService.resetScoreboard().subscribe(
      () => {
        this.results = [];
      },
      (error) => {
        throw new Error(
          'An error occurred while resetting the scoreboard. Please try again later. '
        );
      }
    );
  }
}
