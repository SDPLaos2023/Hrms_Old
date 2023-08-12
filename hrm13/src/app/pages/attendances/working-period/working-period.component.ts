import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { NgxSpinnerService } from 'ngx-spinner';
import { PageDataService } from 'src/app/Services/shared/page-data.service';
import { TimesheetService } from 'src/app/Services/timesheet.service';

@Component({
  selector: 'app-working-period',
  templateUrl: './working-period.component.html',
  styleUrls: ['./working-period.component.css']
})
export class WorkingPeriodComponent implements OnInit {

  constructor(private page: PageDataService,
    public dialog: MatDialog, private spinner: NgxSpinnerService, private service: TimesheetService) { }

  ngOnInit(): void {

  }

}
