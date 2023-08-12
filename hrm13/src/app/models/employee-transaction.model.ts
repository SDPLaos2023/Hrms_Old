import { TransactionType } from "./transaction-type.model"

export class EmployeeTransaction {
    id: string
    employee: string
    transactionType: string
    effectiveDate: string
    description: string
    createdAt: string
    createdBy: string
    updatedAt: string
    updatedBy: string
    transactionTypeNavigation: TransactionType


}
