import { AfterContentInit, AfterViewInit, ChangeDetectorRef, Component, ElementRef, OnChanges, OnInit, SimpleChanges, ViewChild } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { NgxSpinnerService } from 'ngx-spinner';
import { BloodGroup } from 'src/app/models/blood-group.model';
import { Country } from 'src/app/models/country.model';
import { District } from 'src/app/models/district.model';
import { MaritalStatus } from 'src/app/models/marital-status.model';
import { Nationality } from 'src/app/models/nationality.model';
import { Province } from 'src/app/models/province.model';
import { Race } from 'src/app/models/race.model';
import { BloodGroupService } from 'src/app/Services/blood-group.service';
import { CountryService } from 'src/app/Services/country.service';
import { DistrictService } from 'src/app/Services/district.service';
import { EmployeeService } from 'src/app/Services/employee.service';
import { MaritalStatusService } from 'src/app/Services/marital-status.service';
import { NationlityAndRaceService } from 'src/app/Services/nationlity-and-race.service';
import { ProvinceService } from 'src/app/Services/province.service';
import { PageDataService } from 'src/app/Services/shared/page-data.service';
import { UitlsService } from 'src/app/Services/shared/uitls.service';
import { UserInfoService } from 'src/app/Services/shared/user-info.service';
import Swal from 'sweetalert2'
import { ModalAddEmployeeEducationComponent } from 'src/app/components/modals/modal-add-employee-education/modal-add-employee-education.component';
import { EmployeeCategory } from 'src/app/models/employee-category.model';
import { EmployeeLevel } from 'src/app/models/employee-level.model';
import { EmployeeGroup } from 'src/app/models/employee-group.model';
import { WorkingType } from 'src/app/models/working-type.model';
import { EmployeeType } from 'src/app/models/employee-type.model';
import { Position } from 'src/app/models/position.model';
import { Section } from 'src/app/models/section.model';
import { Division } from 'src/app/models/division.model';
import { Department } from 'src/app/models/department.model';
import { DepartmentService } from 'src/app/Services/department.service';
import { DivisionService } from 'src/app/Services/division.service';
import { SectionService } from 'src/app/Services/section.service';
import { PositionService } from 'src/app/Services/position.service';
import { EmployeeTypeService } from 'src/app/Services/employee-type.service';
import { EmployeeGroupService } from 'src/app/Services/employee-group.service';
import { EmployeeCategoryService } from 'src/app/Services/employee-category.service';
import { EmployeeLevelService } from 'src/app/Services/employee-level.service';
import { WorkingTypeService } from 'src/app/Services/working-type.service';
import { ContractTypeService } from 'src/app/Services/contract-type.service';
import { ContractType } from 'src/app/models/contract-type.model';
import { Bank } from 'src/app/models/bank.model';
import { BankService } from 'src/app/Services/bank.service';
import { SalaryPayType } from 'src/app/models/salary-pay-type.model';
import { SalaryPayTypeService } from 'src/app/Services/salary-pay-type.service';
import { SalaryTypeService } from 'src/app/Services/salary-type.service';
import { SalaryType } from 'src/app/models/salary-type.model';
import { AnnualLeaveTypeService } from 'src/app/Services/annual-leave-type.service';
import { AnnualLeaveType } from 'src/app/models/annual-leave-type.model';
import { EmployeeEducation } from 'src/app/models/employee-education.model';
import { Subject } from 'rxjs';
import { DataTableDirective } from 'angular-datatables';
import { EmployeeEducationService } from 'src/app/Services/employee-education.service';
import { EducationInstitutionService } from 'src/app/Services/education-institution.service';
import { ModalIdCardComponent } from 'src/app/components/modals/modal-id-card/modal-id-card.component';
import { EmployeeIdentityService } from 'src/app/Services/employee-identity.service';
import { EmployeeIdentity } from 'src/app/models/employee-identity.model';
import { DatePipe } from '@angular/common';
import { EmployeeAllowance } from 'src/app/models/employee-allowance.model';
import { ModalEmployeeAllownceComponent } from 'src/app/modals/modal-employee-allownce/modal-employee-allownce.component';
import { EmployeeAllowanceService } from 'src/app/Services/employee-allowance.service';
import { EmployeeHealthHistory } from 'src/app/models/employee-health-history.model';
import { EmployeeHealthHistoryService } from 'src/app/Services/employee-health-history.service';
import { ModalEmployeeHealthHistoryComponent } from 'src/app/modals/modal-employee-health-history/modal-employee-health-history.component';
import { ActivatedRoute } from '@angular/router';
import { environment } from 'src/environments/environment';
// import Swal from 'sweetalert2'

