import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { environment } from 'src/environments/environment';
import { EmployeeAllowance } from '../models/employee-allowance.model';
import { EmployeeClassification } from '../models/employee-classification.model';
import { EmployeeContact } from '../models/employee-contact.model';
import { EmployeeContract } from '../models/employee-contract.model';
import { EmployeeEducation } from '../models/employee-education.model';
import { EmployeeEmployment } from '../models/employee-employment.model';
import { EmployeeFamilyContact } from '../models/employee-family-contact.model';
import { EmployeeHealthHistory } from '../models/employee-health-history.model';
import { EmployeeInsurance } from '../models/employee-insurance.model';
import { EmployeeLeaveSetting } from '../models/employee-leave-setting.model';
import { EmployeeProbationContract } from '../models/employee-probation-contract.model';
import { EmployeeSalarySetting } from '../models/employee-salary-setting.model';
import { Employee } from '../models/employee.model';
import { IdCard } from '../models/id-card.model';
import { UitlsService } from './shared/uitls.service';
import { UserInfoService } from './shared/user-info.service';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
  Delete(id: any) {
    return this.http.delete(this.baseUrl + "api/Employees/" + id)
  }


  employee: Employee = new Employee();
  pathAvatar: string = "assets/dist/img/noImg.png"
  avatarNoImage: string = "assets/dist/img/noImg.png"

  baseUrl = environment.baseUrlApi

  constructor(private http: HttpClient,
    public user: UserInfoService,
    private util: UitlsService) {

  }

  NewEmployee(param: any) {
    return this.http.post(this.baseUrl + "api/Employees", param)
  }

  UpdateEmployee(param: any) {
    return this.http.put(this.baseUrl + "api/Employees/" + param.employee.id, param)
  }

  GetEmployee(id: any) {
    return this.http.get(this.baseUrl + "api/Employees/" + id)
  }

  GetList() {
    return this.http.get(this.baseUrl + "api/Employees")
  }

  GetListNoneUser() {
    return this.http.get(this.baseUrl + "api/Employees/none-users")
  }

  CreateOne(param: any) {
    this.http.post(this.baseUrl + "api/Employees", param.employee)
      .subscribe((resp: any) => {
        console.log('9', resp)
      }, error => {
        console.error('0', error)
      })

  }

  GetEmployeeName(id: any) {
    return this.http.post(this.baseUrl + "api/Employees/get-name/" + id, {});
  }

  GetEmployeeByDepartment(department: any) {
    return this.http.post(this.baseUrl + "api/Employees/getlist/" + department, {});
  }


  tempIdCard: IdCard[] = [];
  tempEmpContact: EmployeeContact = new EmployeeContact();
  tempEmpFamilyContact: EmployeeFamilyContact = new EmployeeFamilyContact();
  tempEmpEducations: EmployeeEducation[] = [];
  tempEmpContract: EmployeeContract = new EmployeeContract();
  tempEmpProbationContract: EmployeeProbationContract = new EmployeeProbationContract();
  tempEmpClassification: EmployeeClassification = new EmployeeClassification();
  tempEmpEmployment: EmployeeEmployment = new EmployeeEmployment();
  tempEmpSalarySetting: EmployeeSalarySetting = new EmployeeSalarySetting();
  tempEmpLeaveSetting: EmployeeLeaveSetting = new EmployeeLeaveSetting();
  tempEmpAllowances: EmployeeAllowance[] = [];
  tempEmpInsurance: EmployeeInsurance = new EmployeeInsurance();
  tempEmpHealths: EmployeeHealthHistory[] = [];

  initNewFormEmployee(): FormGroup {

    let date = new Date();//
    let userAct = this.user.GetUsername();
    let age = this.AgeCalculate(date);
    let dummyId = this.DummyEmpId();

    return new FormGroup({
      employee: new FormGroup({
        id: new FormControl(dummyId),
        code: new FormControl(""),
        name: new FormControl("", Validators.required),
        nameEn: new FormControl("", Validators.required),
        dob: new FormControl(date, Validators.required),
        age: new FormControl(age),
        gender: new FormControl("M"),
        bloodGroup: new FormControl("BG", Validators.required),
        nationality: new FormControl("N", Validators.required),
        race: new FormControl("R", Validators.required),
        address: new FormControl(""),
        province: new FormControl("PR", Validators.required),
        district: new FormControl("DI", Validators.required),
        country: new FormControl("C", Validators.required),
        status: new FormControl("ACTIVE", Validators.required),
        maritalStatus: new FormControl("MR", Validators.required),
        createdBy: new FormControl(userAct, Validators.required),
        createdAt: new FormControl(date),
        updatedBy: new FormControl(userAct, Validators.required),
        updatedAt: new FormControl(date),
        avatar: new FormControl(""),
      }),
      contact: new FormGroup({
        id: new FormControl(dummyId),
        employee: new FormControl(dummyId, Validators.required),
        mobile: new FormControl(""),
        home: new FormControl(""),
        email: new FormControl(""),
        wa: new FormControl(""),
        line: new FormControl(""),
        wechat: new FormControl(""),
        facebook: new FormControl(""),
        twitter: new FormControl(""),
        skype: new FormControl(""),
        contactPerson: new FormControl(""),
        contactNumber: new FormControl(""),
        contactRelation: new FormControl(""),
        createdBy: new FormControl(userAct),
        createdAt: new FormControl(date),
        updatedBy: new FormControl(userAct),
        updatedAt: new FormControl(date),
      }),
      familyContact: new FormGroup({
        id: new FormControl(dummyId),
        employee: new FormControl(dummyId, Validators.required),
        fatherName: new FormControl(""),
        fatherDob: new FormControl(""),
        fatherAge: new FormControl(""),
        fatherContactNumber: new FormControl(""),
        motherName: new FormControl(""),
        motherDob: new FormControl(""),
        motherAge: new FormControl(""),
        motherContactNumber: new FormControl(""),
        spouseName: new FormControl(""),
        spouseDob: new FormControl(""),
        spouseAge: new FormControl(""),
        spouseContactNumber: new FormControl(""),
        noChildren: new FormControl(""),
        noDaughter: new FormControl(""),
      }),
      contract: new FormGroup({
        id: new FormControl(dummyId),
        employee: new FormControl(dummyId, Validators.required),
        contractType: new FormControl("CT"),
        contractStartAt: new FormControl(""),
        contractStopAt: new FormControl(""),
        contractNo: new FormControl("*"),
        createdAt: new FormControl(date),
        createdBy: new FormControl(userAct),
        updatedAt: new FormControl(date),
        updatedBy: new FormControl(userAct),
      }),
      probationContract: new FormGroup({
        id: new FormControl(dummyId),
        employee: new FormControl(dummyId, Validators.required),
        contractStartAt: new FormControl(""),
        contractStopAt: new FormControl(""),
        createdAt: new FormControl(date),
        createdBy: new FormControl(userAct),
        updatedAt: new FormControl(date),
        updatedBy: new FormControl(userAct),
      }),
      classification: new FormGroup({
        id: new FormControl(dummyId),
        employee: new FormControl(dummyId, Validators.required),
        employeeType: new FormControl("EP", Validators.required),
        employeeGroup: new FormControl("EG", Validators.required),
        employeeCategory: new FormControl("ECA", Validators.required),
        employeeLevel: new FormControl("EL", Validators.required),
        employeeWorkingType: new FormControl("WP", Validators.required),
        createdAt: new FormControl(date),
        createdBy: new FormControl(userAct),
        updatedAt: new FormControl(date),
        updatedBy: new FormControl(userAct),
      }),
      employment: new FormGroup({
        id: new FormControl(dummyId),
        employee: new FormControl(dummyId, Validators.required),
        position: new FormControl("P"),
        department: new FormControl("D"),
        division: new FormControl("DV"),
        section: new FormControl("S"),
        createdAt: new FormControl(date),
        createdBy: new FormControl(userAct),
        updatedAt: new FormControl(date),
        updatedBy: new FormControl(userAct),
      }),
      salarySetting: new FormGroup({
        id: new FormControl(dummyId),
        employee: new FormControl(dummyId, Validators.required),
        baseSalary: new FormControl("0"),
        salaryType: new FormControl("SA"),
        salaryPayType: new FormControl("ST"),
        bank: new FormControl("B"),
        bankAccount: new FormControl(""),
        createdAt: new FormControl(date),
        createdBy: new FormControl(userAct),
        updatedAt: new FormControl(date),
        updatedBy: new FormControl(userAct),
      }),
      leaveSetting: new FormGroup({
        id: new FormControl(dummyId),
        employee: new FormControl(dummyId, Validators.required),
        employeeAnnualLeave: new FormControl("LP"),
        ratio: new FormControl("0"),
        remain: new FormControl("0"),
      }),
      insurance: new FormGroup({
        id: new FormControl(dummyId),
        employee: new FormControl(dummyId, Validators.required),
        ssn: new FormControl("*"),
        rate: new FormControl("0"),
        insuranceCertificate: new FormControl("*"),
        insuranceExpiryDate: new FormControl(null),
        createdAt: new FormControl(date),
        createdBy: new FormControl(userAct),
        updatedAt: new FormControl(date),
        updatedBy: new FormControl(userAct),
      }),
      idCards: new FormControl([]),
      educations: new FormControl([]),
      healthHistories: new FormControl([]),
      allowances: new FormControl([]),

    });
  }


  DummyEmpId(): any {
    let date: Date = new Date();
    return "TEMP" + date.getMilliseconds();
  }

  AgeCalculate(date: any) {
    let age = this.util.ageCalculator(date)
    return age;
  }


}
