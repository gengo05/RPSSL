import { Component } from '@angular/core';
import { GameService } from '../services/game.service';
import { CommonModule, NgClass, NgFor, NgIf } from '@angular/common';
import { BehaviorSubject, map } from 'rxjs';

enum GameMove {
  Rock = 0,
  Paper = 1,
  Scissors = 2,
  Spock = 3,
  Lizard = 4,
}

@Component({
  selector: 'app-game',
  standalone: true,
  imports: [NgIf, NgFor, NgClass, CommonModule],
  templateUrl: './game.component.html',
  styleUrl: './game.component.css',
})
export class GameComponent {
  GameMove = GameMove;
  gameResult: any;
  choices: { move: number; name: string }[] = [];
  constructor(private gameService: GameService) {}

  ngOnInit(): void {
    this.loadChoices();
  }

  loadChoices(): void {
    this.gameService.getChoices().subscribe(
      (data) => {
        this.choices = data;
      },
      (error) => {
        console.error('Error fetching choices', error);
        throw new Error('Error fetching choices');
      }
    );
  }

  playMove(move: number): void {
    this.gameService.playGame(move).subscribe(
      (result) => {
        this.gameResult = result;
        this.gameService.notifyScoreboardUpdate();
      },
      (error) => {
        console.error('Error playing the game', error);
        throw new Error('Error playing the game');
      }
    );
  }

  playRandomChoice(): void {
    this.gameService.getRandomChoice().subscribe(
      (data) => {
        this.playMove(data.move);
      },
      (error) => {
        console.error('Error fetching random choice', error);
      }
    );
  }

  getIconClass(choiceName: string): string {
    switch (choiceName.toLowerCase()) {
      case 'rock':
        return 'fas fa-hand-rock';
      case 'paper':
        return 'fas fa-hand-paper';
      case 'scissors':
        return 'fas fa-hand-scissors';
      case 'lizard':
        return 'fas fa-hand-lizard';
      case 'spock':
        return 'fas fa-hand-spock';
      default:
        return 'fas fa-hand';
    }
  }
}