@Component({
  selector: 'app-add-new-employee',
  templateUrl: './add-new-employee.component.html',
  styleUrls: ['./add-new-employee.component.css']
})
export class AddNewEmployeeComponent implements OnInit, OnChanges, AfterContentInit, AfterViewInit {
  countries: Country[] = [];
  provinces: Province[] = [];
  districts: District[] = [];

  employee: string;

  isUpdate: boolean = false
  employeeInfoSaves: boolean;
  formxx: FormGroup;


  test = 15

  constructor(private page: PageDataService, private datepipe: DatePipe,
    private spinner: NgxSpinnerService,
    public dialog: MatDialog,
    public user: UserInfoService,
    private cdr: ChangeDetectorRef,
    private countryService: CountryService,
    private provinceService: ProvinceService,
    private districtService: DistrictService,
    private nationalityAndRaceService: NationlityAndRaceService,
    private bloodGroupService: BloodGroupService,
    private util: UitlsService,
    public emp: EmployeeService,
    private mstatusService: MaritalStatusService,
    private departmentService: DepartmentService,
    private divisionService: DivisionService,
    private sectionService: SectionService,
    private positionService: PositionService,
    private employeeTypeService: EmployeeTypeService,
    private employeeGroupService: EmployeeGroupService,
    private employeeCategoryService: EmployeeCategoryService,
    private employeeLevelService: EmployeeLevelService,
    private workingTypeService: WorkingTypeService,
    private contractTypeService: ContractTypeService,
    private bankService: BankService,
    private salaryPayTypeService: SalaryPayTypeService,
    private salaryTypeService: SalaryTypeService,
    private annualLeaveTypeService: AnnualLeaveTypeService,
    private empEdu: EmployeeEducationService,
    private eduInstitution: EducationInstitutionService,
    private empIdentity: EmployeeIdentityService,
    private empAllowance: EmployeeAllowanceService,
    private empHealth: EmployeeHealthHistoryService,
    private route: ActivatedRoute,


  ) {
    const routeParams = this.route.snapshot.paramMap;
    this.employee = routeParams.get('empid') || this.emp.DummyEmpId();

  }

  LoadEmployee(employee: string) {
    this.emp.GetEmployee(employee).subscribe((resp: any) => {
      this.loadDistricts(resp.province)

      let dob = this.ShowDate(resp.dob)
      resp.dob = dob
      let family = resp.tbemployeeFamilyContacts.length <= 0 ? null : resp.tbemployeeFamilyContacts[0];
      if (family != null) {
        family.fatherDob = this.ShowDate(family.fatherDob)
        family.motherDob = this.ShowDate(family.motherDob)
        family.spouseDob = this.ShowDate(family.spouseDob)
      }

      let contract = resp.tbemployeeContracts.length <= 0 ? null : resp.tbemployeeContracts[0];
      if (contract != null) {
        contract.contractStartAt = this.ShowDate(contract.contractStartAt)
        contract.contractStopAt = this.ShowDate(contract.contractStopAt)
      }
      let proContract = resp.tbemployeeProbations.length <= 0 ? null : resp.tbemployeeProbations[0]
      if (proContract != null) {
        proContract.contractStartAt = this.ShowDate(proContract.contractStartAt)
        proContract.contractStopAt = this.ShowDate(proContract.contractStopAt)
      }

      let insurance = resp.tbemployeeInsurances.length <= 0 ? null : resp.tbemployeeInsurances[0]
      if (insurance != null) {
        insurance.insuranceExpiryDate = this.ShowDate(insurance.insuranceExpiryDate)
      }


      this.formxx.patchValue({
        employee: resp,
        contact: resp.tbemployeeContacts[0],
        familyContact: family,
        contract: contract,
        probationContract: proContract,
        classification: resp.tbemployeeClassifications[0],
        employment: resp.tbemployeeEmployments[0],
        salarySetting: resp.tbemployeeSalarySettings[0],
        leaveSetting: resp.tbemployeeLeaveSettings[0],
        insurance: insurance,
      });
      console.log('employeeeeeee', resp)
      if (resp.avatar == null) {
        this.formxx.patchValue({
          employee: { avatar: this.emp.avatarNoImage }
        })
      } else {
        let baseUrl = environment.baseUrlApi;
        this.emp.pathAvatar = baseUrl + this.formxx.value.employee.avatar;
      }


      // console.log('tag >>>>>>>', this.formxx.value)
      // console.log('tag', this.ShowDate(null))
      this.ShowDate(null)
      this.LoadEducations(employee);
      this.LoadIdCards(employee);
      this.LoadIdAllowance(employee)
      this.LoadIdHealthHistories(employee)


    })

  }

