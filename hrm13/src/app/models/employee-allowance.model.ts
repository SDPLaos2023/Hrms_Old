import { Allowance } from "./allowance.model"

export class EmployeeAllowance {
    id: string
    employee: string
    allowance: string
    rate: string
    status: string
    createdAt: string
    createdBy: string
    updatedAt: string
    updatedBy: string
    allowanceNavigation: Allowance
}
