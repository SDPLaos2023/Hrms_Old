import { IdentityType } from "./identity-type.model"

export class IdCard {
    id: string
    idNumber: string
    idType: string
    idExpiryDate: string
    idIssuedBy: string
    employee: string
    idTypeNavigation: IdentityType
}