  GetDate(today: any) {
    let actionDate = this.datepipe.transform(today, 'dd/MM/yyyy');
    return actionDate;
  }

  ShowDate(today: any) {
    let actionDate = this.datepipe.transform(today, 'yyyy-MM-dd');
    return actionDate;
  }
  ngAfterViewInit(): void {
    this.cdr.detectChanges();
  }

  ngAfterContentInit(): void {

  }

  ngOnChanges(changes: SimpleChanges): void {
    // console.log('tag', changes.user)
    // if (changes.user !== undefined) {

    // }
  }

  ngOnInit(): void {
    this.page.pagename = "ຂໍ້ມູນພະນັກງານ"
    this.page.breadcrumb = '<li class="breadcrumb-item"> <i class="fas fa-home"></i> Home</li><li class="breadcrumb-item"> ການຈັການຂໍ້ມູນບຸຄະລາກອນ </li> <li class="breadcrumb-item active" > ຂໍ້ມູນພະນັກງານ </li>'

    this.formxx = this.emp.initNewFormEmployee()

    this.loadCountries();
    this.loadProvinces();
    this.loadNationalities();
    this.loadRaces();
    this.loadBloodGroups();
    this.loadStatus();

    this.GetDepartments();
    this.GetDivisions();
    this.GetSections();
    this.GetPositions();
    // this.GetDepartments();
    this.GetEmployeeLevels();
    this.GetEmployeeGroups();
    this.GetEmployeeTypes();
    this.GetEmployeeCategories();
    this.GetWorkingTypes();
    this.GetContractTypes();
    this.GetBanks();
    this.GetSalaryPayTypes();
    this.GetSalaryTypes();
    this.GetAnnualLeaveType();
    // this.LoadIdCards("E00099");

    if (this.employee.startsWith("E")) {
      this.isUpdate = true;
      this.LoadEmployee(this.employee)
    }
    console.log('tag', this.employee)

  }

  contractTypes: ContractType[] = []
  GetContractTypes() {
    this.contractTypeService.GetListContractTypes();
    this.contractTypeService._contractTypes.subscribe(contractType => {
      this.contractTypes.push(contractType)
    })
  }

  AgeCalculate(date: any) {
    // let date = this.formxx..value.Dob
    let age = this.util.ageCalculator(date)
    this.formxx.patchValue({
      employee: { age: age.toString(), }
    })

  }

  loadProvinces() {
    this.provinceService.GetListProvinces();
    this.provinceService._provinces.subscribe(province => {
      this.provinces.push(province)
    })
  }

  loadDistricts(provinceId: any) {
    this.districtService.GetDistricts(provinceId).subscribe((resp: any) => {
      this.districts = resp as District[]
    })
  }

  loadCountries() {
    this.countryService.GetListCountries();
    this.countryService._countries.subscribe(country => {
      this.countries.push(country)
    });
  }

  nationalities: Nationality[] = []
  loadNationalities() {
    this.nationalityAndRaceService.GetListNationalities();
    this.nationalityAndRaceService._nationalities.subscribe(nationality => {
      this.nationalities.push(nationality)
    });
  }

  races: Race[] = []
  loadRaces() {
    this.nationalityAndRaceService.GetListRaces();
    this.nationalityAndRaceService._races.subscribe(race => {
      this.races.push(race)
    });
  }

  bloodgroups: BloodGroup[] = []
  loadBloodGroups() {
    this.bloodGroupService.GetListBg();
    this.bloodGroupService._bloodgroups.subscribe(bg => {
      this.bloodgroups.push(bg)
    });
  }

  mstatus: MaritalStatus[] = []
  loadStatus() {
    this.mstatusService.GetListStatus();
    this.mstatusService._mstatus.subscribe((resp: any) => {
      this.mstatus.push(resp)
    });
  }

