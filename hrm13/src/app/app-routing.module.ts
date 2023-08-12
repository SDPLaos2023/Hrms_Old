import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './pages/shared/dashboard/dashboard.component';
import { MainLayoutComponent } from './pages/shared/main-layout/main-layout.component';
import { LoginComponent } from './pages/auth/login/login.component';
import { LoginLayoutComponent } from './login-layout/login-layout.component';
import { PageNotFoundComponent } from './pages/shared/page-not-found/page-not-found.component';
import { CompanyComponent } from './pages/company/company.component';
import { DepartmentComponent } from './pages/master/department/department.component';
import { DivisionComponent } from './pages/master/division/division.component';
import { SectionComponent } from './pages/master/section/section.component';
import { PositionComponent } from './pages/master/position/position.component';
import { UserProfileComponent } from './pages/user-profile/user-profile.component';
import { ContactComponent } from './pages/contact/contact.component';
import { ContractComponent } from './pages/contract/contract.component';
import { AuthGuardService } from './Services/auth-guard.service';
import { NoneGuardService } from './Services/none-guard.service';
import { AddNewEmployeeComponent } from './pages/employee/add-new-employee/add-new-employee.component';
import { NationalityRaceComponent } from './pages/master/nationality-race/nationality-race.component';
import { BloodGroupComponent } from './pages/master/blood-group/blood-group.component';
import { CountryComponent } from './pages/master/country/country.component';
import { MaritalStatusComponent } from './pages/master/marital-status/marital-status.component';
import { EmployeeTypeComponent } from './pages/master/employee-type/employee-type.component';
import { WorkingTypeComponent } from './pages/master/working-type/working-type.component';
import { SalaryTypeComponent } from './pages/master/salary-type/salary-type.component';
import { ContractTypeComponent } from './pages/master/contract-type/contract-type.component';
import { ResignationReasonComponent } from './pages/master/resignation-reason/resignation-reason.component';
import { EmployeeLevelsComponent } from './pages/master/employee-levels/employee-levels.component';
import { EmployeeGroupsComponent } from './pages/master/employee-groups/employee-groups.component';
import { EmployeeCategoriesComponent } from './pages/master/employee-categories/employee-categories.component';
import { ProvincesComponent } from './pages/master/provinces/provinces.component';
import { DistrictsComponent } from './pages/master/districts/districts.component';
import { RacesComponent } from './pages/master/races/races.component';
import { BanksComponent } from './pages/master/banks/banks.component';
import { CurrenciesComponent } from './pages/master/currencies/currencies.component';
import { ModalEducationDegreeTypeComponent } from './components/modals/modal-education-degree-type/modal-education-degree-type.component';
import { EdicationDegreeTypeComponent } from './pages/master/edication-degree-type/edication-degree-type.component';
import { SalaryPayTypesComponent } from './pages/master/salary-pay-types/salary-pay-types.component';
import { EmployeeListComponent } from './pages/employee/employee-list/employee-list.component';
import { EmployeeTransactionComponent } from './pages/employee-transaction/employee-transaction.component';
import { EmployeeTransationTimelineComponent } from './pages/employee-transation-timeline/employee-transation-timeline.component';
import { TransactionTypeComponent } from './pages/master/transaction-type/transaction-type.component';
import { LeaveTypeComponent } from './pages/master/leave-type/leave-type.component';
import { InstitutionsComponent } from './pages/master/institutions/institutions.component';
import { FpManagementComponent } from './pages/master/fp-management/fp-management.component';
import { FpUsersComponent } from './pages/master/fp-users/fp-users.component';
import { FpFingerprintMappingComponent } from './pages/master/fp-fingerprint-mapping/fp-fingerprint-mapping.component';
import { ListEmployeeComponent } from './pages/timesheet/list-employee/list-employee.component';
import { MonthlyTimesheetComponent } from './pages/timesheet/monthly-timesheet/monthly-timesheet.component';
import { TimeTableComponent } from './pages/attendances/time-table/time-table.component';
import { ListDraftPublicHolidayComponent } from './pages/master/list-draft-public-holiday/list-draft-public-holiday.component';
import { PublicHolidayComponent } from './pages/public-holiday/public-holiday.component';
import { UsersComponent } from './pages/users/users.component';
import { RulesComponent } from './pages/users/rules/rules.component';
import { RuleItemsComponent } from './pages/users/rules/rule-items/rule-items.component';
import { FormUserComponent } from './pages/users/form-user/form-user.component';
import { AttCalculateComponent } from './timesheet/att-calculate/att-calculate.component';
import { ChangePasswordComponent } from './pages/users/change-password/change-password.component';
import { TimeAssignmentComponent } from './pages/attendances/time-assignment/time-assignment.component';
import { UpdateTimestampComponent } from './pages/attendances/update-timestamp/update-timestamp.component';
import { AddTimestampComponent } from './pages/attendances/add-timestamp/add-timestamp.component';
import { PrintComponent } from './pages/timesheet/print/print.component';
import { BlankLayoutComponent } from './pages/shared/blank-layout/blank-layout.component';
import { WorkingPeriodComponent } from './pages/attendances/working-period/working-period.component';
import { ShiftmanagementComponent } from './pages/attendances/shiftmanagement/shiftmanagement.component';
import { ShiftDetailComponent } from './pages/attendances/shift-detail/shift-detail.component';
import { LeaveRequestComponent } from './pages/leaves/leave-request/leave-request.component';
import { LeaveRequestFormComponent } from './pages/leaves/leave-request-form/leave-request-form.component';
import { LeaveHistoryComponent } from './pages/leaves/leave-history/leave-history.component';
import { LeaveRequestWComponent } from './pages/leaves/leave-request-w/leave-request-w.component';
import { LeaveRequestActiveComponent } from './pages/leaves/leave-request-active/leave-request-active.component';
import { LeaveRequestApprovedComponent } from './pages/leaves/leave-request-approved/leave-request-approved.component';
import { LeaveRequestRejectedComponent } from './pages/leaves/leave-request-rejected/leave-request-rejected.component';
import { PrintSummaryComponent } from './pages/leaves/print-summary/print-summary.component';

