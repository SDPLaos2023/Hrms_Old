import { IdentityType } from "./identity-type.model"

export class EmployeeIdentity {
    id: string
    idNumber: string
    idType: string
    idExpiryDate: string
    idIssuedBy: string
    employee: string
    idTypeNavigation: IdentityType

}
