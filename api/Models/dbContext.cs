using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hrm_api.Models
{
    public partial class dbContext : DbContext
    {
        public dbContext()
        {

        }
        public dbContext(DbContextOptions<dbContext> options)
           : base(options)
        {
        }

        public virtual DbSet<Timesheet> Tbtimesheets { get; set; }
        public virtual DbSet<DepartmentTimesheet> SpDepartmentTimesheets { get; set; }
        public virtual DbSet<attendance.CalculateAttendanceResponse> SpCalculateAttendance { get; set; }
        public virtual DbSet<attendance.Workingperiod> SpWorkingperiod { get; set; }
        public virtual DbSet<hr.Employee> SpGetEmployeeByDept { get; set; }
        //public virtual DbSet<LeaveHistory> SpGetLeaveRequestByEmpId { get; set; }
        //public virtual DbSet<LeaveHistory> SpGetLeaveHistoryByEmpId { get; set; }
        public virtual DbSet<LeaveHistory> SpSupervisorGetEmployeeLeaveRequest { get; set; }
        public virtual DbSet<LeaveHistory> SpSupervisorGetEmployeeLeaveRequestApproved { get; set; }
        public virtual DbSet<LeaveHistory> SpSupervisorGetEmployeeLeaveRequestRejected { get; set; }
        public virtual DbSet<LeaveHistory> SpHrGetEmployeeLeaveRequest { get; set; }
        public virtual DbSet<LeaveHistory> SpHrGetEmployeeLeaveRequestApproved { get; set; }
        public virtual DbSet<LeaveHistory> SpHrGetEmployeeLeaveRequestRejected { get; set; }
        public virtual DbSet<LeaveHistory> SpEmployeeGetLeaveHistories { get; set; }
        public virtual DbSet<LeaveHistory> SpEmployeeGetLeaveRequest { get; set; }
        public virtual DbSet<LeaveSummary> SpEmployeeGetLeaveSummary { get; set; }





        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("server=localhost;user=auth;password=auth;database=hrm_project;charset=utf8;SslMode=none;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Timesheet>(entity =>
            {
                entity.ToTable("tbtimesheets");

                //entity.HasIndex(e => e.Employee, "timsheet_employee");

                entity.Property(e => e.Id)
                    .HasMaxLength(100)
                    .HasColumnName("id");

                entity.Property(e => e.AttDate)
                    .HasColumnType("date")
                    .HasColumnName("att_date")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.ClockIn)
                    .HasColumnName("clock_in")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.ClockOut)
                    .HasColumnName("clock_out")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Division)
                    .HasMaxLength(50)
                    .HasColumnName("division")
                    .HasDefaultValueSql("'NULL'")
                    .HasComment("'NULL'");
                entity.Property(e => e.DivisionName)
                   .HasMaxLength(50)
                   .HasColumnName("division_name")
                   .HasDefaultValueSql("'NULL'")
                   .HasComment("'NULL'");

                entity.Property(e => e.Department)
                    .HasMaxLength(50)
                    .HasColumnName("department")
                    .HasDefaultValueSql("'NULL'")
                    .HasComment("'NULL'");
                entity.Property(e => e.DepartmentName)
                   .HasMaxLength(50)
                   .HasColumnName("department_name")
                   .HasDefaultValueSql("'NULL'")
                   .HasComment("'NULL'");

                entity.Property(e => e.Section)
                    .HasMaxLength(50)
                    .HasColumnName("section")
                    .HasDefaultValueSql("'NULL'")
                    .HasComment("'NULL'");
                entity.Property(e => e.SectionName)
                   .HasMaxLength(50)
                   .HasColumnName("section_name")
                   .HasDefaultValueSql("'NULL'")
                   .HasComment("'NULL'");

                entity.Property(e => e.EarlyMin)
                    .HasColumnType("int(11)")
                    .HasColumnName("early_out_min")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.WorkMin)
                    .HasColumnType("int(11)")
                    .HasColumnName("workmin")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Employee)
                    .HasMaxLength(100)
                    .HasColumnName("employee")
                    .HasDefaultValueSql("'NULL'");
                entity.Property(e => e.EmployeeName)
                   .HasMaxLength(100)
                   .HasColumnName("employee_name")
                   .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.LateMin)
                    .HasColumnType("int(11)")
                    .HasColumnName("late_in_min")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.RawIn)
                    .HasColumnName("raw_in")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.RawOut)
                    .HasColumnName("raw_out")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Remark)
                    .HasMaxLength(500)
                    .HasColumnName("remark")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Code)
                    .HasColumnName("code")
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<DepartmentTimesheet>(entity =>
            {
                //entity.To("tbtimesheets");
                entity.Property(e => e.FpUserId)
                     .HasMaxLength(50)
                    .HasColumnName("fp_user_id")
                    .HasDefaultValueSql("'NULL'");
                entity.Property(e => e.AttDate)
                    .HasColumnType("date")
                    .HasColumnName("att_date")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.CIn)
                    .HasColumnName("c_in")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.COut)
                    .HasColumnName("c_out")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Division)
                    .HasMaxLength(50)
                    .HasColumnName("division")
                    .HasDefaultValueSql("'NULL'")
                    .HasComment("'NULL'");

                entity.Property(e => e.Department)
                    .HasMaxLength(50)
                    .HasColumnName("department")
                    .HasDefaultValueSql("'NULL'")
                    .HasComment("'NULL'");

                entity.Property(e => e.Section)
                    .HasMaxLength(50)
                    .HasColumnName("section")
                    .HasDefaultValueSql("'NULL'")
                    .HasComment("'NULL'");

                entity.Property(e => e.EarlyMin)
                    .HasColumnType("int(11)")
                    .HasColumnName("early_out")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.WorkMin)
                    .HasColumnType("int(11)")
                    .HasColumnName("workmin")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Employee)
                    .HasMaxLength(100)
                    .HasColumnName("employee")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.EmployeeName)
                    .HasMaxLength(100)
                    .HasColumnName("employee_name")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.LateMin)
                    .HasColumnType("int(11)")
                    .HasColumnName("late_in")
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<attendance.CalculateAttendanceResponse>(entity =>
            {
                entity.Property(e => e.employeecode)
                     .HasMaxLength(100)
                    .HasColumnName("employeecode");
                entity.Property(e => e.employeename)
                    .HasColumnName("employeename")
                    .HasDefaultValueSql("'NULL'");
                entity.Property(e => e.minwork)
                    .HasColumnName("minwork")
                    .HasDefaultValueSql("'NULL'");
                entity.Property(e => e.late_in)
                    .HasColumnName("late_in")
                    .HasDefaultValueSql("'NULL'");
                entity.Property(e => e.total_late)
                    .HasColumnName("total_late")
                    .HasDefaultValueSql("'NULL'");
                entity.Property(e => e.early_out)
                    .HasColumnName("early_out")
                    .HasDefaultValueSql("'NULL'");
                entity.Property(e => e.total_early_out)
                    .HasColumnName("total_early_out")
                    .HasDefaultValueSql("'NULL'");
                entity.Property(e => e.totalworkdays)
                    .HasColumnName("totalworkdays")
                    .HasDefaultValueSql("'NULL'");
                entity.Property(e => e.totaldays)
                    .HasColumnName("totaldays")
                    .HasDefaultValueSql("'NULL'");
                entity.Property(e => e.total_hrs)
                    .HasColumnName("total_hrs")
                    .HasDefaultValueSql("'NULL'");
                entity.Property(e => e.totalworkhrs)
                    .HasColumnName("totalworkhrs")
                    .HasDefaultValueSql("'NULL'");
                entity.Property(e => e.totalmissdays)
                    .HasColumnName("totalmissdays")
                    .HasDefaultValueSql("'NULL'");
                entity.Property(e => e.totalleavewp)
                    .HasColumnName("totalleavewp")
                    .HasDefaultValueSql("'NULL'");
                entity.Property(e => e.totalleavewop)
                    .HasColumnName("totalleavewop")
                    .HasDefaultValueSql("'NULL'");
                entity.Property(e => e.totalleaves)
                    .HasColumnName("totalleaves")
                    .HasDefaultValueSql("'NULL'");
                entity.Property(e => e.sessionid)
                    .HasColumnName("sessionid")
                    .HasDefaultValueSql("'NULL'");
                entity.Property(e => e.created_by)
                    .HasColumnName("created_by")
                    .HasDefaultValueSql("'NULL'");
                entity.Property(e => e.data_asofdate)
                    .HasColumnName("data_asofdate")
                    .HasDefaultValueSql("'NULL'");

            });


            modelBuilder.Entity<hr.Employee>(entity =>
            {
                entity.Property(e => e.employeecode)
                     .HasMaxLength(100)
                    .HasColumnName("employeecode");
                entity.Property(e => e.employeename)
                    .HasColumnName("employeename")
                    .HasDefaultValueSql("'NULL'");
                entity.Property(e => e.fp_user_id)
                    .HasColumnName("fp_user_id")
                    .HasDefaultValueSql("'NULL'");
                entity.Property(e => e.department)
                    .HasColumnName("department")
                    .HasDefaultValueSql("'NULL'");
                entity.Property(e => e.departmentname)
                    .HasColumnName("departmentname")
                    .HasDefaultValueSql("'NULL'");
                entity.Property(e => e.division)
                    .HasColumnName("division")
                    .HasDefaultValueSql("'NULL'");
                entity.Property(e => e.divisionname)
                    .HasColumnName("divisionname")
                    .HasDefaultValueSql("'NULL'");
                entity.Property(e => e.section)
                    .HasColumnName("section")
                    .HasDefaultValueSql("'NULL'");
                entity.Property(e => e.sectionname)
                      .HasColumnName("sectionname")
                      .HasDefaultValueSql("'NULL'");

            });


            modelBuilder.Entity<attendance.Workingperiod>(entity =>
            {
                entity.Property(e => e.id)
                    .HasColumnName("id");
                entity.Property(e => e.company)
                    .HasColumnName("company")
                    .HasDefaultValueSql("'NULL'");
                entity.Property(e => e.name)
                    .HasColumnName("name")
                    .HasDefaultValueSql("'NULL'");
                entity.Property(e => e.started_at)
                    .HasColumnName("started_at")
                    .HasDefaultValueSql("'NULL'");
                entity.Property(e => e.ended_at)
                    .HasColumnName("ended_at")
                    .HasDefaultValueSql("'NULL'");
                entity.Property(e => e.total)
                    .HasColumnName("total")
                    .HasDefaultValueSql("'NULL'");
                entity.Property(e => e.working_hrs)
                    .HasColumnName("working_hrs")
                    .HasDefaultValueSql("'NULL'");
                entity.Property(e => e.created_at)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'NULL'");
                entity.Property(e => e.created_by)
                      .HasColumnName("created_by")
                      .HasDefaultValueSql("'NULL'");
                entity.Property(e => e.updated_at)
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("'NULL'");
                entity.Property(e => e.updated_by)
                      .HasColumnName("updated_by")
                      .HasDefaultValueSql("'NULL'");
                entity.Property(e => e.status)
                      .HasColumnName("status")
                      .HasDefaultValueSql("'NULL'");

            });

            modelBuilder.Entity<LeaveHistory>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Name)
                      .HasColumnName("name")
                      .HasDefaultValueSql("'NULL'");
                entity.Property(e => e.Employee)
                     .HasColumnName("employee")
                     .HasDefaultValueSql("'NULL'");
                entity.Property(e => e.LeaveType)
                     .HasColumnName("leave_type")
                     .HasDefaultValueSql("'NULL'");
                entity.Property(e => e.Datefrom)
                     .HasColumnName("datefrom")
                     .HasDefaultValueSql("'NULL'");
                entity.Property(e => e.Dateto)
                     .HasColumnName("dateto")
                     .HasDefaultValueSql("'NULL'");
                entity.Property(e => e.Total)
                     .HasColumnName("total")
                     .HasDefaultValueSql("'NULL'");
                entity.Property(e => e.NeedApproval)
                     .HasColumnName("need_approval")
                     .HasDefaultValueSql("'NULL'");
                entity.Property(e => e.NeedHrApproval)
                     .HasColumnName("need_hr_approval")
                     .HasDefaultValueSql("'NULL'");
                entity.Property(e => e.ApprovedBy)
                     .HasColumnName("approved_by")
                     .HasDefaultValueSql("'NULL'");
                entity.Property(e => e.HrApprovedBy)
                     .HasColumnName("hr_approved_by")
                     .HasDefaultValueSql("'NULL'");
                entity.Property(e => e.ApprovalNote)
                     .HasColumnName("approval_note")
                     .HasDefaultValueSql("'NULL'");
                entity.Property(e => e.HrApprovalNote)
                     .HasColumnName("hr_approval_note")
                     .HasDefaultValueSql("'NULL'");
                entity.Property(e => e.CreatedAt)
                     .HasColumnName("created_at")
                     .HasDefaultValueSql("'NULL'");
                entity.Property(e => e.CreatedBy)
                     .HasColumnName("created_by")
                     .HasDefaultValueSql("'NULL'");
                entity.Property(e => e.UpdatedAt)
                     .HasColumnName("updated_at")
                     .HasDefaultValueSql("'NULL'");
                entity.Property(e => e.UpdatedBy)
                     .HasColumnName("updated_by")
                     .HasDefaultValueSql("'NULL'");
                entity.Property(e => e.Remark)
                     .HasColumnName("remark")
                     .HasDefaultValueSql("'NULL'");
                entity.Property(e => e.FpUserId)
                     .HasColumnName("fp_user_id")
                     .HasDefaultValueSql("'NULL'");
                entity.Property(e => e.Company)
                    .HasColumnName("company")
                    .HasDefaultValueSql("'NULL'");
                entity.Property(e => e.Department)
                    .HasColumnName("department")
                    .HasDefaultValueSql("'NULL'");
                entity.Property(e => e.DepartmentName)
                    .HasColumnName("department_name")
                    .HasDefaultValueSql("'NULL'");
                entity.Property(e => e.Division)
                    .HasColumnName("division")
                    .HasDefaultValueSql("'NULL'");
                entity.Property(e => e.DivisionName)
                    .HasColumnName("division_name")
                    .HasDefaultValueSql("'NULL'");
                entity.Property(e => e.Section)
                    .HasColumnName("section")
                    .HasDefaultValueSql("'NULL'");
                entity.Property(e => e.SectionName)
                    .HasColumnName("section_name")
                    .HasDefaultValueSql("'NULL'");
                entity.Property(e => e.LeaveTypeName)
                    .HasColumnName("leave_type_name")
                    .HasDefaultValueSql("'NULL'");
                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasDefaultValueSql("'NULL'");
            });


            modelBuilder.Entity<LeaveSummary>(entity =>
            {
                entity.Property(e => e.Employee)
                      .HasColumnName("employee")
                      .HasDefaultValueSql("'NULL'");
                entity.Property(e => e.EmployeeName)
                     .HasColumnName("employee_name")
                     .HasDefaultValueSql("'NULL'");
                entity.Property(e => e.CreatedAt)
                     .HasColumnName("created_at")
                     .HasDefaultValueSql("'NULL'");
                entity.Property(e => e.Datefrom)
                     .HasColumnName("datefrom")
                     .HasDefaultValueSql("'NULL'");
                entity.Property(e => e.Dateto)
                     .HasColumnName("dateto")
                     .HasDefaultValueSql("'NULL'");
                entity.Property(e => e.Total)
                     .HasColumnName("total")
                     .HasDefaultValueSql("'NULL'");
                entity.Property(e => e.LeaveType)
                     .HasColumnName("leave_type")
                     .HasDefaultValueSql("'NULL'");
                entity.Property(e => e.LeaveTypeName)
                     .HasColumnName("leave_name")
                     .HasDefaultValueSql("'NULL'");
                entity.Property(e => e.Remark)
                     .HasColumnName("remark")
                     .HasDefaultValueSql("'NULL'");
                entity.Property(e => e.PeriodYear)
                     .HasColumnName("period_year")
                     .HasDefaultValueSql("'NULL'");
                entity.Property(e => e.HrApprovalName)
                     .HasColumnName("hr_approval_name")
                     .HasDefaultValueSql("'NULL'");
                entity.Property(e => e.SpApprovalName)
                     .HasColumnName("sp_approval_name")
                     .HasDefaultValueSql("'NULL'");
                entity.Property(e => e.FpUserId)
                     .HasColumnName("fp_user_id")
                     .HasDefaultValueSql("'NULL'");
            });


            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);


    }
    public partial class Timesheet
    {
        public string Id { get; set; }
        public DateTime? AttDate { get; set; }
        public TimeSpan? ClockIn { get; set; }
        public TimeSpan? ClockOut { get; set; }
        public TimeSpan? RawIn { get; set; }
        public TimeSpan? RawOut { get; set; }
        public string Remark { get; set; }
        public string Employee { get; set; }
        public string EmployeeName { get; set; }
        public int? LateMin { get; set; }
        public int? EarlyMin { get; set; }
        public int? WorkMin { get; set; }
        public string Division { get; set; }
        public string DivisionName { get; set; }
        public string Department { get; set; }
        public string DepartmentName { get; set; }
        public string Section { get; set; }
        public string SectionName { get; set; }
        public string Code { get; set; }
    }

    [Keyless]
    public partial class DepartmentTimesheet
    {
        public string? FpUserId { get; set; }
        public DateTime? AttDate { get; set; }
        public DateTime? CIn { get; set; }
        public DateTime? COut { get; set; }
        public string? Employee { get; set; }
        public string? EmployeeName { get; set; }
        public int? LateMin { get; set; }
        public int? EarlyMin { get; set; }
        public int? WorkMin { get; set; }
        public string? Division { get; set; }
        public string? Department { get; set; }
        public string? Section { get; set; }
    }

    [Keyless]
    public class LeaveHistory
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public string Employee { get; set; }
        public string LeaveType { get; set; }
        public DateTime Datefrom { get; set; }
        public DateTime Dateto { get; set; }
        public int Total { get; set; }
        public int NeedApproval { get; set; }
        public int NeedHrApproval { get; set; }
        public string ApprovedBy { get; set; }
        public string HrApprovedBy { get; set; }
        public string ApprovalNote { get; set; }
        public string HrApprovalNote { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public string Remark { get; set; }
        public string FpUserId { get; set; }
        public string Company { get; set; }
        public string Department { get; set; }
        public string DepartmentName { get; set; }
        public string Division { get; set; }
        public string DivisionName { get; set; }
        public string Section { get; set; }
        public string SectionName { get; set; }
        public string LeaveTypeName { get; set; }
        public string Status { get; set; } //ACTIVE CANCELED S-APPROVED S-REJECTED H-APPROVED H-REJECTED
    }

    [Keyless]
    public class LeaveSummary
    {
        public string Employee { get; set; }//
        public string EmployeeName { get; set; }//
        public DateTime CreatedAt { get; set; }//
        public DateTime Datefrom { get; set; }//
        public DateTime Dateto { get; set; }//
        public int Total { get; set; }//
        public string LeaveType { get; set; }//
        public string LeaveTypeName { get; set; }//
        public string Remark { get; set; }//
        public string PeriodYear { get; set; }//
        public string HrApprovalName { get; set; }//
        public string SpApprovalName { get; set; }//
        public string FpUserId { get; set; }//
    }

}
