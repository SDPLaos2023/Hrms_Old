import { HttpClient } from '@angular/common/http';
import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { NgxSpinnerService } from 'ngx-spinner';
import { Subject } from 'rxjs';
import { BloodGroup } from 'src/app/models/blood-group.model';
import { Country } from 'src/app/models/country.model';
import { District } from 'src/app/models/district.model';
import { EmployeeContact } from 'src/app/models/employee-contact.model';
import { Employee } from 'src/app/models/employee.model';
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
import { UitlsService } from 'src/app/Services/shared/uitls.service';
import { UserInfoService } from 'src/app/Services/shared/user-info.service';
import Swal from 'sweetalert2'

@Component({
  selector: 'app-employee-personal-info',
  templateUrl: './employee-personal-info.component.html',
  styleUrls: ['./employee-personal-info.component.css']
})
export class EmployeePersonalInfoComponent implements OnInit {
  countries: Country[] = [];
  provinces: Province[] = [];
  districts: District[] = [];
  age: number;
  employee: Employee
  _emloyee = new Subject<Employee>();
  readonly _emloyees = this._emloyee.asObservable();


  form: FormGroup = new FormGroup({

    Id: new FormControl(""),
    Code: new FormControl(""),
    Name: new FormControl("", Validators.required),
    NameEn: new FormControl("", Validators.required),
    Dob: new FormControl("", Validators.required),
    age: new FormControl(""),
    Gender: new FormControl("M"),
    BloodGroup: new FormControl("", Validators.required),
    Nationality: new FormControl("", Validators.required),
    Race: new FormControl("", Validators.required),
    IdCard: new FormControl("", Validators.required),
    IdCardExpiryDate: new FormControl(""),
    IdCardIssuedBy: new FormControl(""),
    PassportNo: new FormControl(""),
    PassportExpiryDate: new FormControl(""),
    PassportIssuedBy: new FormControl(""),
    Address: new FormControl(""),
    Province: new FormControl("", Validators.required),
    District: new FormControl("", Validators.required),
    Country: new FormControl("", Validators.required),
    Status: new FormControl("ACTIVE", Validators.required),
    MaritalStatus: new FormControl("", Validators.required),
    CreatedBy: new FormControl("", Validators.required),
    CreatedAt: new FormControl(""),
    UpdatedBy: new FormControl("", Validators.required),
    UpdatedAt: new FormControl(""),

  })



  @Output() isPaid = new EventEmitter<boolean>();
  isUpdate: boolean;

  constructor(
    private countryService: CountryService,
    private provinceService: ProvinceService,
    private districtService: DistrictService,
    private nationalityAndRaceService: NationlityAndRaceService,
    private bloodGroupService: BloodGroupService,
    private util: UitlsService,
    private user: UserInfoService,
    private emp: EmployeeService,
    private mstatusService: MaritalStatusService,
    private spinner: NgxSpinnerService

  ) { }

  ngOnInit(): void {
    this.loadCountries();
    this.loadProvinces();
    this.loadNationalities();
    this.loadRaces();
    this.loadBloodGroups();
    this.loadStatus();
  }

  AgeCalculate() {
    let date = this.form.value.Dob
    let age = this.util.ageCalculator(date)
    this.form.patchValue({
      age: age
    })
  }

  loadProvinces() {
    this.provinceService.GetListProvinces();
    this.provinceService._provinces.subscribe(province => {
      this.provinces.push(province)
    })
  }

  loadDistricts(provinceId: any) {
    this.districtService.GetListDistricts(provinceId);
    this.districtService._districts.subscribe(district => {
      this.districts.push(district)
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

  SaveInfo(isUpdate: any) {
    this.isUpdate = isUpdate;
    if (isUpdate) {
      return false
    }
    let date = new Date();
    this.form.patchValue({
      CreatedAt: date,
      CreatedBy: this.user.GetUsername(),
      UpdatedAt: date,
      UpdatedBy: this.user.GetUsername(),
    })
    if (this.form.valid) {
      this.emp.NewEmployee(this.form.value).subscribe((resp: any) => {
        console.log('NewEmployee', resp)
        this.employee = resp as Employee;
        this._emloyee.next(this.employee)
        console.log(' this.employee ', this.employee)
        this.isUpdate = true;
        this.form.patchValue({ Id: resp.id })
      }, error => {
        this.spinner.hide();
      })

    } else {
      this.spinner.hide();
      Swal.fire({
        title: "ມີບາງຂໍ້ມູນບໍ່ຖືກເລືອກ",
        html: 'ກະລຸນາກວດສອບ',
        icon: "warning",
        cancelButtonText: 'ປິດ'
      })
    }

    return this.employee;

  }
}
