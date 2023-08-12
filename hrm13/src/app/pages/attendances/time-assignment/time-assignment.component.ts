import { Component, OnInit } from '@angular/core';
import { PageDataService } from 'src/app/Services/shared/page-data.service';

@Component({
  selector: 'app-time-assignment',
  templateUrl: './time-assignment.component.html',
  styleUrls: ['./time-assignment.component.css']
})
export class TimeAssignmentComponent implements OnInit {

  constructor(private page: PageDataService) { }

  ngOnInit(): void {
    this.page.pagename = "ການກຳຫນົດຕາລາງເວລາ"
    this.page.breadcrumb = '<li class="breadcrumb-item"> <i class="fas fa-home"></i> Home</li><li class="breadcrumb-item"> Attendances </li> <li class="breadcrumb-item active" >' + this.page.pagename + ' </li>'

  }

}
