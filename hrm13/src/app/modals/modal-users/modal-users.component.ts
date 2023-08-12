import { Component, OnInit } from '@angular/core';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { ModalSelectEmployeeComponent } from '../modal-select-employee/modal-select-employee.component';

@Component({
  selector: 'app-modal-users',
  templateUrl: './modal-users.component.html',
  styleUrls: ['./modal-users.component.css']
})
export class ModalUsersComponent implements OnInit {

  constructor(public dialog: MatDialog, public dialogRef: MatDialogRef<ModalUsersComponent>) { }

  ngOnInit(): void {
  }


  openDialog() {
    const dialogRef = this.dialog.open(ModalSelectEmployeeComponent, {
      width: '800px'
    });
    dialogRef.afterClosed().subscribe(result => {
      console.log('nothing', 'is working')
    });
  }
}
