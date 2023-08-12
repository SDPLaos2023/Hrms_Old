import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { NgxSpinnerService } from 'ngx-spinner';
import { EducationDegree } from 'src/app/models/education-degree.model';
import { EducationInstitution } from 'src/app/models/education-institution.model';
import { EmployeeEducation } from 'src/app/models/employee-education.model';
import { EducationDegreeTypeService } from 'src/app/Services/education-degree-type.service';
import { EducationInstitutionService } from 'src/app/Services/education-institution.service';
import { EmployeeEducationService } from 'src/app/Services/employee-education.service';

@Component({
  selector: 'app-modal-add-employee-education',
  templateUrl: './modal-add-employee-education.component.html',
  styleUrls: ['./modal-add-employee-education.component.css']
})
export class ModalAddEmployeeEducationComponent implements OnInit {
  form: FormGroup;
  isUpdate: boolean;

  constructor(public dialogRef: MatDialogRef<ModalAddEmployeeEducationComponent>,
    private degreeService: EducationDegreeTypeService,
    private institutionService: EducationInstitutionService,
    private empEdu: EmployeeEducationService,

    private spinner: NgxSpinnerService, @Inject(MAT_DIALOG_DATA) public data: any) {

    this.data
    console.log('(data)', data)
    if (data != null) {
      this.isUpdate = true;
    }
  }

  ngOnInit(): void {
    this.LoadInstitution();
    this.LoadDegrees();
    this.initForm(this.data)
  }

  initForm(data: any) {
    let date = new Date()
    this.form = new FormGroup({
      id: new FormControl(data.id != undefined ? data.id : "0"),
      employee: new FormControl(data.employee != undefined ? data.employee : "0"),
      institution: new FormControl(data.institution != undefined ? data.institution : "I"),
      degree: new FormControl(data.degree != undefined ? data.degree : "DG"),
      year: new FormControl(data.year != undefined ? data.year : date.getFullYear()),
      major: new FormControl(data.major != undefined ? data.major : ""),
      gpa: new FormControl(data.gpa != undefined ? data.gpa : "1"),
      sequence: new FormControl(data.sequence != undefined ? data.sequence : "0"),
      isNew: new FormControl(true),
      degreeNavigation: new FormControl(new EducationDegree()),
      institutionNavigation: new FormControl(new EducationInstitution()),
    });
  }

  confirmCreate() {
    this.spinner.show()
    let f = this.form.value
    this.degreeChange(f.degree)
    this.institutionChange(f.institution)

    if (f.employee.startsWith("TEMP") && f.id.startsWith("TEMP")) {
      let edu = JSON.stringify(this.form.value)
      this.onNoClick(edu);
      this.spinner.hide();
    } else {
      console.log('9', f)
      if (f.employee.startsWith("E") && f.id.startsWith("TEMP")) {
        this.empEdu.Create(this.form.value).subscribe((resp: any) => {
          console.log('resp', resp)
          let edu = JSON.stringify(this.form.value)
          this.onNoClick(edu);
          this.spinner.hide();
        }, error => {
          console.log('error', error)
        });
      } else if (f.employee.startsWith("E") && f.id.startsWith("EE")) {
        this.empEdu.Update(this.form.value).subscribe((resp: any) => {
          console.log('resp', resp)
          let edu = JSON.stringify(this.form.value)
          this.onNoClick(edu);
          this.spinner.hide();
        }, error => {
          console.log('error', error)
        });
      }
    }
  }

  onNoClick(rs: any): void {
    this.dialogRef.close(rs);
  }

  degrees: EducationDegree[] = []
  LoadDegrees() {
    this.degreeService.GetListDegrees();
    this.degreeService._degreeList.subscribe(degree => {
      this.degrees.push(degree)
    });
  }

  institutions: EducationInstitution[] = []
  LoadInstitution() {
    this.institutionService.GetListInstitutions();
    this.institutionService._eduInstitutionList.subscribe(institution => {
      console.log('tag', this.institutions)
      this.institutions.push(institution)
    });
  }

  degreeChange(id: any) {
    console.log('degreeChange', id)
    this.degrees.forEach(element => {
      if (element.id == id) {
        console.log('degreeChange', element)
        this.form.patchValue({ degreeNavigation: element })
      }
    })

  }

  institutionChange(id: any) {
    console.log('institutions', id)
    this.institutions.forEach(element => {
      if (element.id == id) {
        console.log('institutions', element)
        this.form.patchValue({ institutionNavigation: element })
      }
    })
  }
}
