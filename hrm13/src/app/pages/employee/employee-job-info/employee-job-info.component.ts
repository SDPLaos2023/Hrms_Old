import { AfterContentInit, Component, OnInit } from '@angular/core';
import { UserInfoService } from 'src/app/Services/shared/user-info.service';

@Component({
  selector: 'app-employee-job-info',
  templateUrl: './employee-job-info.component.html',
  styleUrls: ['./employee-job-info.component.css']
})
export class EmployeeJobInfoComponent implements OnInit, AfterContentInit {

  constructor(public user: UserInfoService) { }
  ngAfterContentInit(): void {
  }

  ngOnInit(): void {
    this.user.displayPositionName = "Aministrator"

  }

}
