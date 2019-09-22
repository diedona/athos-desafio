import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material';

@Injectable({
  providedIn: 'root'
})
export class MessageService {

  private action = 'fechar';

  constructor(
    private snackBar: MatSnackBar
  ) { }

  success(message: string): void {
    this.snackBar.open(message, this.action, { panelClass: 'success-snackbar' })
  }

  error(data: any): void {
    if (typeof (data) === "string") {
      this.showError(data);
    } else {
      const message = data.error || "Ocorreu um erro!";
      this.showError(message);
    }
  }

  //
  // PRIVATES
  //

  private showError(message: string) {
    this.snackBar.open(message, this.action, { panelClass: 'danger-snackbar' });
  }
}
