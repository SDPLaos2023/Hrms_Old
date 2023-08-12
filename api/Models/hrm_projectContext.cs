using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace hrm_api.Models
{
    public partial class hrm_projectContext : DbContext
    {
        public hrm_projectContext()
        {
        }

        public hrm_projectContext(DbContextOptions<hrm_projectContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AttlogsBak> AttlogsBaks { get; set; }
        public virtual DbSet<AuthSession> AuthSessions { get; set; }
        public virtual DbSet<AuthUser> AuthUsers { get; set; }
        public virtual DbSet<AuthUserRole> AuthUserRoles { get; set; }
        public virtual DbSet<AuthUserRule> AuthUserRules { get; set; }
        public virtual DbSet<Efmigrationshistory> Efmigrationshistories { get; set; }
        public virtual DbSet<Numbercontrol> Numbercontrols { get; set; }
        public virtual DbSet<Tballowance> Tballowances { get; set; }
        public virtual DbSet<TbannualLeaveType> TbannualLeaveTypes { get; set; }
        public virtual DbSet<Tbattcalculated> Tbattcalculateds { get; set; }
        public virtual DbSet<Tbattendancelog> Tbattendancelogs { get; set; }
        public virtual DbSet<Tbattlog> Tbattlogs { get; set; }
        public virtual DbSet<Tbbank> Tbbanks { get; set; }
        public virtual DbSet<Tbbloodgroup> Tbbloodgroups { get; set; }
        public virtual DbSet<Tbcardmapping> Tbcardmappings { get; set; }
        public virtual DbSet<Tbcompany> Tbcompanies { get; set; }
        public virtual DbSet<Tbcontoller> Tbcontollers { get; set; }
        public virtual DbSet<TbcontractType> TbcontractTypes { get; set; }
        public virtual DbSet<Tbcountry> Tbcountries { get; set; }
        public virtual DbSet<Tbcurrency> Tbcurrencies { get; set; }
        public virtual DbSet<Tbdepartment> Tbdepartments { get; set; }
        public virtual DbSet<Tbdistrict> Tbdistricts { get; set; }
        public virtual DbSet<Tbdivision> Tbdivisions { get; set; }
        public virtual DbSet<TbeducationDegree> TbeducationDegrees { get; set; }
        public virtual DbSet<Tbemployee> Tbemployees { get; set; }
        public virtual DbSet<TbemployeeAllowance> TbemployeeAllowances { get; set; }
        public virtual DbSet<TbemployeeCatagory> TbemployeeCatagories { get; set; }
        public virtual DbSet<TbemployeeClassification> TbemployeeClassifications { get; set; }
        public virtual DbSet<TbemployeeContact> TbemployeeContacts { get; set; }
        public virtual DbSet<TbemployeeContract> TbemployeeContracts { get; set; }
        public virtual DbSet<TbemployeeEducationHistory> TbemployeeEducationHistories { get; set; }
        public virtual DbSet<TbemployeeEmployment> TbemployeeEmployments { get; set; }
        public virtual DbSet<TbemployeeFamilyContact> TbemployeeFamilyContacts { get; set; }
        public virtual DbSet<TbemployeeGroup> TbemployeeGroups { get; set; }
        public virtual DbSet<TbemployeeHealthHistory> TbemployeeHealthHistories { get; set; }
        public virtual DbSet<TbemployeeIdentity> TbemployeeIdentities { get; set; }
        public virtual DbSet<TbemployeeInsurance> TbemployeeInsurances { get; set; }
        public virtual DbSet<TbemployeeLeaveSetting> TbemployeeLeaveSettings { get; set; }
        public virtual DbSet<TbemployeeLevel> TbemployeeLevels { get; set; }
        public virtual DbSet<TbemployeeProbation> TbemployeeProbations { get; set; }
        public virtual DbSet<TbemployeeRelation> TbemployeeRelations { get; set; }
        public virtual DbSet<TbemployeeSalaryHistory> TbemployeeSalaryHistories { get; set; }
        public virtual DbSet<TbemployeeSalarySetting> TbemployeeSalarySettings { get; set; }
        public virtual DbSet<TbemployeeSchedule> TbemployeeSchedules { get; set; }
        public virtual DbSet<TbemployeeSupervisor> TbemployeeSupervisors { get; set; }
        public virtual DbSet<TbemployeeTransaction> TbemployeeTransactions { get; set; }
        public virtual DbSet<TbemployeeType> TbemployeeTypes { get; set; }
        public virtual DbSet<TbemployeeWorkingPeriod> TbemployeeWorkingPeriods { get; set; }
        public virtual DbSet<Tbfile> Tbfiles { get; set; }
        public virtual DbSet<Tbfingerprint> Tbfingerprints { get; set; }
        public virtual DbSet<Tbfingerprintmapping> Tbfingerprintmappings { get; set; }
        public virtual DbSet<Tbfpuser> Tbfpusers { get; set; }
        public virtual DbSet<TbholidaySetting> TbholidaySettings { get; set; }
        public virtual DbSet<TbidentityType> TbidentityTypes { get; set; }
        public virtual DbSet<Tbinstitution> Tbinstitutions { get; set; }
        public virtual DbSet<Tbjob> Tbjobs { get; set; }
        public virtual DbSet<TbleaveRequest> TbleaveRequests { get; set; }
        public virtual DbSet<Tbleavelog> Tbleavelogs { get; set; }
        public virtual DbSet<Tbmarriage> Tbmarriages { get; set; }
        public virtual DbSet<Tbnationality> Tbnationalities { get; set; }
        public virtual DbSet<Tborganizationchart> Tborganizationcharts { get; set; }
        public virtual DbSet<Tbot> Tbots { get; set; }
        public virtual DbSet<Tbotrequest> Tbotrequests { get; set; }
        public virtual DbSet<TbpageMaster> TbpageMasters { get; set; }
        public virtual DbSet<TbpageUri> TbpageUris { get; set; }
        public virtual DbSet<Tbpostion> Tbpostions { get; set; }
        public virtual DbSet<Tbprovince> Tbprovinces { get; set; }
        public virtual DbSet<Tbrace> Tbraces { get; set; }
        public virtual DbSet<Tbrelation> Tbrelations { get; set; }
        public virtual DbSet<Tbresignationreason> Tbresignationreasons { get; set; }
        public virtual DbSet<Tbrole> Tbroles { get; set; }
        public virtual DbSet<Tbrule> Tbrules { get; set; }
        public virtual DbSet<TbruleItem> TbruleItems { get; set; }
        public virtual DbSet<TbsalaryPayType> TbsalaryPayTypes { get; set; }
        public virtual DbSet<TbsalaryType> TbsalaryTypes { get; set; }
        public virtual DbSet<Tbsection> Tbsections { get; set; }
        public virtual DbSet<Tbshiftdetail> Tbshiftdetails { get; set; }
        public virtual DbSet<Tbshiftmanagement> Tbshiftmanagements { get; set; }
        public virtual DbSet<TbtimeAssigment> TbtimeAssigments { get; set; }
        public virtual DbSet<Tbtimesheet> Tbtimesheets { get; set; }
        public virtual DbSet<Tbtimetable> Tbtimetables { get; set; }
        public virtual DbSet<TbtransactionType> TbtransactionTypes { get; set; }
        public virtual DbSet<TbworkingType> TbworkingTypes { get; set; }
        public virtual DbSet<Tbworkingperiod> Tbworkingperiods { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySQL("server=localhost;user=auth;password=auth;database=hrm_project;charset=utf8;SslMode=none;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AttlogsBak>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("attlogs_bak");

                entity.Property(e => e.AttCode)
                    .HasMaxLength(100)
                    .HasColumnName("att_code")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.AttDate)
                    .HasColumnType("date")
                    .HasColumnName("att_date")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.AttTime)
                    .HasColumnName("att_time")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.FpId)
                    .HasMaxLength(100)
                    .HasColumnName("fp_id")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.FpUserId)
                    .HasMaxLength(100)
                    .HasColumnName("fp_user_id")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Id)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("id");
            });

            modelBuilder.Entity<AuthSession>(entity =>
            {
                entity.ToTable("auth_sessions");

                entity.HasIndex(e => e.User, "session_userFk");

                entity.Property(e => e.Id)
                    .HasMaxLength(500)
                    .HasColumnName("ID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("date")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.LastToken)
                    .HasMaxLength(4000)
                    .HasColumnName("last_token")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Location)
                    .HasMaxLength(200)
                    .HasColumnName("location")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Os)
                    .HasMaxLength(100)
                    .HasColumnName("OS")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.User)
                    .HasMaxLength(100)
                    .HasColumnName("user")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.UserNavigation)
                    .WithMany(p => p.AuthSessions)
                    .HasForeignKey(d => d.User)
                    .HasConstraintName("session_userFk");
            });

            modelBuilder.Entity<AuthUser>(entity =>
            {
                entity.ToTable("auth_users");

                entity.HasIndex(e => e.Employee, "user_employeeFk");

                entity.HasIndex(e => e.Role, "user_role");

                entity.HasIndex(e => e.Rule, "user_rule");

                entity.Property(e => e.Id)
                    .HasMaxLength(100)
                    .HasColumnName("ID");

                entity.Property(e => e.Employee)
                    .HasMaxLength(100)
                    .HasColumnName("employee")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.IsChangePwd)
                    .HasColumnName("isChangePwd")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Password)
                    .HasMaxLength(500)
                    .HasColumnName("password")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Role)
                    .HasMaxLength(100)
                    .HasColumnName("role")
                    .HasDefaultValueSql("'''ROLE_USERS'''");

                entity.Property(e => e.Rule)
                    .HasMaxLength(100)
                    .HasColumnName("rule")
                    .HasDefaultValueSql("'''RU00003'''");

                entity.Property(e => e.Status)
                    .HasMaxLength(100)
                    .HasColumnName("status")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Username)
                    .HasMaxLength(250)
                    .HasColumnName("username")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.EmployeeNavigation)
                    .WithMany(p => p.AuthUsers)
                    .HasForeignKey(d => d.Employee)
                    .HasConstraintName("user_employeeFk");

                entity.HasOne(d => d.RoleNavigation)
                    .WithMany(p => p.AuthUsers)
                    .HasForeignKey(d => d.Role)
                    .HasConstraintName("user_role");

                entity.HasOne(d => d.RuleNavigation)
                    .WithMany(p => p.AuthUsers)
                    .HasForeignKey(d => d.Rule)
                    .HasConstraintName("user_rule");
            });

            modelBuilder.Entity<AuthUserRole>(entity =>
            {
                entity.ToTable("auth_user_roles");

                entity.HasIndex(e => e.Role, "role_tbRolesFk");

                entity.HasIndex(e => e.User, "role_user");

                entity.Property(e => e.Id)
                    .HasMaxLength(100)
                    .HasColumnName("ID");

                entity.Property(e => e.Role)
                    .HasMaxLength(100)
                    .HasColumnName("role")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.User)
                    .HasMaxLength(100)
                    .HasColumnName("user")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.RoleNavigation)
                    .WithMany(p => p.AuthUserRoles)
                    .HasForeignKey(d => d.Role)
                    .HasConstraintName("role_tbRolesFk");

                entity.HasOne(d => d.UserNavigation)
                    .WithMany(p => p.AuthUserRoles)
                    .HasForeignKey(d => d.User)
                    .HasConstraintName("role_user");
            });

            modelBuilder.Entity<AuthUserRule>(entity =>
            {
                entity.ToTable("auth_user_rules");

                entity.HasIndex(e => e.User, "auth_userFK");

                entity.HasIndex(e => e.Rule, "user_ruleFK");

                entity.Property(e => e.Id)
                    .HasMaxLength(100)
                    .HasColumnName("id");

                entity.Property(e => e.Rule)
                    .HasMaxLength(100)
                    .HasColumnName("rule")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.User)
                    .HasMaxLength(100)
                    .HasColumnName("user")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.RuleNavigation)
                    .WithMany(p => p.AuthUserRules)
                    .HasForeignKey(d => d.Rule)
                    .HasConstraintName("user_ruleFK");

                entity.HasOne(d => d.UserNavigation)
                    .WithMany(p => p.AuthUserRules)
                    .HasForeignKey(d => d.User)
                    .HasConstraintName("auth_userFK");
            });

            modelBuilder.Entity<Efmigrationshistory>(entity =>
            {
                entity.HasKey(e => e.MigrationId)
                    .HasName("PRIMARY");

                entity.ToTable("__efmigrationshistory");

                entity.Property(e => e.MigrationId).HasMaxLength(150);

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<Numbercontrol>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("PRIMARY");

                entity.ToTable("numbercontrol");

                entity.HasIndex(e => e.Company, "number_companyFk");

                entity.Property(e => e.Code)
                    .HasMaxLength(100)
                    .HasColumnName("code");

                entity.Property(e => e.Company)
                    .HasMaxLength(100)
                    .HasColumnName("company")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Number)
                    .HasColumnType("int(11)")
                    .HasColumnName("number")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Remark)
                    .HasMaxLength(200)
                    .HasColumnName("remark")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Strlength)
                    .HasMaxLength(2)
                    .HasColumnName("strlength")
                    .HasDefaultValueSql("'''6'''");

                entity.HasOne(d => d.CompanyNavigation)
                    .WithMany(p => p.Numbercontrols)
                    .HasForeignKey(d => d.Company)
                    .HasConstraintName("number_companyFk");
            });

            modelBuilder.Entity<Tballowance>(entity =>
            {
                entity.ToTable("tballowances");

                entity.HasIndex(e => e.Group, "group");

                entity.Property(e => e.Id)
                    .HasMaxLength(100)
                    .HasColumnName("ID");

                entity.Property(e => e.Code)
                    .HasMaxLength(10)
                    .HasColumnName("code")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Group)
                    .HasMaxLength(100)
                    .HasColumnName("group")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Name)
                    .HasMaxLength(500)
                    .HasColumnName("name")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.NameEn)
                    .HasMaxLength(500)
                    .HasColumnName("nameEn")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .HasColumnName("status")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.GroupNavigation)
                    .WithMany(p => p.InverseGroupNavigation)
                    .HasForeignKey(d => d.Group)
                    .HasConstraintName("tballowances_ibfk_1");
            });

            modelBuilder.Entity<TbannualLeaveType>(entity =>
            {
                entity.ToTable("tbannual_leave_types");

                entity.HasIndex(e => e.Company, "lt_company_fk");

                entity.Property(e => e.Id)
                    .HasMaxLength(100)
                    .HasColumnName("id");

                entity.Property(e => e.Code)
                    .HasMaxLength(10)
                    .HasColumnName("code")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Company)
                    .HasMaxLength(100)
                    .HasColumnName("company")
                    .HasDefaultValueSql("'''C00001'''");

                entity.Property(e => e.LeaveType)
                    .HasMaxLength(5)
                    .HasColumnName("leave_type")
                    .HasDefaultValueSql("'''WP'''");

                entity.Property(e => e.Name)
                    .HasMaxLength(500)
                    .HasColumnName("name")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.NameEn)
                    .HasMaxLength(500)
                    .HasColumnName("nameEn")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Ratio)
                    .HasColumnType("int(11)")
                    .HasColumnName("ratio")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .HasColumnName("status")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.CompanyNavigation)
                    .WithMany(p => p.TbannualLeaveTypes)
                    .HasForeignKey(d => d.Company)
                    .HasConstraintName("lt_company_fk");
            });

            modelBuilder.Entity<Tbattcalculated>(entity =>
            {
                entity.ToTable("tbattcalculated");

                entity.HasIndex(e => e.Company, "companypk");

                entity.Property(e => e.Id)
                    .HasMaxLength(100)
                    .HasColumnName("id");

                entity.Property(e => e.Company)
                    .HasMaxLength(100)
                    .HasColumnName("company")
                    .HasDefaultValueSql("'''C00001'''");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(100)
                    .HasColumnName("created_by")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.DataAsofdate)
                    .HasColumnType("date")
                    .HasColumnName("data_asofdate")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.EarlyOut)
                    .HasColumnType("int(11)")
                    .HasColumnName("early_out")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Employeecode)
                    .HasMaxLength(100)
                    .HasColumnName("employeecode")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Employeename)
                    .HasMaxLength(500)
                    .HasColumnName("employeename")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.LateIn)
                    .HasColumnType("int(11)")
                    .HasColumnName("late_in")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Minwork)
                    .HasColumnType("int(11)")
                    .HasColumnName("minwork")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Sessionid)
                    .HasMaxLength(250)
                    .HasColumnName("sessionid")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.TotalEarlyOut)
                    .HasColumnType("int(11)")
                    .HasColumnName("total_early_out")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.TotalHrs)
                    .HasColumnType("int(11)")
                    .HasColumnName("total_hrs")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.TotalLate)
                    .HasColumnType("int(11)")
                    .HasColumnName("total_late")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Totaldays)
                    .HasColumnType("int(11)")
                    .HasColumnName("totaldays")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Totalleaves)
                    .HasColumnType("int(11)")
                    .HasColumnName("totalleaves")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Totalleavewop)
                    .HasColumnType("int(11)")
                    .HasColumnName("totalleavewop")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Totalleavewp)
                    .HasColumnType("int(11)")
                    .HasColumnName("totalleavewp")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Totalmissdays)
                    .HasColumnType("int(11)")
                    .HasColumnName("totalmissdays")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Totalworkdays)
                    .HasColumnType("int(11)")
                    .HasColumnName("totalworkdays")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Totalworkhrs)
                    .HasColumnName("totalworkhrs")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.CompanyNavigation)
                    .WithMany(p => p.Tbattcalculateds)
                    .HasForeignKey(d => d.Company)
                    .HasConstraintName("companypk");
            });

            modelBuilder.Entity<Tbattendancelog>(entity =>
            {
                entity.ToTable("tbattendancelogs");

                entity.HasIndex(e => e.Employee, "attendance_employee");

                entity.HasIndex(e => e.FpId, "attendance_fp_id");

                entity.Property(e => e.Id)
                    .HasMaxLength(100)
                    .HasColumnName("id");

                entity.Property(e => e.AttDate)
                    .HasColumnType("date")
                    .HasColumnName("att_date")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.AttTime)
                    .HasColumnName("att_time")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Employee)
                    .HasMaxLength(100)
                    .HasColumnName("employee")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.FpId)
                    .HasMaxLength(100)
                    .HasColumnName("fp_id")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.FpUserId)
                    .HasMaxLength(100)
                    .HasColumnName("fp_user_id")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Status)
                    .HasMaxLength(100)
                    .HasColumnName("status")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.EmployeeNavigation)
                    .WithMany(p => p.Tbattendancelogs)
                    .HasForeignKey(d => d.Employee)
                    .HasConstraintName("attendance_employee");

                entity.HasOne(d => d.Fp)
                    .WithMany(p => p.Tbattendancelogs)
                    .HasForeignKey(d => d.FpId)
                    .HasConstraintName("attendance_fp_id");
            });

            modelBuilder.Entity<Tbattlog>(entity =>
            {
                entity.ToTable("tbattlogs");

                entity.HasIndex(e => e.FpId, "fp_id");

                entity.HasIndex(e => e.FpUserId, "fp_user_id");

                entity.Property(e => e.Id)
                    .HasMaxLength(100)
                    .HasColumnName("id");

                entity.Property(e => e.AttCode)
                    .HasMaxLength(100)
                    .HasColumnName("att_code")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.AttDate)
                    .HasColumnType("date")
                    .HasColumnName("att_date")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.AttTime)
                    .HasColumnName("att_time")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.FpId)
                    .HasMaxLength(100)
                    .HasColumnName("fp_id")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.FpUserId)
                    .HasMaxLength(100)
                    .HasColumnName("fp_user_id")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.Fp)
                    .WithMany(p => p.Tbattlogs)
                    .HasForeignKey(d => d.FpId)
                    .HasConstraintName("attlog_fp");
            });

            modelBuilder.Entity<Tbbank>(entity =>
            {
                entity.ToTable("tbbanks");

                entity.Property(e => e.Id)
                    .HasMaxLength(100)
                    .HasColumnName("ID");

                entity.Property(e => e.Code)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Name)
                    .HasMaxLength(250)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.NameEn)
                    .HasMaxLength(250)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Tbbloodgroup>(entity =>
            {
                entity.ToTable("tbbloodgroups");

                entity.Property(e => e.Id)
                    .HasMaxLength(100)
                    .HasColumnName("ID");

                entity.Property(e => e.Code)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Name)
                    .HasMaxLength(250)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.NameEn)
                    .HasMaxLength(250)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Tbcardmapping>(entity =>
            {
                entity.ToTable("tbcardmappings");

                entity.Property(e => e.Id)
                    .HasMaxLength(100)
                    .HasColumnName("id");

                entity.Property(e => e.CardNumber)
                    .HasMaxLength(100)
                    .HasColumnName("card_number")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Employee)
                    .HasMaxLength(100)
                    .HasColumnName("employee")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.FpId)
                    .HasMaxLength(100)
                    .HasColumnName("fp_id")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Status)
                    .HasMaxLength(100)
                    .HasColumnName("status")
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Tbcompany>(entity =>
            {
                entity.ToTable("tbcompanies");

                entity.HasIndex(e => e.Controller, "controllerFK");

                entity.HasIndex(e => e.Homebranch, "homeBranchFK");

                entity.Property(e => e.Id)
                    .HasMaxLength(100)
                    .HasColumnName("ID");

                entity.Property(e => e.Address)
                    .HasMaxLength(500)
                    .HasColumnName("address")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Code)
                    .HasMaxLength(20)
                    .HasColumnName("code")
                    .HasDefaultValueSql("'NULL'")
                    .HasComment("ຊື່ຫຍໍ້");

                entity.Property(e => e.Controller)
                    .HasMaxLength(100)
                    .HasColumnName("controller")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Homebranch)
                    .HasMaxLength(100)
                    .HasColumnName("homebranch")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Name)
                    .HasMaxLength(500)
                    .HasColumnName("name")
                    .HasDefaultValueSql("'NULL'")
                    .HasComment("ຊື່ບໍລິສັດ");

                entity.Property(e => e.NameEn)
                    .HasMaxLength(500)
                    .HasColumnName("nameEn")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .HasColumnName("status")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.ControllerNavigation)
                    .WithMany(p => p.Tbcompanies)
                    .HasForeignKey(d => d.Controller)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("controllerFK");

                entity.HasOne(d => d.HomebranchNavigation)
                    .WithMany(p => p.InverseHomebranchNavigation)
                    .HasForeignKey(d => d.Homebranch)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("homeBranchFK");
            });

            modelBuilder.Entity<Tbcontoller>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("PRIMARY");

                entity.ToTable("tbcontollers");

                entity.Property(e => e.Code)
                    .HasMaxLength(100)
                    .HasColumnName("code");

                entity.Property(e => e.ControllerName)
                    .HasMaxLength(250)
                    .HasColumnName("controller_name")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Keys)
                    .HasMaxLength(4000)
                    .HasColumnName("keys")
                    .HasDefaultValueSql("'NULL'")
                    .HasComment("key generated by keygen");

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .HasColumnName("status")
                    .HasDefaultValueSql("'NULL'")
                    .HasComment("active inactive suspend");
            });

            modelBuilder.Entity<TbcontractType>(entity =>
            {
                entity.ToTable("tbcontract_types");

                entity.Property(e => e.Id)
                    .HasMaxLength(100)
                    .HasColumnName("ID");

                entity.Property(e => e.Code)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Name)
                    .HasMaxLength(250)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.NameEn)
                    .HasMaxLength(250)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Tbcountry>(entity =>
            {
                entity.ToTable("tbcountries");

                entity.Property(e => e.Id)
                    .HasMaxLength(100)
                    .HasColumnName("ID");

                entity.Property(e => e.Code)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Name)
                    .HasMaxLength(250)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.NameEn)
                    .HasMaxLength(250)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Tbcurrency>(entity =>
            {
                entity.ToTable("tbcurrencies");

                entity.Property(e => e.Id)
                    .HasMaxLength(100)
                    .HasColumnName("ID");

                entity.Property(e => e.Code)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Name)
                    .HasMaxLength(250)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.NameEn)
                    .HasMaxLength(250)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Tbdepartment>(entity =>
            {
                entity.ToTable("tbdepartments");

                entity.HasIndex(e => e.Company, "department_companyFk");

                entity.HasIndex(e => e.Parent, "department_parentFk");

                entity.Property(e => e.Id)
                    .HasMaxLength(100)
                    .HasColumnName("ID");

                entity.Property(e => e.Code)
                    .HasMaxLength(10)
                    .HasColumnName("code")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Company)
                    .HasMaxLength(100)
                    .HasColumnName("company")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Name)
                    .HasMaxLength(500)
                    .HasColumnName("name")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.NameEn)
                    .HasMaxLength(500)
                    .HasColumnName("nameEn")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Parent)
                    .HasMaxLength(100)
                    .HasColumnName("parent")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .HasColumnName("status")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.CompanyNavigation)
                    .WithMany(p => p.Tbdepartments)
                    .HasForeignKey(d => d.Company)
                    .HasConstraintName("department_companyFk");

                entity.HasOne(d => d.ParentNavigation)
                    .WithMany(p => p.InverseParentNavigation)
                    .HasForeignKey(d => d.Parent)
                    .HasConstraintName("department_parentFk");
            });

            modelBuilder.Entity<Tbdistrict>(entity =>
            {
                entity.ToTable("tbdistricts");

                entity.HasIndex(e => e.Province, "District_ProvinceFk");

                entity.Property(e => e.Id)
                    .HasMaxLength(100)
                    .HasColumnName("ID");

                entity.Property(e => e.Code)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Name)
                    .HasMaxLength(250)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.NameEn)
                    .HasMaxLength(250)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Province)
                    .HasMaxLength(100)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.ProvinceNavigation)
                    .WithMany(p => p.Tbdistricts)
                    .HasForeignKey(d => d.Province)
                    .HasConstraintName("District_ProvinceFk");
            });

            modelBuilder.Entity<Tbdivision>(entity =>
            {
                entity.ToTable("tbdivisions");

                entity.HasIndex(e => e.Company, "division_companyFk");

                entity.Property(e => e.Id)
                    .HasMaxLength(100)
                    .HasColumnName("ID");

                entity.Property(e => e.Code)
                    .HasMaxLength(10)
                    .HasColumnName("code")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Company)
                    .HasMaxLength(100)
                    .HasColumnName("company")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Name)
                    .HasMaxLength(500)
                    .HasColumnName("name")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.NameEn)
                    .HasMaxLength(500)
                    .HasColumnName("nameEn")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .HasColumnName("status")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.CompanyNavigation)
                    .WithMany(p => p.Tbdivisions)
                    .HasForeignKey(d => d.Company)
                    .HasConstraintName("division_companyFk");
            });

            modelBuilder.Entity<TbeducationDegree>(entity =>
            {
                entity.ToTable("tbeducation_degrees");

                entity.Property(e => e.Id)
                    .HasMaxLength(100)
                    .HasColumnName("ID");

                entity.Property(e => e.Code)
                    .HasMaxLength(100)
                    .HasColumnName("code")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.NameEn)
                    .HasMaxLength(100)
                    .HasColumnName("nameEn")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Status)
                    .HasMaxLength(100)
                    .HasColumnName("status")
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Tbemployee>(entity =>
            {
                entity.ToTable("tbemployees");

                entity.HasIndex(e => e.BloodGroup, "emp_bloodGroupFK");

                entity.HasIndex(e => e.Company, "emp_company_fk");

                entity.HasIndex(e => e.Country, "emp_countryFK");

                entity.HasIndex(e => e.District, "emp_districtFK");

                entity.HasIndex(e => e.MaritalStatus, "emp_maritalStatusFK");

                entity.HasIndex(e => e.Nationality, "emp_nationalityFK");

                entity.HasIndex(e => e.Province, "emp_provinceFK");

                entity.HasIndex(e => e.Race, "emp_raceFK");

                entity.Property(e => e.Id)
                    .HasMaxLength(100)
                    .HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasMaxLength(500)
                    .HasColumnName("address")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Avatar)
                    .HasMaxLength(500)
                    .HasColumnName("avatar")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.BloodGroup)
                    .HasMaxLength(100)
                    .HasColumnName("blood_group")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Code)
                    .HasMaxLength(10)
                    .HasColumnName("code")
                    .HasDefaultValueSql("'NULL'")
                    .HasComment("attendance id");

                entity.Property(e => e.Company)
                    .HasMaxLength(100)
                    .HasColumnName("company")
                    .HasDefaultValueSql("'''C00001'''");

                entity.Property(e => e.Country)
                    .HasMaxLength(100)
                    .HasColumnName("country")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("date")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(100)
                    .HasColumnName("created_by")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.District)
                    .HasMaxLength(100)
                    .HasColumnName("district")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("dob")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Gender)
                    .HasMaxLength(100)
                    .HasColumnName("gender")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.IdCard)
                    .HasMaxLength(100)
                    .HasColumnName("id_card")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.IdCardExpiryDate)
                    .HasColumnType("date")
                    .HasColumnName("id_card_expiry_date")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.IdCardIssuedBy)
                    .HasMaxLength(100)
                    .HasColumnName("id_card_issued_by")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.MaritalStatus)
                    .HasMaxLength(100)
                    .HasColumnName("marital_status")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Name)
                    .HasMaxLength(500)
                    .HasColumnName("name")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.NameEn)
                    .HasMaxLength(500)
                    .HasColumnName("nameEn")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Nationality)
                    .HasMaxLength(100)
                    .HasColumnName("nationality")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.PassportExpiryDate)
                    .HasColumnType("date")
                    .HasColumnName("passport_expiry_date")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.PassportIssuedBy)
                    .HasMaxLength(250)
                    .HasColumnName("passport_issued_by")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.PassportNo)
                    .HasMaxLength(100)
                    .HasColumnName("passport_no")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Province)
                    .HasMaxLength(100)
                    .HasColumnName("province")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Race)
                    .HasMaxLength(100)
                    .HasColumnName("race")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .HasColumnName("status")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("date")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(100)
                    .HasColumnName("updated_by")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.BloodGroupNavigation)
                    .WithMany(p => p.Tbemployees)
                    .HasForeignKey(d => d.BloodGroup)
                    .HasConstraintName("emp_bloodGroupFK");

                entity.HasOne(d => d.CompanyNavigation)
                    .WithMany(p => p.Tbemployees)
                    .HasForeignKey(d => d.Company)
                    .HasConstraintName("emp_company_fk");

                entity.HasOne(d => d.CountryNavigation)
                    .WithMany(p => p.Tbemployees)
                    .HasForeignKey(d => d.Country)
                    .HasConstraintName("emp_countryFK");

                entity.HasOne(d => d.DistrictNavigation)
                    .WithMany(p => p.Tbemployees)
                    .HasForeignKey(d => d.District)
                    .HasConstraintName("emp_districtFK");

                entity.HasOne(d => d.MaritalStatusNavigation)
                    .WithMany(p => p.Tbemployees)
                    .HasForeignKey(d => d.MaritalStatus)
                    .HasConstraintName("emp_maritalStatusFK");

                entity.HasOne(d => d.NationalityNavigation)
                    .WithMany(p => p.Tbemployees)
                    .HasForeignKey(d => d.Nationality)
                    .HasConstraintName("emp_nationalityFK");

                entity.HasOne(d => d.ProvinceNavigation)
                    .WithMany(p => p.Tbemployees)
                    .HasForeignKey(d => d.Province)
                    .HasConstraintName("emp_provinceFK");

                entity.HasOne(d => d.RaceNavigation)
                    .WithMany(p => p.Tbemployees)
                    .HasForeignKey(d => d.Race)
                    .HasConstraintName("emp_raceFK");
            });

            modelBuilder.Entity<TbemployeeAllowance>(entity =>
            {
                entity.ToTable("tbemployee_allowances");

                entity.HasIndex(e => e.Allowance, "empAllowanceFK");

                entity.HasIndex(e => e.Employee, "empAllowanceTbEmpFK");

                entity.Property(e => e.Id)
                    .HasMaxLength(100)
                    .HasColumnName("ID");

                entity.Property(e => e.Allowance)
                    .HasMaxLength(100)
                    .HasColumnName("allowance")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("date")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(100)
                    .HasColumnName("created_by")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Employee)
                    .HasMaxLength(100)
                    .HasColumnName("employee")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Rate)
                    .HasColumnName("rate")
                    .HasDefaultValueSql("'NULL'")
                    .HasComment("ມູນຄ່າ");

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .HasColumnName("status")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("date")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(100)
                    .HasColumnName("updated_by")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.AllowanceNavigation)
                    .WithMany(p => p.TbemployeeAllowances)
                    .HasForeignKey(d => d.Allowance)
                    .HasConstraintName("empAllowanceFK");

                entity.HasOne(d => d.EmployeeNavigation)
                    .WithMany(p => p.TbemployeeAllowances)
                    .HasForeignKey(d => d.Employee)
                    .HasConstraintName("empAllowanceTbEmpFK");
            });

            modelBuilder.Entity<TbemployeeCatagory>(entity =>
            {
                entity.ToTable("tbemployee_catagories");

                entity.Property(e => e.Id)
                    .HasMaxLength(100)
                    .HasColumnName("ID");

                entity.Property(e => e.Code)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Name)
                    .HasMaxLength(250)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.NameEn)
                    .HasMaxLength(250)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<TbemployeeClassification>(entity =>
            {
                entity.ToTable("tbemployee_classifications");

                entity.HasIndex(e => e.EmployeeCategory, "class_emp_categoryFK");

                entity.HasIndex(e => e.EmployeeGroup, "class_emp_groupFK");

                entity.HasIndex(e => e.EmployeeLevel, "class_emp_levelFK");

                entity.HasIndex(e => e.EmployeeType, "class_emp_typeFK");

                entity.HasIndex(e => e.EmployeeWorkingType, "class_emp_working_typeFK");

                entity.HasIndex(e => e.Employee, "class_employeeFK");

                entity.Property(e => e.Id)
                    .HasMaxLength(100)
                    .HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("date")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(100)
                    .HasColumnName("created_by")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Employee)
                    .HasMaxLength(100)
                    .HasColumnName("employee")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.EmployeeCategory)
                    .HasMaxLength(100)
                    .HasColumnName("employee_category")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.EmployeeGroup)
                    .HasMaxLength(100)
                    .HasColumnName("employee_group")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.EmployeeLevel)
                    .HasMaxLength(100)
                    .HasColumnName("employee_level")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.EmployeeType)
                    .HasMaxLength(100)
                    .HasColumnName("employee_type")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.EmployeeWorkingType)
                    .HasMaxLength(100)
                    .HasColumnName("employee_working_type")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("date")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(100)
                    .HasColumnName("updated_by")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.EmployeeNavigation)
                    .WithMany(p => p.TbemployeeClassifications)
                    .HasForeignKey(d => d.Employee)
                    .HasConstraintName("class_employeeFK");

                entity.HasOne(d => d.EmployeeCategoryNavigation)
                    .WithMany(p => p.TbemployeeClassifications)
                    .HasForeignKey(d => d.EmployeeCategory)
                    .HasConstraintName("class_emp_categoryFK");

                entity.HasOne(d => d.EmployeeGroupNavigation)
                    .WithMany(p => p.TbemployeeClassifications)
                    .HasForeignKey(d => d.EmployeeGroup)
                    .HasConstraintName("class_emp_groupFK");

                entity.HasOne(d => d.EmployeeLevelNavigation)
                    .WithMany(p => p.TbemployeeClassifications)
                    .HasForeignKey(d => d.EmployeeLevel)
                    .HasConstraintName("class_emp_levelFK");

                entity.HasOne(d => d.EmployeeTypeNavigation)
                    .WithMany(p => p.TbemployeeClassifications)
                    .HasForeignKey(d => d.EmployeeType)
                    .HasConstraintName("class_emp_typeFK");

                entity.HasOne(d => d.EmployeeWorkingTypeNavigation)
                    .WithMany(p => p.TbemployeeClassifications)
                    .HasForeignKey(d => d.EmployeeWorkingType)
                    .HasConstraintName("class_emp_working_typeFK");
            });

            modelBuilder.Entity<TbemployeeContact>(entity =>
            {
                entity.ToTable("tbemployee_contacts");

                entity.HasIndex(e => e.Employee, "employeeFK");

                entity.Property(e => e.Id)
                    .HasMaxLength(100)
                    .HasColumnName("ID");

                entity.Property(e => e.ContactNumber)
                    .HasMaxLength(100)
                    .HasColumnName("contact_number")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.ContactPerson)
                    .HasMaxLength(100)
                    .HasColumnName("contact_person")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.ContactRelation)
                    .HasMaxLength(100)
                    .HasColumnName("contact_relation")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("date")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(100)
                    .HasColumnName("created_by")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .HasColumnName("email")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Employee)
                    .HasMaxLength(100)
                    .HasColumnName("employee")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Facebook)
                    .HasMaxLength(100)
                    .HasColumnName("facebook")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Home)
                    .HasMaxLength(100)
                    .HasColumnName("home")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Line)
                    .HasMaxLength(100)
                    .HasColumnName("line")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Mobile)
                    .HasMaxLength(100)
                    .HasColumnName("mobile")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Skype)
                    .HasMaxLength(100)
                    .HasColumnName("skype")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Twitter)
                    .HasMaxLength(100)
                    .HasColumnName("twitter")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("date")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(100)
                    .HasColumnName("updated_by")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Wa)
                    .HasMaxLength(100)
                    .HasColumnName("wa")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Wechat)
                    .HasMaxLength(100)
                    .HasColumnName("wechat")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.EmployeeNavigation)
                    .WithMany(p => p.TbemployeeContacts)
                    .HasForeignKey(d => d.Employee)
                    .HasConstraintName("employeeFK");
            });

            modelBuilder.Entity<TbemployeeContract>(entity =>
            {
                entity.ToTable("tbemployee_contracts");

                entity.HasIndex(e => e.Employee, "contract_empFK");

                entity.HasIndex(e => e.ContractType, "contract_typeFK");

                entity.Property(e => e.Id)
                    .HasMaxLength(100)
                    .HasColumnName("id");

                entity.Property(e => e.ContractNo)
                    .HasMaxLength(100)
                    .HasColumnName("contract_no")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.ContractStartAt)
                    .HasColumnType("date")
                    .HasColumnName("contract_start_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.ContractStopAt)
                    .HasColumnType("date")
                    .HasColumnName("contract_stop_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.ContractType)
                    .HasMaxLength(100)
                    .HasColumnName("contract_type")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("date")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(100)
                    .HasColumnName("created_by")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Employee)
                    .HasMaxLength(100)
                    .HasColumnName("employee")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("date")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(100)
                    .HasColumnName("updated_by")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.ContractTypeNavigation)
                    .WithMany(p => p.TbemployeeContracts)
                    .HasForeignKey(d => d.ContractType)
                    .HasConstraintName("contract_typeFK");

                entity.HasOne(d => d.EmployeeNavigation)
                    .WithMany(p => p.TbemployeeContracts)
                    .HasForeignKey(d => d.Employee)
                    .HasConstraintName("contract_empFK");
            });

            modelBuilder.Entity<TbemployeeEducationHistory>(entity =>
            {
                entity.ToTable("tbemployee_education_histories");

                entity.HasIndex(e => e.Degree, "degreeFK");

                entity.HasIndex(e => e.Employee, "educationEmployeeFK");

                entity.HasIndex(e => e.Institution, "education_institutionFK");

                entity.Property(e => e.Id)
                    .HasMaxLength(100)
                    .HasColumnName("ID");

                entity.Property(e => e.Degree)
                    .HasMaxLength(100)
                    .HasColumnName("degree")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Employee)
                    .HasMaxLength(100)
                    .HasColumnName("employee")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Gpa)
                    .HasMaxLength(10)
                    .HasColumnName("gpa")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Institution)
                    .HasMaxLength(500)
                    .HasColumnName("institution")
                    .HasDefaultValueSql("'NULL'")
                    .HasComment("graduated from");

                entity.Property(e => e.Major)
                    .HasMaxLength(250)
                    .HasColumnName("major")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Sequence)
                    .HasColumnType("int(11)")
                    .HasColumnName("sequence")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Year)
                    .HasColumnType("year(4)")
                    .HasColumnName("year")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.DegreeNavigation)
                    .WithMany(p => p.TbemployeeEducationHistories)
                    .HasForeignKey(d => d.Degree)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("degreeFK");

                entity.HasOne(d => d.EmployeeNavigation)
                    .WithMany(p => p.TbemployeeEducationHistories)
                    .HasForeignKey(d => d.Employee)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("educationEmployeeFK");

                entity.HasOne(d => d.InstitutionNavigation)
                    .WithMany(p => p.TbemployeeEducationHistories)
                    .HasForeignKey(d => d.Institution)
                    .HasConstraintName("education_institutionFK");
            });

            modelBuilder.Entity<TbemployeeEmployment>(entity =>
            {
                entity.ToTable("tbemployee_employments");

                entity.HasIndex(e => e.Department, "employment_departmentFK");

                entity.HasIndex(e => e.Division, "employment_divisionFK");

                entity.HasIndex(e => e.Employee, "employment_employeeFK");

                entity.HasIndex(e => e.Position, "employment_positionFK");

                entity.HasIndex(e => e.Section, "employment_sectionFK");

                entity.Property(e => e.Id)
                    .HasMaxLength(100)
                    .HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("date")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(100)
                    .HasColumnName("created_by")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Department)
                    .HasMaxLength(100)
                    .HasColumnName("department")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Division)
                    .HasMaxLength(100)
                    .HasColumnName("division")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Employee)
                    .HasMaxLength(100)
                    .HasColumnName("employee")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Position)
                    .HasMaxLength(100)
                    .HasColumnName("position")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Section)
                    .HasMaxLength(100)
                    .HasColumnName("section")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("date")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(100)
                    .HasColumnName("updated_by")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.DepartmentNavigation)
                    .WithMany(p => p.TbemployeeEmployments)
                    .HasForeignKey(d => d.Department)
                    .HasConstraintName("employment_departmentFK");

                entity.HasOne(d => d.DivisionNavigation)
                    .WithMany(p => p.TbemployeeEmployments)
                    .HasForeignKey(d => d.Division)
                    .HasConstraintName("employment_divisionFK");

                entity.HasOne(d => d.EmployeeNavigation)
                    .WithMany(p => p.TbemployeeEmployments)
                    .HasForeignKey(d => d.Employee)
                    .HasConstraintName("employment_employeeFK");

                entity.HasOne(d => d.PositionNavigation)
                    .WithMany(p => p.TbemployeeEmployments)
                    .HasForeignKey(d => d.Position)
                    .HasConstraintName("employment_positionFK");

                entity.HasOne(d => d.SectionNavigation)
                    .WithMany(p => p.TbemployeeEmployments)
                    .HasForeignKey(d => d.Section)
                    .HasConstraintName("employment_sectionFK");
            });

            modelBuilder.Entity<TbemployeeFamilyContact>(entity =>
            {
                entity.ToTable("tbemployee_family_contacts");

                entity.HasIndex(e => e.Employee, "family_empFK");

                entity.Property(e => e.Id)
                    .HasMaxLength(100)
                    .HasColumnName("id");

                entity.Property(e => e.Employee)
                    .HasMaxLength(100)
                    .HasColumnName("employee")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.FatherContactNumber)
                    .HasMaxLength(100)
                    .HasColumnName("father_contact_number")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.FatherDob)
                    .HasColumnType("date")
                    .HasColumnName("father_dob")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.FatherName)
                    .HasMaxLength(200)
                    .HasColumnName("father_name")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.MotherContactNumber)
                    .HasMaxLength(100)
                    .HasColumnName("mother_contact_number")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.MotherDob)
                    .HasColumnType("date")
                    .HasColumnName("mother_dob")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.MotherName)
                    .HasMaxLength(200)
                    .HasColumnName("mother_name")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.NoChildren)
                    .HasColumnType("int(11)")
                    .HasColumnName("no_children")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.NoDaughter)
                    .HasColumnType("int(11)")
                    .HasColumnName("no_daughter")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.SpouseContactNumber)
                    .HasMaxLength(100)
                    .HasColumnName("spouse_contact_number")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.SpouseDob)
                    .HasColumnType("date")
                    .HasColumnName("spouse_dob")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.SpouseName)
                    .HasMaxLength(200)
                    .HasColumnName("spouse_name")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.EmployeeNavigation)
                    .WithMany(p => p.TbemployeeFamilyContacts)
                    .HasForeignKey(d => d.Employee)
                    .HasConstraintName("family_empFK");
            });

            modelBuilder.Entity<TbemployeeGroup>(entity =>
            {
                entity.ToTable("tbemployee_groups");

                entity.Property(e => e.Id)
                    .HasMaxLength(100)
                    .HasColumnName("ID");

                entity.Property(e => e.Code)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Name)
                    .HasMaxLength(250)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.NameEn)
                    .HasMaxLength(250)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<TbemployeeHealthHistory>(entity =>
            {
                entity.ToTable("tbemployee_health_histories");

                entity.HasIndex(e => e.Employee, "healthTbEmployeeFK");

                entity.Property(e => e.Id)
                    .HasMaxLength(100)
                    .HasColumnName("id");

                entity.Property(e => e.DateLog)
                    .HasColumnType("date")
                    .HasColumnName("dateLog")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .HasColumnName("description")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Employee)
                    .HasMaxLength(100)
                    .HasColumnName("employee")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.FilePath)
                    .HasMaxLength(500)
                    .HasColumnName("file_path")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Location)
                    .HasMaxLength(500)
                    .HasColumnName("location")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .HasColumnName("status")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.EmployeeNavigation)
                    .WithMany(p => p.TbemployeeHealthHistories)
                    .HasForeignKey(d => d.Employee)
                    .HasConstraintName("healthTbEmployeeFK");
            });

            modelBuilder.Entity<TbemployeeIdentity>(entity =>
            {
                entity.ToTable("tbemployee_identities");

                entity.HasIndex(e => e.Employee, "identity_employeeFK");

                entity.HasIndex(e => e.IdType, "identity_typeFk");

                entity.Property(e => e.Id)
                    .HasMaxLength(100)
                    .HasColumnName("id");

                entity.Property(e => e.Employee)
                    .HasMaxLength(100)
                    .HasColumnName("employee")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.IdExpiryDate)
                    .HasColumnType("date")
                    .HasColumnName("id_expiry_date")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.IdIssuedBy)
                    .HasMaxLength(500)
                    .HasColumnName("id_issued_by")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.IdNumber)
                    .HasMaxLength(100)
                    .HasColumnName("id_number")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.IdType)
                    .HasMaxLength(100)
                    .HasColumnName("id_type")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.EmployeeNavigation)
                    .WithMany(p => p.TbemployeeIdentities)
                    .HasForeignKey(d => d.Employee)
                    .HasConstraintName("identity_employeeFK");

                entity.HasOne(d => d.IdTypeNavigation)
                    .WithMany(p => p.TbemployeeIdentities)
                    .HasForeignKey(d => d.IdType)
                    .HasConstraintName("identity_typeFk");
            });

            modelBuilder.Entity<TbemployeeInsurance>(entity =>
            {
                entity.ToTable("tbemployee_insurances");

                entity.HasIndex(e => e.Employee, "insurance_employeeFK");

                entity.Property(e => e.Id)
                    .HasMaxLength(100)
                    .HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("date")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(100)
                    .HasColumnName("created_by")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Employee)
                    .HasMaxLength(100)
                    .HasColumnName("employee")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.InsuranceCertificate)
                    .HasMaxLength(100)
                    .HasColumnName("insurance_certificate")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.InsuranceExpiryDate)
                    .HasColumnType("date")
                    .HasColumnName("insurance_expiry_date")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Rate)
                    .HasColumnName("rate")
                    .HasDefaultValueSql("'NULL'")
                    .HasComment("rate pay");

                entity.Property(e => e.Ssn)
                    .HasMaxLength(100)
                    .HasColumnName("ssn")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("date")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(100)
                    .HasColumnName("updated_by")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.EmployeeNavigation)
                    .WithMany(p => p.TbemployeeInsurances)
                    .HasForeignKey(d => d.Employee)
                    .HasConstraintName("insurance_employeeFK");
            });

            modelBuilder.Entity<TbemployeeLeaveSetting>(entity =>
            {
                entity.ToTable("tbemployee_leave_settings");

                entity.HasIndex(e => e.EmployeeAnnualLeave, "annual_leave_typeFK");

                entity.HasIndex(e => e.Employee, "leave_setting_employeeFK");

                entity.Property(e => e.Id)
                    .HasMaxLength(100)
                    .HasColumnName("id");

                entity.Property(e => e.Employee)
                    .HasMaxLength(100)
                    .HasColumnName("employee")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.EmployeeAnnualLeave)
                    .HasMaxLength(100)
                    .HasColumnName("employee_annual_leave")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Ratio)
                    .HasColumnType("int(11)")
                    .HasColumnName("ratio")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Remain)
                    .HasColumnType("int(11)")
                    .HasColumnName("remain")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.EmployeeNavigation)
                    .WithMany(p => p.TbemployeeLeaveSettings)
                    .HasForeignKey(d => d.Employee)
                    .HasConstraintName("leave_setting_employeeFK");

                entity.HasOne(d => d.EmployeeAnnualLeaveNavigation)
                    .WithMany(p => p.TbemployeeLeaveSettings)
                    .HasForeignKey(d => d.EmployeeAnnualLeave)
                    .HasConstraintName("annual_leave_typeFK");
            });

            modelBuilder.Entity<TbemployeeLevel>(entity =>
            {
                entity.ToTable("tbemployee_levels");

                entity.Property(e => e.Id)
                    .HasMaxLength(100)
                    .HasColumnName("ID");

                entity.Property(e => e.Code)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.DirectReport)
                    .HasMaxLength(100)
                    .HasColumnName("directReport")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Name)
                    .HasMaxLength(250)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.NameEn)
                    .HasMaxLength(250)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Seq)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<TbemployeeProbation>(entity =>
            {
                entity.ToTable("tbemployee_probations");

                entity.HasIndex(e => e.Employee, "probation_empFK");

                entity.Property(e => e.Id)
                    .HasMaxLength(100)
                    .HasColumnName("id");

                entity.Property(e => e.ContractStartAt)
                    .HasColumnType("date")
                    .HasColumnName("contract_start_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.ContractStopAt)
                    .HasColumnType("date")
                    .HasColumnName("contract_stop_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("date")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(100)
                    .HasColumnName("created_by")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Employee)
                    .HasMaxLength(100)
                    .HasColumnName("employee")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("date")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(100)
                    .HasColumnName("updated_by")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.EmployeeNavigation)
                    .WithMany(p => p.TbemployeeProbations)
                    .HasForeignKey(d => d.Employee)
                    .HasConstraintName("probation_empFK");
            });

            modelBuilder.Entity<TbemployeeRelation>(entity =>
            {
                entity.ToTable("tbemployee_relations");

                entity.HasIndex(e => e.Relation, "empTbRelationFK");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("dob")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Name)
                    .HasMaxLength(500)
                    .HasColumnName("name")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.NameEn)
                    .HasMaxLength(500)
                    .HasColumnName("nameEn")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Relation)
                    .HasMaxLength(100)
                    .HasColumnName("relation")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .HasColumnName("status")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.RelationNavigation)
                    .WithMany(p => p.TbemployeeRelations)
                    .HasForeignKey(d => d.Relation)
                    .HasConstraintName("empTbRelationFK");
            });

            modelBuilder.Entity<TbemployeeSalaryHistory>(entity =>
            {
                entity.ToTable("tbemployee_salary_histories");

                entity.HasIndex(e => e.Employee, "salaryEmployeeFk");

                entity.Property(e => e.Id)
                    .HasMaxLength(100)
                    .HasColumnName("ID");

                entity.Property(e => e.Contract)
                    .HasMaxLength(100)
                    .HasColumnName("contract")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.DateFrom)
                    .HasColumnType("date")
                    .HasColumnName("dateFrom")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.DateTo)
                    .HasColumnType("date")
                    .HasColumnName("dateTo")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Employee)
                    .HasMaxLength(100)
                    .HasColumnName("employee")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Salary)
                    .HasColumnName("salary")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.EmployeeNavigation)
                    .WithMany(p => p.TbemployeeSalaryHistories)
                    .HasForeignKey(d => d.Employee)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("salaryEmployeeFk");
            });

            modelBuilder.Entity<TbemployeeSalarySetting>(entity =>
            {
                entity.ToTable("tbemployee_salary_settings");

                entity.HasIndex(e => e.Bank, "salary_bankFK");

                entity.HasIndex(e => e.Employee, "salary_employeeFK");

                entity.HasIndex(e => e.SalaryPayType, "salary_pay_typeFK");

                entity.HasIndex(e => e.SalaryType, "salary_typeFK");

                entity.Property(e => e.Id)
                    .HasMaxLength(100)
                    .HasColumnName("id");

                entity.Property(e => e.Bank)
                    .HasMaxLength(100)
                    .HasColumnName("bank")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.BankAccount)
                    .HasMaxLength(100)
                    .HasColumnName("bank_account")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.BaseSalary)
                    .HasColumnName("base_salary")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("date")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(100)
                    .HasColumnName("created_by")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Employee)
                    .HasMaxLength(100)
                    .HasColumnName("employee")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.SalaryPayType)
                    .HasMaxLength(100)
                    .HasColumnName("salary_pay_type")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.SalaryType)
                    .HasMaxLength(100)
                    .HasColumnName("salary_type")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("date")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(100)
                    .HasColumnName("updated_by")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.BankNavigation)
                    .WithMany(p => p.TbemployeeSalarySettings)
                    .HasForeignKey(d => d.Bank)
                    .HasConstraintName("salary_bankFK");

                entity.HasOne(d => d.EmployeeNavigation)
                    .WithMany(p => p.TbemployeeSalarySettings)
                    .HasForeignKey(d => d.Employee)
                    .HasConstraintName("salary_employeeFK");

                entity.HasOne(d => d.SalaryPayTypeNavigation)
                    .WithMany(p => p.TbemployeeSalarySettings)
                    .HasForeignKey(d => d.SalaryPayType)
                    .HasConstraintName("salary_pay_typeFK");

                entity.HasOne(d => d.SalaryTypeNavigation)
                    .WithMany(p => p.TbemployeeSalarySettings)
                    .HasForeignKey(d => d.SalaryType)
                    .HasConstraintName("salary_typeFK");
            });

            modelBuilder.Entity<TbemployeeSchedule>(entity =>
            {
                entity.ToTable("tbemployee_schedules");

                entity.HasIndex(e => e.Shift, "fk_schedule_shift");

                entity.Property(e => e.Id)
                    .HasMaxLength(100)
                    .HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(100)
                    .HasColumnName("created_by")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.FpUserId)
                    .HasMaxLength(100)
                    .HasColumnName("fp_user_id")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Shift)
                    .HasMaxLength(100)
                    .HasColumnName("shift")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(100)
                    .HasColumnName("updated_by")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.ShiftNavigation)
                    .WithMany(p => p.TbemployeeSchedules)
                    .HasForeignKey(d => d.Shift)
                    .HasConstraintName("fk_schedule_shift");
            });

            modelBuilder.Entity<TbemployeeSupervisor>(entity =>
            {
                entity.ToTable("tbemployee_supervisors");

                entity.HasIndex(e => e.Employee, "employeeMappingFK");

                entity.HasIndex(e => e.Supervisor, "employeeSupervisor");

                entity.Property(e => e.Id)
                    .HasMaxLength(100)
                    .HasColumnName("ID");

                entity.Property(e => e.Employee)
                    .HasMaxLength(100)
                    .HasColumnName("employee")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Remark)
                    .HasMaxLength(250)
                    .HasColumnName("remark")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Status)
                    .HasMaxLength(100)
                    .HasColumnName("status")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Supervisor)
                    .HasMaxLength(100)
                    .HasColumnName("supervisor")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.EmployeeNavigation)
                    .WithMany(p => p.TbemployeeSupervisorEmployeeNavigations)
                    .HasForeignKey(d => d.Employee)
                    .HasConstraintName("employeeMappingFK");

                entity.HasOne(d => d.SupervisorNavigation)
                    .WithMany(p => p.TbemployeeSupervisorSupervisorNavigations)
                    .HasForeignKey(d => d.Supervisor)
                    .HasConstraintName("employeeSupervisor");
            });

            modelBuilder.Entity<TbemployeeTransaction>(entity =>
            {
                entity.ToTable("tbemployee_transactions");

                entity.HasIndex(e => e.Employee, "transaction_empFK");

                entity.HasIndex(e => e.TransactionType, "transaction_type");

                entity.Property(e => e.Id)
                    .HasMaxLength(100)
                    .HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("date")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(100)
                    .HasColumnName("created_by")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Description)
                    .HasMaxLength(1000)
                    .HasColumnName("description")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.EffectiveDate)
                    .HasColumnType("date")
                    .HasColumnName("effective_date")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Employee)
                    .HasMaxLength(100)
                    .HasColumnName("employee")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.TransactionType)
                    .HasMaxLength(100)
                    .HasColumnName("transaction_type")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("date")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(100)
                    .HasColumnName("updated_by")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.EmployeeNavigation)
                    .WithMany(p => p.TbemployeeTransactions)
                    .HasForeignKey(d => d.Employee)
                    .HasConstraintName("transaction_empFK");

                entity.HasOne(d => d.TransactionTypeNavigation)
                    .WithMany(p => p.TbemployeeTransactions)
                    .HasForeignKey(d => d.TransactionType)
                    .HasConstraintName("tbemployee_transactions_ibfk_1");
            });

            modelBuilder.Entity<TbemployeeType>(entity =>
            {
                entity.ToTable("tbemployee_types");

                entity.Property(e => e.Id)
                    .HasMaxLength(100)
                    .HasColumnName("ID");

                entity.Property(e => e.Code)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Name)
                    .HasMaxLength(250)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.NameEn)
                    .HasMaxLength(250)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<TbemployeeWorkingPeriod>(entity =>
            {
                entity.ToTable("tbemployee_working_periods");

                entity.HasIndex(e => e.WorkingPeriod, "pk_working_period");

                entity.Property(e => e.Id)
                    .HasMaxLength(100)
                    .HasColumnName("id");

                entity.Property(e => e.FpUserId)
                    .HasMaxLength(100)
                    .HasColumnName("fp_user_id")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.WorkingPeriod)
                    .HasMaxLength(100)
                    .HasColumnName("working_period")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.WorkingPeriodNavigation)
                    .WithMany(p => p.TbemployeeWorkingPeriods)
                    .HasForeignKey(d => d.WorkingPeriod)
                    .HasConstraintName("pk_working_period");
            });

            modelBuilder.Entity<Tbfile>(entity =>
            {
                entity.ToTable("tbfiles");

                entity.Property(e => e.Id)
                    .HasMaxLength(100)
                    .HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("date")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(100)
                    .HasColumnName("created_by")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.DisplayName)
                    .HasMaxLength(250)
                    .HasColumnName("display_name")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.FileName)
                    .HasMaxLength(500)
                    .HasColumnName("file_name")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.FileSize)
                    .HasColumnType("int(11)")
                    .HasColumnName("file_size")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.FileType)
                    .HasMaxLength(100)
                    .HasColumnName("file_type")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Owner)
                    .HasMaxLength(100)
                    .HasColumnName("owner")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Path)
                    .HasMaxLength(500)
                    .HasColumnName("path")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("date")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(100)
                    .HasColumnName("updated_by")
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Tbfingerprint>(entity =>
            {
                entity.ToTable("tbfingerprints");

                entity.Property(e => e.Id)
                    .HasMaxLength(100)
                    .HasColumnName("id");

                entity.Property(e => e.IpAddress)
                    .HasMaxLength(250)
                    .HasColumnName("ip_address")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Mac)
                    .HasMaxLength(250)
                    .HasColumnName("mac")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Name)
                    .HasMaxLength(250)
                    .HasColumnName("name")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Port)
                    .HasMaxLength(100)
                    .HasColumnName("port")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Remark)
                    .HasMaxLength(500)
                    .HasColumnName("remark")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Sn)
                    .HasMaxLength(250)
                    .HasColumnName("sn")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Status)
                    .HasMaxLength(100)
                    .HasColumnName("status")
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Tbfingerprintmapping>(entity =>
            {
                entity.ToTable("tbfingerprintmappings");

                entity.Property(e => e.Id)
                    .HasMaxLength(100)
                    .HasColumnName("id");

                entity.Property(e => e.FingerImg)
                    .HasColumnName("finger_img")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.FingerIndex)
                    .HasMaxLength(100)
                    .HasColumnName("finger_index")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.FingerUserId)
                    .HasMaxLength(100)
                    .HasColumnName("finger_user_id")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Status)
                    .HasMaxLength(100)
                    .HasColumnName("status")
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Tbfpuser>(entity =>
            {
                entity.ToTable("tbfpusers");

                entity.Property(e => e.Id)
                    .HasMaxLength(100)
                    .HasColumnName("id");

                entity.Property(e => e.Employee)
                    .HasMaxLength(100)
                    .HasColumnName("employee")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.FpId)
                    .HasMaxLength(100)
                    .HasColumnName("fp_id")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.FpRole)
                    .HasMaxLength(100)
                    .HasColumnName("fp_role")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.FpUserId)
                    .HasMaxLength(100)
                    .HasColumnName("fp_user_id")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.FpUserName)
                    .HasMaxLength(100)
                    .HasColumnName("fp_user_name")
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<TbholidaySetting>(entity =>
            {
                entity.ToTable("tbholiday_settings");

                entity.Property(e => e.Id)
                    .HasMaxLength(100)
                    .HasColumnName("id");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .HasColumnName("description")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.IsDraft)
                    .HasColumnName("isDraft")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Name)
                    .HasMaxLength(250)
                    .HasColumnName("name")
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<TbidentityType>(entity =>
            {
                entity.ToTable("tbidentity_types");

                entity.Property(e => e.Id)
                    .HasMaxLength(100)
                    .HasColumnName("ID");

                entity.Property(e => e.Code)
                    .HasMaxLength(10)
                    .HasColumnName("code")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Name)
                    .HasMaxLength(500)
                    .HasColumnName("name")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.NameEn)
                    .HasMaxLength(500)
                    .HasColumnName("nameEn")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .HasColumnName("status")
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Tbinstitution>(entity =>
            {
                entity.ToTable("tbinstitutions");

                entity.Property(e => e.Id)
                    .HasMaxLength(100)
                    .HasColumnName("ID");

                entity.Property(e => e.Code)
                    .HasMaxLength(10)
                    .HasColumnName("code")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Name)
                    .HasMaxLength(500)
                    .HasColumnName("name")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.NameEn)
                    .HasMaxLength(500)
                    .HasColumnName("nameEn")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .HasColumnName("status")
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Tbjob>(entity =>
            {
                entity.ToTable("tbjobs");

                entity.Property(e => e.Id)
                    .HasMaxLength(100)
                    .HasColumnName("ID");

                entity.Property(e => e.Code)
                    .HasMaxLength(10)
                    .HasColumnName("code")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Name)
                    .HasMaxLength(500)
                    .HasColumnName("name")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.NameEn)
                    .HasMaxLength(500)
                    .HasColumnName("nameEn")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .HasColumnName("status")
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<TbleaveRequest>(entity =>
            {
                entity.ToTable("tbleave_requests");

                entity.HasIndex(e => e.Company, "fk_lr_company");

                entity.HasIndex(e => e.Employee, "fk_lr_employee");

                entity.Property(e => e.Id)
                    .HasMaxLength(100)
                    .HasColumnName("id");

                entity.Property(e => e.ApprovalNote)
                    .HasMaxLength(1000)
                    .HasColumnName("approval_note")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.ApprovedBy)
                    .HasMaxLength(100)
                    .HasColumnName("approved_by")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Company)
                    .HasMaxLength(100)
                    .HasColumnName("company")
                    .HasDefaultValueSql("'''C00001'''");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(100)
                    .HasColumnName("created_by")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Datefrom)
                    .HasColumnType("date")
                    .HasColumnName("datefrom")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Dateto)
                    .HasColumnType("date")
                    .HasColumnName("dateto")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Employee)
                    .HasMaxLength(100)
                    .HasColumnName("employee")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.FpUserId)
                    .HasMaxLength(100)
                    .HasColumnName("fp_user_id")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.HrApprovalNote)
                    .HasMaxLength(1000)
                    .HasColumnName("hr_approval_note")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.HrApprovedBy)
                    .HasMaxLength(100)
                    .HasColumnName("hr_approved_by")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.LeaveType)
                    .HasMaxLength(100)
                    .HasColumnName("leave_type")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.NeedApproval)
                    .HasColumnName("need_approval")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.NeedHrApproval)
                    .HasColumnName("need_hr_approval")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Remark)
                    .HasMaxLength(1000)
                    .HasColumnName("remark")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Status)
                    .HasMaxLength(100)
                    .HasColumnName("status")
                    .HasDefaultValueSql("'''ACTIVE'''");

                entity.Property(e => e.Total)
                    .HasColumnName("total")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(100)
                    .HasColumnName("updated_by")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.CompanyNavigation)
                    .WithMany(p => p.TbleaveRequests)
                    .HasForeignKey(d => d.Company)
                    .HasConstraintName("fk_lr_company");

                entity.HasOne(d => d.EmployeeNavigation)
                    .WithMany(p => p.TbleaveRequests)
                    .HasForeignKey(d => d.Employee)
                    .HasConstraintName("fk_lr_employee");
            });

            modelBuilder.Entity<Tbleavelog>(entity =>
            {
                entity.ToTable("tbleavelogs");

                entity.Property(e => e.Id)
                    .HasMaxLength(100)
                    .HasColumnName("id");

                entity.Property(e => e.FpUserId)
                    .HasMaxLength(100)
                    .HasColumnName("fp_user_id")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.LeaveDay)
                    .HasColumnType("date")
                    .HasColumnName("leave_day")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.LeaveId)
                    .HasMaxLength(100)
                    .HasColumnName("leave_id")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Remark)
                    .HasMaxLength(500)
                    .HasColumnName("remark")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Status)
                    .HasMaxLength(5)
                    .HasColumnName("status")
                    .HasDefaultValueSql("'''WP'''")
                    .HasComment("WP WOP");
            });

            modelBuilder.Entity<Tbmarriage>(entity =>
            {
                entity.ToTable("tbmarriages");

                entity.Property(e => e.Id)
                    .HasMaxLength(100)
                    .HasColumnName("ID");

                entity.Property(e => e.Code)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Name)
                    .HasMaxLength(250)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.NameEn)
                    .HasMaxLength(250)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Tbnationality>(entity =>
            {
                entity.ToTable("tbnationalities");

                entity.Property(e => e.Id)
                    .HasMaxLength(100)
                    .HasColumnName("ID");

                entity.Property(e => e.Code)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Name)
                    .HasMaxLength(250)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.NameEn)
                    .HasMaxLength(250)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Tborganizationchart>(entity =>
            {
                entity.ToTable("tborganizationcharts");

                entity.Property(e => e.Id)
                    .HasMaxLength(100)
                    .HasColumnName("ID");

                entity.Property(e => e.Employee)
                    .HasMaxLength(100)
                    .HasColumnName("employee")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Jobtitle)
                    .HasMaxLength(100)
                    .HasColumnName("jobtitle")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Remark)
                    .HasMaxLength(500)
                    .HasColumnName("remark")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.ReportsTo)
                    .HasMaxLength(100)
                    .HasColumnName("reportsTo")
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Tbot>(entity =>
            {
                entity.ToTable("tbot");

                entity.Property(e => e.Id)
                    .HasMaxLength(100)
                    .HasColumnName("id");

                entity.Property(e => e.Employee)
                    .HasMaxLength(100)
                    .HasColumnName("employee")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.OtDate)
                    .HasColumnType("date")
                    .HasColumnName("ot_date")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.OtIn)
                    .HasColumnName("ot_in")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.OtOut)
                    .HasColumnName("ot_out")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Remark)
                    .HasMaxLength(500)
                    .HasColumnName("remark")
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Tbotrequest>(entity =>
            {
                entity.ToTable("tbotrequests");

                entity.Property(e => e.Id)
                    .HasMaxLength(100)
                    .HasColumnName("id");

                entity.Property(e => e.AuthorizerId)
                    .HasMaxLength(100)
                    .HasColumnName("authorizer_id")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Employee)
                    .HasMaxLength(100)
                    .HasColumnName("employee")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.OtDate)
                    .HasColumnType("date")
                    .HasColumnName("ot_date")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.OtIn)
                    .HasColumnName("ot_in")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.OtOut)
                    .HasColumnName("ot_out")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Remark)
                    .HasMaxLength(500)
                    .HasColumnName("remark")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Status)
                    .HasMaxLength(100)
                    .HasColumnName("status")
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<TbpageMaster>(entity =>
            {
                entity.ToTable("tbpage_masters");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .HasColumnName("description")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Name)
                    .HasMaxLength(500)
                    .HasColumnName("name")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.PageGroup)
                    .HasMaxLength(100)
                    .HasColumnName("page_group")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Uri)
                    .HasMaxLength(250)
                    .HasColumnName("uri")
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<TbpageUri>(entity =>
            {
                entity.ToTable("tbpage_uri");

                entity.Property(e => e.Id)
                    .HasMaxLength(100)
                    .HasColumnName("id");

                entity.Property(e => e.Active)
                    .HasMaxLength(100)
                    .HasColumnName("active")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Name)
                    .HasMaxLength(250)
                    .HasColumnName("name")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Uri)
                    .HasMaxLength(250)
                    .HasColumnName("uri")
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Tbpostion>(entity =>
            {
                entity.ToTable("tbpostions");

                entity.HasIndex(e => e.Level, "posi_fk_level");

                entity.Property(e => e.Id)
                    .HasMaxLength(100)
                    .HasColumnName("ID");

                entity.Property(e => e.Code)
                    .HasMaxLength(10)
                    .HasColumnName("code")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Level)
                    .HasMaxLength(100)
                    .HasDefaultValueSql("'''EL'''");

                entity.Property(e => e.Name)
                    .HasMaxLength(500)
                    .HasColumnName("name")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.NameEn)
                    .HasMaxLength(500)
                    .HasColumnName("nameEn")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .HasColumnName("status")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.LevelNavigation)
                    .WithMany(p => p.Tbpostions)
                    .HasForeignKey(d => d.Level)
                    .HasConstraintName("posi_fk_level");
            });

            modelBuilder.Entity<Tbprovince>(entity =>
            {
                entity.ToTable("tbprovinces");

                entity.HasIndex(e => e.Country, "Province_CountryFK");

                entity.Property(e => e.Id)
                    .HasMaxLength(100)
                    .HasColumnName("ID");

                entity.Property(e => e.Code)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Country)
                    .HasMaxLength(100)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Name)
                    .HasMaxLength(250)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.NameEn)
                    .HasMaxLength(250)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.CountryNavigation)
                    .WithMany(p => p.Tbprovinces)
                    .HasForeignKey(d => d.Country)
                    .HasConstraintName("Province_CountryFK");
            });

            modelBuilder.Entity<Tbrace>(entity =>
            {
                entity.ToTable("tbraces");

                entity.Property(e => e.Id)
                    .HasMaxLength(100)
                    .HasColumnName("ID");

                entity.Property(e => e.Code)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Name)
                    .HasMaxLength(250)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.NameEn)
                    .HasMaxLength(250)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Tbrelation>(entity =>
            {
                entity.ToTable("tbrelations");

                entity.Property(e => e.Id)
                    .HasMaxLength(100)
                    .HasColumnName("ID");

                entity.Property(e => e.Code)
                    .HasMaxLength(10)
                    .HasColumnName("code")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Name)
                    .HasMaxLength(500)
                    .HasColumnName("name")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.NameEn)
                    .HasMaxLength(500)
                    .HasColumnName("nameEn")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .HasColumnName("status")
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Tbresignationreason>(entity =>
            {
                entity.ToTable("tbresignationreasons");

                entity.Property(e => e.Id)
                    .HasMaxLength(100)
                    .HasColumnName("ID");

                entity.Property(e => e.Code)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Name)
                    .HasMaxLength(250)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.NameEn)
                    .HasMaxLength(250)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Tbrole>(entity =>
            {
                entity.ToTable("tbroles");

                entity.Property(e => e.Id)
                    .HasMaxLength(100)
                    .HasColumnName("ID");

                entity.Property(e => e.Code)
                    .HasMaxLength(10)
                    .HasColumnName("code")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Name)
                    .HasMaxLength(250)
                    .HasColumnName("name")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.NameEn)
                    .HasMaxLength(250)
                    .HasColumnName("nameEn")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Status)
                    .HasMaxLength(100)
                    .HasColumnName("status")
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Tbrule>(entity =>
            {
                entity.ToTable("tbrules");

                entity.Property(e => e.Id)
                    .HasMaxLength(100)
                    .HasColumnName("ID");

                entity.Property(e => e.Name)
                    .HasMaxLength(250)
                    .HasColumnName("name")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Status)
                    .HasMaxLength(100)
                    .HasColumnName("status")
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<TbruleItem>(entity =>
            {
                entity.ToTable("tbrule_items");

                entity.HasIndex(e => e.PageId, "page_master_fk");

                entity.HasIndex(e => e.Rule, "rule_master");

                entity.Property(e => e.Id)
                    .HasMaxLength(100)
                    .HasColumnName("ID");

                entity.Property(e => e.PageId)
                    .HasColumnType("int(11)")
                    .HasColumnName("page_id")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.PageName)
                    .HasMaxLength(500)
                    .HasColumnName("page_name")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Rule)
                    .HasMaxLength(100)
                    .HasColumnName("rule")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Seq)
                    .HasColumnType("int(11)")
                    .HasColumnName("seq")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Uri)
                    .HasMaxLength(250)
                    .HasColumnName("uri")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.Page)
                    .WithMany(p => p.TbruleItems)
                    .HasForeignKey(d => d.PageId)
                    .HasConstraintName("page_master_fk");

                entity.HasOne(d => d.RuleNavigation)
                    .WithMany(p => p.TbruleItems)
                    .HasForeignKey(d => d.Rule)
                    .HasConstraintName("rule_master");
            });

            modelBuilder.Entity<TbsalaryPayType>(entity =>
            {
                entity.ToTable("tbsalary_pay_types");

                entity.Property(e => e.Id)
                    .HasMaxLength(100)
                    .HasColumnName("ID");

                entity.Property(e => e.Code)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Name)
                    .HasMaxLength(250)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.NameEn)
                    .HasMaxLength(250)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<TbsalaryType>(entity =>
            {
                entity.ToTable("tbsalary_types");

                entity.Property(e => e.Id)
                    .HasMaxLength(100)
                    .HasColumnName("ID");

                entity.Property(e => e.Code)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Name)
                    .HasMaxLength(250)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.NameEn)
                    .HasMaxLength(250)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Tbsection>(entity =>
            {
                entity.ToTable("tbsections");

                entity.Property(e => e.Id)
                    .HasMaxLength(100)
                    .HasColumnName("ID");

                entity.Property(e => e.Code)
                    .HasMaxLength(10)
                    .HasColumnName("code")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Name)
                    .HasMaxLength(500)
                    .HasColumnName("name")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.NameEn)
                    .HasMaxLength(500)
                    .HasColumnName("nameEn")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .HasColumnName("status")
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Tbshiftdetail>(entity =>
            {
                entity.ToTable("tbshiftdetails");

                entity.HasIndex(e => e.Shift, "fk_shift");

                entity.HasIndex(e => e.Timetable, "fk_timetable");

                entity.Property(e => e.Id)
                    .HasMaxLength(100)
                    .HasColumnName("id");

                entity.Property(e => e.Shift)
                    .HasMaxLength(100)
                    .HasColumnName("shift")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Timetable)
                    .HasMaxLength(100)
                    .HasColumnName("timetable")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Weekday)
                    .HasColumnType("int(1)")
                    .HasColumnName("weekday")
                    .HasDefaultValueSql("'0'");

                entity.HasOne(d => d.ShiftNavigation)
                    .WithMany(p => p.Tbshiftdetails)
                    .HasForeignKey(d => d.Shift)
                    .HasConstraintName("fk_shift");

                entity.HasOne(d => d.TimetableNavigation)
                    .WithMany(p => p.Tbshiftdetails)
                    .HasForeignKey(d => d.Timetable)
                    .HasConstraintName("fk_timetable");
            });

            modelBuilder.Entity<Tbshiftmanagement>(entity =>
            {
                entity.ToTable("tbshiftmanagements");

                entity.HasIndex(e => e.Company, "fk_company");

                entity.Property(e => e.Id)
                    .HasMaxLength(100)
                    .HasColumnName("id");

                entity.Property(e => e.Company)
                    .HasMaxLength(100)
                    .HasColumnName("company")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(100)
                    .HasColumnName("created_by")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Shiftname)
                    .HasMaxLength(500)
                    .HasColumnName("shiftname")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Status)
                    .HasMaxLength(100)
                    .HasColumnName("status")
                    .HasDefaultValueSql("'''ACTIVE'''");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(100)
                    .HasColumnName("updated_by")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Workingday)
                    .HasMaxLength(100)
                    .HasColumnName("workingday")
                    .HasDefaultValueSql("'''012345'''");

                entity.HasOne(d => d.CompanyNavigation)
                    .WithMany(p => p.Tbshiftmanagements)
                    .HasForeignKey(d => d.Company)
                    .HasConstraintName("fk_company");
            });

            modelBuilder.Entity<TbtimeAssigment>(entity =>
            {
                entity.ToTable("tbtime_assigments");

                entity.HasIndex(e => e.Employee, "assignment_employee");

                entity.Property(e => e.Id)
                    .HasMaxLength(100)
                    .HasColumnName("id");

                entity.Property(e => e.Employee)
                    .HasMaxLength(100)
                    .HasColumnName("employee")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.EndedAt)
                    .HasColumnType("date")
                    .HasColumnName("ended_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.StartedAt)
                    .HasColumnType("date")
                    .HasColumnName("started_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Timetable)
                    .HasMaxLength(100)
                    .HasColumnName("timetable")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.EmployeeNavigation)
                    .WithMany(p => p.TbtimeAssigments)
                    .HasForeignKey(d => d.Employee)
                    .HasConstraintName("assignment_employee");
            });

            modelBuilder.Entity<Tbtimesheet>(entity =>
            {
                entity.ToTable("tbtimesheets");

                entity.HasIndex(e => e.Employee, "timsheet_employee");

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

                entity.Property(e => e.ClockStatus)
                    .HasMaxLength(500)
                    .HasColumnName("clock_status")
                    .HasDefaultValueSql("'NULL'")
                    .HasComment("clock state");

                entity.Property(e => e.EarlyMin)
                    .HasColumnType("int(11)")
                    .HasColumnName("early_min")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Employee)
                    .HasMaxLength(100)
                    .HasColumnName("employee")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.LateMin)
                    .HasColumnType("int(11)")
                    .HasColumnName("late_min")
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

                entity.HasOne(d => d.EmployeeNavigation)
                    .WithMany(p => p.Tbtimesheets)
                    .HasForeignKey(d => d.Employee)
                    .HasConstraintName("timsheet_employee");
            });

            modelBuilder.Entity<Tbtimetable>(entity =>
            {
                entity.ToTable("tbtimetables");

                entity.HasIndex(e => e.Company, "fk_tt_company");

                entity.Property(e => e.Id)
                    .HasMaxLength(100)
                    .HasColumnName("id");

                entity.Property(e => e.BreakIn)
                    .HasColumnName("break_in")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.BreakOut)
                    .HasColumnName("break_out")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Company)
                    .HasMaxLength(100)
                    .HasColumnName("company")
                    .HasDefaultValueSql("'''C00001'''");

                entity.Property(e => e.DayOfWeek)
                    .HasMaxLength(100)
                    .HasColumnName("day_of_week")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.EarlyOut)
                    .HasColumnType("int(11)")
                    .HasColumnName("early_out")
                    .HasDefaultValueSql("'NULL'")
                    .HasComment("minute");

                entity.Property(e => e.EarlyOutAt)
                    .HasColumnName("early_out_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.LateAt)
                    .HasColumnName("late_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.LateIn)
                    .HasColumnType("int(11)")
                    .HasColumnName("late_in")
                    .HasDefaultValueSql("'NULL'")
                    .HasComment("minute");

                entity.Property(e => e.Name)
                    .HasMaxLength(500)
                    .HasColumnName("name")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.StartIn)
                    .HasColumnName("start_in")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.StartOut)
                    .HasColumnName("start_out")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Status)
                    .HasMaxLength(100)
                    .HasColumnName("status")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.WorkingHourRatio)
                    .HasColumnType("int(11)")
                    .HasColumnName("working_hour_ratio")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.CompanyNavigation)
                    .WithMany(p => p.Tbtimetables)
                    .HasForeignKey(d => d.Company)
                    .HasConstraintName("fk_tt_company");
            });

            modelBuilder.Entity<TbtransactionType>(entity =>
            {
                entity.ToTable("tbtransaction_types");

                entity.Property(e => e.Id)
                    .HasMaxLength(100)
                    .HasColumnName("ID");

                entity.Property(e => e.Code)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Name)
                    .HasMaxLength(250)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.NameEn)
                    .HasMaxLength(250)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<TbworkingType>(entity =>
            {
                entity.ToTable("tbworking_types");

                entity.Property(e => e.Id)
                    .HasMaxLength(100)
                    .HasColumnName("ID");

                entity.Property(e => e.Code)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Name)
                    .HasMaxLength(250)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.NameEn)
                    .HasMaxLength(250)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Tbworkingperiod>(entity =>
            {
                entity.ToTable("tbworkingperiods");

                entity.Property(e => e.Id)
                    .HasMaxLength(100)
                    .HasColumnName("id");

                entity.Property(e => e.Company)
                    .HasMaxLength(100)
                    .HasColumnName("company")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(100)
                    .HasColumnName("created_by")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.EndedAt)
                    .HasColumnType("date")
                    .HasColumnName("ended_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Name)
                    .HasMaxLength(250)
                    .HasColumnName("name")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.StartedAt)
                    .HasColumnType("date")
                    .HasColumnName("started_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Status)
                    .HasMaxLength(100)
                    .HasColumnName("status")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Total)
                    .HasColumnType("int(11)")
                    .HasColumnName("total")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(100)
                    .HasColumnName("updated_by")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.WorkingHrs)
                    .HasColumnType("int(11)")
                    .HasColumnName("working_hrs")
                    .HasDefaultValueSql("'8'");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
