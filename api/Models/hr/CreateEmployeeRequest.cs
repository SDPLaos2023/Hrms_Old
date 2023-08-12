using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hrm_api.Models.hr
{
    public class CreateEmployeeRequest
    {
        public Tbemployee employee { get; set; }
        public TbemployeeContact contact { get; set; }
        public TbemployeeFamilyContact familyContact { get; set; }
        public TbemployeeContract contract { get; set; }
        public TbemployeeProbation probationContract { get; set; }
        public TbemployeeClassification classification { get; set; }
        public TbemployeeEmployment employment { get; set; }
        public TbemployeeSalarySetting salarySetting { get; set; }
        public TbemployeeLeaveSetting leaveSetting { get; set; }
        
        public TbemployeeInsurance insurance { get; set; }
        public TbemployeeIdentity[] idCards { get; set; }
        public TbemployeeEducationHistory[] educations { get; set; }
        public TbemployeeHealthHistory[] healthHistories { get; set; }
        public TbemployeeAllowance[] allowances { get; set; }
    }

    //public class Employee
    //{
    //    public string Id { get; set; }
    //    public string Code { get; set; }
    //    public string Name { get; set; }
    //    public string NameEn { get; set; }
    //    public DateTime Dob { get; set; }
    //    public int age { get; set; }
    //    public string Gender { get; set; }
    //    public string BloodGroup { get; set; }
    //    public string Nationality { get; set; }
    //    public string Race { get; set; }
    //    public string Address { get; set; }
    //    public string Province { get; set; }
    //    public string District { get; set; }
    //    public string Country { get; set; }
    //    public string Status { get; set; }
    //    public string MaritalStatus { get; set; }
    //    public string CreatedBy { get; set; }
    //    public DateTime CreatedAt { get; set; }
    //    public string UpdatedBy { get; set; }
    //    public DateTime UpdatedAt { get; set; }
    //}

    //public class Contact
    //{
    //    public string Id { get; set; }
    //    public string Employee { get; set; }
    //    public string Mobile { get; set; }
    //    public string Home { get; set; }
    //    public string Email { get; set; }
    //    public string Wa { get; set; }
    //    public string Line { get; set; }
    //    public string Wechat { get; set; }
    //    public string Facebook { get; set; }
    //    public string Twitter { get; set; }
    //    public string ContactPerson { get; set; }
    //    public string ContactNumber { get; set; }
    //    public string ContactRelation { get; set; }
    //    public string CreatedBy { get; set; }
    //    public DateTime CreatedAt { get; set; }
    //    public string UpdatedBy { get; set; }
    //    public DateTime UpdatedAt { get; set; }
    //}

    //public class Familycontact
    //{
    //    public string Id { get; set; }
    //    public string Employee { get; set; }
    //    public string FatherName { get; set; }
    //    public string FatherDob { get; set; }
    //    public string FatherAge { get; set; }
    //    public string FatherContactNumber { get; set; }
    //    public string MotherName { get; set; }
    //    public string MotherDob { get; set; }
    //    public string MotherAge { get; set; }
    //    public string MotherContactNumber { get; set; }
    //    public string SpouseName { get; set; }
    //    public string SpouseDob { get; set; }
    //    public string SpouseAge { get; set; }
    //    public string SpouseContactNumber { get; set; }
    //    public string NoChildren { get; set; }
    //    public string NoDaughter { get; set; }
    //}

    //public class Contract
    //{
    //    public string Id { get; set; }
    //    public string Employee { get; set; }
    //    public string ContractType { get; set; }
    //    public string ContractStartAt { get; set; }
    //    public string ContractStopAt { get; set; }
    //    public string ContractNo { get; set; }
    //    public DateTime CreatedAt { get; set; }
    //    public string CreatedBy { get; set; }
    //    public DateTime UpdatedAt { get; set; }
    //    public string UpdatedBy { get; set; }
    //}

    //public class Probationcontract
    //{
    //    public string Id { get; set; }
    //    public string Employee { get; set; }
    //    public string ContractStartAt { get; set; }
    //    public string ContractStopAt { get; set; }
    //    public DateTime CreatedAt { get; set; }
    //    public string CreatedBy { get; set; }
    //    public DateTime UpdatedAt { get; set; }
    //    public string UpdatedBy { get; set; }
    //}

    //public class Classification
    //{
    //    public string Id { get; set; }
    //    public string Employee { get; set; }
    //    public string EmployeeType { get; set; }
    //    public string EmployeeGroup { get; set; }
    //    public string EmployeeCategory { get; set; }
    //    public string EmployeeLevel { get; set; }
    //    public string EmployeeWorkingType { get; set; }
    //    public DateTime CreatedAt { get; set; }
    //    public string CreatedBy { get; set; }
    //    public DateTime UpdatedAt { get; set; }
    //    public string UpdatedBy { get; set; }
    //}

    //public class Employment
    //{
    //    public string Id { get; set; }
    //    public string Employee { get; set; }
    //    public string Position { get; set; }
    //    public string Department { get; set; }
    //    public string Division { get; set; }
    //    public string Section { get; set; }
    //    public DateTime CreatedAt { get; set; }
    //    public string CreatedBy { get; set; }
    //    public DateTime UpdatedAt { get; set; }
    //    public string UpdatedBy { get; set; }
    //}

    //public class Salarysetting
    //{
    //    public string Id { get; set; }
    //    public string Employee { get; set; }
    //    public string BaseSalary { get; set; }
    //    public string SalaryType { get; set; }
    //    public string SalaryPayType { get; set; }
    //    public string Bank { get; set; }
    //    public string BankAccount { get; set; }
    //    public DateTime CreatedAt { get; set; }
    //    public string CreatedBy { get; set; }
    //    public DateTime UpdatedAt { get; set; }
    //    public string UpdatedBy { get; set; }
    //}

    //public class Leavesetting
    //{
    //    public string Id { get; set; }
    //    public string Employee { get; set; }
    //    public string EmployeeAnnualLeave { get; set; }
    //    public string Ratio { get; set; }
    //    public string Remain { get; set; }
    //}

    //public class Insurance
    //{
    //    public string Id { get; set; }
    //    public string Employee { get; set; }
    //    public string Ssn { get; set; }
    //    public string Rate { get; set; }
    //    public string InsuranceCertificate { get; set; }
    //    public string InsuranceExpiryDate { get; set; }
    //    public DateTime CreatedAt { get; set; }
    //    public string CreatedBy { get; set; }
    //    public DateTime UpdatedAt { get; set; }
    //    public string UpdatedBy { get; set; }
    //}


}