const routes: Routes = [
  {
    path: '', component: LoginLayoutComponent, children: [
      { path: '', redirectTo: '/login', pathMatch: 'full' },
      { path: 'login', component: LoginComponent, canActivate: [NoneGuardService] },
      { path: '404', component: PageNotFoundComponent },
      //{ path: 'timesheet/print', component: PrintComponent },

    ]
  },
  {
    path: '', component: BlankLayoutComponent, children: [
      { path: 'timesheet/print/:employee', component: PrintComponent },
      { path: 'leave-print-summary/:employee', component: PrintSummaryComponent },

    ]
  },
  {
    path: '', component: MainLayoutComponent, canActivate: [AuthGuardService], canActivateChild: [AuthGuardService], children: [
      { path: '', redirectTo: '/dashboard', pathMatch: 'full' },
      { path: 'institutions', component: InstitutionsComponent },
      { path: 'user-profile', component: UserProfileComponent },
      { path: 'contact', component: ContactComponent },
      { path: 'contract', component: ContractComponent },
      { path: 'contract-type', component: ContractTypeComponent },
      { path: 'resignation-reason', component: ResignationReasonComponent },
      { path: 'dashboard', component: DashboardComponent, canActivate: [AuthGuardService] },
      { path: 'company', component: CompanyComponent },
      { path: 'department', component: DepartmentComponent },
      { path: 'division', component: DivisionComponent },
      { path: 'section', component: SectionComponent },
      { path: 'position', component: PositionComponent },
      { path: 'new-employee', component: AddNewEmployeeComponent },
      { path: 'employees/:empid', component: AddNewEmployeeComponent },
      { path: 'employees', component: EmployeeListComponent },
      { path: 'employee-type', component: EmployeeTypeComponent },
      { path: 'working-type', component: WorkingTypeComponent },
      { path: 'nationalities', component: NationalityRaceComponent },
      { path: 'races', component: RacesComponent },
      { path: 'bloodgroup', component: BloodGroupComponent },
      { path: 'countries', component: CountryComponent },
      { path: 'provinces', component: ProvincesComponent },
      { path: 'provinces/districts/:province', component: DistrictsComponent },
      { path: 'marital-status', component: MaritalStatusComponent },
      { path: 'education-degree', component: EdicationDegreeTypeComponent },
      { path: 'salary-type', component: SalaryTypeComponent },
      { path: 'salary-pay-type', component: SalaryPayTypesComponent },
      { path: 'employee-level', component: EmployeeLevelsComponent },
      { path: 'employee-group', component: EmployeeGroupsComponent },
      { path: 'employee-category', component: EmployeeCategoriesComponent },
      { path: 'banks', component: BanksComponent },
      { path: 'currencies', component: CurrenciesComponent },
      { path: 'employee-transaction', component: EmployeeTransactionComponent },
      { path: 'employee-transaction/:empid', component: EmployeeTransactionComponent },
      { path: 'employee-transaction/timeline/:empid', component: EmployeeTransationTimelineComponent },
      { path: 'transaction-type', component: TransactionTypeComponent },
      { path: 'leave-type', component: LeaveTypeComponent },
      {
        path: 'fingerprints', component: FpManagementComponent
      },
      { path: 'time-assignment', component: TimeAssignmentComponent },
      { path: 'timetables', component: TimeTableComponent },
      { path: 'fingerprints/users/:fpid/:fpName', component: FpUsersComponent },
      { path: 'fingerprints/:fpUserId', component: FpFingerprintMappingComponent },
      { path: 'timesheet/inquiry', component: ListEmployeeComponent },
      { path: 'timesheet/inquiry/monthly', component: MonthlyTimesheetComponent },
      { path: 'timesheet/monthly/self', component: MonthlyTimesheetComponent },
      { path: 'draft/public-holiday', component: ListDraftPublicHolidayComponent },
      { path: 'public-holiday', component: PublicHolidayComponent },
      { path: 'users', component: UsersComponent },
      { path: 'new-user', component: FormUserComponent },
      { path: 'user-info/:user_id', component: FormUserComponent },
      { path: 'user-rights', component: RulesComponent },
      { path: 'user-rights/items/:rule_id', component: RuleItemsComponent },
      { path: 'timesheet/calculation', component: AttCalculateComponent },
      { path: 'user-change-password/seft', component: ChangePasswordComponent },
      { path: 'updatetimestamp', component: UpdateTimestampComponent },
      { path: 'timesheet/addtime', component: AddTimestampComponent },
      { path: 'timesheet/working-period', component: WorkingPeriodComponent },
      { path: 'timesheet/shift-management', component: ShiftmanagementComponent },
      { path: 'timesheet/shift-management/detail/:shift', component: ShiftDetailComponent },


      { path: 'leave-request/:condition', component: LeaveRequestComponent },
      { path: 'leave-request-active/:condition', component: LeaveRequestActiveComponent },
      { path: 'leave-request-approved/:condition', component: LeaveRequestApprovedComponent },
      { path: 'leave-request-rejected/:condition', component: LeaveRequestRejectedComponent },
      { path: 'leave-request-form/:condition', component: LeaveRequestFormComponent },
      { path: 'leave-request-form/:condition/:leaveid', component: LeaveRequestFormComponent },
      { path: 'leave-histories/:condition', component: LeaveHistoryComponent },
      { path: 'leave-request/:condition/:leaveid', component: LeaveRequestWComponent },



    ]
  },
  { path: '*', redirectTo: '/dashboard' },
  { path: '**', redirectTo: '/404' },

];

@NgModule({
  declarations: [],
  exports: [RouterModule],
  imports: [
    CommonModule,
    RouterModule.forRoot(routes)
  ]
})
export class AppRoutingModule { }