  departments: Department[] = []
  GetDepartments() {
    this.departmentService.GetDepartments();
    this.departmentService._departments.subscribe(department => {
      this.departments.push(department)
    })
  }

  divisions: Division[] = []
  GetDivisions() {
    this.divisionService.GetDivisions();
    this.divisionService._divisions.subscribe(division => {
      this.divisions.push(division)
    })
  }

  sections: Section[] = []
  GetSections() {
    this.sectionService.GetSections();
    this.sectionService._sections.subscribe(section => {
      this.sections.push(section)
    })
  }

  positions: Position[] = []
  GetPositions() {
    this.positionService.GetPositions();
    this.positionService._positions.subscribe(position => {
      this.positions.push(position)
    })
  }

  employeeTypes: EmployeeType[] = []
  GetEmployeeTypes() {
    this.employeeTypeService.GetEmployeeTypes();
    this.employeeTypeService._employeeTypes.subscribe(obj => {
      this.employeeTypes.push(obj)
    })
  }

  workingTypes: WorkingType[] = []
  GetWorkingTypes() {
    this.workingTypeService.GetworkingTypes();
    this.workingTypeService._workingTypes.subscribe(obj => {
      this.workingTypes.push(obj)
    })
  }

  employeeGroups: EmployeeGroup[] = []
  GetEmployeeGroups() {
    this.employeeGroupService.GetEmployeeGroups();
    this.employeeGroupService._employeeGroups.subscribe(obj => {
      this.employeeGroups.push(obj)
    })
  }

  employeeLevels: EmployeeLevel[] = []
  GetEmployeeLevels() {
    this.employeeLevelService.GetEmployeeLevels();
    this.employeeLevelService._employeeLevels.subscribe(obj => {
      this.employeeLevels.push(obj)
    })
  }

  employeeCategories: EmployeeCategory[] = []
  GetEmployeeCategories() {
    this.employeeCategoryService.GetEmployeeCategories();
    this.employeeCategoryService._employeeCategories.subscribe(obj => {
      this.employeeCategories.push(obj)
    })
  }

  banks: Bank[] = []
  GetBanks() {
    this.bankService.GetBankOpts();
    this.bankService._BankOpts.subscribe(obj => {
      this.banks.push(obj)
    })
  }
  salaryPayTypes: SalaryPayType[] = []
  GetSalaryPayTypes() {
    this.salaryPayTypeService.GetSalaryPayTypes();
    this.salaryPayTypeService._SalaryPayTypes.subscribe(obj => {
      this.salaryPayTypes.push(obj)
    })
  }

  salaryTypes: SalaryType[] = []
  GetSalaryTypes() {
    this.salaryTypeService.GetSalaryTypes();
    this.salaryTypeService._SalaryTypes.subscribe(obj => {
      this.salaryTypes.push(obj)
    })
  }
  annualLeaveTypes: AnnualLeaveType[] = []
  GetAnnualLeaveType() {
    this.annualLeaveTypeService.GetAnnualLeaveTypes()
    this.annualLeaveTypeService._AnnualLeaveTypes.subscribe(obj => {
      this.annualLeaveTypes.push(obj)
    })
  }

  saveAll() {
    console.log(JSON.stringify(this.formxx.value))
    console.log('tag', this.isUpdate)
    if (this.isUpdate == true) {
      this.UpdateAll();
      return
    }

    this.spinner.show()
    this.SaveEmployeeInfo();

    setTimeout(() => {
      this.spinner.hide();
    }, 1500);

  }

