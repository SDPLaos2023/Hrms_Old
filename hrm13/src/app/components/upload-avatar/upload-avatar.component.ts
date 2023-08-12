import { HttpClient, HttpEventType, HttpRequest } from '@angular/common/http';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { EmployeeService } from 'src/app/Services/employee.service';
import { UserInfoService } from 'src/app/Services/shared/user-info.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-upload-avatar',
  templateUrl: './upload-avatar.component.html',
  styleUrls: ['./upload-avatar.component.css']
})
export class UploadAvatarComponent implements OnInit {

  public progress: number;
  public message: string;
  @Input("empID") _empid: string = ""
  @Output() public onUploadFinished = new EventEmitter();
  baseUrl = environment.baseUrlApi;
  constructor(private http: HttpClient, public emp: EmployeeService) { }
  ngOnInit() {
  }
  public uploadFile = (files: any) => {
    if (files.length === 0) {
      return;
    }
    let fileToUpload = <File>files[0];
    console.log(fileToUpload)
    console.log(fileToUpload.name)
    const formData = new FormData();
    formData.append('file', fileToUpload, fileToUpload.name);
    formData.append('empID', this._empid);

    const uploadReq = new HttpRequest('POST', this.baseUrl + 'api/FileUpload/avatar/' + this._empid, formData, {
      reportProgress: true
    });
    this.http.request(uploadReq).subscribe((event: any) => {
      console.log('tag', event)
      let body = event.body;
      if (body != null) {
        this.emp.pathAvatar = this.baseUrl + body.dbPath
      }

      if (event.type === HttpEventType.UploadProgress) {
        this.progress = Math.round(100 * event.loaded / event.total);
        this.message = "Image Ok";
      };
    });

  }

}
