import { Injectable, NgZone } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ErrorHandlerDialogComponent } from '../error-handler-dialog/error-handler-dialog.component';

@Injectable({
  providedIn: 'root',
})
export class NotificationService {
  constructor(private snackbar: MatSnackBar, private zone: NgZone) {}

  showClientError(message: string): void {
    this.zone.run(() => {
      console.log(message);
      this.snackbar.open(`Error: ${message}`, 'OK', {
        panelClass: ['error-snack'],
      });
    });
  }

  showNonErrorSnackBar(message: string, duration = 6000) {
    this.snackbar.open(message, 'OK', {
      panelClass: ['non-error-snack'],
      duration,
    });
  }
}
