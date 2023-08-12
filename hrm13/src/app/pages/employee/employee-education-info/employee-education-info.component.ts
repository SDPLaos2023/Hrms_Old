import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { NgxSpinnerService } from 'ngx-spinner';
import { ModalAddEmployeeEducationComponent } from 'src/app/components/modals/modal-add-employee-education/modal-add-employee-education.component';
import { EmployeeEducationService } from 'src/app/Services/employee-education.service';

@Component({
  selector: 'app-employee-education-info',
  templateUrl: './employee-education-info.component.html',
  styleUrls: ['./employee-education-info.component.css']
})
export class EmployeeEducationInfoComponent implements OnInit {

  constructor(private spinner: NgxSpinnerService, public dialog: MatDialog,
    private service: EmployeeEducationService) { }

  ngOnInit(): void {
  }


  openDialog() {
    const dialogRef = this.dialog.open(ModalAddEmployeeEducationComponent, {
      width: '600px',
    });
    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed ' + result);
      if (result === "OK") {
        this.LoadAll()
      }
    });
  }
  LoadAll() {
  }

  ShowUpdate(data: any) {
    const dialogRef = this.dialog.open(ModalAddEmployeeEducationComponent, {
      width: '600px', data: data
    });
    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed ' + result);
      if (result === "OK") {
        this.LoadAll()
      }
    });
  }


}
