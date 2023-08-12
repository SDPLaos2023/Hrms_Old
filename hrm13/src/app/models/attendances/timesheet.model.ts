export class Timesheet {
    id: string;
    attDate: Date;
    clockIn: string | null;
    clockOut: string | null;
    rawIn: string;
    rawOut: string;
    remark: string;
    employee: string;
    employeeName: string;
    lateMin: string;
    earlyMin: string;
    workMin: string;
    division: string;
    divisionName: string;
    department: string;
    departmentName: string;
    section: string;
    sectionName: string;
    code: string;
}

