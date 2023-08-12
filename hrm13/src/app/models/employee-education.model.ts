import { EducationDegree } from "./education-degree.model"
import { EducationInstitution } from "./education-institution.model"

export class EmployeeEducation {
    id: string
    employee: string
    institution: string
    degree: string
    sequence: string
    year: string
    major: string
    gpa: string
    isNew: boolean = false
    degreeNavigation: EducationDegree = new EducationDegree()
    institutionNavigation: EducationInstitution = new EducationInstitution();
}

