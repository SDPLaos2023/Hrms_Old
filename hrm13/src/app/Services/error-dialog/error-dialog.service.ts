import { Injectable } from '@angular/core';
import Swal from 'sweetalert2'

@Injectable({
  providedIn: 'root'
})
export class ErrorDialogService {
  public isDialogOpen: Boolean = false;
  constructor() { }
  openDialog(data: any): any {
    if (this.isDialogOpen) {
      return false;
    }
    this.isDialogOpen = true;
    Swal.fire('Oops!', 'Something Wrong', 'warning')
  }
}
