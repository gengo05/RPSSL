import { Component, Inject } from "@angular/core";
import { MAT_DIALOG_DATA, MatDialogModule } from "@angular/material/dialog";

@Component({
  selector: "error-handler-dialog",
  styleUrls: ["./error-handler-dialog.component.scss"],
  standalone: true,
  imports: [MatDialogModule],
  template: `
    <h1 mat-dialog-title>
      {{ title }}
    </h1>
    <mat-dialog-content>
      <p>{{ data.message }}</p>
    </mat-dialog-content>
    <mat-dialog-actions align="end">
      <button id="error-btn" mat-raised-button mat-dialog-close>OK</button>
    </mat-dialog-actions>
  `
})
export class ErrorHandlerDialogComponent {
  public title = "Network Error";
  constructor(@Inject(MAT_DIALOG_DATA) public data: any) {}
}
