using System;
using System.Collections.Generic;

#nullable disable

namespace hrm_api.Models
{
    public partial class Tbemployee
    {
        public Tbemployee()
        {
            AuthUsers = new HashSet<AuthUser>();
            Tbattendancelogs = new HashSet<Tbattendancelog>();
            TbemployeeAllowances = new HashSet<TbemployeeAllowance>();
            TbemployeeClassifications = new HashSet<TbemployeeClassification>();
            TbemployeeContacts = new HashSet<TbemployeeContact>();
            TbemployeeContracts = new HashSet<TbemployeeContract>();
            TbemployeeEducationHistories = new HashSet<TbemployeeEducationHistory>();
            TbemployeeEmployments = new HashSet<TbemployeeEmployment>();
            TbemployeeFamilyContacts = new HashSet<TbemployeeFamilyContact>();
            TbemployeeHealthHistories = new HashSet<TbemployeeHealthHistory>();
            TbemployeeIdentities = new HashSet<TbemployeeIdentity>();
            TbemployeeInsurances = new HashSet<TbemployeeInsurance>();
            TbemployeeLeaveSettings = new HashSet<TbemployeeLeaveSetting>();
            TbemployeeProbations = new HashSet<TbemployeeProbation>();
            TbemployeeSalaryHistories = new HashSet<TbemployeeSalaryHistory>();
            TbemployeeSalarySettings = new HashSet<TbemployeeSalarySetting>();
            TbemployeeSupervisorEmployeeNavigations = new HashSet<TbemployeeSupervisor>();
            TbemployeeSupervisorSupervisorNavigations = new HashSet<TbemployeeSupervisor>();
            TbemployeeTransactions = new HashSet<TbemployeeTransaction>();
            TbleaveRequests = new HashSet<TbleaveRequest>();
            TbtimeAssigments = new HashSet<TbtimeAssigment>();
            Tbtimesheets = new HashSet<Tbtimesheet>();
        }

        public string Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string NameEn { get; set; }
        public DateTime? Dob { get; set; }
        public string Gender { get; set; }
        public string BloodGroup { get; set; }
        public string Nationality { get; set; }
        public string Race { get; set; }
        public string IdCard { get; set; }
        public DateTime? IdCardExpiryDate { get; set; }
        public string IdCardIssuedBy { get; set; }
        public string PassportNo { get; set; }
        public DateTime? PassportExpiryDate { get; set; }
        public string PassportIssuedBy { get; set; }
        public string Address { get; set; }
        public string Province { get; set; }
        public string District { get; set; }
        public string Country { get; set; }
        public string Status { get; set; }
        public string MaritalStatus { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string Avatar { get; set; }
        public string Company { get; set; }

        public virtual Tbbloodgroup BloodGroupNavigation { get; set; }
        public virtual Tbcompany CompanyNavigation { get; set; }
        public virtual Tbcountry CountryNavigation { get; set; }
        public virtual Tbdistrict DistrictNavigation { get; set; }
        public virtual Tbmarriage MaritalStatusNavigation { get; set; }
        public virtual Tbnationality NationalityNavigation { get; set; }
        public virtual Tbprovince ProvinceNavigation { get; set; }
        public virtual Tbrace RaceNavigation { get; set; }
        public virtual ICollection<AuthUser> AuthUsers { get; set; }
        public virtual ICollection<Tbattendancelog> Tbattendancelogs { get; set; }
        public virtual ICollection<TbemployeeAllowance> TbemployeeAllowances { get; set; }
        public virtual ICollection<TbemployeeClassification> TbemployeeClassifications { get; set; }
        public virtual ICollection<TbemployeeContact> TbemployeeContacts { get; set; }
        public virtual ICollection<TbemployeeContract> TbemployeeContracts { get; set; }
        public virtual ICollection<TbemployeeEducationHistory> TbemployeeEducationHistories { get; set; }
        public virtual ICollection<TbemployeeEmployment> TbemployeeEmployments { get; set; }
        public virtual ICollection<TbemployeeFamilyContact> TbemployeeFamilyContacts { get; set; }
        public virtual ICollection<TbemployeeHealthHistory> TbemployeeHealthHistories { get; set; }
        public virtual ICollection<TbemployeeIdentity> TbemployeeIdentities { get; set; }
        public virtual ICollection<TbemployeeInsurance> TbemployeeInsurances { get; set; }
        public virtual ICollection<TbemployeeLeaveSetting> TbemployeeLeaveSettings { get; set; }
        public virtual ICollection<TbemployeeProbation> TbemployeeProbations { get; set; }
        public virtual ICollection<TbemployeeSalaryHistory> TbemployeeSalaryHistories { get; set; }
        public virtual ICollection<TbemployeeSalarySetting> TbemployeeSalarySettings { get; set; }
        public virtual ICollection<TbemployeeSupervisor> TbemployeeSupervisorEmployeeNavigations { get; set; }
        public virtual ICollection<TbemployeeSupervisor> TbemployeeSupervisorSupervisorNavigations { get; set; }
        public virtual ICollection<TbemployeeTransaction> TbemployeeTransactions { get; set; }
        public virtual ICollection<TbleaveRequest> TbleaveRequests { get; set; }
        public virtual ICollection<TbtimeAssigment> TbtimeAssigments { get; set; }
        public virtual ICollection<Tbtimesheet> Tbtimesheets { get; set; }
    }
}
