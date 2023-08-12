import { Component, OnInit } from '@angular/core';
import { Department } from 'src/app/models/department.model';
import { Division } from 'src/app/models/division.model';
import { EmployeeCategory } from 'src/app/models/employee-category.model';
import { EmployeeGroup } from 'src/app/models/employee-group.model';
import { EmployeeLevel } from 'src/app/models/employee-level.model';
import { EmployeeType } from 'src/app/models/employee-type.model';
import { Position } from 'src/app/models/position.model';
import { Section } from 'src/app/models/section.model';
import { WorkingType } from 'src/app/models/working-type.model';
import { DepartmentService } from 'src/app/Services/department.service';
import { DivisionService } from 'src/app/Services/division.service';
import { EmployeeCategoryService } from 'src/app/Services/employee-category.service';
import { EmployeeGroupService } from 'src/app/Services/employee-group.service';
import { EmployeeLevelService } from 'src/app/Services/employee-level.service';
import { EmployeeTypeService } from 'src/app/Services/employee-type.service';
import { PositionService } from 'src/app/Services/position.service';
import { SectionService } from 'src/app/Services/section.service';
import { WorkingTypeService } from 'src/app/Services/working-type.service';

@Component({
  selector: 'app-employee-employment-info',
  templateUrl: './employee-employment-info.component.html',
  styleUrls: ['./employee-employment-info.component.css']
})
export class EmployeeEmploymentInfoComponent implements OnInit {

  constructor(
    private departmentService: DepartmentService,
    private divisionService: DivisionService,
    private sectionService: SectionService,
    private positionService: PositionService,
    private employeeTypeService: EmployeeTypeService,
    private employeeGroupService: EmployeeGroupService,
    private employeeCategoryService: EmployeeCategoryService,
    private employeeLevelService: EmployeeLevelService,
    private workingTypeService: WorkingTypeService,
  ) { }

  ngOnInit(): void {
    this.GetDepartments();
    this.GetDivisions();
    this.GetSections();
    this.GetPositions();
    this.GetDepartments();
    this.GetEmployeeLevels();
    this.GetEmployeeGroups();
    this.GetEmployeeTypes();
    this.GetEmployeeCategories();
    this.GetWorkingTypes();

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
}
