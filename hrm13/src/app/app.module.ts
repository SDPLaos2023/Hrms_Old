import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { LoginLayoutComponent } from './login-layout/login-layout.component';
import { DashboardComponent } from './pages/shared/dashboard/dashboard.component';
import { MainLayoutComponent } from './pages/shared/main-layout/main-layout.component';
import { NgxSpinnerModule } from 'ngx-spinner';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CookieService } from 'ngx-cookie-service';
import { HeaderComponent } from './pages/shared/header/header.component';
import { LeftComponent } from './pages/shared/left/left.component';
import { FooterComponent } from './pages/shared/footer/footer.component';
import { TopComponent } from './pages/shared/top/top.component';
import { RightComponent } from './pages/shared/right/right.component';
import { PageNotFoundComponent } from './pages/shared/page-not-found/page-not-found.component';
import { CompanyComponent } from './pages/company/company.component';
import { DivisionComponent } from './pages/master/division/division.component';
import { DepartmentComponent } from './pages/master/department/department.component';
import { SectionComponent } from './pages/master/section/section.component';
import { PositionComponent } from './pages/master/position/position.component';
import { UserProfileComponent } from './pages/user-profile/user-profile.component';
import { ContractComponent } from './pages/contract/contract.component';
import { ContactComponent } from './pages/contact/contact.component';
import { LoginComponent } from './pages/auth/login/login.component';
import { HttpConfigInterceptor } from './interceptor/httpconfig.interceptor';
import { DataTablesModule } from "angular-datatables";
import { MatDialogModule } from '@angular/material/dialog';
import { ModalDepartmentComponent } from './components/modals/modal-department/modal-department.component';
import { ModalDivisionComponent } from './components/modals/modal-division/modal-division.component';
import { ModalSectionComponent } from './components/modals/modal-section/modal-section.component';
import { ModalPositionComponent } from './components/modals/modal-position/modal-position.component';
import { AddNewEmployeeComponent } from './pages/employee/add-new-employee/add-new-employee.component';
import { EmployeePersonalInfoComponent } from './pages/employee/employee-personal-info/employee-personal-info.component';
import { EmployeeJobInfoComponent } from './pages/employee/employee-job-info/employee-job-info.component';
import { EmployeeFamilyInfoComponent } from './pages/employee/employee-family-info/employee-family-info.component';
import { EmployeeEducationInfoComponent } from './pages/employee/employee-education-info/employee-education-info.component';
import { EmployeeMarriageInfoComponent } from './pages/employee/employee-marriage-info/employee-marriage-info.component';
import { EmployeeContactInfoComponent } from './pages/employee/employee-contact-info/employee-contact-info.component';
import { NationalityRaceComponent } from './pages/master/nationality-race/nationality-race.component';
import { ModalNationalityComponent } from './components/modals/modal-nationality/modal-nationality.component';
import { ModalRaceComponent } from './components/modals/modal-race/modal-race.component';
import { ModalBloodGroupComponent } from './components/modals/modal-blood-group/modal-blood-group.component';
import { BloodGroupComponent } from './pages/master/blood-group/blood-group.component';
import { TableNationalityComponent } from './components/tables/table-nationality/table-nationality.component';
import { TableRaceComponent } from './components/tables/table-race/table-race.component';
import { CountryComponent } from './pages/master/country/country.component';
import { ModalCountryComponent } from './components/modals/modal-country/modal-country.component';
import { ModalMaritalStatusComponent } from './components/modals/modal-marital-status/modal-marital-status.component';
import { MaritalStatusComponent } from './pages/master/marital-status/marital-status.component';
import { WorkingTypeComponent } from './pages/master/working-type/working-type.component';
import { EmployeeTypeComponent } from './pages/master/employee-type/employee-type.component';
import { EdicationDegreeTypeComponent } from './pages/master/edication-degree-type/edication-degree-type.component';
import { ModalEducationDegreeTypeComponent } from './components/modals/modal-education-degree-type/modal-education-degree-type.component';
import { ModalWorkingTypeComponent } from './components/modals/modal-working-type/modal-working-type.component';
import { ModalEmployeeTypeComponent } from './components/modals/modal-employee-type/modal-employee-type.component';
import { ModalSalaryTypeComponent } from './components/modals/modal-salary-type/modal-salary-type.component';
import { SalaryTypeComponent } from './pages/master/salary-type/salary-type.component';
import { ResignationReasonComponent } from './pages/master/resignation-reason/resignation-reason.component';
import { ContractTypeComponent } from './pages/master/contract-type/contract-type.component';
import { ModalResignationReasonComponent } from './components/modals/modal-resignation-reason/modal-resignation-reason.component';
import { ModalContractTypeComponent } from './components/modals/modal-contract-type/modal-contract-type.component';
import { EmployeeLevelsComponent } from './pages/master/employee-levels/employee-levels.component';
import { ModalEmployeeLevelComponent } from './components/modals/modal-employee-level/modal-employee-level.component';
import { EmployeeGroupsComponent } from './pages/master/employee-groups/employee-groups.component';
import { ModalEmployeeGroupComponent } from './components/modals/modal-employee-group/modal-employee-group.component';
import { ModalEmployeeCategoryComponent } from './components/modals/modal-employee-category/modal-employee-category.component';
import { EmployeeCategoriesComponent } from './pages/master/employee-categories/employee-categories.component';
import { ProvincesComponent } from './pages/master/provinces/provinces.component';
import { ModalProvinceComponent } from './components/modals/modal-province/modal-province.component';
import { ModalDistrictComponent } from './components/modals/modal-district/modal-district.component';
import { DistrictsComponent } from './pages/master/districts/districts.component';
import { RacesComponent } from './pages/master/races/races.component';
import { BanksComponent } from './pages/master/banks/banks.component';
import { ModalBankComponent } from './components/modals/modal-bank/modal-bank.component';
import { ModalCurrencyComponent } from './components/modals/modal-currency/modal-currency.component';
import { CurrenciesComponent } from './pages/master/currencies/currencies.component';
import { SalaryPayTypesComponent } from './pages/master/salary-pay-types/salary-pay-types.component';
import { ModalSalarayPayTypeComponent } from './components/modals/modal-salaray-pay-type/modal-salaray-pay-type.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { MatMenuModule } from '@angular/material/menu';
import { ModalAddEmployeeEducationComponent } from './components/modals/modal-add-employee-education/modal-add-employee-education.component';
import { EmployeeAllowanceInfoComponent } from './pages/employee/employee-allowance-info/employee-allowance-info.component';
import { EmployeeInsuranceInfoComponent } from './pages/employee/employee-insurance-info/employee-insurance-info.component';
import { EmployeeEmploymentInfoComponent } from './pages/employee/employee-employment-info/employee-employment-info.component';
import { ModalAddCompanyComponent } from './components/modals/modal-add-company/modal-add-company.component';
import { EmployeeListComponent } from './pages/employee/employee-list/employee-list.component';
import { ModalIdCardComponent } from './components/modals/modal-id-card/modal-id-card.component';
import { ModalEduInstitutionComponent } from './modals/modal-edu-institution/modal-edu-institution.component';
import { DatePipe, HashLocationStrategy, LocationStrategy, PathLocationStrategy } from '@angular/common';
import { ModalEmployeeAllownceComponent } from './modals/modal-employee-allownce/modal-employee-allownce.component';
import { ModalEmployeeHealthHistoryComponent } from './modals/modal-employee-health-history/modal-employee-health-history.component';
import { TransactionTypeComponent } from './pages/master/transaction-type/transaction-type.component';
import { EmployeeTransactionComponent } from './pages/employee-transaction/employee-transaction.component';
import { EmployeeTransationTimelineComponent } from './pages/employee-transation-timeline/employee-transation-timeline.component';
import { ModalEmployeeTransactionComponent } from './modals/modal-employee-transaction/modal-employee-transaction.component';
import { UploadAvatarComponent } from './components/upload-avatar/upload-avatar.component';
import { UploadDocumentComponent } from './components/upload-document/upload-document.component';
import { ModalTransactionTypeComponent } from './components/modals/modal-transaction-type/modal-transaction-type.component';
import { FpManagementComponent } from './pages/master/fp-management/fp-management.component';
import { LeaveTypeComponent } from './pages/master/leave-type/leave-type.component';
import { ModalAnnualLeaveComponent } from './components/modals/modal-annual-leave/modal-annual-leave.component';
import { InstitutionsComponent } from './pages/master/institutions/institutions.component';
import { ModalInstitutionComponent } from './components/modals/modal-institution/modal-institution.component';
import { ModalFpManagerComponent } from './components/modals/modal-fp-manager/modal-fp-manager.component';
import { FpUsersComponent } from './pages/master/fp-users/fp-users.component';
import { ModalFpUserComponent } from './components/modals/modal-fp-user/modal-fp-user.component';
import { FpFingerprintMappingComponent } from './pages/master/fp-fingerprint-mapping/fp-fingerprint-mapping.component';
import { ModalCopyUserComponent } from './components/modals/modal-copy-user/modal-copy-user.component';
import { ListEmployeeComponent } from './pages/timesheet/list-employee/list-employee.component';
import { MonthlyTimesheetComponent } from './pages/timesheet/monthly-timesheet/monthly-timesheet.component';
import { TimeTableComponent } from './pages/attendances/time-table/time-table.component';
import { ModalTimeTableComponent } from './components/modals/modal-time-table/modal-time-table.component';
import { TimeAssignmentComponent } from './pages/attendances/time-assignment/time-assignment.component';
import { ListDraftPublicHolidayComponent } from './pages/master/list-draft-public-holiday/list-draft-public-holiday.component';
import { PublicHolidayComponent } from './pages/public-holiday/public-holiday.component';
import { ModalPublicHolidayComponent } from './modals/modal-public-holiday/modal-public-holiday.component';
import { UsersComponent } from './pages/users/users.component';
import { ModalUsersComponent } from './modals/modal-users/modal-users.component';
import { ModalSelectEmployeeComponent } from './modals/modal-select-employee/modal-select-employee.component';
import { RulesComponent } from './pages/users/rules/rules.component';
import { FormUserComponent } from './pages/users/form-user/form-user.component';
import { RuleItemsComponent } from './pages/users/rules/rule-items/rule-items.component';
import { ModalRuleComponent } from './modals/modal-rule/modal-rule.component';
import { ModalRuleItemComponent } from './modals/modal-rule-item/modal-rule-item.component';
import { EncrDecrService } from './Services/encr-decr.service';
import { AdminLeftComponent } from './manus/admin-left/admin-left.component';
import { UsersLeftComponent } from './manus/users-left/users-left.component';
import { ItLeftComponent } from './manus/it-left/it-left.component';
import { ManagersLeftComponent } from './manus/managers-left/managers-left.component';
import { SupervisorsLeftComponent } from './manus/supervisors-left/supervisors-left.component';
import { SuperusersLeftComponent } from './manus/superusers-left/superusers-left.component';
import { AttCalculateComponent } from './timesheet/att-calculate/att-calculate.component';
import { MatTableModule } from '@angular/material/table';
import { ChangePasswordComponent } from './pages/users/change-password/change-password.component';
import { ModalSelectFpNoneUserComponent } from './components/modals/modal-select-fp-none-user/modal-select-fp-none-user.component';
import { UpdateTimestampComponent } from './pages/attendances/update-timestamp/update-timestamp.component';
import { AddTimestampComponent } from './pages/attendances/add-timestamp/add-timestamp.component';
import { PrintComponent } from './pages/timesheet/print/print.component';
import { BlankLayoutComponent } from './pages/shared/blank-layout/blank-layout.component';
import { WorkingPeriodComponent } from './pages/attendances/working-period/working-period.component';
import { HrLeftComponent } from './menus/hr-left/hr-left.component';
import { ShiftmanagementComponent } from './pages/attendances/shiftmanagement/shiftmanagement.component';
import { ModalShiftmanagementComponent } from './components/modals/modal-shiftmanagement/modal-shiftmanagement.component';
import { ShiftDetailComponent } from './pages/attendances/shift-detail/shift-detail.component';
import { ModalAddShitftimeComponent } from './components/modals/modal-add-shitftime/modal-add-shitftime.component';
import { LeaveRequestComponent } from './pages/leaves/leave-request/leave-request.component';
import { LeaveHistoryComponent } from './pages/leaves/leave-history/leave-history.component';
import { LeaveRequestFormComponent } from './pages/leaves/leave-request-form/leave-request-form.component';
import { LeaveRequestWComponent } from './pages/leaves/leave-request-w/leave-request-w.component';
import { LeaveRequestApprovedComponent } from './pages/leaves/leave-request-approved/leave-request-approved.component';
import { LeaveRequestRejectedComponent } from './pages/leaves/leave-request-rejected/leave-request-rejected.component';
import { LeaveRequestActiveComponent } from './pages/leaves/leave-request-active/leave-request-active.component';
import { PrintSummaryComponent } from './pages/leaves/print-summary/print-summary.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginLayoutComponent,
    DashboardComponent,
    MainLayoutComponent,
    HeaderComponent,
    LeftComponent,
    FooterComponent,
    TopComponent,
    RightComponent,
    PageNotFoundComponent,
    CompanyComponent,
    DivisionComponent,
    DepartmentComponent,
    SectionComponent,
    PositionComponent,
    UserProfileComponent,
    ContractComponent,
    ContactComponent,
    LoginComponent,
    ModalDepartmentComponent,
    ModalDivisionComponent,
    ModalSectionComponent,
    ModalPositionComponent,
    AddNewEmployeeComponent,
    EmployeePersonalInfoComponent,
    EmployeeJobInfoComponent,
    EmployeeFamilyInfoComponent,
    EmployeeEducationInfoComponent,
    EmployeeMarriageInfoComponent,
    EmployeeContactInfoComponent,
    NationalityRaceComponent,
    ModalNationalityComponent,
    ModalRaceComponent,
    ModalBloodGroupComponent,
    BloodGroupComponent,
    TableNationalityComponent,
    TableRaceComponent,
    CountryComponent,
    ModalCountryComponent,
    ModalMaritalStatusComponent,
    MaritalStatusComponent,
    WorkingTypeComponent,
    EmployeeTypeComponent,
    EdicationDegreeTypeComponent,
    ModalEducationDegreeTypeComponent,
    ModalWorkingTypeComponent,
    ModalEmployeeTypeComponent,
    ModalSalaryTypeComponent,
    SalaryTypeComponent,
    ResignationReasonComponent,
    ContractTypeComponent,
    ModalResignationReasonComponent,
    ModalContractTypeComponent,
    EmployeeLevelsComponent,
    ModalEmployeeLevelComponent,
    EmployeeGroupsComponent,
    ModalEmployeeGroupComponent,
    ModalEmployeeCategoryComponent,
    EmployeeCategoriesComponent,
    ProvincesComponent,
    ModalProvinceComponent,
    ModalDistrictComponent,
    DistrictsComponent,
    RacesComponent,
    BanksComponent,
    ModalBankComponent,
    ModalCurrencyComponent,
    CurrenciesComponent,
    ModalEducationDegreeTypeComponent,
    SalaryPayTypesComponent,
    ModalSalarayPayTypeComponent,
    ModalAddEmployeeEducationComponent,
    EmployeeAllowanceInfoComponent,
    EmployeeInsuranceInfoComponent,
    EmployeeEmploymentInfoComponent,
    ModalAddCompanyComponent,
    EmployeeListComponent,
    ModalIdCardComponent,
    ModalEduInstitutionComponent,
    ModalEmployeeAllownceComponent,
    ModalEmployeeHealthHistoryComponent,
    TransactionTypeComponent,
    EmployeeTransactionComponent,
    EmployeeTransationTimelineComponent,
    ModalEmployeeTransactionComponent,
    UploadAvatarComponent,
    UploadDocumentComponent,
    ModalTransactionTypeComponent,
    FpManagementComponent,
    LeaveTypeComponent,
    ModalAnnualLeaveComponent,
    InstitutionsComponent,
    ModalInstitutionComponent,
    ModalFpManagerComponent,
    FpUsersComponent,
    ModalFpUserComponent,
    FpFingerprintMappingComponent,
    ModalCopyUserComponent,
    ListEmployeeComponent,
    MonthlyTimesheetComponent,
    TimeTableComponent,
    ModalTimeTableComponent,
    TimeAssignmentComponent,
    ListDraftPublicHolidayComponent,
    PublicHolidayComponent,
    ModalPublicHolidayComponent,
    UsersComponent,
    ModalUsersComponent,
    ModalSelectEmployeeComponent,
    RulesComponent,
    FormUserComponent,
    RuleItemsComponent,
    ModalRuleComponent,
    ModalRuleItemComponent,
    AdminLeftComponent,
    UsersLeftComponent,
    ItLeftComponent,
    ManagersLeftComponent,
    SupervisorsLeftComponent,
    SuperusersLeftComponent,
    AttCalculateComponent,
    ChangePasswordComponent,
    ModalSelectFpNoneUserComponent,
    UpdateTimestampComponent,
    AddTimestampComponent,
    PrintComponent,
    BlankLayoutComponent,
    WorkingPeriodComponent,
    HrLeftComponent,
    ShiftmanagementComponent,
    ModalShiftmanagementComponent,
    ShiftDetailComponent,
    ModalAddShitftimeComponent,
    LeaveRequestComponent,
    LeaveHistoryComponent,
    LeaveRequestFormComponent,
    LeaveRequestWComponent,
    LeaveRequestApprovedComponent,
    LeaveRequestRejectedComponent,
    LeaveRequestActiveComponent,
    PrintSummaryComponent
  ],
  imports: [
    // NgModule,
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    NgxSpinnerModule,
    DataTablesModule, MatDialogModule, MatMenuModule, MatTableModule
  ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
  providers: [EncrDecrService, DatePipe,
    CookieService, { provide: HTTP_INTERCEPTORS, useClass: HttpConfigInterceptor, multi: true },
    { provide: LocationStrategy, useClass: HashLocationStrategy }, Location, { provide: LocationStrategy, useClass: PathLocationStrategy }],
  bootstrap: [AppComponent]
})
export class AppModule { }
