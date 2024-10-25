import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class GameService {
  private apiUrl = 'https://localhost:44344/api/';
  private scoreboard = this.apiUrl + 'scoreboard';
  private choice = this.apiUrl + 'choice';

  private scoreboardUpdatedSubject = new BehaviorSubject<void>(undefined);
  scoreboardUpdated$ = this.scoreboardUpdatedSubject.asObservable();

  constructor(private http: HttpClient) {}

  getScoreboard(): Observable<any[]> {
    return this.http.get<any[]>(this.scoreboard);
  }

  resetScoreboard(): Observable<void> {
    return this.http.post<void>(`${this.scoreboard}/reset`, null);
  }

  getChoices(): Observable<{ move: number; name: string }[]> {
    return this.http.get<{ move: number; name: string }[]>(
      `${this.choice}/choices`
    );
  }

  playGame(playerMove: number): Observable<any> {
    return this.http.post(`${this.apiUrl}game`, { playerMove });
  }

  getRandomChoice(): Observable<{ move: number; name: string }> {
    return this.http.get<{ move: number; name: string }>(
      `${this.choice}/choice`
    );
  }

  notifyScoreboardUpdate() {
    this.scoreboardUpdatedSubject.next();
  }
}