  SaveEmployeeInfo() {
    console.log('a', this.employeeAllowances)
    console.log('b', this.edus)
    console.log('c', this.empIdCards)
    console.log('d', this.employeehealths)
    this.formxx.patchValue({
      allowances: this.employeeAllowances,
      educations: this.edus,
      idCards: this.empIdCards,
      healthHistories: this.employeehealths
    })
    this.emp.NewEmployee(this.formxx.value).subscribe((rs: any) => {
      this.employee = rs.id
      console.log('tag', rs)
      console.log('tag.tbemployeeIdentities', rs.tbemployeeClassifications)
      let empId: string = rs.id;
      let classifyId = rs.tbemployeeClassifications.length <= 0 ? "" : rs.tbemployeeClassifications[0].id;
      let familyContactId = rs.tbemployeeFamilyContacts.length <= 0 ? "" : rs.tbemployeeFamilyContacts[0].id;
      let contactId = rs.tbemployeeContacts.length <= 0 ? "" : rs.tbemployeeContacts[0].id;
      let proContactId = rs.tbemployeeProbations.length <= 0 ? "" : rs.tbemployeeProbations[0].id;
      let contractId = rs.tbemployeeContracts.length <= 0 ? "" : rs.tbemployeeContracts[0].id;
      let employmentId = rs.tbemployeeEmployments.length <= 0 ? "" : rs.tbemployeeEmployments[0].id;
      let salarySettingId = rs.tbemployeeSalarySettings.length <= 0 ? "" : rs.tbemployeeSalarySettings[0].id;
      let leaveSettingId = rs.tbemployeeLeaveSettings.length <= 0 ? "" : rs.tbemployeeLeaveSettings[0].id;
      let insuranceId = rs.tbemployeeInsurances.length <= 0 ? "" : rs.tbemployeeInsurances[0].id;

      this.isUpdate = true;
      this.formxx.patchValue({
        employee: { id: empId },
        familyContact: { id: familyContactId, employee: empId },
        contact: { id: contactId, employee: empId },
        probationContract: { id: proContactId, employee: empId },
        contract: { id: contractId, employee: empId },
        classification: { id: classifyId, employee: empId },
        employment: { id: employmentId, employee: empId },
        salarySetting: { id: salarySettingId, employee: empId },
        leaveSetting: { id: leaveSettingId, employee: empId },
        insurance: { id: insuranceId, employee: empId },
        idCards: rs.tbemployeeIdentities,
        educations: rs.tbemployeeEducationHistories,
        healthHistories: rs.tbemployeeHealthHistories,
        allowances: rs.tbemployeeAllowances,
      })

      this.LoadEducations(empId);
      this.LoadIdCards(empId);
      this.LoadIdAllowance(empId)
      this.LoadIdHealthHistories(empId)

    }, error => {
      console.log('(new employee error)', error)
    })


  }

  LoadEducations(empId: string) {
    this.empEdu.GetList(empId).pipe(this.extractData).subscribe((reps: any) => {
      console.log('tag', reps)
      this.edus = [];
      let list = reps as EmployeeEducation[]
      list.forEach(item => {
        item.isNew = false;
        this.edus.push(item)
      })
    })
  }

  UpdateAll() {
    this.spinner.show()
    console.log(JSON.stringify(this.formxx.value))

    this.emp.UpdateEmployee(this.formxx.value).subscribe((rs: any) => {
      console.log('tag', rs)
      let empId: string = rs.id;
      this.isUpdate = true;
      this.LoadEducations(this.employee);
      this.LoadIdCards(this.employee);
      this.LoadIdAllowance(this.employee)
      this.LoadIdHealthHistories(this.employee)

    }, error => {
      console.log('(update employee error)', error)
    })

    setTimeout(() => {
      this.spinner.hide();
    }, 1500);
  }


  GetInstitutionName(id: any) {
    let name
    this.eduInstitution.Get(id).subscribe((resp: any) => {
      name = resp.name
    })
    console.log('(tag)', name)
  }

  private extractData(res: any) {
    const body = res;
    return body || {};
  }

  dtOptions: DataTables.Settings = {};
  @ViewChild(DataTableDirective, { static: false })
  dtElement: DataTableDirective;
  dtTriggerEdu: Subject<any> = new Subject();
  edus: EmployeeEducation[] = []

  openDialogAddEducation() {
    console.log('edus', this.edus)
    let data = new EmployeeEducation();
    data.id = this.emp.DummyEmpId()
    data.employee = this.formxx.value.employee.id
    const dialogRef = this.dialog.open(ModalAddEmployeeEducationComponent, {
      width: '600px', data: data
    });
    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed ' + result);
      if (result != 'CANCEL') {
        let edu = JSON.parse(result)
        console.log('tag', edu)
        if (this.employee.startsWith("E")) {
          this.LoadEducations(this.employee)
        } else {
          this.edus.push(edu)
        }
      }
    });
  }

  ShowUpdateEducation(data: any) {
    const dialogRef = this.dialog.open(ModalAddEmployeeEducationComponent, {
      width: '600px', data: data
    });
    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed ' + result);
      if (result != 'CANCEL') {
        this.LoadEducations(this.employee)
      }
    });
  }

  removeEducationRow(row: any) {
    console.log('(tag)', row)
    Swal.fire({
      title: 'ຢືນຢັນການລຶບ',
      text: 'ຕ້ອງການລຶບຂໍ້ມູນການສຶກສານີ້ອອກແທ້ບໍ່',
      icon: 'question',
      showCancelButton: true,
      confirmButtonText: 'ດຳເນີນການຕໍ່',
      cancelButtonText: 'ຍົກເລີກ'

    }).then((result: any) => {
      if (result.value) {
        this.edus.forEach((value, index) => {
          if (value == row) {
            if (value.isNew == true) {
              this.edus.splice(index, 1)
            } else {
              this.empEdu.Delete(value.id).subscribe((resp: any) => {
                if (resp == "SUCCESS") { this.edus.splice(index, 1); }
              })
            }
            this.LoadEducations(this.employee)
          }
        })
      } else if (result.dismiss === Swal.DismissReason.cancel) {
        this.spinner.hide();
      }
    })
  }

  openDialogAddIdCard() {
    let data = new EmployeeIdentity();
    data.id = this.emp.DummyEmpId()
    data.employee = this.formxx.value.employee.id
    const dialogRef = this.dialog.open(ModalIdCardComponent, {
      width: '600px', data: data
    });
    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed ' + result);
      if (result != 'CANCEL') {
        let ei = JSON.parse(result)
        console.log('tag', ei)
        if (this.employee.startsWith("E")) {

          this.LoadIdCards(this.employee)

        } else {
          this.empIdCards.push(ei)

        }
      }
    });
  }

  empIdCards: EmployeeIdentity[] = []
  dtTriggerIdCard: Subject<any> = new Subject();
  dtElementIdCard: DataTableDirective;

  LoadIdCards(empId: any) {

    this.empIdentity.GetList(empId).pipe(this.extractData)
      .subscribe((reps: any) => {
        console.log('LoadIdCards', reps)
        this.empIdCards = [];
        let list = reps as EmployeeIdentity[]
        list.forEach(item => {
          this.empIdCards.push(item)
        })
      }, error => {
        console.log('tag', error)
      })
  }

  ShowUpdateIdCard(data: any) {
    const dialogRef = this.dialog.open(ModalIdCardComponent, {
      width: '600px', data: data
    });
    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed ' + result);
      if (result != 'CANCEL') {
        this.LoadIdCards(this.employee)
      }
    });
  }

  removeIdCardRow(row: any) {
    console.log('tag', row)
    Swal.fire({
      title: 'ຢືນຢັນການລຶບ',
      text: 'ຕ້ອງການລຶບຂໍ້ມູນເອກະສານນີ້ອອກແທ້ບໍ່',
      icon: 'question',
      showCancelButton: true,
      confirmButtonText: 'ດຳເນີນການຕໍ່',
      cancelButtonText: 'ຍົກເລີກ'

    }).then((result: any) => {
      if (result.value) {
        this.empIdCards.forEach((value, index) => {
          if (value == row) {
            console.log('will', value)
            if (value.id.startsWith("TEMP")) {
              console.log('TEMP', value)
              this.empIdCards.splice(index, 1)
            } else {
              console.log('delete', value)

              this.empIdentity.Delete(row.id).subscribe((resp: any) => {
                console.log('(tag)', resp)
                if (resp == "SUCCESS") {
                  this.empIdCards.splice(index, 1);
                  this.LoadIdCards(this.employee)
                }
              })
            }
          }
        })
      } else if (result.dismiss === Swal.DismissReason.cancel) {
        this.spinner.hide();
      }
    })
  }
  employeeAllowances: EmployeeAllowance[] = []
  openDialogAddAllowance() {
    let data = new EmployeeAllowance();
    data.id = this.emp.DummyEmpId()
    data.employee = this.formxx.value.employee.id
    const dialogRef = this.dialog.open(ModalEmployeeAllownceComponent, {
      width: '600px', data: data
    });
    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed ' + result);
      if (result != 'CANCEL') {
        let ei = JSON.parse(result)
        console.log('tag', ei)
        if (this.employee.startsWith("E")) {

          this.LoadIdAllowance(this.employee)

        } else {
          this.employeeAllowances.push(ei)

        }
      }
    });
  }

  LoadIdAllowance(empId: any) {
    this.empAllowance.GetList(empId).pipe(this.extractData)
      .subscribe((reps: any) => {
        console.log('empAllowance', reps)
        this.employeeAllowances = [];
        let list = reps as EmployeeAllowance[]
        list.forEach(item => {
          this.employeeAllowances.push(item)
        })
      }, error => {
        console.log('tag', error)
      })
  }

  ShowUpdateAllowance(data: any) {
    const dialogRef = this.dialog.open(ModalEmployeeAllownceComponent, {
      width: '600px', data: data
    });
    dialogRef.afterClosed().subscribe(result => {
      if (result != 'CANCEL') {
        console.log('The dialog was closed ' + result);
        this.LoadIdAllowance(this.employee)
      }
    });
  }

  removeAllowance(row: any) {
    console.log('tag', row)
    Swal.fire({
      title: 'ຢືນຢັນການລຶບ',
      text: 'ຕ້ອງການລຶບຂໍ້ມູນນີ້ອອກແທ້ບໍ່',
      icon: 'question',
      showCancelButton: true,
      confirmButtonText: 'ດຳເນີນການຕໍ່',
      cancelButtonText: 'ຍົກເລີກ'

    }).then((result: any) => {
      if (result.value) {
        this.employeeAllowances.forEach((value, index) => {
          if (value == row) {
            console.log('will', value)
            if (value.id.startsWith("TEMP")) {
              console.log('TEMP', value)
              this.employeeAllowances.splice(index, 1)
            } else {
              console.log('delete', value)

              this.empAllowance.Delete(row.id).subscribe((resp: any) => {
                console.log('(tag)', resp)
                if (resp == "SUCCESS") {
                  this.employeeAllowances.splice(index, 1);
                  this.LoadIdAllowance(this.employee)
                }
              })
            }
          }
        })
      } else if (result.dismiss === Swal.DismissReason.cancel) {
        this.spinner.hide();
      }
    })
  }

  employeehealths: EmployeeHealthHistory[] = []
  openDialogAddHealth() {
    let data = new EmployeeHealthHistory();
    data.id = this.emp.DummyEmpId()
    data.employee = this.formxx.value.employee.id
    const dialogRef = this.dialog.open(ModalEmployeeHealthHistoryComponent, {
      width: '600px', data: data
    });
    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed ' + result);
      console.log('tag', result)
      if (result != 'CANCEL') {
        console.log('tag', result)
        let ei = JSON.parse(result)
        console.log('tag', ei)
        if (this.employee.startsWith("E")) {

          this.LoadIdHealthHistories(this.employee)

        } else {
          this.employeehealths.push(ei)

        }
      }
    });
  }

  ShowUpdateHealth(data: any) {
    const dialogRef = this.dialog.open(ModalEmployeeHealthHistoryComponent, {
      width: '600px', data: data
    });
    dialogRef.afterClosed().subscribe(result => {
      if (result != 'CANCEL') {
        console.log('The dialog was closed ' + result);
        this.LoadIdHealthHistories(this.employee)
      }
    });
  }

  removeHealth(row: any) {
    console.log('tag', row)
    Swal.fire({
      title: 'ຢືນຢັນການລຶບ',
      text: 'ຕ້ອງການລຶບຂໍ້ມູນນີ້ອອກແທ້ບໍ່',
      icon: 'question',
      showCancelButton: true,
      confirmButtonText: 'ດຳເນີນການຕໍ່',
      cancelButtonText: 'ຍົກເລີກ'

    }).then((result: any) => {
      if (result.value) {
        this.employeehealths.forEach((value, index) => {
          if (value == row) {
            console.log('will', value)
            if (value.id.startsWith("TEMP")) {
              console.log('TEMP', value)
              this.employeehealths.splice(index, 1)
            } else {
              console.log('delete', value)

              this.empHealth.Delete(row.id).subscribe((resp: any) => {
                console.log('(tag)', resp)
                if (resp == "SUCCESS") {
                  this.employeehealths.splice(index, 1);
                  this.LoadIdHealthHistories(this.employee)
                }
              })
            }
          }
        })
      } else if (result.dismiss === Swal.DismissReason.cancel) {
        this.spinner.hide();
      }
    })
  }

  LoadIdHealthHistories(empId: string) {
    console.log('emp', empId)
    this.empHealth.GetList(empId).pipe(this.extractData)
      .subscribe((reps: any) => {
        console.log('empAllowance', reps)
        this.employeehealths = [];
        let list = reps as EmployeeHealthHistory[]
        list.forEach(item => {
          this.employeehealths.push(item)
        })
      }, error => {
        console.log('tag', error)
      })
  }

}
